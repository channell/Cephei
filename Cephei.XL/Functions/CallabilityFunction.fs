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
  %instrument callability
  </summary> *)
[<AutoSerializable(true)>]
module CallabilityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Callability", Description="Create a Callability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Callability_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Callability.Price")>] 
         price : obj)
        ([<ExcelArgument(Name="Type",Description = "Callability.Type: Call, Put")>] 
         Type : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toCell<Callability.Price> price "price" 
                let _Type = Helper.toCell<Callability.Type> Type "Type" 
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = (Fun.Callability 
                                                            _price.cell 
                                                            _Type.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Callability>) l

                let source () = Helper.sourceFold "Fun.Callability" 
                                               [| _price.source
                                               ;  _Type.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _Type.cell
                                ;  _date.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Callability> format
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
    [<ExcelFunction(Name="_Callability_date", Description="Create a Callability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Callability_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Callability")>] 
         callability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability"  
                let builder (current : ICell) = ((CallabilityModel.Cast _Callability.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Callability.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_price", Description="Create a Callability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Callability_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Callability")>] 
         callability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability"  
                let builder (current : ICell) = ((CallabilityModel.Cast _Callability.cell).Price
                                                       ) :> ICell
                let format (o : Callability.Price) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Callability.source + ".Price") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_type", Description="Create a Callability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Callability_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Callability")>] 
         callability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability"  
                let builder (current : ICell) = ((CallabilityModel.Cast _Callability.cell).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Callability.source + ".TYPE") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_accept", Description="Create a Callability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Callability_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Callability")>] 
         callability : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((CallabilityModel.Cast _Callability.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : Callability) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Callability.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_hasOccurred", Description="Create a Callability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Callability_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Callability")>] 
         callability : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability"  
                let _d = Helper.toCell<Date> d "d" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = ((CallabilityModel.Cast _Callability.cell).HasOccurred
                                                            _d.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Callability.source + ".HasOccurred") 

                                               [| _d.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_registerWith", Description="Create a Callability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Callability_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Callability")>] 
         callability : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CallabilityModel.Cast _Callability.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Callability) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Callability.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_unregisterWith", Description="Create a Callability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Callability_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Callability")>] 
         callability : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CallabilityModel.Cast _Callability.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Callability) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Callability.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_Range", Description="Create a range of Callability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Callability_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Callability> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Callability> (c)) :> ICell
                let format (i : Cephei.Cell.List<Callability>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Callability>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
