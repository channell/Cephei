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
  Intermediate class for payoffs based on a fixed strike
  </summary> *)
[<AutoSerializable(true)>]
module StrikedTypePayoffFunction =

    (*
        Payoff interface
    *)
    [<ExcelFunction(Name="_StrikedTypePayoff_description", Description="Create a StrikedTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StrikedTypePayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "StrikedTypePayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrikedTypePayoff",Description = "StrikedTypePayoff")>] 
         strikedtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrikedTypePayoff = Helper.toCell<StrikedTypePayoff> strikedtypepayoff "StrikedTypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((StrikedTypePayoffModel.Cast _StrikedTypePayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_StrikedTypePayoff.source + ".Description") 
                                               [| _StrikedTypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrikedTypePayoff.cell
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
    [<ExcelFunction(Name="_StrikedTypePayoff_strike", Description="Create a StrikedTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StrikedTypePayoff_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "StrikedTypePayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrikedTypePayoff",Description = "StrikedTypePayoff")>] 
         strikedtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrikedTypePayoff = Helper.toCell<StrikedTypePayoff> strikedtypepayoff "StrikedTypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((StrikedTypePayoffModel.Cast _StrikedTypePayoff.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_StrikedTypePayoff.source + ".Strike") 
                                               [| _StrikedTypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrikedTypePayoff.cell
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
    [<ExcelFunction(Name="_StrikedTypePayoff", Description="Create a StrikedTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StrikedTypePayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "StrikedTypePayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="p",Description = "Payoff")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _p = Helper.toCell<Payoff> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.StrikedTypePayoff 
                                                            _p.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<StrikedTypePayoff>) l

                let source () = Helper.sourceFold "Fun.StrikedTypePayoff" 
                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _p.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StrikedTypePayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StrikedTypePayoff1", Description="Create a StrikedTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StrikedTypePayoff_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "StrikedTypePayoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.StrikedTypePayoff1 
                                                            _Type.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<StrikedTypePayoff>) l

                let source () = Helper.sourceFold "Fun.StrikedTypePayoff1" 
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
                    ; subscriber = Helper.subscriberModel<StrikedTypePayoff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StrikedTypePayoff_optionType", Description="Create a StrikedTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StrikedTypePayoff_optionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrikedTypePayoff",Description = "StrikedTypePayoff")>] 
         strikedtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrikedTypePayoff = Helper.toCell<StrikedTypePayoff> strikedtypepayoff "StrikedTypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((StrikedTypePayoffModel.Cast _StrikedTypePayoff.cell).OptionType
                                                       ) :> ICell
                let format (o : Option.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_StrikedTypePayoff.source + ".OptionType") 
                                               [| _StrikedTypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrikedTypePayoff.cell
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
    [<ExcelFunction(Name="_StrikedTypePayoff_accept", Description="Create a StrikedTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StrikedTypePayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrikedTypePayoff",Description = "StrikedTypePayoff")>] 
         strikedtypepayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrikedTypePayoff = Helper.toCell<StrikedTypePayoff> strikedtypepayoff "StrikedTypePayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((StrikedTypePayoffModel.Cast _StrikedTypePayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : StrikedTypePayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_StrikedTypePayoff.source + ".Accept") 
                                               [| _StrikedTypePayoff.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrikedTypePayoff.cell
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
    [<ExcelFunction(Name="_StrikedTypePayoff_name", Description="Create a StrikedTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StrikedTypePayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrikedTypePayoff",Description = "StrikedTypePayoff")>] 
         strikedtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrikedTypePayoff = Helper.toCell<StrikedTypePayoff> strikedtypepayoff "StrikedTypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((StrikedTypePayoffModel.Cast _StrikedTypePayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_StrikedTypePayoff.source + ".Name") 
                                               [| _StrikedTypePayoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrikedTypePayoff.cell
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
    [<ExcelFunction(Name="_StrikedTypePayoff_value", Description="Create a StrikedTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StrikedTypePayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrikedTypePayoff",Description = "StrikedTypePayoff")>] 
         strikedtypepayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrikedTypePayoff = Helper.toCell<StrikedTypePayoff> strikedtypepayoff "StrikedTypePayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((StrikedTypePayoffModel.Cast _StrikedTypePayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_StrikedTypePayoff.source + ".Value") 
                                               [| _StrikedTypePayoff.source
                                               ;  _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrikedTypePayoff.cell
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
    [<ExcelFunction(Name="_StrikedTypePayoff_Range", Description="Create a range of StrikedTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StrikedTypePayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<StrikedTypePayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<StrikedTypePayoff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<StrikedTypePayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<StrikedTypePayoff>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
