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
    [<ExcelFunction(Name="_SoftCallability", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        ([<ExcelArgument(Name="trigger",Description = "Reference to trigger")>] 
         trigger : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toCell<Callability.Price> price "price" true
                let _date = Helper.toCell<Date> date "date" true
                let _trigger = Helper.toCell<double> trigger "trigger" true
                let builder () = withMnemonic mnemonic (Fun.SoftCallability 
                                                            _price.cell 
                                                            _date.cell 
                                                            _trigger.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SoftCallability>) l

                let source = Helper.sourceFold "Fun.SoftCallability" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SoftCallability_trigger", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_trigger
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "Reference to SoftCallability")>] 
         softcallability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability" true 
                let builder () = withMnemonic mnemonic ((_SoftCallability.cell :?> SoftCallabilityModel).Trigger
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SoftCallability.source + ".Trigger") 
                                               [| _SoftCallability.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
        Event interface
    *)
    [<ExcelFunction(Name="_SoftCallability_date", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "Reference to SoftCallability")>] 
         softcallability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability" true 
                let builder () = withMnemonic mnemonic ((_SoftCallability.cell :?> SoftCallabilityModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SoftCallability.source + ".Date") 
                                               [| _SoftCallability.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
    [<ExcelFunction(Name="_SoftCallability_price", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "Reference to SoftCallability")>] 
         softcallability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability" true 
                let builder () = withMnemonic mnemonic ((_SoftCallability.cell :?> SoftCallabilityModel).Price
                                                       ) :> ICell
                let format (o : Callability.Price) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SoftCallability.source + ".Price") 
                                               [| _SoftCallability.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
    [<ExcelFunction(Name="_SoftCallability_type", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "Reference to SoftCallability")>] 
         softcallability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability" true 
                let builder () = withMnemonic mnemonic ((_SoftCallability.cell :?> SoftCallabilityModel).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SoftCallability.source + ".TYPE") 
                                               [| _SoftCallability.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
    [<ExcelFunction(Name="_SoftCallability_accept", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "Reference to SoftCallability")>] 
         softcallability : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_SoftCallability.cell :?> SoftCallabilityModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : SoftCallability) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SoftCallability.source + ".Accept") 
                                               [| _SoftCallability.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
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
    (*
        ! If includeRefDate is true, then an event has not occurred if its date is the same as the refDate, i.e. this method returns false if the event date is the same as the refDate.
    *)
    [<ExcelFunction(Name="_SoftCallability_hasOccurred", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "Reference to SoftCallability")>] 
         softcallability : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability" true 
                let _d = Helper.toCell<Date> d "d" true
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_SoftCallability.cell :?> SoftCallabilityModel).HasOccurred
                                                            _d.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SoftCallability.source + ".HasOccurred") 
                                               [| _SoftCallability.source
                                               ;  _d.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
                                ;  _d.cell
                                ;  _includeRefDate.cell
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
    [<ExcelFunction(Name="_SoftCallability_registerWith", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "Reference to SoftCallability")>] 
         softcallability : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_SoftCallability.cell :?> SoftCallabilityModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SoftCallability) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SoftCallability.source + ".RegisterWith") 
                                               [| _SoftCallability.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_SoftCallability_unregisterWith", Description="Create a SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SoftCallability",Description = "Reference to SoftCallability")>] 
         softcallability : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SoftCallability = Helper.toCell<SoftCallability> softcallability "SoftCallability" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_SoftCallability.cell :?> SoftCallabilityModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SoftCallability) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SoftCallability.source + ".UnregisterWith") 
                                               [| _SoftCallability.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SoftCallability.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_SoftCallability_Range", Description="Create a range of SoftCallability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SoftCallability_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SoftCallability")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SoftCallability> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SoftCallability>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SoftCallability>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SoftCallability>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
