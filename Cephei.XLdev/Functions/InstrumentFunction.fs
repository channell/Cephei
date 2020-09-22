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
Abstract instrument class. It defines the interface of concrete instruments
  </summary> *)
[<AutoSerializable(true)>]
module InstrumentFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Instrument_CASH", Description="Create a Instrument",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Instrument_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Instrument",Description = "Reference to Instrument")>] 
         instrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Instrument = Helper.toCell<Instrument> instrument "Instrument" true 
                let builder () = withMnemonic mnemonic ((_Instrument.cell :?> InstrumentModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Instrument.source + ".CASH") 
                                               [| _Instrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Instrument.cell
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
    [<ExcelFunction(Name="_Instrument_errorEstimate", Description="Create a Instrument",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Instrument_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Instrument",Description = "Reference to Instrument")>] 
         instrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Instrument = Helper.toCell<Instrument> instrument "Instrument" true 
                let builder () = withMnemonic mnemonic ((_Instrument.cell :?> InstrumentModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Instrument.source + ".ErrorEstimate") 
                                               [| _Instrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Instrument.cell
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
        ! returns whether the instrument is still tradable.
    *)
    [<ExcelFunction(Name="_Instrument_isExpired", Description="Create a Instrument",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Instrument_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Instrument",Description = "Reference to Instrument")>] 
         instrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Instrument = Helper.toCell<Instrument> instrument "Instrument" true 
                let builder () = withMnemonic mnemonic ((_Instrument.cell :?> InstrumentModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Instrument.source + ".IsExpired") 
                                               [| _Instrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Instrument.cell
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
    [<ExcelFunction(Name="_Instrument_NPV", Description="Create a Instrument",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Instrument_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Instrument",Description = "Reference to Instrument")>] 
         instrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Instrument = Helper.toCell<Instrument> instrument "Instrument" true 
                let builder () = withMnemonic mnemonic ((_Instrument.cell :?> InstrumentModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Instrument.source + ".NPV") 
                                               [| _Instrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Instrument.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_Instrument_result", Description="Create a Instrument",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Instrument_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Instrument",Description = "Reference to Instrument")>] 
         instrument : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Instrument = Helper.toCell<Instrument> instrument "Instrument" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_Instrument.cell :?> InstrumentModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Instrument.source + ".Result") 
                                               [| _Instrument.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Instrument.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_Instrument_setPricingEngine", Description="Create a Instrument",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Instrument_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Instrument",Description = "Reference to Instrument")>] 
         instrument : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Instrument = Helper.toCell<Instrument> instrument "Instrument" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_Instrument.cell :?> InstrumentModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Instrument) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Instrument.source + ".SetPricingEngine") 
                                               [| _Instrument.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Instrument.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_Instrument_valuationDate", Description="Create a Instrument",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Instrument_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Instrument",Description = "Reference to Instrument")>] 
         instrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Instrument = Helper.toCell<Instrument> instrument "Instrument" true 
                let builder () = withMnemonic mnemonic ((_Instrument.cell :?> InstrumentModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Instrument.source + ".ValuationDate") 
                                               [| _Instrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Instrument.cell
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
    [<ExcelFunction(Name="_Instrument_Range", Description="Create a range of Instrument",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Instrument_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Instrument")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Instrument> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Instrument>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Instrument>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Instrument>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
