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
module GbpLiborSwapIsdaFixFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.GbpLiborSwapIsdaFix 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GbpLiborSwapIsdaFix>) l

                let source = Helper.sourceFold "Fun.GbpLiborSwapIsdaFix" 
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
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix1", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.GbpLiborSwapIsdaFix1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GbpLiborSwapIsdaFix>) l

                let source = Helper.sourceFold "Fun.GbpLiborSwapIsdaFix1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_clone", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".Clone") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_clone1", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".Clone1") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_clone2", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".Clone2") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_discountingTermStructure", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".DiscountingTermStructure") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_exogenousDiscount", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".ExogenousDiscount") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_fixedLegConvention", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".FixedLegConvention") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_fixedLegTenor", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".FixedLegTenor") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_forecastFixing", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".ForecastFixing") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_forwardingTermStructure", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".ForwardingTermStructure") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_iborIndex", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".IborIndex") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_maturityDate", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".MaturityDate") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_underlyingSwap", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".UnderlyingSwap") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_currency", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".Currency") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_dayCounter", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".DayCounter") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_familyName", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".FamilyName") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_fixing", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".Fixing") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_fixingCalendar", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".FixingCalendar") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_fixingDate", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".FixingDate") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_fixingDays", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".FixingDays") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_isValidFixingDate", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".IsValidFixingDate") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_name", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".Name") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_pastFixing", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".PastFixing") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_tenor", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".Tenor") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GbpLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_update", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).Update
                                                       ) :> ICell
                let format (o : GbpLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".Update") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_valueDate", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".ValueDate") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_addFixing", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GbpLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".AddFixing") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_addFixings", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GbpLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".AddFixings") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_addFixings1", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GbpLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".AddFixings1") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_allowsNativeFixings", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".AllowsNativeFixings") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_clearFixings", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).ClearFixings
                                                       ) :> ICell
                let format (o : GbpLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".ClearFixings") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_registerWith", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GbpLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".RegisterWith") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_timeSeries", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".TimeSeries") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_unregisterWith", Description="Create a GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GbpLiborSwapIsdaFix",Description = "Reference to GbpLiborSwapIsdaFix")>] 
         gbpliborswapisdafix : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GbpLiborSwapIsdaFix = Helper.toCell<GbpLiborSwapIsdaFix> gbpliborswapisdafix "GbpLiborSwapIsdaFix"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_GbpLiborSwapIsdaFix.cell :?> GbpLiborSwapIsdaFixModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GbpLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GbpLiborSwapIsdaFix.source + ".UnregisterWith") 
                                               [| _GbpLiborSwapIsdaFix.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GbpLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_GbpLiborSwapIsdaFix_Range", Description="Create a range of GbpLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GbpLiborSwapIsdaFix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GbpLiborSwapIsdaFix")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GbpLiborSwapIsdaFix> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GbpLiborSwapIsdaFix>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GbpLiborSwapIsdaFix>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GbpLiborSwapIsdaFix>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
