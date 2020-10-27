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
  This class provides the at-the-money volatility for a given cap/floor interpolating a volatility vector whose elements are the market volatilities of a set of caps/floors with given length.
  </summary> *)
[<AutoSerializable(true)>]
module CapFloorTermVolCurveFunction =

    (*
        ! floating reference date, fixed market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve1", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Period range")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "double range")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _vols = Helper.toCell<Generic.List<double>> vols "vols" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CapFloorTermVolCurve1 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolCurve>) l

                let source () = Helper.sourceFold "Fun.CapFloorTermVolCurve1" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _vols.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixed reference date, fixed market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve3", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDate",Description = "Date")>] 
         settlementDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Period range")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "double range")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDate = Helper.toCell<Date> settlementDate "settlementDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _vols = Helper.toCell<Generic.List<double>> vols "vols" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CapFloorTermVolCurve3
                                                            _settlementDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolCurve>) l

                let source () = Helper.sourceFold "Fun.CapFloorTermVolCurve3" 
                                               [| _settlementDate.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDate.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _vols.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixed reference date, floating market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve2", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDate",Description = "Date")>] 
         settlementDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Period range")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Quote range")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDate = Helper.toCell<Date> settlementDate "settlementDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _vols = Helper.toCell<Generic.List<Handle<Quote>>> vols "vols" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CapFloorTermVolCurve2 
                                                            _settlementDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolCurve>) l

                let source () = Helper.sourceFold "Fun.CapFloorTermVolCurve2" 
                                               [| _settlementDate.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDate.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _vols.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! floating reference date, floating market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Period range")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Quote range")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _vols = Helper.toCell<Generic.List<Handle<Quote>>> vols "vols" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CapFloorTermVolCurve
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolCurve>) l

                let source () = Helper.sourceFold "Fun.CapFloorTermVolCurve" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _vols.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolCurve> format
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_maxDate", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_maxStrike", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_minStrike", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_optionDates", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_optionDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).OptionDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".OptionDates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
        some inspectors
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_optionTenors", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_optionTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).OptionTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".OptionTenors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_optionTimes", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_optionTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).OptionTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".OptionTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
        LazyObject interface
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_update", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).Update
                                                       ) :> ICell
                let format (o : CapFloorTermVolCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        ! returns the volatility for a given cap/floor length and strike rate
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_volatility", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="length",Description = "Period")>] 
         length : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _length = Helper.toCell<Period> length "length" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).Volatility
                                                            _length.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Volatility") 

                                               [| _length.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                ;  _length.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given end time and strike rate
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_volatility1", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).Volatility1
                                                            _t.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Volatility1") 

                                               [| _t.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                ;  _t.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_volatility2", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="End",Description = "Date")>] 
         End : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _End = Helper.toCell<Date> End "End" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).Volatility2
                                                            _End.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Volatility2") 

                                               [| _End.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                ;  _End.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_businessDayConvention", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_optionDateFromTenor", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".OptionDateFromTenor") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                ;  _p.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_calendar", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolCurve> format
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_dayCounter", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapFloorTermVolCurve> format
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_maxTime", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_referenceDate", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_settlementDays", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_timeFromReference", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                ;  _date.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_allowsExtrapolation", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_disableExtrapolation", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapFloorTermVolCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_enableExtrapolation", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapFloorTermVolCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_extrapolate", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapFloorTermVolCurveModel.Cast _CapFloorTermVolCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_Range", Description="Create a range of CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CapFloorTermVolCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CapFloorTermVolCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CapFloorTermVolCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CapFloorTermVolCurve>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
