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
  This instrument is an aggregate of other instruments. Its NPV is the sum of the NPVs of its components, each possibly multiplied by a given factor.  Methods that drive the calculation directly (such as recalculate(), freeze() and others) might not work correctly.  instruments
  </summary> *)
[<AutoSerializable(true)>]
module CompositeInstrumentFunction =
(*!! duplicate Add function
    (*
        ! adds an instrument to the composite
    *)
    [<ExcelFunction(Name="_CompositeInstrument_add", Description="Create a CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeInstrument",Description = "Reference to CompositeInstrument")>] 
         compositeinstrument : obj)
        ([<ExcelArgument(Name="instrument",Description = "Reference to instrument")>] 
         instrument : obj)
        ([<ExcelArgument(Name="multiplier",Description = "Reference to multiplier")>] 
         multiplier : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeInstrument = Helper.toCell<CompositeInstrument> compositeinstrument "CompositeInstrument"  
                let _instrument = Helper.toCell<Instrument> instrument "instrument" 
                let _multiplier = Helper.toDefault<double> multiplier "multiplier" 1.0
                let builder (current : ICell) = withMnemonic mnemonic ((CompositeInstrumentModel.Cast _CompositeInstrument.cell).Add
                                                            _instrument.cell 
                                                            _multiplier.cell 
                                                       ) :> ICell
                let format (o : CompositeInstrument) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CompositeInstrument.source + ".Add") 
                                               [| _CompositeInstrument.source
                                               ;  _instrument.source
                                               ;  _multiplier.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeInstrument.cell
                                ;  _instrument.cell
                                ;  _multiplier.cell
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_CompositeInstrument_isExpired", Description="Create a CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeInstrument",Description = "Reference to CompositeInstrument")>] 
         compositeinstrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeInstrument = Helper.toCell<CompositeInstrument> compositeinstrument "CompositeInstrument"  
                let builder (current : ICell) = withMnemonic mnemonic ((CompositeInstrumentModel.Cast _CompositeInstrument.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CompositeInstrument.source + ".IsExpired") 
                                               [| _CompositeInstrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeInstrument.cell
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
        ! shorts an instrument from the composite
    *)
    [<ExcelFunction(Name="_CompositeInstrument_subtract", Description="Create a CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_subtract
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeInstrument",Description = "Reference to CompositeInstrument")>] 
         compositeinstrument : obj)
        ([<ExcelArgument(Name="instrument",Description = "Reference to instrument")>] 
         instrument : obj)
        ([<ExcelArgument(Name="multiplier",Description = "Reference to multiplier")>] 
         multiplier : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeInstrument = Helper.toCell<CompositeInstrument> compositeinstrument "CompositeInstrument"  
                let _instrument = Helper.toCell<Instrument> instrument "instrument" 
                let _multiplier = Helper.toDefault<double> multiplier "multiplier" 1.0
                let builder (current : ICell) = withMnemonic mnemonic ((CompositeInstrumentModel.Cast _CompositeInstrument.cell).Subtract
                                                            _instrument.cell 
                                                            _multiplier.cell 
                                                       ) :> ICell
                let format (o : CompositeInstrument) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CompositeInstrument.source + ".Subtract") 
                                               [| _CompositeInstrument.source
                                               ;  _instrument.source
                                               ;  _multiplier.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeInstrument.cell
                                ;  _instrument.cell
                                ;  _multiplier.cell
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
    [<ExcelFunction(Name="_CompositeInstrument_CASH", Description="Create a CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeInstrument",Description = "Reference to CompositeInstrument")>] 
         compositeinstrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeInstrument = Helper.toCell<CompositeInstrument> compositeinstrument "CompositeInstrument"  
                let builder (current : ICell) = withMnemonic mnemonic ((CompositeInstrumentModel.Cast _CompositeInstrument.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CompositeInstrument.source + ".CASH") 
                                               [| _CompositeInstrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeInstrument.cell
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
    [<ExcelFunction(Name="_CompositeInstrument_errorEstimate", Description="Create a CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeInstrument",Description = "Reference to CompositeInstrument")>] 
         compositeinstrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeInstrument = Helper.toCell<CompositeInstrument> compositeinstrument "CompositeInstrument"  
                let builder (current : ICell) = withMnemonic mnemonic ((CompositeInstrumentModel.Cast _CompositeInstrument.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CompositeInstrument.source + ".ErrorEstimate") 
                                               [| _CompositeInstrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeInstrument.cell
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
    [<ExcelFunction(Name="_CompositeInstrument_NPV", Description="Create a CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeInstrument",Description = "Reference to CompositeInstrument")>] 
         compositeinstrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeInstrument = Helper.toCell<CompositeInstrument> compositeinstrument "CompositeInstrument"  
                let builder (current : ICell) = withMnemonic mnemonic ((CompositeInstrumentModel.Cast _CompositeInstrument.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CompositeInstrument.source + ".NPV") 
                                               [| _CompositeInstrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeInstrument.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_CompositeInstrument_result", Description="Create a CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeInstrument",Description = "Reference to CompositeInstrument")>] 
         compositeinstrument : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeInstrument = Helper.toCell<CompositeInstrument> compositeinstrument "CompositeInstrument"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CompositeInstrumentModel.Cast _CompositeInstrument.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CompositeInstrument.source + ".Result") 
                                               [| _CompositeInstrument.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeInstrument.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_CompositeInstrument_setPricingEngine", Description="Create a CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeInstrument",Description = "Reference to CompositeInstrument")>] 
         compositeinstrument : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeInstrument = Helper.toCell<CompositeInstrument> compositeinstrument "CompositeInstrument"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CompositeInstrumentModel.Cast _CompositeInstrument.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CompositeInstrument) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CompositeInstrument.source + ".SetPricingEngine") 
                                               [| _CompositeInstrument.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeInstrument.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_CompositeInstrument_valuationDate", Description="Create a CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeInstrument",Description = "Reference to CompositeInstrument")>] 
         compositeinstrument : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeInstrument = Helper.toCell<CompositeInstrument> compositeinstrument "CompositeInstrument"  
                let builder (current : ICell) = withMnemonic mnemonic ((CompositeInstrumentModel.Cast _CompositeInstrument.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CompositeInstrument.source + ".ValuationDate") 
                                               [| _CompositeInstrument.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeInstrument.cell
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
    [<ExcelFunction(Name="_CompositeInstrument_Range", Description="Create a range of CompositeInstrument",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeInstrument_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CompositeInstrument")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CompositeInstrument> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CompositeInstrument>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CompositeInstrument>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CompositeInstrument>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
