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
    [<ExcelFunction(Name="_CapFloorTermVolCurve1", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
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
                let builder () = withMnemonic mnemonic (Fun.CapFloorTermVolCurve1 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolCurve>) l

                let source = Helper.sourceFold "Fun.CapFloorTermVolCurve1" 
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve3", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDate",Description = "Reference to settlementDate")>] 
         settlementDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
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
                let builder () = withMnemonic mnemonic (Fun.CapFloorTermVolCurve3
                                                            _settlementDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolCurve>) l

                let source = Helper.sourceFold "Fun.CapFloorTermVolCurve3" 
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve2", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDate",Description = "Reference to settlementDate")>] 
         settlementDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
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
                let builder () = withMnemonic mnemonic (Fun.CapFloorTermVolCurve2 
                                                            _settlementDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolCurve>) l

                let source = Helper.sourceFold "Fun.CapFloorTermVolCurve2" 
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
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
                let builder () = withMnemonic mnemonic (Fun.CapFloorTermVolCurve
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolCurve>) l

                let source = Helper.sourceFold "Fun.CapFloorTermVolCurve" 
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_maxDate", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".MaxDate") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_maxStrike", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".MaxStrike") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_minStrike", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".MinStrike") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_optionDates", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_optionDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).OptionDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".OptionDates") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        some inspectors
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_optionTenors", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_optionTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).OptionTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".OptionTenors") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_optionTimes", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_optionTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).OptionTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".OptionTimes") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        LazyObject interface
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_update", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).Update
                                                       ) :> ICell
                let format (o : CapFloorTermVolCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Update") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        ! returns the volatility for a given cap/floor length and strike rate
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_volatility", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="length",Description = "Reference to length")>] 
         length : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _length = Helper.toCell<Period> length "length" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).Volatility
                                                            _length.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Volatility") 
                                               [| _CapFloorTermVolCurve.source
                                               ;  _length.source
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
        ! returns the volatility for a given end time and strike rate
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_volatility1", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).Volatility1
                                                            _t.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Volatility1") 
                                               [| _CapFloorTermVolCurve.source
                                               ;  _t.source
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_volatility2", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _End = Helper.toCell<Date> End "End" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).Volatility2
                                                            _End.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Volatility2") 
                                               [| _CapFloorTermVolCurve.source
                                               ;  _End.source
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_businessDayConvention", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".BusinessDayConvention") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_optionDateFromTenor", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _p = Helper.toCell<Period> p "p" 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".OptionDateFromTenor") 
                                               [| _CapFloorTermVolCurve.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                ;  _p.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_CapFloorTermVolCurve_calendar", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Calendar") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_dayCounter", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".DayCounter") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_maxTime", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".MaxTime") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_referenceDate", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".ReferenceDate") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_settlementDays", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".SettlementDays") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_timeFromReference", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".TimeFromReference") 
                                               [| _CapFloorTermVolCurve.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_allowsExtrapolation", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".AllowsExtrapolation") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_disableExtrapolation", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapFloorTermVolCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".DisableExtrapolation") 
                                               [| _CapFloorTermVolCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_enableExtrapolation", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapFloorTermVolCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".EnableExtrapolation") 
                                               [| _CapFloorTermVolCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_extrapolate", Description="Create a CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolCurve",Description = "Reference to CapFloorTermVolCurve")>] 
         capfloortermvolcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolCurve = Helper.toCell<CapFloorTermVolCurve> capfloortermvolcurve "CapFloorTermVolCurve"  
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolCurve.cell :?> CapFloorTermVolCurveModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolCurve.source + ".Extrapolate") 
                                               [| _CapFloorTermVolCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolCurve.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolCurve_Range", Description="Create a range of CapFloorTermVolCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CapFloorTermVolCurve")>] 
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
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CapFloorTermVolCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CapFloorTermVolCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
