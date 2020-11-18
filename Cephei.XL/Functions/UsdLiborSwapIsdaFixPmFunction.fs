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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.UsdLiborSwapIsdaFixPm 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UsdLiborSwapIsdaFixPm>) l

                let source () = Helper.sourceFold "Fun.UsdLiborSwapIsdaFixPm" 
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
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm1", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.UsdLiborSwapIsdaFixPm1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UsdLiborSwapIsdaFixPm>) l

                let source () = Helper.sourceFold "Fun.UsdLiborSwapIsdaFixPm1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_clone", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Clone") 

                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_clone1", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "YieldTermStructure")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Clone1") 

                                               [| _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_clone2", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Clone2") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_discountingTermStructure", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".DiscountingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_exogenousDiscount", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ExogenousDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixedLegConvention", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixedLegConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixedLegTenor", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixedLegTenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_forecastFixing", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_forwardingTermStructure", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_iborIndex", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".IborIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_maturityDate", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_underlyingSwap", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".UnderlyingSwap") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_currency", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_dayCounter", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_familyName", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixing", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixingCalendar", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixingDate", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_fixingDays", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_isValidFixingDate", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_name", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_pastFixing", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_tenor", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UsdLiborSwapIsdaFixPm> format
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_update", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).Update
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_valueDate", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_addFixing", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".AddFixing") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_addFixings", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".AddFixings") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_addFixings1", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_allowsNativeFixings", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_clearFixings", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).ClearFixings
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_registerWith", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_timeSeries", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_unregisterWith", Description="Create a UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UsdLiborSwapIsdaFixPm",Description = "UsdLiborSwapIsdaFixPm")>] 
         usdliborswapisdafixpm : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UsdLiborSwapIsdaFixPm = Helper.toCell<UsdLiborSwapIsdaFixPm> usdliborswapisdafixpm "UsdLiborSwapIsdaFixPm"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((UsdLiborSwapIsdaFixPmModel.Cast _UsdLiborSwapIsdaFixPm.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UsdLiborSwapIsdaFixPm) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UsdLiborSwapIsdaFixPm.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UsdLiborSwapIsdaFixPm.cell
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
    [<ExcelFunction(Name="_UsdLiborSwapIsdaFixPm_Range", Description="Create a range of UsdLiborSwapIsdaFixPm",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UsdLiborSwapIsdaFixPm_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UsdLiborSwapIsdaFixPm> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<UsdLiborSwapIsdaFixPm> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<UsdLiborSwapIsdaFixPm>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<UsdLiborSwapIsdaFixPm>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
