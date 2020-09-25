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

  </summary> *)
[<AutoSerializable(true)>]
module UsdLiborSwapIsdaFixPmFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_create
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
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.UsdLiborSwapIsdaFixPm 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UsdLiborSwapIsdaFixPm>) l

                let source = Helper.sourceFold "Fun.UsdLiborSwapIsdaFixPm" 
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
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm1", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.UsdLiborSwapIsdaFixPm1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UsdLiborSwapIsdaFixPm>) l

                let source = Helper.sourceFold "Fun.UsdLiborSwapIsdaFixPm1" 
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
        ! returns a copy of itself linked to a different tenor
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_clone", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Clone") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_clone1", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Clone1") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_clone2", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Clone2") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_discountingTermStructure", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".DiscountingTermStructure") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_exogenousDiscount", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ExogenousDiscount") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixedLegConvention", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixedLegConvention") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixedLegTenor", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixedLegTenor") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_forecastFixing", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ForecastFixing") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_forwardingTermStructure", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ForwardingTermStructure") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_iborIndex", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".IborIndex") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_maturityDate", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".MaturityDate") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_underlyingSwap", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".UnderlyingSwap") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_currency", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Currency") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_dayCounter", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".DayCounter") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_familyName", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FamilyName") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixing", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Fixing") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixingCalendar", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixingCalendar") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixingDate", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixingDate") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixingDays", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixingDays") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_isValidFixingDate", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".IsValidFixingDate") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_name", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Name") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_pastFixing", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".PastFixing") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_tenor", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Tenor") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_update", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).Update
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Update") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_valueDate", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ValueDate") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_addFixing", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".AddFixing") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_addFixings", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".AddFixings") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_addFixings1", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".AddFixings1") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_allowsNativeFixings", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".AllowsNativeFixings") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_clearFixings", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).ClearFixings
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ClearFixings") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_registerWith", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".RegisterWith") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_timeSeries", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".TimeSeries") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_unregisterWith", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "Reference to UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_UsdLiborSwapIsdaFixPm.cell :?> UsdLiborSwapIsdaFixPmModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".UnregisterWith") 
                                               [| _UsdLiborSwapIsdaFixPm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_Range", Description="Create a range of UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the UsdLiborSwapIsdaFixPm")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UsdLiborSwapIsdaFixPm> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<UsdLiborSwapIsdaFixPm>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<UsdLiborSwapIsdaFixPm>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<UsdLiborSwapIsdaFixPm>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
