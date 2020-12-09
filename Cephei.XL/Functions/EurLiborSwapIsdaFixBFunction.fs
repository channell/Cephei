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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB2", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_create2
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EurLiborSwapIsdaFixB2 
                                                            _tenor.cell 
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIsdaFixB>) l

                let source () = Helper.sourceFold "Fun.EurLiborSwapIsdaFixB2" 
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EurLiborSwapIsdaFixB
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIsdaFixB>) l

                let source () = Helper.sourceFold "Fun.EurLiborSwapIsdaFixB" 
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB1", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EurLiborSwapIsdaFixB1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EurLiborSwapIsdaFixB>) l

                let source () = Helper.sourceFold "Fun.EurLiborSwapIsdaFixB1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_clone", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Clone") 

                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_clone1", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "YieldTermStructure")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Clone1") 

                                               [| _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_clone2", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Clone2") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_discountingTermStructure", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".DiscountingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_exogenousDiscount", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ExogenousDiscount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixedLegConvention", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixedLegConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixedLegTenor", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixedLegTenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_forecastFixing", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_forwardingTermStructure", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_iborIndex", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".IborIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_maturityDate", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_underlyingSwap", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".UnderlyingSwap") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_currency", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_dayCounter", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_familyName", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixing", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixingCalendar", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixingDate", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_fixingDays", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_isValidFixingDate", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_name", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_pastFixing", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_tenor", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_update", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).Update
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_valueDate", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_addFixing", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".AddFixing") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_addFixings", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".AddFixings") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_addFixings1", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_allowsNativeFixings", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_clearFixings", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).ClearFixings
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_registerWith", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_timeSeries", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_unregisterWith", Description="Create a EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EurLiborSwapIsdaFixB",Description = "EurLiborSwapIsdaFixB")>] 
         eurliborswapisdafixb : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EurLiborSwapIsdaFixB = Helper.toCell<EurLiborSwapIsdaFixB> eurliborswapisdafixb "EurLiborSwapIsdaFixB"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((EurLiborSwapIsdaFixBModel.Cast _EurLiborSwapIsdaFixB.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EurLiborSwapIsdaFixB) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EurLiborSwapIsdaFixB.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EurLiborSwapIsdaFixB.cell
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
    [<ExcelFunction(Name="_EurLiborSwapIsdaFixB_Range", Description="Create a range of EurLiborSwapIsdaFixB",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EurLiborSwapIsdaFixB_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EurLiborSwapIsdaFixB> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EurLiborSwapIsdaFixB> (c)) :> ICell
                let format (i : Generic.List<ICell<EurLiborSwapIsdaFixB>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EurLiborSwapIsdaFixB>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
