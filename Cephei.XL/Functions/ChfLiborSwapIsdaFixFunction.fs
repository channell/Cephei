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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix1", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ChfLiborSwapIsdaFix1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ChfLiborSwapIsdaFix>) l

                let source () = Helper.sourceFold "Fun.ChfLiborSwapIsdaFix1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ChfLiborSwapIsdaFix
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ChfLiborSwapIsdaFix>) l

                let source () = Helper.sourceFold "Fun.ChfLiborSwapIsdaFix" 
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
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_clone", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Clone") 

                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_clone1", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "YieldTermStructure")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Clone1") 

                                               [| _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_clone2", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Clone2") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_discountingTermStructure", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".DiscountingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_exogenousDiscount", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ExogenousDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixedLegConvention", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixedLegConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixedLegTenor", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixedLegTenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_forecastFixing", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_forwardingTermStructure", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_iborIndex", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".IborIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_maturityDate", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_underlyingSwap", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".UnderlyingSwap") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_currency", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_dayCounter", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_familyName", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixing", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixingCalendar", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixingDate", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_fixingDays", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_isValidFixingDate", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_name", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_pastFixing", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_tenor", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ChfLiborSwapIsdaFix> format
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_update", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).Update
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_valueDate", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_addFixing", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".AddFixing") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_addFixings", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".AddFixings") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_addFixings1", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_allowsNativeFixings", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_clearFixings", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).ClearFixings
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_registerWith", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_timeSeries", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_unregisterWith", Description="Create a ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ChfLiborSwapIsdaFix",Description = "ChfLiborSwapIsdaFix")>] 
         chfliborswapisdafix : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ChfLiborSwapIsdaFix = Helper.toCell<ChfLiborSwapIsdaFix> chfliborswapisdafix "ChfLiborSwapIsdaFix"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ChfLiborSwapIsdaFixModel.Cast _ChfLiborSwapIsdaFix.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ChfLiborSwapIsdaFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ChfLiborSwapIsdaFix.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ChfLiborSwapIsdaFix.cell
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
    [<ExcelFunction(Name="_ChfLiborSwapIsdaFix_Range", Description="Create a range of ChfLiborSwapIsdaFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ChfLiborSwapIsdaFix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ChfLiborSwapIsdaFix> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ChfLiborSwapIsdaFix>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<ChfLiborSwapIsdaFix>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ChfLiborSwapIsdaFix>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
