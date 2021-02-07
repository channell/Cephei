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
  %Euribor %Swap indexes published by IFR Markets and distributed by Reuters page TGM42281 and by Telerate. Annual 30/360 vs 6M Euribor, 1Y vs 3M Euribor. For more info see <http://www.ifrmarkets.com>.
  </summary> *)
[<AutoSerializable(true)>]
module EuriborSwapIfrFixFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix2", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = (Fun.EuriborSwapIfrFix2 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSwapIfrFix>) l

                let source () = Helper.sourceFold "Fun.EuriborSwapIfrFix2" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_create
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
                let builder (current : ICell) = (Fun.EuriborSwapIfrFix 
                                                            _tenor.cell 
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSwapIfrFix>) l

                let source () = Helper.sourceFold "Fun.EuriborSwapIfrFix" 
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
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix1", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_create1
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
                let builder (current : ICell) = (Fun.EuriborSwapIfrFix1
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSwapIfrFix>) l

                let source () = Helper.sourceFold "Fun.EuriborSwapIfrFix1" 
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
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_clone", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".Clone") 

                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_clone1", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "YieldTermStructure")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".Clone1") 

                                               [| _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_clone2", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".Clone2") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix_discountingTermStructure", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".DiscountingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix_exogenousDiscount", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".ExogenousDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_fixedLegConvention", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".FixedLegConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_fixedLegTenor", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".FixedLegTenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix_forecastFixing", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_forwardingTermStructure", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix_iborIndex", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".IborIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_maturityDate", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_underlyingSwap", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".UnderlyingSwap") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix_currency", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix_dayCounter", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_familyName", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_fixing", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_fixingCalendar", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIfrFix_fixingDate", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_fixingDays", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_isValidFixingDate", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_name", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_pastFixing", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_tenor", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIfrFix> format
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_update", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).Update
                                                       ) :> ICell
                let format (o : EuriborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_valueDate", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_addFixing", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_addFixings", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_addFixings1", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_allowsNativeFixings", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_clearFixings", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).ClearFixings
                                                       ) :> ICell
                let format (o : EuriborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_registerWith", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_timeSeries", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_unregisterWith", Description="Create a EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIfrFix",Description = "EuriborSwapIfrFix")>] 
         euriborswapifrfix : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIfrFix = Helper.toCell<EuriborSwapIfrFix> euriborswapifrfix "EuriborSwapIfrFix"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((EuriborSwapIfrFixModel.Cast _EuriborSwapIfrFix.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIfrFix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIfrFix.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIfrFix.cell
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
    [<ExcelFunction(Name="_EuriborSwapIfrFix_Range", Description="Create a range of EuriborSwapIfrFix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIfrFix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EuriborSwapIfrFix> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EuriborSwapIfrFix> (c)) :> ICell
                let format (i : Cephei.Cell.List<EuriborSwapIfrFix>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EuriborSwapIfrFix>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
