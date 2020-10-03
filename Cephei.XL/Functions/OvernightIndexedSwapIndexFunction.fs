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
  base class for overnight indexed swap indexes
  </summary> *)
[<AutoSerializable(true)>]
module OvernightIndexedSwapIndexFunction =

    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_overnightIndex", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_overnightIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).OvernightIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndex>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".OvernightIndex") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "Reference to familyName")>] 
         familyName : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="currency",Description = "Reference to currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="overnightIndex",Description = "Reference to overnightIndex")>] 
         overnightIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let _overnightIndex = Helper.toCell<OvernightIndex> overnightIndex "overnightIndex" 
                let builder () = withMnemonic mnemonic (Fun.OvernightIndexedSwapIndex 
                                                            _familyName.cell 
                                                            _tenor.cell 
                                                            _settlementDays.cell 
                                                            _currency.cell 
                                                            _overnightIndex.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndexedSwapIndex>) l

                let source = Helper.sourceFold "Fun.OvernightIndexedSwapIndex" 
                                               [| _familyName.source
                                               ;  _tenor.source
                                               ;  _settlementDays.source
                                               ;  _currency.source
                                               ;  _overnightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _tenor.cell
                                ;  _settlementDays.cell
                                ;  _currency.cell
                                ;  _overnightIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \warning Relinking the term structure underlying the index will not have effect on the returned swap.
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_underlyingSwap", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_underlyingSwap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).UnderlyingSwap
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndexedSwap>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".UnderlyingSwap") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_clone", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).Clone
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".Clone") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                ;  _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_clone1", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_clone1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        ([<ExcelArgument(Name="discounting",Description = "Reference to discounting")>] 
         discounting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let _discounting = Helper.toHandle<YieldTermStructure> discounting "discounting" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).Clone1
                                                            _forwarding.cell 
                                                            _discounting.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".Clone1") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _forwarding.source
                                               ;  _discounting.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                ;  _forwarding.cell
                                ;  _discounting.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_clone2", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_clone2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).Clone2
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".Clone") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_discountingTermStructure", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_discountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).DiscountingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".DiscountingTermStructure") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_exogenousDiscount", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_exogenousDiscount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).ExogenousDiscount
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".ExogenousDiscount") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_fixedLegConvention", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_fixedLegConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).FixedLegConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".FixedLegConvention") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_fixedLegTenor", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_fixedLegTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).FixedLegTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".FixedLegTenor") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_forecastFixing", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".ForecastFixing") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_forwardingTermStructure", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".ForwardingTermStructure") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_iborIndex", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".IborIndex") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_maturityDate", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".MaturityDate") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_currency", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".Currency") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_dayCounter", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".DayCounter") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_familyName", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".FamilyName") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_fixing", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".Fixing") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_fixingCalendar", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".FixingCalendar") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_fixingDate", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".FixingDate") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_fixingDays", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".FixingDays") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_isValidFixingDate", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".IsValidFixingDate") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_name", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".Name") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_pastFixing", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".PastFixing") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_tenor", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".Tenor") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedSwapIndex> format
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_update", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).Update
                                                       ) :> ICell
                let format (o : OvernightIndexedSwapIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".Update") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_valueDate", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".ValueDate") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_addFixing", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedSwapIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".AddFixing") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_addFixings", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedSwapIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".AddFixings") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_addFixings1", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedSwapIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".AddFixings1") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_allowsNativeFixings", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".AllowsNativeFixings") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_clearFixings", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).ClearFixings
                                                       ) :> ICell
                let format (o : OvernightIndexedSwapIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".ClearFixings") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_registerWith", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedSwapIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".RegisterWith") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_timeSeries", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".TimeSeries") 
                                               [| _OvernightIndexedSwapIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_unregisterWith", Description="Create a OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedSwapIndex",Description = "Reference to OvernightIndexedSwapIndex")>] 
         overnightindexedswapindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedSwapIndex = Helper.toCell<OvernightIndexedSwapIndex> overnightindexedswapindex "OvernightIndexedSwapIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedSwapIndexModel.Cast _OvernightIndexedSwapIndex.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedSwapIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedSwapIndex.source + ".UnregisterWith") 
                                               [| _OvernightIndexedSwapIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedSwapIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndexedSwapIndex_Range", Description="Create a range of OvernightIndexedSwapIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedSwapIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the OvernightIndexedSwapIndex")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OvernightIndexedSwapIndex> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<OvernightIndexedSwapIndex>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<OvernightIndexedSwapIndex>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<OvernightIndexedSwapIndex>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
