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
  %Euribor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 12am Frankfurt. Annual 30/360 vs 6M Euribor, 1Y vs 3M Euribor. Reuters page ISDAFIX2 or EURSFIXB=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.
  </summary> *)
[<AutoSerializable(true)>]
module EuriborSwapIsdaFixBFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EuriborSwapIsdaFixB 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSwapIsdaFixB>) l

                let source () = Helper.sourceFold "Fun.EuriborSwapIsdaFixB" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB1", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_create1
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

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EuriborSwapIsdaFixB1 
                                                            _tenor.cell 
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSwapIsdaFixB>) l

                let source () = Helper.sourceFold "Fun.EuriborSwapIsdaFixB1" 
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
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB2", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_create2
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EuriborSwapIsdaFixB2 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSwapIsdaFixB>) l

                let source () = Helper.sourceFold "Fun.EuriborSwapIsdaFixB2" 
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
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_clone", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".Clone") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_clone1", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".Clone") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_clone2", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".Clone") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_discountingTermStructure", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".DiscountingTermStructure") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_exogenousDiscount", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".ExogenousDiscount") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_fixedLegConvention", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".FixedLegConvention") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_fixedLegTenor", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".FixedLegTenor") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_forecastFixing", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".ForecastFixing") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_forwardingTermStructure", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".ForwardingTermStructure") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_iborIndex", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".IborIndex") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_maturityDate", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".MaturityDate") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_underlyingSwap", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".UnderlyingSwap") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_currency", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".Currency") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_dayCounter", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".DayCounter") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_familyName", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".FamilyName") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_fixing", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".Fixing") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_fixingCalendar", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".FixingCalendar") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_fixingDate", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".FixingDate") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_fixingDays", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".FixingDays") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_isValidFixingDate", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".IsValidFixingDate") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_name", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".Name") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_pastFixing", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".PastFixing") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_tenor", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".Tenor") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EuriborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_update", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).Update
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".Update") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_valueDate", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".ValueDate") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_addFixing", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".AddFixing") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_addFixings", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".AddFixings") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_addFixings1", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".AddFixings") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_allowsNativeFixings", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".AllowsNativeFixings") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_clearFixings", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).ClearFixings
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".ClearFixings") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_registerWith", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".RegisterWith") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_timeSeries", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".TimeSeries") 
                                               [| _EuriborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_unregisterWith", Description="Create a EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixB",Description = "Reference to EuriborSwapIsdaFixB")>] 
         euriborswapisdafixb : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixB = Helper.toCell<EuriborSwapIsdaFixB> euriborswapisdafixb "EuriborSwapIsdaFixB"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((EuriborSwapIsdaFixBModel.Cast _EuriborSwapIsdaFixB.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EuriborSwapIsdaFixB.source + ".UnregisterWith") 
                                               [| _EuriborSwapIsdaFixB.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixB_Range", Description="Create a range of EuriborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixB_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EuriborSwapIsdaFixB")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EuriborSwapIsdaFixB> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EuriborSwapIsdaFixB>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<EuriborSwapIsdaFixB>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<EuriborSwapIsdaFixB>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
