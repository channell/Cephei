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
  Binary asset-or-nothing payoff
  </summary> *)
[<AutoSerializable(true)>]
module AssetOrNothingPayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AssetOrNothingPayoff", Description="Create a AssetOrNothingPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetOrNothingPayoff_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AssetOrNothingPayoff 
                                                            _Type.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AssetOrNothingPayoff>) l

                let source () = Helper.sourceFold "Fun.AssetOrNothingPayoff" 
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
                    ; subscriber = Helper.subscriberModel<AssetOrNothingPayoff> format
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
    [<ExcelFunction(Name="_AssetOrNothingPayoff_name", Description="Create a AssetOrNothingPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetOrNothingPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetOrNothingPayoff",Description = "Reference to AssetOrNothingPayoff")>] 
         assetornothingpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetOrNothingPayoff = Helper.toCell<AssetOrNothingPayoff> assetornothingpayoff "AssetOrNothingPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetOrNothingPayoffModel.Cast _AssetOrNothingPayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetOrNothingPayoff.source + ".Name") 
                                               [| _AssetOrNothingPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_AssetOrNothingPayoff_value", Description="Create a AssetOrNothingPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetOrNothingPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetOrNothingPayoff",Description = "Reference to AssetOrNothingPayoff")>] 
         assetornothingpayoff : obj)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetOrNothingPayoff = Helper.toCell<AssetOrNothingPayoff> assetornothingpayoff "AssetOrNothingPayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetOrNothingPayoffModel.Cast _AssetOrNothingPayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetOrNothingPayoff.source + ".Value") 
                                               [| _AssetOrNothingPayoff.source
                                               ;  _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_AssetOrNothingPayoff_description", Description="Create a AssetOrNothingPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetOrNothingPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetOrNothingPayoff",Description = "Reference to AssetOrNothingPayoff")>] 
         assetornothingpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetOrNothingPayoff = Helper.toCell<AssetOrNothingPayoff> assetornothingpayoff "AssetOrNothingPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetOrNothingPayoffModel.Cast _AssetOrNothingPayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetOrNothingPayoff.source + ".Description") 
                                               [| _AssetOrNothingPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_AssetOrNothingPayoff_strike", Description="Create a AssetOrNothingPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetOrNothingPayoff_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetOrNothingPayoff",Description = "Reference to AssetOrNothingPayoff")>] 
         assetornothingpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetOrNothingPayoff = Helper.toCell<AssetOrNothingPayoff> assetornothingpayoff "AssetOrNothingPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetOrNothingPayoffModel.Cast _AssetOrNothingPayoff.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AssetOrNothingPayoff.source + ".Strike") 
                                               [| _AssetOrNothingPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_AssetOrNothingPayoff_optionType", Description="Create a AssetOrNothingPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetOrNothingPayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetOrNothingPayoff",Description = "Reference to AssetOrNothingPayoff")>] 
         assetornothingpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetOrNothingPayoff = Helper.toCell<AssetOrNothingPayoff> assetornothingpayoff "AssetOrNothingPayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((AssetOrNothingPayoffModel.Cast _AssetOrNothingPayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetOrNothingPayoff.source + ".OptionType") 
                                               [| _AssetOrNothingPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_AssetOrNothingPayoff_accept", Description="Create a AssetOrNothingPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetOrNothingPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AssetOrNothingPayoff",Description = "Reference to AssetOrNothingPayoff")>] 
         assetornothingpayoff : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AssetOrNothingPayoff = Helper.toCell<AssetOrNothingPayoff> assetornothingpayoff "AssetOrNothingPayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((AssetOrNothingPayoffModel.Cast _AssetOrNothingPayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : AssetOrNothingPayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AssetOrNothingPayoff.source + ".Accept") 
                                               [| _AssetOrNothingPayoff.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AssetOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_AssetOrNothingPayoff_Range", Description="Create a range of AssetOrNothingPayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AssetOrNothingPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AssetOrNothingPayoff")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AssetOrNothingPayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AssetOrNothingPayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AssetOrNothingPayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AssetOrNothingPayoff>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
