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
  %Euribor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 11am Frankfurt. Annual 30/360 vs 6M Euribor, 1Y vs 3M Euribor. Reuters page ISDAFIX2 or EURSFIXA=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.
  </summary> *)
[<AutoSerializable(true)>]
module EuriborSwapIsdaFixAFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA2", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_create2
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

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder () = withMnemonic mnemonic (Fun.EuriborSwapIsdaFixA2
                                                            _tenor.cell 
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSwapIsdaFixA>) l

                let source = Helper.sourceFold "Fun.EuriborSwapIsdaFixA2" 
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
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA1", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EuriborSwapIsdaFixA1 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSwapIsdaFixA>) l

                let source = Helper.sourceFold "Fun.EuriborSwapIsdaFixA1" 
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
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.EuriborSwapIsdaFixA
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSwapIsdaFixA>) l

                let source = Helper.sourceFold "Fun.EuriborSwapIsdaFixA" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_clone", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".Clone") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_clone1", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".Clone1") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_clone2", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".Clone2") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_discountingTermStructure", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".DiscountingTermStructure") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_exogenousDiscount", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".ExogenousDiscount") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_fixedLegConvention", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".FixedLegConvention") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_fixedLegTenor", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".FixedLegTenor") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_forecastFixing", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".ForecastFixing") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_forwardingTermStructure", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".ForwardingTermStructure") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_iborIndex", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".IborIndex") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_maturityDate", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".MaturityDate") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_underlyingSwap", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".UnderlyingSwap") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_currency", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".Currency") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_dayCounter", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".DayCounter") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_familyName", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".FamilyName") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_fixing", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".Fixing") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_fixingCalendar", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".FixingCalendar") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_fixingDate", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".FixingDate") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_fixingDays", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".FixingDays") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_isValidFixingDate", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".IsValidFixingDate") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_name", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".Name") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_pastFixing", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".PastFixing") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_tenor", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".Tenor") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_update", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).Update
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".Update") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_valueDate", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".ValueDate") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_addFixing", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".AddFixing") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_addFixings", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".AddFixings") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_addFixings1", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".AddFixings1") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_allowsNativeFixings", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".AllowsNativeFixings") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_clearFixings", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).ClearFixings
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".ClearFixings") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_registerWith", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".RegisterWith") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_timeSeries", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".TimeSeries") 
                                               [| _EuriborSwapIsdaFixA.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_unregisterWith", Description="Create a EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSwapIsdaFixA",Description = "Reference to EuriborSwapIsdaFixA")>] 
         euriborswapisdafixa : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSwapIsdaFixA = Helper.toCell<EuriborSwapIsdaFixA> euriborswapisdafixa "EuriborSwapIsdaFixA" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EuriborSwapIsdaFixA.cell :?> EuriborSwapIsdaFixAModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EuriborSwapIsdaFixA) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSwapIsdaFixA.source + ".UnregisterWith") 
                                               [| _EuriborSwapIsdaFixA.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSwapIsdaFixA.cell
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
    [<ExcelFunction(Name="_EuriborSwapIsdaFixA_Range", Description="Create a range of EuriborSwapIsdaFixA",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSwapIsdaFixA_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EuriborSwapIsdaFixA")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EuriborSwapIsdaFixA> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EuriborSwapIsdaFixA>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EuriborSwapIsdaFixA>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EuriborSwapIsdaFixA>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
