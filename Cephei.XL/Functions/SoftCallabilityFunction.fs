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
  %callability leaving to the holder the possibility to convert
  </summary> *)
[<AutoSerializable(true)>]
module SoftCallabilityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SoftCallability", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Callability.Price")>] 
         price : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        ([<ExcelArgument(Name="trigger",Description = "double")>] 
         trigger : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toCell<Callability.Price> price "price" 
                let _date = Helper.toCell<Date> date "date" 
                let _trigger = Helper.toCell<double> trigger "trigger" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SoftCallability 
                                                            _price.cell 
                                                            _date.cell 
                                                            _trigger.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SoftCallability>) l

                let source () = Helper.sourceFold "Fun.SoftCallability" 
                                               [| _price.source
                                               ;  _date.source
                                               ;  _trigger.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _date.cell
                                ;  _trigger.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SoftCallability> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SoftCallability_trigger", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_trigger
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "SoftCallability")>] 
         softcallability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability"  
                let builder (current : ICell) = withMnemonic mnemonic ((SoftCallabilityModel.Cast _SoftCallability.cell).Trigger
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SoftCallability.source + ".Trigger") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
        Event interface
    *)
    [<ExcelFunction(Name="_SoftCallability_date", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "SoftCallability")>] 
         softcallability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability"  
                let builder (current : ICell) = withMnemonic mnemonic ((SoftCallabilityModel.Cast _SoftCallability.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SoftCallability.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
    [<ExcelFunction(Name="_SoftCallability_price", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "SoftCallability")>] 
         softcallability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability"  
                let builder (current : ICell) = withMnemonic mnemonic ((SoftCallabilityModel.Cast _SoftCallability.cell).Price
                                                       ) :> ICell
                let format (o : Callability.Price) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SoftCallability.source + ".Price") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
    [<ExcelFunction(Name="_SoftCallability_type", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "SoftCallability")>] 
         softcallability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability"  
                let builder (current : ICell) = withMnemonic mnemonic ((SoftCallabilityModel.Cast _SoftCallability.cell).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SoftCallability.source + ".TYPE") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
    [<ExcelFunction(Name="_SoftCallability_accept", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "SoftCallability")>] 
         softcallability : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((SoftCallabilityModel.Cast _SoftCallability.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : SoftCallability) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SoftCallability.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
        ! If includeRefDate is true, then an event has not occurred if its date is the same as the refDate, i.e. this method returns false if the event date is the same as the refDate.
    *)
    [<ExcelFunction(Name="_SoftCallability_hasOccurred", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "SoftCallability")>] 
         softcallability : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability"  
                let _d = Helper.toCell<Date> d "d" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((SoftCallabilityModel.Cast _SoftCallability.cell).HasOccurred
                                                            _d.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SoftCallability.source + ".HasOccurred") 

                                               [| _d.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
                                ;  _d.cell
                                ;  _includeRefDate.cell
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
    [<ExcelFunction(Name="_SoftCallability_registerWith", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "SoftCallability")>] 
         softcallability : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((SoftCallabilityModel.Cast _SoftCallability.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SoftCallability) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SoftCallability.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_SoftCallability_unregisterWith", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "SoftCallability")>] 
         softcallability : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((SoftCallabilityModel.Cast _SoftCallability.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SoftCallability) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SoftCallability.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_SoftCallability_Range", Description="Create a range of SoftCallability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SoftCallability_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SoftCallability> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SoftCallability> (c)) :> ICell
                let format (i : Generic.List<ICell<SoftCallability>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SoftCallability>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
