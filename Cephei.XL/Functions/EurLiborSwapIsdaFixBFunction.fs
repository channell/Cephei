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
  %EUR %Libor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 11am London. Annual 30/360 vs 6M Libor, 1Y vs 3M Libor. Reuters page ISDAFIX2 or EURSFIXLB=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.
  </summary> *)
[<AutoSerializable(true)>]
module EurLiborSwapIsdaFixBFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB2", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_create2
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
                let builder () = withMnemonic mnemonic (Fun.EurLiborSwapIsdaFixB2 
                                                            _tenor.cell 
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIsdaFixB>) l

                let source = Helper.sourceFold "Fun.EurLiborSwapIsdaFixB2" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_create
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
                let builder () = withMnemonic mnemonic (Fun.EurLiborSwapIsdaFixB
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIsdaFixB>) l

                let source = Helper.sourceFold "Fun.EurLiborSwapIsdaFixB" 
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
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB1", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.EurLiborSwapIsdaFixB1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIsdaFixB>) l

                let source = Helper.sourceFold "Fun.EurLiborSwapIsdaFixB1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_clone", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Clone") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_clone1", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Clone1") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_clone2", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Clone2") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_discountingTermStructure", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".DiscountingTermStructure") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_exogenousDiscount", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ExogenousDiscount") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixedLegConvention", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixedLegConvention") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixedLegTenor", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixedLegTenor") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_forecastFixing", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ForecastFixing") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_forwardingTermStructure", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ForwardingTermStructure") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_iborIndex", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".IborIndex") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_maturityDate", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".MaturityDate") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_underlyingSwap", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".UnderlyingSwap") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_currency", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Currency") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_dayCounter", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".DayCounter") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_familyName", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FamilyName") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixing", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Fixing") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixingCalendar", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixingCalendar") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixingDate", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixingDate") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixingDays", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixingDays") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_isValidFixingDate", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".IsValidFixingDate") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_name", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Name") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_pastFixing", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".PastFixing") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_tenor", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Tenor") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixB> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_update", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).Update
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Update") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_valueDate", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ValueDate") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_addFixing", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".AddFixing") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_addFixings", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".AddFixings") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_addFixings1", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".AddFixings1") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_allowsNativeFixings", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".AllowsNativeFixings") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_clearFixings", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).ClearFixings
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ClearFixings") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_registerWith", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".RegisterWith") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_timeSeries", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".TimeSeries") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_unregisterWith", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "Reference to EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixB.cell :?> EurLiborSwapIsdaFixBModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".UnregisterWith") 
                                               [| _EurLiborSwapIsdaFixB.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_Range", Description="Create a range of EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EurLiborSwapIsdaFixB")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EurLiborSwapIsdaFixB> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EurLiborSwapIsdaFixB>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EurLiborSwapIsdaFixB>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EurLiborSwapIsdaFixB>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
