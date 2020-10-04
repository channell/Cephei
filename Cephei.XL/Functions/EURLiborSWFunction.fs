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
  1-week %EUR %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module EURLiborSWFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborSW", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EURLiborSW 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLiborSW>) l

                let source = Helper.sourceFold "Fun.EURLiborSW" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborSW> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborSW1", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EURLiborSW1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLiborSW>) l

                let source = Helper.sourceFold "Fun.EURLiborSW1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborSW> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborSW_maturityDate", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".MaturityDate") 
                                               [| _EURLiborSW.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
        Date calculations  See <https://www.theice.com/marketdata/reports/170>.
    *)
    [<ExcelFunction(Name="_EURLiborSW_valueDate", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".ValueDate") 
                                               [| _EURLiborSW.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_EURLiborSW_businessDayConvention", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".BusinessDayConvention") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_EURLiborSW_clone", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EURLiborSW.source + ".Clone") 
                                               [| _EURLiborSW.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborSW> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborSW_endOfMonth", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".EndOfMonth") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_forecastFixing1", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".ForecastFixing1") 
                                               [| _EURLiborSW.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_EURLiborSW_forecastFixing", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".ForecastFixing") 
                                               [| _EURLiborSW.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_EURLiborSW_forwardingTermStructure", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EURLiborSW.source + ".ForwardingTermStructure") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborSW> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborSW_currency", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EURLiborSW.source + ".Currency") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborSW> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborSW_dayCounter", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EURLiborSW.source + ".DayCounter") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborSW> format
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
    [<ExcelFunction(Name="_EURLiborSW_familyName", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".FamilyName") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_fixing", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".Fixing") 
                                               [| _EURLiborSW.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_fixingCalendar", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EURLiborSW.source + ".FixingCalendar") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborSW> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLiborSW_fixingDate", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".FixingDate") 
                                               [| _EURLiborSW.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_fixingDays", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".FixingDays") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_isValidFixingDate", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".IsValidFixingDate") 
                                               [| _EURLiborSW.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_name", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".Name") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_pastFixing", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".PastFixing") 
                                               [| _EURLiborSW.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_tenor", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EURLiborSW.source + ".Tenor") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLiborSW> format
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
    [<ExcelFunction(Name="_EURLiborSW_update", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).Update
                                                       ) :> ICell
                let format (o : EURLiborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".Update") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_addFixing", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLiborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".AddFixing") 
                                               [| _EURLiborSW.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_addFixings", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLiborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".AddFixings") 
                                               [| _EURLiborSW.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_addFixings1", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLiborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".AddFixings1") 
                                               [| _EURLiborSW.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_allowsNativeFixings", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".AllowsNativeFixings") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_clearFixings", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).ClearFixings
                                                       ) :> ICell
                let format (o : EURLiborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".ClearFixings") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_registerWith", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLiborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".RegisterWith") 
                                               [| _EURLiborSW.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_timeSeries", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".TimeSeries") 
                                               [| _EURLiborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_unregisterWith", Description="Create a EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLiborSW",Description = "Reference to EURLiborSW")>] 
         eurliborsw : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLiborSW = Helper.toCell<EURLiborSW> eurliborsw "EURLiborSW"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((EURLiborSWModel.Cast _EURLiborSW.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLiborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLiborSW.source + ".UnregisterWith") 
                                               [| _EURLiborSW.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLiborSW.cell
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
    [<ExcelFunction(Name="_EURLiborSW_Range", Description="Create a range of EURLiborSW",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLiborSW_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURLiborSW")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLiborSW> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURLiborSW>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURLiborSW>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EURLiborSW>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
