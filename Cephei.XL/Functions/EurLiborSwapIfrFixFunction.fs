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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix2", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "YieldTermStructure")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EurLiborSwapIfrFix2 
                                                            _tenor.cell 
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIfrFix>) l

                let source () = Helper.sourceFold "Fun.EurLiborSwapIfrFix2" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix1", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EurLiborSwapIfrFix1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIfrFix>) l

                let source () = Helper.sourceFold "Fun.EurLiborSwapIfrFix1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EurLiborSwapIfrFix
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIfrFix>) l

                let source () = Helper.sourceFold "Fun.EurLiborSwapIfrFix" 
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
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_clone", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Clone") 

                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_clone1", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "YieldTermStructure")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Clone1") 

                                               [| _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_clone2", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Clone2") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_discountingTermStructure", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".DiscountingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_exogenousDiscount", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ExogenousDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixedLegConvention", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixedLegConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixedLegTenor", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixedLegTenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_forecastFixing", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_forwardingTermStructure", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_iborIndex", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".IborIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_maturityDate", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_underlyingSwap", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".UnderlyingSwap") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_currency", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_dayCounter", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_familyName", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixing", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixingCalendar", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixingDate", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_fixingDays", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_isValidFixingDate", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_name", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_pastFixing", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_tenor", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_update", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).Update
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_valueDate", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_addFixing", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".AddFixing") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_addFixings", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".AddFixings") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_addFixings1", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_allowsNativeFixings", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_clearFixings", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).ClearFixings
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_registerWith", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_timeSeries", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_unregisterWith", Description="Create a EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIfrFix",Description = "EurLiborSwapIfrFix")>] 
         eurliborswapifrfix : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIfrFix = Helper.toCell<EurLiborSwapIfrFix> eurliborswapifrfix "EurLiborSwapIfrFix"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIfrFixModel.Cast _EurLiborSwapIfrFix.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIfrFix.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIfrFix_Range", Description="Create a range of EurLiborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIfrFix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EurLiborSwapIfrFix> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<EurLiborSwapIfrFix> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<EurLiborSwapIfrFix>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<EurLiborSwapIfrFix>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
