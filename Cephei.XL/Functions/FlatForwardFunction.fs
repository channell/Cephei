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
  Flat interest-rate curve
  </summary> *)
[<AutoSerializable(true)>]
module FlatForwardFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward4", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward4 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward4" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward10", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create10
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _forward = Helper.toCell<Quote> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward10
                                                            _referenceDate.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward10" 
                                               [| _referenceDate.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward9", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create9
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward9
                                                            _referenceDate.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward9" 
                                               [| _referenceDate.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward8", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create8
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward8
                                                            _referenceDate.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward8" 
                                               [| _referenceDate.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward7", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward7
                                                            _referenceDate.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward7" 
                                               [| _referenceDate.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward1", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _forward = Helper.toCell<Quote> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward1
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward1" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward11", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create11
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _forward = Helper.toCell<Quote> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward11 
                                                            _referenceDate.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward11" 
                                               [| _referenceDate.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward5", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _forward = Helper.toCell<Quote> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward5
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward5" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        constructors
    *)
    [<ExcelFunction(Name="_FlatForward", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _forward = Helper.toCell<Quote> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward
                                                            _referenceDate.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward" 
                                               [| _referenceDate.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward3", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward3 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward3" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward2", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward2
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward2" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward6", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_create6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _forward = Helper.toCell<Quote> forward "forward" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let builder () = withMnemonic mnemonic (Fun.FlatForward6 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _forward.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatForward>) l

                let source = Helper.sourceFold "Fun.FlatForward6" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _forward.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _forward.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        TermStructure interface
    *)
    [<ExcelFunction(Name="_FlatForward_maxDate", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".MaxDate") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
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
        ! The same day-counting rule used by the term structure should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_FlatForward_discount", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).Discount
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".Discount") 
                                               [| _FlatForward.source
                                               ;  _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _t.cell
                                ;  _extrapolate.cell
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
        These methods return the discount factor from a given date or time to the reference date.  In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_FlatForward_discount1", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_discount1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).Discount1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".Discount1") 
                                               [| _FlatForward.source
                                               ;  _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _d.cell
                                ;  _extrapolate.cell
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
        ! The resulting interest rate has the required day-counting rule. \warning dates are not adjusted for holidays
    *)
    [<ExcelFunction(Name="_FlatForward_forwardRate", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).ForwardRate
                                                            _d.cell 
                                                            _p.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FlatForward.source + ".ForwardRate") 
                                               [| _FlatForward.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the required day-counting rule.
    *)
    [<ExcelFunction(Name="_FlatForward_forwardRate1", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_forwardRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).ForwardRate1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FlatForward.source + ".ForwardRate1") 
                                               [| _FlatForward.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed times t1 and t2.
    *)
    [<ExcelFunction(Name="_FlatForward_forwardRate2", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_forwardRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).ForwardRate2
                                                            _t1.cell 
                                                            _t2.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FlatForward.source + ".ForwardRate2") 
                                               [| _FlatForward.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _t1.cell
                                ;  _t2.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward_jumpDates", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_jumpDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).JumpDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FlatForward.source + ".JumpDates") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward_jumpTimes", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_jumpTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).JumpTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FlatForward.source + ".JumpTimes") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatForward_update", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).Update
                                                       ) :> ICell
                let format (o : FlatForward) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".Update") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
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
        ! The resulting interest rate has the required daycounting rule.
    *)
    [<ExcelFunction(Name="_FlatForward_zeroRate1", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_zeroRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _d = Helper.toCell<Date> d "d" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).ZeroRate1
                                                            _d.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FlatForward.source + ".ZeroRate1") 
                                               [| _FlatForward.source
                                               ;  _d.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _d.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_FlatForward_zeroRate", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _t = Helper.toCell<double> t "t" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).ZeroRate
                                                            _t.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FlatForward.source + ".ZeroRate") 
                                               [| _FlatForward.source
                                               ;  _t.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _t.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_FlatForward_calendar", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_FlatForward.source + ".Calendar") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the day counter used for date/time conversion
    *)
    [<ExcelFunction(Name="_FlatForward_dayCounter", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_FlatForward.source + ".DayCounter") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatForward> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_FlatForward_maxTime", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".MaxTime") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_FlatForward_referenceDate", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".ReferenceDate") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_FlatForward_settlementDays", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".SettlementDays") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_FlatForward_timeFromReference", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".TimeFromReference") 
                                               [| _FlatForward.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _date.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_FlatForward_allowsExtrapolation", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".AllowsExtrapolation") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_FlatForward_disableExtrapolation", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FlatForward) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".DisableExtrapolation") 
                                               [| _FlatForward.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_FlatForward_enableExtrapolation", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FlatForward) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".EnableExtrapolation") 
                                               [| _FlatForward.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_FlatForward_extrapolate", Description="Create a FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatForward",Description = "Reference to FlatForward")>] 
         flatforward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatForward = Helper.toCell<FlatForward> flatforward "FlatForward"  
                let builder () = withMnemonic mnemonic ((_FlatForward.cell :?> FlatForwardModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FlatForward.source + ".Extrapolate") 
                                               [| _FlatForward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatForward.cell
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
    [<ExcelFunction(Name="_FlatForward_Range", Description="Create a range of FlatForward",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FlatForward_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FlatForward")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FlatForward> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FlatForward>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FlatForward>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FlatForward>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
