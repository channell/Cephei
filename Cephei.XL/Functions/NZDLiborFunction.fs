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
  New Zealand Dollar LIBOR discontinued as of 2013.
  </summary> *)
[<AutoSerializable(true)>]
module NZDLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NZDLibor", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.NZDLibor 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NZDLibor>) l

                let source () = Helper.sourceFold "Fun.NZDLibor" 
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
                    ; subscriber = Helper.subscriberModel<NZDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NZDLibor1", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.NZDLibor1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NZDLibor>) l

                let source () = Helper.sourceFold "Fun.NZDLibor1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Other methods
    *)
    [<ExcelFunction(Name="_NZDLibor_clone", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_NZDLibor.source + ".Clone") 
                                               [| _NZDLibor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NZDLibor_maturityDate", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".MaturityDate") 
                                               [| _NZDLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
        Date calculations  See <https://www.theice.com/marketdata/reports/170>.
    *)
    [<ExcelFunction(Name="_NZDLibor_valueDate", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".ValueDate") 
                                               [| _NZDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_NZDLibor_businessDayConvention", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".BusinessDayConvention") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_endOfMonth", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".EndOfMonth") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_forecastFixing1", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".ForecastFixing1") 
                                               [| _NZDLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_NZDLibor_forecastFixing", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".ForecastFixing") 
                                               [| _NZDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_NZDLibor_forwardingTermStructure", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_NZDLibor.source + ".ForwardingTermStructure") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NZDLibor_currency", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_NZDLibor.source + ".Currency") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NZDLibor_dayCounter", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_NZDLibor.source + ".DayCounter") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDLibor> format
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
    [<ExcelFunction(Name="_NZDLibor_familyName", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".FamilyName") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_fixing", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".Fixing") 
                                               [| _NZDLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_fixingCalendar", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_NZDLibor.source + ".FixingCalendar") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NZDLibor_fixingDate", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".FixingDate") 
                                               [| _NZDLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_fixingDays", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".FixingDays") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_isValidFixingDate", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".IsValidFixingDate") 
                                               [| _NZDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_name", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".Name") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_pastFixing", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".PastFixing") 
                                               [| _NZDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_tenor", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_NZDLibor.source + ".Tenor") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NZDLibor> format
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
    [<ExcelFunction(Name="_NZDLibor_update", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).Update
                                                       ) :> ICell
                let format (o : NZDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".Update") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_addFixing", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : NZDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".AddFixing") 
                                               [| _NZDLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_addFixings", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : NZDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".AddFixings") 
                                               [| _NZDLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_addFixings1", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : NZDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".AddFixings1") 
                                               [| _NZDLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_allowsNativeFixings", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".AllowsNativeFixings") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_clearFixings", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : NZDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".ClearFixings") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_registerWith", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : NZDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".RegisterWith") 
                                               [| _NZDLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_timeSeries", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".TimeSeries") 
                                               [| _NZDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_unregisterWith", Description="Create a NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NZDLibor",Description = "Reference to NZDLibor")>] 
         nzdlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NZDLibor = Helper.toCell<NZDLibor> nzdlibor "NZDLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((NZDLiborModel.Cast _NZDLibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : NZDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NZDLibor.source + ".UnregisterWith") 
                                               [| _NZDLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NZDLibor.cell
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
    [<ExcelFunction(Name="_NZDLibor_Range", Description="Create a range of NZDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NZDLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NZDLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NZDLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NZDLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<NZDLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<NZDLibor>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
