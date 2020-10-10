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
  9-months %EUR %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module EURLibor9MFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor9M", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EURLibor9M 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor9M>) l

                let source () = Helper.sourceFold "Fun.EURLibor9M" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor9M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor9M1", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.EURLibor9M1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor9M>) l

                let source () = Helper.sourceFold "Fun.EURLibor9M1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor9M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor9M_maturityDate", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".MaturityDate") 
                                               [| _EURLibor9M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_valueDate", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".ValueDate") 
                                               [| _EURLibor9M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_businessDayConvention", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".BusinessDayConvention") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_EURLibor9M_clone", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_EURLibor9M.source + ".Clone") 
                                               [| _EURLibor9M.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor9M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor9M_endOfMonth", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".EndOfMonth") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_forecastFixing1", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".ForecastFixing1") 
                                               [| _EURLibor9M.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_forecastFixing", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".ForecastFixing") 
                                               [| _EURLibor9M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_forwardingTermStructure", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_EURLibor9M.source + ".ForwardingTermStructure") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor9M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor9M_currency", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_EURLibor9M.source + ".Currency") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor9M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor9M_dayCounter", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_EURLibor9M.source + ".DayCounter") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor9M> format
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
    [<ExcelFunction(Name="_EURLibor9M_familyName", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".FamilyName") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_fixing", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".Fixing") 
                                               [| _EURLibor9M.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_fixingCalendar", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_EURLibor9M.source + ".FixingCalendar") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor9M> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor9M_fixingDate", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".FixingDate") 
                                               [| _EURLibor9M.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_fixingDays", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".FixingDays") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_isValidFixingDate", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".IsValidFixingDate") 
                                               [| _EURLibor9M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_name", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".Name") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_pastFixing", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".PastFixing") 
                                               [| _EURLibor9M.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_tenor", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_EURLibor9M.source + ".Tenor") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EURLibor9M> format
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
    [<ExcelFunction(Name="_EURLibor9M_update", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).Update
                                                       ) :> ICell
                let format (o : EURLibor9M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".Update") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_addFixing", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor9M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".AddFixing") 
                                               [| _EURLibor9M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_addFixings", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor9M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".AddFixings") 
                                               [| _EURLibor9M.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_addFixings1", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor9M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".AddFixings1") 
                                               [| _EURLibor9M.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_allowsNativeFixings", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".AllowsNativeFixings") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_clearFixings", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).ClearFixings
                                                       ) :> ICell
                let format (o : EURLibor9M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".ClearFixings") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_registerWith", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor9M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".RegisterWith") 
                                               [| _EURLibor9M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_timeSeries", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".TimeSeries") 
                                               [| _EURLibor9M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_unregisterWith", Description="Create a EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor9M",Description = "Reference to EURLibor9M")>] 
         eurlibor9m : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor9M = Helper.toCell<EURLibor9M> eurlibor9m "EURLibor9M"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((EURLibor9MModel.Cast _EURLibor9M.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor9M) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_EURLibor9M.source + ".UnregisterWith") 
                                               [| _EURLibor9M.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor9M.cell
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
    [<ExcelFunction(Name="_EURLibor9M_Range", Description="Create a range of EURLibor9M",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EURLibor9M_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURLibor9M")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLibor9M> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURLibor9M>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURLibor9M>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<EURLibor9M>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
