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
  Binary cash-or-nothing payoff
  </summary> *)
[<AutoSerializable(true)>]
module CashOrNothingPayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CashOrNothingPayoff", Description="Create a CashOrNothingPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CashOrNothingPayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="cashPayoff",Description = "Reference to cashPayoff")>] 
         cashPayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _cashPayoff = Helper.toCell<double> cashPayoff "cashPayoff" 
                let builder () = withMnemonic mnemonic (Fun.CashOrNothingPayoff 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _cashPayoff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashOrNothingPayoff>) l

                let source = Helper.sourceFold "Fun.CashOrNothingPayoff" 
                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _cashPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                ;  _cashPayoff.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CashOrNothingPayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CashOrNothingPayoff_cashPayoff", Description="Create a CashOrNothingPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CashOrNothingPayoff_cashPayoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CashOrNothingPayoff",Description = "Reference to CashOrNothingPayoff")>] 
         cashornothingpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CashOrNothingPayoff = Helper.toCell<CashOrNothingPayoff> cashornothingpayoff "CashOrNothingPayoff"  
                let builder () = withMnemonic mnemonic ((CashOrNothingPayoffModel.Cast _CashOrNothingPayoff.cell).CashPayoff
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CashOrNothingPayoff.source + ".CashPayoff") 
                                               [| _CashOrNothingPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CashOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_CashOrNothingPayoff_description", Description="Create a CashOrNothingPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CashOrNothingPayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CashOrNothingPayoff",Description = "Reference to CashOrNothingPayoff")>] 
         cashornothingpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CashOrNothingPayoff = Helper.toCell<CashOrNothingPayoff> cashornothingpayoff "CashOrNothingPayoff"  
                let builder () = withMnemonic mnemonic ((CashOrNothingPayoffModel.Cast _CashOrNothingPayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CashOrNothingPayoff.source + ".Description") 
                                               [| _CashOrNothingPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CashOrNothingPayoff.cell
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
        Payoff interface
    *)
    [<ExcelFunction(Name="_CashOrNothingPayoff_name", Description="Create a CashOrNothingPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CashOrNothingPayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CashOrNothingPayoff",Description = "Reference to CashOrNothingPayoff")>] 
         cashornothingpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CashOrNothingPayoff = Helper.toCell<CashOrNothingPayoff> cashornothingpayoff "CashOrNothingPayoff"  
                let builder () = withMnemonic mnemonic ((CashOrNothingPayoffModel.Cast _CashOrNothingPayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CashOrNothingPayoff.source + ".Name") 
                                               [| _CashOrNothingPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CashOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_CashOrNothingPayoff_value", Description="Create a CashOrNothingPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CashOrNothingPayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CashOrNothingPayoff",Description = "Reference to CashOrNothingPayoff")>] 
         cashornothingpayoff : obj)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CashOrNothingPayoff = Helper.toCell<CashOrNothingPayoff> cashornothingpayoff "CashOrNothingPayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder () = withMnemonic mnemonic ((CashOrNothingPayoffModel.Cast _CashOrNothingPayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CashOrNothingPayoff.source + ".Value") 
                                               [| _CashOrNothingPayoff.source
                                               ;  _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CashOrNothingPayoff.cell
                                ;  _price.cell
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
    [<ExcelFunction(Name="_CashOrNothingPayoff_strike", Description="Create a CashOrNothingPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CashOrNothingPayoff_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CashOrNothingPayoff",Description = "Reference to CashOrNothingPayoff")>] 
         cashornothingpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CashOrNothingPayoff = Helper.toCell<CashOrNothingPayoff> cashornothingpayoff "CashOrNothingPayoff"  
                let builder () = withMnemonic mnemonic ((CashOrNothingPayoffModel.Cast _CashOrNothingPayoff.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CashOrNothingPayoff.source + ".Strike") 
                                               [| _CashOrNothingPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CashOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_CashOrNothingPayoff_optionType", Description="Create a CashOrNothingPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CashOrNothingPayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CashOrNothingPayoff",Description = "Reference to CashOrNothingPayoff")>] 
         cashornothingpayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CashOrNothingPayoff = Helper.toCell<CashOrNothingPayoff> cashornothingpayoff "CashOrNothingPayoff"  
                let builder () = withMnemonic mnemonic ((CashOrNothingPayoffModel.Cast _CashOrNothingPayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CashOrNothingPayoff.source + ".OptionType") 
                                               [| _CashOrNothingPayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CashOrNothingPayoff.cell
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
    [<ExcelFunction(Name="_CashOrNothingPayoff_accept", Description="Create a CashOrNothingPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CashOrNothingPayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CashOrNothingPayoff",Description = "Reference to CashOrNothingPayoff")>] 
         cashornothingpayoff : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CashOrNothingPayoff = Helper.toCell<CashOrNothingPayoff> cashornothingpayoff "CashOrNothingPayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((CashOrNothingPayoffModel.Cast _CashOrNothingPayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CashOrNothingPayoff) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CashOrNothingPayoff.source + ".Accept") 
                                               [| _CashOrNothingPayoff.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CashOrNothingPayoff.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_CashOrNothingPayoff_Range", Description="Create a range of CashOrNothingPayoff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CashOrNothingPayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CashOrNothingPayoff")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CashOrNothingPayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CashOrNothingPayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CashOrNothingPayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CashOrNothingPayoff>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
