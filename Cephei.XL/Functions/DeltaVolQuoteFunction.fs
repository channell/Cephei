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
  It includes the various delta quotation types in FX markets as well as ATM types.
  </summary> *)
[<AutoSerializable(true)>]
module DeltaVolQuoteFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DeltaVolQuote_atmType", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_atmType
        ([<ExcelArgument(Name="Mnemonic",Description = "DeltaVolQuote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DeltaVolQuote",Description = "DeltaVolQuote")>] 
         deltavolquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DeltaVolQuote = Helper.toCell<DeltaVolQuote> deltavolquote "DeltaVolQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DeltaVolQuoteModel.Cast _DeltaVolQuote.cell).AtmType
                                                       ) :> ICell
                let format (o : DeltaVolQuote.AtmType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DeltaVolQuote.source + ".AtmType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DeltaVolQuote.cell
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
    [<ExcelFunction(Name="_DeltaVolQuote_delta", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "DeltaVolQuote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DeltaVolQuote",Description = "DeltaVolQuote")>] 
         deltavolquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DeltaVolQuote = Helper.toCell<DeltaVolQuote> deltavolquote "DeltaVolQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DeltaVolQuoteModel.Cast _DeltaVolQuote.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DeltaVolQuote.source + ".Delta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DeltaVolQuote.cell
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
    (*!!
    [<ExcelFunction(Name="_DeltaVolQuote_deltaType", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_deltaType
        ([<ExcelArgument(Name="Mnemonic",Description = "DeltaVolQuote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DeltaVolQuote",Description = "DeltaVolQuote")>] 
         deltavolquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DeltaVolQuote = Helper.toCell<DeltaVolQuote> deltavolquote "DeltaVolQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DeltaVolQuoteModel.Cast _DeltaVolQuote.cell).DeltaType
                                                       ) :> ICell
                let format (o : DeltaType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DeltaVolQuote.source + ".DeltaType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DeltaVolQuote.cell
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
            *)
    (*
        Additional constructor, if special atm quote is used
    *)
    [<ExcelFunction(Name="_DeltaVolQuote", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_create
        ([<ExcelArgument(Name="Mnemonic",Description = "DeltaVolQuote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="vol",Description = "Quote")>] 
         vol : obj)
        ([<ExcelArgument(Name="deltaType",Description = "DeltaVolQuote.DeltaType: Spot, Fwd, PaSpot, PaFwd")>] 
         deltaType : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="atmType",Description = "DeltaVolQuote.AtmType: AtmNull, AtmSpot, AtmFwd, AtmDeltaNeutral, AtmVegaMax, AtmGammaMax, AtmPutCall50")>] 
         atmType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _deltaType = Helper.toCell<DeltaVolQuote.DeltaType> deltaType "deltaType" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _atmType = Helper.toCell<DeltaVolQuote.AtmType> atmType "atmType" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DeltaVolQuote 
                                                            _vol.cell 
                                                            _deltaType.cell 
                                                            _maturity.cell 
                                                            _atmType.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DeltaVolQuote>) l

                let source () = Helper.sourceFold "Fun.DeltaVolQuote" 
                                               [| _vol.source
                                               ;  _deltaType.source
                                               ;  _maturity.source
                                               ;  _atmType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _vol.cell
                                ;  _deltaType.cell
                                ;  _maturity.cell
                                ;  _atmType.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DeltaVolQuote> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Standard constructor delta vs vol.
    *)
    [<ExcelFunction(Name="_DeltaVolQuote1", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "DeltaVolQuote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="delta",Description = "double")>] 
         delta : obj)
        ([<ExcelArgument(Name="vol",Description = "Quote")>] 
         vol : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="deltaType",Description = "DeltaVolQuote.DeltaType: Spot, Fwd, PaSpot, PaFwd")>] 
         deltaType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _delta = Helper.toCell<double> delta "delta" 
                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _deltaType = Helper.toCell<DeltaVolQuote.DeltaType> deltaType "deltaType" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DeltaVolQuote1 
                                                            _delta.cell 
                                                            _vol.cell 
                                                            _maturity.cell 
                                                            _deltaType.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DeltaVolQuote>) l

                let source () = Helper.sourceFold "Fun.DeltaVolQuote1" 
                                               [| _delta.source
                                               ;  _vol.source
                                               ;  _maturity.source
                                               ;  _deltaType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _delta.cell
                                ;  _vol.cell
                                ;  _maturity.cell
                                ;  _deltaType.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DeltaVolQuote> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DeltaVolQuote_isValid", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_isValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DeltaVolQuote",Description = "DeltaVolQuote")>] 
         deltavolquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DeltaVolQuote = Helper.toCell<DeltaVolQuote> deltavolquote "DeltaVolQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DeltaVolQuoteModel.Cast _DeltaVolQuote.cell).IsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DeltaVolQuote.source + ".IsValid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DeltaVolQuote.cell
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
    [<ExcelFunction(Name="_DeltaVolQuote_maturity", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_maturity
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DeltaVolQuote",Description = "DeltaVolQuote")>] 
         deltavolquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DeltaVolQuote = Helper.toCell<DeltaVolQuote> deltavolquote "DeltaVolQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DeltaVolQuoteModel.Cast _DeltaVolQuote.cell).Maturity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DeltaVolQuote.source + ".Maturity") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DeltaVolQuote.cell
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
    [<ExcelFunction(Name="_DeltaVolQuote_update", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DeltaVolQuote",Description = "DeltaVolQuote")>] 
         deltavolquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DeltaVolQuote = Helper.toCell<DeltaVolQuote> deltavolquote "DeltaVolQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DeltaVolQuoteModel.Cast _DeltaVolQuote.cell).Update
                                                       ) :> ICell
                let format (o : DeltaVolQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DeltaVolQuote.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DeltaVolQuote.cell
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
    [<ExcelFunction(Name="_DeltaVolQuote_value", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DeltaVolQuote",Description = "DeltaVolQuote")>] 
         deltavolquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DeltaVolQuote = Helper.toCell<DeltaVolQuote> deltavolquote "DeltaVolQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DeltaVolQuoteModel.Cast _DeltaVolQuote.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DeltaVolQuote.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DeltaVolQuote.cell
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
    [<ExcelFunction(Name="_DeltaVolQuote_registerWith", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DeltaVolQuote",Description = "DeltaVolQuote")>] 
         deltavolquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DeltaVolQuote = Helper.toCell<DeltaVolQuote> deltavolquote "DeltaVolQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DeltaVolQuoteModel.Cast _DeltaVolQuote.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DeltaVolQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DeltaVolQuote.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DeltaVolQuote.cell
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
    [<ExcelFunction(Name="_DeltaVolQuote_unregisterWith", Description="Create a DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DeltaVolQuote",Description = "DeltaVolQuote")>] 
         deltavolquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DeltaVolQuote = Helper.toCell<DeltaVolQuote> deltavolquote "DeltaVolQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DeltaVolQuoteModel.Cast _DeltaVolQuote.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DeltaVolQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DeltaVolQuote.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DeltaVolQuote.cell
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
    [<ExcelFunction(Name="_DeltaVolQuote_Range", Description="Create a range of DeltaVolQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DeltaVolQuote_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DeltaVolQuote> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DeltaVolQuote>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DeltaVolQuote>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DeltaVolQuote>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
