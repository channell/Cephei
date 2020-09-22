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
module ConstantCapFloorTermVolatilityFunction =

    (*
        fixed reference date, fixed market data
    *)
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _volatility = Helper.toCell<double> volatility "volatility" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let builder () = withMnemonic mnemonic (Fun.ConstantCapFloorTermVolatility 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantCapFloorTermVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantCapFloorTermVolatility" 
                                               [| _referenceDate.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _volatility.cell
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
        ! floating reference date, fixed market data
    *)
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility1", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _volatility = Helper.toCell<double> volatility "volatility" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let builder () = withMnemonic mnemonic (Fun.ConstantCapFloorTermVolatility1 
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantCapFloorTermVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantCapFloorTermVolatility1" 
                                               [| _settlementDays.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _volatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility2", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _volatility = Helper.toHandle<Handle<Quote>> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let builder () = withMnemonic mnemonic (Fun.ConstantCapFloorTermVolatility2 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantCapFloorTermVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantCapFloorTermVolatility2" 
                                               [| _referenceDate.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _volatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility3", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _volatility = Helper.toHandle<Handle<Quote>> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let builder () = withMnemonic mnemonic (Fun.ConstantCapFloorTermVolatility3 
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantCapFloorTermVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantCapFloorTermVolatility3" 
                                               [| _settlementDays.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _volatility.cell
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
        
    *)
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_maxDate", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".MaxDate") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_maxStrike", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".MaxStrike") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_minStrike", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".MinStrike") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_volatility", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="length",Description = "Reference to length")>] 
         length : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let _length = Helper.toCell<Period> length "length" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).Volatility
                                                            _length.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Volatility") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               ;  _length.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_volatility", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let _t = Helper.toCell<double> t "t" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).Volatility1
                                                            _t.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Volatility1") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               ;  _t.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_volatility", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let _End = Helper.toCell<Date> End "End" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).Volatility2
                                                            _End.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Volatility2") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               ;  _End.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_businessDayConvention", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".BusinessDayConvention") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_optionDateFromTenor", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let _p = Helper.toCell<Period> p "p" true
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".OptionDateFromTenor") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_calendar", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Calendar") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_dayCounter", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".DayCounter") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_maxTime", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".MaxTime") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_referenceDate", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".ReferenceDate") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_settlementDays", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".SettlementDays") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_timeFromReference", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".TimeFromReference") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_update", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).Update
                                                       ) :> ICell
                let format (o : ConstantCapFloorTermVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Update") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_allowsExtrapolation", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".AllowsExtrapolation") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_disableExtrapolation", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantCapFloorTermVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".DisableExtrapolation") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_enableExtrapolation", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantCapFloorTermVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".EnableExtrapolation") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_extrapolate", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "Reference to ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantCapFloorTermVolatility.cell :?> ConstantCapFloorTermVolatilityModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Extrapolate") 
                                               [| _ConstantCapFloorTermVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_Range", Description="Create a range of ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConstantCapFloorTermVolatility")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConstantCapFloorTermVolatility> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConstantCapFloorTermVolatility>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConstantCapFloorTermVolatility>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConstantCapFloorTermVolatility>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
