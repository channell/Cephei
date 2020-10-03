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
  %JPY %TIBOR index   Tokyo Interbank Offered Rate.  This is the rate fixed in Tokio by JBA. Use JPYLibor if you're interested in the London fixing by BBA.  check settlement days and end-of-month adjustment.
  </summary> *)
[<AutoSerializable(true)>]
module TiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Tibor", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.Tibor 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Tibor>) l

                let source = Helper.sourceFold "Fun.Tibor" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Tibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Tibor1", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_create1
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
                let builder () = withMnemonic mnemonic (Fun.Tibor1 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Tibor>) l

                let source = Helper.sourceFold "Fun.Tibor1" 
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
                    ; subscriber = Helper.subscriberModel<Tibor> format
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
    [<ExcelFunction(Name="_Tibor_businessDayConvention", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".BusinessDayConvention") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_clone", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Tibor.source + ".Clone") 
                                               [| _Tibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Tibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Tibor_endOfMonth", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".EndOfMonth") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_forecastFixing1", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Tibor.source + ".ForecastFixing1") 
                                               [| _Tibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_forecastFixing", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Tibor.source + ".ForecastFixing") 
                                               [| _Tibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_forwardingTermStructure", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Tibor.source + ".ForwardingTermStructure") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Tibor> format
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
    [<ExcelFunction(Name="_Tibor_maturityDate", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".MaturityDate") 
                                               [| _Tibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_currency", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Tibor.source + ".Currency") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Tibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Tibor_dayCounter", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Tibor.source + ".DayCounter") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Tibor> format
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
    [<ExcelFunction(Name="_Tibor_familyName", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".FamilyName") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_fixing", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Tibor.source + ".Fixing") 
                                               [| _Tibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_fixingCalendar", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Tibor.source + ".FixingCalendar") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Tibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Tibor_fixingDate", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".FixingDate") 
                                               [| _Tibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_fixingDays", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Tibor.source + ".FixingDays") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_isValidFixingDate", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".IsValidFixingDate") 
                                               [| _Tibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_name", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".Name") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_pastFixing", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".PastFixing") 
                                               [| _Tibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_tenor", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Tibor.source + ".Tenor") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Tibor> format
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
    [<ExcelFunction(Name="_Tibor_update", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).Update
                                                       ) :> ICell
                let format (o : Tibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".Update") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_valueDate", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".ValueDate") 
                                               [| _Tibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_addFixing", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Tibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".AddFixing") 
                                               [| _Tibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_addFixings", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Tibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".AddFixings") 
                                               [| _Tibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_addFixings1", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Tibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".AddFixings1") 
                                               [| _Tibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_allowsNativeFixings", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".AllowsNativeFixings") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_clearFixings", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : Tibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".ClearFixings") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_registerWith", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Tibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".RegisterWith") 
                                               [| _Tibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_timeSeries", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".TimeSeries") 
                                               [| _Tibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_unregisterWith", Description="Create a Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Tibor",Description = "Reference to Tibor")>] 
         tibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Tibor = Helper.toCell<Tibor> tibor "Tibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((TiborModel.Cast _Tibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Tibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Tibor.source + ".UnregisterWith") 
                                               [| _Tibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Tibor.cell
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
    [<ExcelFunction(Name="_Tibor_Range", Description="Create a range of Tibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Tibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Tibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Tibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Tibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Tibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Tibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
