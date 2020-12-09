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
  Class for forward type payoffs
  </summary> *)
[<AutoSerializable(true)>]
module ForwardTypePayoffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ForwardTypePayoff_description", Description="Create a ForwardTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardTypePayoff_description
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardTypePayoff",Description = "ForwardTypePayoff")>] 
         forwardtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardTypePayoff = Helper.toCell<ForwardTypePayoff> forwardtypepayoff "ForwardTypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardTypePayoffModel.Cast _ForwardTypePayoff.cell).Description
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardTypePayoff.source + ".Description") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardTypePayoff.cell
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
    [<ExcelFunction(Name="_ForwardTypePayoff_forwardType", Description="Create a ForwardTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardTypePayoff_forwardType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardTypePayoff",Description = "ForwardTypePayoff")>] 
         forwardtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardTypePayoff = Helper.toCell<ForwardTypePayoff> forwardtypepayoff "ForwardTypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardTypePayoffModel.Cast _ForwardTypePayoff.cell).ForwardType
                                                       ) :> ICell
                let format (o : Position.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardTypePayoff.source + ".ForwardType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardTypePayoff.cell
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
    [<ExcelFunction(Name="_ForwardTypePayoff", Description="Create a ForwardTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardTypePayoff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Position.Type: Long, Short")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Position.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ForwardTypePayoff 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ForwardTypePayoff>) l

                let source () = Helper.sourceFold "Fun.ForwardTypePayoff" 
                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardTypePayoff> format
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
    [<ExcelFunction(Name="_ForwardTypePayoff_name", Description="Create a ForwardTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardTypePayoff_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardTypePayoff",Description = "ForwardTypePayoff")>] 
         forwardtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardTypePayoff = Helper.toCell<ForwardTypePayoff> forwardtypepayoff "ForwardTypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardTypePayoffModel.Cast _ForwardTypePayoff.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardTypePayoff.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardTypePayoff.cell
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
    [<ExcelFunction(Name="_ForwardTypePayoff_strike", Description="Create a ForwardTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardTypePayoff_strike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardTypePayoff",Description = "ForwardTypePayoff")>] 
         forwardtypepayoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardTypePayoff = Helper.toCell<ForwardTypePayoff> forwardtypepayoff "ForwardTypePayoff"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardTypePayoffModel.Cast _ForwardTypePayoff.cell).Strike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardTypePayoff.source + ".Strike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardTypePayoff.cell
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
    [<ExcelFunction(Name="_ForwardTypePayoff_value", Description="Create a ForwardTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardTypePayoff_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardTypePayoff",Description = "ForwardTypePayoff")>] 
         forwardtypepayoff : obj)
        ([<ExcelArgument(Name="price",Description = "double")>] 
         price : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardTypePayoff = Helper.toCell<ForwardTypePayoff> forwardtypepayoff "ForwardTypePayoff"  
                let _price = Helper.toCell<double> price "price" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardTypePayoffModel.Cast _ForwardTypePayoff.cell).Value
                                                            _price.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardTypePayoff.source + ".Value") 

                                               [| _price.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardTypePayoff.cell
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
        
    *)
    [<ExcelFunction(Name="_ForwardTypePayoff_accept", Description="Create a ForwardTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardTypePayoff_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardTypePayoff",Description = "ForwardTypePayoff")>] 
         forwardtypepayoff : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardTypePayoff = Helper.toCell<ForwardTypePayoff> forwardtypepayoff "ForwardTypePayoff"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardTypePayoffModel.Cast _ForwardTypePayoff.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : ForwardTypePayoff) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardTypePayoff.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardTypePayoff.cell
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
    [<ExcelFunction(Name="_ForwardTypePayoff_Range", Description="Create a range of ForwardTypePayoff",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardTypePayoff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardTypePayoff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ForwardTypePayoff> (c)) :> ICell
                let format (i : Generic.List<ICell<ForwardTypePayoff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ForwardTypePayoff>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
