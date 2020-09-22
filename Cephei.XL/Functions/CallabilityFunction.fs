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
    [<ExcelFunction(Name="_Callability", Description="Create a Callability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Callability_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toCell<Callability.Price> price "price" true
                let _Type = Helper.toCell<Callability.Type> Type "Type" true
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic (Fun.Callability 
                                                            _price.cell 
                                                            _Type.cell 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Callability>) l

                let source = Helper.sourceFold "Fun.Callability" 
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
        Event interface
    *)
    [<ExcelFunction(Name="_Callability_date", Description="Create a Callability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Callability_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Reference to Callability")>] 
         callability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability" true 
                let builder () = withMnemonic mnemonic ((_Callability.cell :?> CallabilityModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Callability.source + ".Date") 
                                               [| _Callability.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_price", Description="Create a Callability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Callability_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Reference to Callability")>] 
         callability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability" true 
                let builder () = withMnemonic mnemonic ((_Callability.cell :?> CallabilityModel).Price
                                                       ) :> ICell
                let format (o : Callability.Price) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Callability.source + ".Price") 
                                               [| _Callability.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_type", Description="Create a Callability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Callability_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Reference to Callability")>] 
         callability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability" true 
                let builder () = withMnemonic mnemonic ((_Callability.cell :?> CallabilityModel).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Callability.source + ".TYPE") 
                                               [| _Callability.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_accept", Description="Create a Callability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Callability_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Reference to Callability")>] 
         callability : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_Callability.cell :?> CallabilityModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : Callability) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Callability.source + ".Accept") 
                                               [| _Callability.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_hasOccurred", Description="Create a Callability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Callability_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Reference to Callability")>] 
         callability : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability" true 
                let _d = Helper.toCell<Date> d "d" true
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_Callability.cell :?> CallabilityModel).HasOccurred
                                                            _d.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Callability.source + ".HasOccurred") 
                                               [| _Callability.source
                                               ;  _d.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_registerWith", Description="Create a Callability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Callability_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Reference to Callability")>] 
         callability : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Callability.cell :?> CallabilityModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Callability) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Callability.source + ".RegisterWith") 
                                               [| _Callability.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_unregisterWith", Description="Create a Callability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Callability_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Callability",Description = "Reference to Callability")>] 
         callability : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Callability = Helper.toCell<Callability> callability "Callability" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Callability.cell :?> CallabilityModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Callability) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Callability.source + ".UnregisterWith") 
                                               [| _Callability.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Callability.cell
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
    [<ExcelFunction(Name="_Callability_Range", Description="Create a range of Callability",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Callability_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Callability")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Callability> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Callability>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Callability>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Callability>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
