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
  %EUR %Libor %Swap indexes published by IFR Markets and distributed by Reuters page TGM42281 and by Telerate. Annual 30/360 vs 6M Libor, 1Y vs 3M Libor. For more info see <http://www.ifrmarkets.com>.
  </summary> *)
[<AutoSerializable(true)>]
module EurLiborSwapIfrFixFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let _discounting = Helper.toHandle<Handle<YieldTermStructure>> discounting "discounting" 
                let builder () = withMnemonic mnemonic (Fun.EurLiborSwapIfrFix 
                                                            _tenor.cell 
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIfrFix>) l

                let source = Helper.sourceFold "Fun.EurLiborSwapIfrFix" 
                                               [| _tenor.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix1", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.EurLiborSwapIfrFix1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIfrFix>) l

                let source = Helper.sourceFold "Fun.EurLiborSwapIfrFix1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix2", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EurLiborSwapIfrFix2 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIfrFix>) l

                let source = Helper.sourceFold "Fun.EurLiborSwapIfrFix2" 
                                               [| _tenor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _h.cell
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
        ! returns a copy of itself linked to a different tenor
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_clone", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Clone") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _tenor.cell
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
        ! returns a copy of itself linked to a different curves
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_clone", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let _discounting = Helper.toHandle<Handle<YieldTermStructure>> discounting "discounting" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Clone1") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_clone", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Clone2") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _forwarding.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_discountingTermStructure", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".DiscountingTermStructure") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_exogenousDiscount", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ExogenousDiscount") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixedLegConvention", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixedLegConvention") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixedLegTenor", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixedLegTenor") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_forecastFixing", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ForecastFixing") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_forwardingTermStructure", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ForwardingTermStructure") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_iborIndex", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".IborIndex") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_maturityDate", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".MaturityDate") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _valueDate.cell
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
        \warning Relinking the term structure underlying the index will not have effect on the returned swap. recheck
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_underlyingSwap", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".UnderlyingSwap") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_currency", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Currency") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_dayCounter", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".DayCounter") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_familyName", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FamilyName") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixing", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Fixing") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixingCalendar", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixingCalendar") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixingDate", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixingDate") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixingDays", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixingDays") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_isValidFixingDate", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".IsValidFixingDate") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_name", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Name") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_pastFixing", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".PastFixing") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_tenor", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Tenor") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_update", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).Update
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Update") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_valueDate", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ValueDate") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_addFixing", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".AddFixing") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_addFixings", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".AddFixings") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_addFixings", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".AddFixings1") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_allowsNativeFixings", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".AllowsNativeFixings") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_clearFixings", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).ClearFixings
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ClearFixings") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_registerWith", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".RegisterWith") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_timeSeries", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".TimeSeries") 
                                               [| _EurLiborSwapIfrFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_unregisterWith", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "Reference to EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIfrFix.cell :?> EurLiborSwapIfrFixModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".UnregisterWith") 
                                               [| _EurLiborSwapIfrFix.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_Range", Description="Create a range of EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EurLiborSwapIfrFix")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EurLiborSwapIfrFix> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EurLiborSwapIfrFix>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EurLiborSwapIfrFix>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EurLiborSwapIfrFix>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
