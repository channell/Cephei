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
  %CHF %Libor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 11am London. Annual 30/360 vs 6M Libor, 1Y vs 3M Libor. Reuters page ISDAFIX4 or CHFSFIX=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.
  </summary> *)
[<AutoSerializable(true)>]
module ChfLiborSwapIsdaFixFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.ChfLiborSwapIsdaFix 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ChfLiborSwapIsdaFix>) l

                let source = Helper.sourceFold "Fun.ChfLiborSwapIsdaFix" 
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix1", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_create1
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
                let builder () = withMnemonic mnemonic (Fun.ChfLiborSwapIsdaFix1 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ChfLiborSwapIsdaFix>) l

                let source = Helper.sourceFold "Fun.ChfLiborSwapIsdaFix1" 
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_clone", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Clone") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_clone", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let _discounting = Helper.toHandle<Handle<YieldTermStructure>> discounting "discounting" 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Clone1") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_clone", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Clone2") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_discountingTermStructure", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".DiscountingTermStructure") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_exogenousDiscount", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ExogenousDiscount") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixedLegConvention", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixedLegConvention") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixedLegTenor", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixedLegTenor") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_forecastFixing", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ForecastFixing") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_forwardingTermStructure", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ForwardingTermStructure") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_iborIndex", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".IborIndex") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_maturityDate", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".MaturityDate") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_underlyingSwap", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".UnderlyingSwap") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_currency", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Currency") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_dayCounter", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".DayCounter") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_familyName", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FamilyName") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixing", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Fixing") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixingCalendar", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixingCalendar") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixingDate", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixingDate") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixingDays", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixingDays") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_isValidFixingDate", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".IsValidFixingDate") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_name", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Name") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_pastFixing", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".PastFixing") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_tenor", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Tenor") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_update", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).Update
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Update") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_valueDate", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ValueDate") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_addFixing", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".AddFixing") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_addFixings", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".AddFixings") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_addFixings", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".AddFixings1") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_allowsNativeFixings", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".AllowsNativeFixings") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_clearFixings", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).ClearFixings
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ClearFixings") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_registerWith", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".RegisterWith") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_timeSeries", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".TimeSeries") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_unregisterWith", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "Reference to ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_ChfLiborSwapIsdaFix.cell :?> ChfLiborSwapIsdaFixModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".UnregisterWith") 
                                               [| _ChfLiborSwapIsdaFix.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_Range", Description="Create a range of ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ChfLiborSwapIsdaFix")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ChfLiborSwapIsdaFix> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ChfLiborSwapIsdaFix>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ChfLiborSwapIsdaFix>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ChfLiborSwapIsdaFix>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
