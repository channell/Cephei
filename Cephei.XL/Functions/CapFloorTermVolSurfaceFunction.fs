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

  </summary> *)
[<AutoSerializable(true)>]
module CapFloorTermVolSurfaceFunction =

    (*
        ! floating reference date, fixed market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface3", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_create3
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
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" true
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let _vols = Helper.toCell<Matrix> vols "vols" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let builder () = withMnemonic mnemonic (Fun.CapFloorTermVolSurface3
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _strikes.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source = Helper.sourceFold "Fun.CapFloorTermVolSurface3" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _strikes.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _strikes.cell
                                ;  _vols.cell
                                ;  _dc.cell
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
        ! fixed reference date, fixed market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_create
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
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDate = Helper.toCell<Date> settlementDate "settlementDate" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" true
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let _vols = Helper.toCell<Matrix> vols "vols" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let builder () = withMnemonic mnemonic (Fun.CapFloorTermVolSurface
                                                            _settlementDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _strikes.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source = Helper.sourceFold "Fun.CapFloorTermVolSurface" 
                                               [| _settlementDate.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _strikes.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDate.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _strikes.cell
                                ;  _vols.cell
                                ;  _dc.cell
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
        ! fixed reference date, floating market data
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface1", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_create1
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
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDate = Helper.toCell<Date> settlementDate "settlementDate" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" true
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let _vols = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> vols "vols" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let builder () = withMnemonic mnemonic (Fun.CapFloorTermVolSurface1
                                                            _settlementDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _strikes.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source = Helper.sourceFold "Fun.CapFloorTermVolSurface1" 
                                               [| _settlementDate.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _strikes.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDate.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _strikes.cell
                                ;  _vols.cell
                                ;  _dc.cell
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
        ! floating reference date, floating market data
    *)
    (*!!vol
    [<ExcelFunction(Name="_CapFloorTermVolSurface3", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_create3
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
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" true
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" true
                let _vols = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> vols "vols" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let builder () = withMnemonic mnemonic (Fun.CapFloorTermVolSurface3 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _strikes.cell 
                                                            _vols.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source = Helper.sourceFold "Fun.CapFloorTermVolSurface3" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _strikes.source
                                               ;  _vols.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _strikes.cell
                                ;  _vols.cell
                                ;  _dc.cell
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
            *)
    (*
        TermStructure interface
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_maxDate", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".MaxDate") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_maxStrike", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".MaxStrike") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_minStrike", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".MinStrike") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_optionDates", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_optionDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).OptionDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".OptionDates") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_optionTenors", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_optionTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).OptionTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".OptionTenors") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_optionTimes", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_optionTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).OptionTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".OptionTimes") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_strikes", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_strikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).Strikes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Strikes") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_update", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).Update
                                                       ) :> ICell
                let format (o : CapFloorTermVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Update") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_volatility", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="length",Description = "Reference to length")>] 
         length : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let _length = Helper.toCell<Period> length "length" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).Volatility
                                                            _length.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Volatility") 
                                               [| _CapFloorTermVolSurface.source
                                               ;  _length.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_volatility1", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let _t = Helper.toCell<double> t "t" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).Volatility1
                                                            _t.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Volatility1") 
                                               [| _CapFloorTermVolSurface.source
                                               ;  _t.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_volatility2", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let _End = Helper.toCell<Date> End "End" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).Volatility2
                                                            _End.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Volatility2") 
                                               [| _CapFloorTermVolSurface.source
                                               ;  _End.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_businessDayConvention", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".BusinessDayConvention") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_optionDateFromTenor", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let _p = Helper.toCell<Period> p "p" true
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".OptionDateFromTenor") 
                                               [| _CapFloorTermVolSurface.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_calendar", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Calendar") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        ! the day counter used for date/time conversion
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_dayCounter", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".DayCounter") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_CapFloorTermVolSurface_maxTime", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".MaxTime") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_referenceDate", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".ReferenceDate") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_settlementDays", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".SettlementDays") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_timeFromReference", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".TimeFromReference") 
                                               [| _CapFloorTermVolSurface.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_allowsExtrapolation", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".AllowsExtrapolation") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_disableExtrapolation", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapFloorTermVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".DisableExtrapolation") 
                                               [| _CapFloorTermVolSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_enableExtrapolation", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapFloorTermVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".EnableExtrapolation") 
                                               [| _CapFloorTermVolSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_extrapolate", Description="Create a CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapFloorTermVolSurface",Description = "Reference to CapFloorTermVolSurface")>] 
         capfloortermvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapFloorTermVolSurface = Helper.toCell<CapFloorTermVolSurface> capfloortermvolsurface "CapFloorTermVolSurface" true 
                let builder () = withMnemonic mnemonic ((_CapFloorTermVolSurface.cell :?> CapFloorTermVolSurfaceModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CapFloorTermVolSurface.source + ".Extrapolate") 
                                               [| _CapFloorTermVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapFloorTermVolSurface.cell
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
    [<ExcelFunction(Name="_CapFloorTermVolSurface_Range", Description="Create a range of CapFloorTermVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CapFloorTermVolSurface_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CapFloorTermVolSurface")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CapFloorTermVolSurface> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CapFloorTermVolSurface>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CapFloorTermVolSurface>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CapFloorTermVolSurface>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
