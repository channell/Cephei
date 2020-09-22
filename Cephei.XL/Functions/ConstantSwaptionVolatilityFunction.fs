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
  Constant swaption volatility, no time-strike dependence
  </summary> *)
[<AutoSerializable(true)>]
module ConstantSwaptionVolatilityFunction =

    (*
        ! fixed reference date, fixed market data
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _vol = Helper.toCell<double> vol "vol" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _shift = Helper.toNullable<double> shift "shift"
                let builder () = withMnemonic mnemonic (Fun.ConstantSwaptionVolatility 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantSwaptionVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantSwaptionVolatility" 
                                               [| _referenceDate.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _Type.cell
                                ;  _shift.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility3", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _vol = Helper.toCell<double> vol "vol" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _shift = Helper.toNullable<double> shift "shift"
                let builder () = withMnemonic mnemonic (Fun.ConstantSwaptionVolatility3 
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantSwaptionVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantSwaptionVolatility3" 
                                               [| _settlementDays.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _Type.cell
                                ;  _shift.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility2", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _shift = Helper.toNullable<double> shift "shift"
                let builder () = withMnemonic mnemonic (Fun.ConstantSwaptionVolatility2 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantSwaptionVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantSwaptionVolatility2" 
                                               [| _referenceDate.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _Type.cell
                                ;  _shift.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility1", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" true
                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _Type = Helper.toCell<VolatilityType> Type "Type" true
                let _shift = Helper.toNullable<double> shift "shift"
                let builder () = withMnemonic mnemonic (Fun.ConstantSwaptionVolatility1 
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                            _Type.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantSwaptionVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantSwaptionVolatility1" 
                                               [| _settlementDays.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               ;  _Type.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                ;  _Type.cell
                                ;  _shift.cell
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
        TermStructure interface
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_maxDate", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".MaxDate") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_maxStrike", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".MaxStrike") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
        SwaptionVolatilityStructure interface
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_maxSwapTenor", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_maxSwapTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).MaxSwapTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".MaxSwapTenor") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_minStrike", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".MinStrike") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_volatilityType", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".VolatilityType") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
        ! returns the Black variance for a given option time and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_blackVariance4", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_blackVariance4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).BlackVariance4
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".BlackVariance4") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
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
        ! returns the Black variance for a given option date and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_blackVariance5", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_blackVariance5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).BlackVariance5
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".BlackVariance5") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
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
        ! returns the Black variance for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_blackVariance3", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_blackVariance3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).BlackVariance3
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".BlackVariance3") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
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
        ! returns the Black variance for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_blackVariance2", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_blackVariance2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).BlackVariance2
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".BlackVariance2") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
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
        ! returns the Black variance for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_blackVariance1", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_blackVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).BlackVariance1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".BlackVariance1") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
        ! returns the Black variance for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_blackVariance", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).BlackVariance
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".BlackVariance") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        ! the largest swapLength for which the term structure can return vols
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_maxSwapLength", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_maxSwapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).MaxSwapLength
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".MaxSwapLength") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
        ! returns the shift for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_shift4", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_shift4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Shift4
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Shift4") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
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
        ! returns the shift for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_shift5", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_shift5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Shift5
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Shift5") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
        ! returns the shift for a given option date and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_shift1", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_shift1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Shift1
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Shift1") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
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
        ! returns the shift for a given option time and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_shift", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Shift
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Shift") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
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
        ! returns the shift for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_shift2", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_shift2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Shift2
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Shift2") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        ! returns the shift for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_shift3", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_shift3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Shift3
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Shift3") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
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
        ! returns the smile for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_smileSection1", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_smileSection1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extr = Helper.toCell<bool> extr "extr" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).SmileSection1
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".SmileSection1") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
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
        ! returns the smile for a given option time and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_smileSection2", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_smileSection2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _extr = Helper.toCell<bool> extr "extr" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).SmileSection2
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".SmileSection2") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _extr.cell
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
        ! returns the smile for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_smileSection", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _extr = Helper.toCell<bool> extr "extr" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).SmileSection
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".SmileSection") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
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
        ! implements the conversion between swap dates and swap (time) length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_swapLength", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_swapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="start",Description = "Reference to start")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _start = Helper.toCell<Date> start "start" true
                let _End = Helper.toCell<Date> End "End" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).SwapLength
                                                            _start.cell 
                                                            _End.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".SwapLength") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _start.source
                                               ;  _End.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _start.cell
                                ;  _End.cell
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
        ! implements the conversion between swap tenor and swap (time) length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_swapLength1", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_swapLength1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).SwapLength1
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".SwapLength1") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_volatility4", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_volatility4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Volatility4
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Volatility4") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option date and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_volatility2", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Volatility2
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Volatility2") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
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
        ! returns the volatility for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_volatility5", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_volatility5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Volatility5
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Volatility5") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_volatility1", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Volatility1
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Volatility1") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
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
        ! returns the volatility for a given option time and swap length
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_volatility3", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_volatility3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapLength = Helper.toCell<double> swapLength "swapLength" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Volatility3
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Volatility") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
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
        ! returns the volatility for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_volatility", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _optionTime = Helper.toCell<double> optionTime "optionTime" true
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Volatility
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Volatility") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_businessDayConvention", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".BusinessDayConvention") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_optionDateFromTenor", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _p = Helper.toCell<Period> p "p" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".OptionDateFromTenor") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_calendar", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Calendar") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_dayCounter", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".DayCounter") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_maxTime", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".MaxTime") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_referenceDate", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".ReferenceDate") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_settlementDays", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".SettlementDays") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_timeFromReference", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".TimeFromReference") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_update", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Update
                                                       ) :> ICell
                let format (o : ConstantSwaptionVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Update") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_allowsExtrapolation", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".AllowsExtrapolation") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_disableExtrapolation", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantSwaptionVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".DisableExtrapolation") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_enableExtrapolation", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantSwaptionVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".EnableExtrapolation") 
                                               [| _ConstantSwaptionVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_extrapolate", Description="Create a ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantSwaptionVolatility",Description = "Reference to ConstantSwaptionVolatility")>] 
         constantswaptionvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantSwaptionVolatility = Helper.toCell<ConstantSwaptionVolatility> constantswaptionvolatility "ConstantSwaptionVolatility" true 
                let builder () = withMnemonic mnemonic ((_ConstantSwaptionVolatility.cell :?> ConstantSwaptionVolatilityModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantSwaptionVolatility.source + ".Extrapolate") 
                                               [| _ConstantSwaptionVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantSwaptionVolatility.cell
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
    [<ExcelFunction(Name="_ConstantSwaptionVolatility_Range", Description="Create a range of ConstantSwaptionVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantSwaptionVolatility_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConstantSwaptionVolatility")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConstantSwaptionVolatility> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConstantSwaptionVolatility>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConstantSwaptionVolatility>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConstantSwaptionVolatility>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
