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
module JpyLiborSwapIsdaFixAmFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_create
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
                let builder () = withMnemonic mnemonic (Fun.JpyLiborSwapIsdaFixAm 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JpyLiborSwapIsdaFixAm>) l

                let source = Helper.sourceFold "Fun.JpyLiborSwapIsdaFixAm" 
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
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm1", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.JpyLiborSwapIsdaFixAm1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JpyLiborSwapIsdaFixAm>) l

                let source = Helper.sourceFold "Fun.JpyLiborSwapIsdaFixAm1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_clone", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".Clone") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_clone1", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".Clone1") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_clone2", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".Clone2") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_discountingTermStructure", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".DiscountingTermStructure") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_exogenousDiscount", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".ExogenousDiscount") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_fixedLegConvention", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".FixedLegConvention") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_fixedLegTenor", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".FixedLegTenor") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_forecastFixing", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".ForecastFixing") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_forwardingTermStructure", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".ForwardingTermStructure") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_iborIndex", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".IborIndex") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_maturityDate", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".MaturityDate") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_underlyingSwap", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".UnderlyingSwap") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_currency", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".Currency") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_dayCounter", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".DayCounter") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_familyName", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".FamilyName") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_fixing", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".Fixing") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_fixingCalendar", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".FixingCalendar") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_fixingDate", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".FixingDate") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_fixingDays", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".FixingDays") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_isValidFixingDate", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".IsValidFixingDate") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_name", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".Name") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_pastFixing", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".PastFixing") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_tenor", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".Tenor") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JpyLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_update", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).Update
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".Update") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_valueDate", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".ValueDate") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_addFixing", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".AddFixing") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_addFixings", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".AddFixings") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_addFixings1", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".AddFixings1") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_allowsNativeFixings", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".AllowsNativeFixings") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_clearFixings", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).ClearFixings
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".ClearFixings") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_registerWith", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".RegisterWith") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_timeSeries", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".TimeSeries") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_unregisterWith", Description="Create a JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JpyLiborSwapIsdaFixAm",Description = "Reference to JpyLiborSwapIsdaFixAm")>] 
         jpyliborswapisdafixam : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JpyLiborSwapIsdaFixAm = Helper.toCell<JpyLiborSwapIsdaFixAm> jpyliborswapisdafixam "JpyLiborSwapIsdaFixAm"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_JpyLiborSwapIsdaFixAm.cell :?> JpyLiborSwapIsdaFixAmModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : JpyLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_JpyLiborSwapIsdaFixAm.source + ".UnregisterWith") 
                                               [| _JpyLiborSwapIsdaFixAm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JpyLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_JpyLiborSwapIsdaFixAm_Range", Description="Create a range of JpyLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JpyLiborSwapIsdaFixAm_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the JpyLiborSwapIsdaFixAm")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<JpyLiborSwapIsdaFixAm> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<JpyLiborSwapIsdaFixAm>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<JpyLiborSwapIsdaFixAm>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<JpyLiborSwapIsdaFixAm>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
