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
module UsdLiborSwapIsdaFixAmFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.UsdLiborSwapIsdaFixAm 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UsdLiborSwapIsdaFixAm>) l

                let source () = Helper.sourceFold "Fun.UsdLiborSwapIsdaFixAm" 
                                               [| _tenor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm1", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.UsdLiborSwapIsdaFixAm1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UsdLiborSwapIsdaFixAm>) l

                let source () = Helper.sourceFold "Fun.UsdLiborSwapIsdaFixAm1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_clone", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".Clone") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_clone1", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".Clone1") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_clone2", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".Clone2") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_discountingTermStructure", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".DiscountingTermStructure") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_exogenousDiscount", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".ExogenousDiscount") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_fixedLegConvention", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".FixedLegConvention") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_fixedLegTenor", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".FixedLegTenor") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_forecastFixing", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".ForecastFixing") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_forwardingTermStructure", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".ForwardingTermStructure") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_iborIndex", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".IborIndex") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_maturityDate", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".MaturityDate") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _valueDate.cell
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
        \warning Relinking the term structure underlying the index will not have effect on the returned swap. recheck
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_underlyingSwap", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".UnderlyingSwap") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_currency", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".Currency") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_dayCounter", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".DayCounter") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_familyName", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".FamilyName") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_fixing", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".Fixing") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_fixingCalendar", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".FixingCalendar") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_fixingDate", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".FixingDate") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_fixingDays", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".FixingDays") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_isValidFixingDate", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".IsValidFixingDate") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_name", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".Name") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_pastFixing", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".PastFixing") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_tenor", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".Tenor") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixAm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_update", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).Update
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".Update") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_valueDate", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".ValueDate") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_addFixing", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".AddFixing") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_addFixings", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".AddFixings") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_addFixings1", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".AddFixings1") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_allowsNativeFixings", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".AllowsNativeFixings") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_clearFixings", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).ClearFixings
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".ClearFixings") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_registerWith", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".RegisterWith") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_timeSeries", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".TimeSeries") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_unregisterWith", Description="Create a UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixAm",Description = "Reference to UsdLiborSwapIsdaFixAm")>] 
         usdliborswapisdafixam : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixAm = Helper.toCell<UsdLiborSwapIsdaFixAm> usdliborswapisdafixam "UsdLiborSwapIsdaFixAm"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixAmModel.Cast _UsdLiborSwapIsdaFixAm.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixAm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixAm.source + ".UnregisterWith") 
                                               [| _UsdLiborSwapIsdaFixAm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixAm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixAm_Range", Description="Create a range of UsdLiborSwapIsdaFixAm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixAm_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the UsdLiborSwapIsdaFixAm")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UsdLiborSwapIsdaFixAm> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<UsdLiborSwapIsdaFixAm>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<UsdLiborSwapIsdaFixAm>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<UsdLiborSwapIsdaFixAm>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
