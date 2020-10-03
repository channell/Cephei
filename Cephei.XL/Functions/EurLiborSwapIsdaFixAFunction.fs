﻿(*
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
  %EUR %Libor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 10am London. Annual 30/360 vs 6M Libor, 1Y vs 3M Libor. Reuters page ISDAFIX2 or EURSFIXLA=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.
  </summary> *)
[<AutoSerializable(true)>]
module EurLiborSwapIsdaFixAFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_create
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
                let builder () = withMnemonic mnemonic (Fun.EurLiborSwapIsdaFixA 
                                                            _tenor.cell 
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIsdaFixA>) l

                let source = Helper.sourceFold "Fun.EurLiborSwapIsdaFixA" 
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
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA1", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_create1
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
                let builder () = withMnemonic mnemonic (Fun.EurLiborSwapIsdaFixA1 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIsdaFixA>) l

                let source = Helper.sourceFold "Fun.EurLiborSwapIsdaFixA1" 
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
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA2", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.EurLiborSwapIsdaFixA2 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIsdaFixA>) l

                let source = Helper.sourceFold "Fun.EurLiborSwapIsdaFixA2" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_clone", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".Clone") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_clone1", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".Clone1") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_clone2", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".Clone2") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_discountingTermStructure", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".DiscountingTermStructure") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_exogenousDiscount", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".ExogenousDiscount") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_fixedLegConvention", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".FixedLegConvention") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_fixedLegTenor", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".FixedLegTenor") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_forecastFixing", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".ForecastFixing") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_forwardingTermStructure", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".ForwardingTermStructure") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_iborIndex", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".IborIndex") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_maturityDate", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".MaturityDate") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_underlyingSwap", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".UnderlyingSwap") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_currency", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".Currency") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_dayCounter", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".DayCounter") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_familyName", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".FamilyName") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_fixing", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".Fixing") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_fixingCalendar", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".FixingCalendar") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_fixingDate", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".FixingDate") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_fixingDays", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".FixingDays") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_isValidFixingDate", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".IsValidFixingDate") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_name", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".Name") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_pastFixing", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".PastFixing") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_tenor", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".Tenor") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EurLiborSwapIsdaFixA> format
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_update", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).Update
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".Update") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_valueDate", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".ValueDate") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_addFixing", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".AddFixing") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_addFixings", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".AddFixings") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_addFixings1", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".AddFixings1") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_allowsNativeFixings", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".AllowsNativeFixings") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_clearFixings", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).ClearFixings
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".ClearFixings") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_registerWith", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".RegisterWith") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_timeSeries", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".TimeSeries") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_unregisterWith", Description="Create a EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixA",Description = "Reference to EurLiborSwapIsdaFixA")>] 
         eurliborswapisdafixa : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixA = Helper.toCell<EurLiborSwapIsdaFixA> eurliborswapisdafixa "EurLiborSwapIsdaFixA"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_EurLiborSwapIsdaFixA.cell :?> EurLiborSwapIsdaFixAModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EurLiborSwapIsdaFixA.source + ".UnregisterWith") 
                                               [| _EurLiborSwapIsdaFixA.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixA_Range", Description="Create a range of EurLiborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixA_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EurLiborSwapIsdaFixA")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EurLiborSwapIsdaFixA> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EurLiborSwapIsdaFixA>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EurLiborSwapIsdaFixA>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EurLiborSwapIsdaFixA>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"