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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility1", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="volatility",Description = "double")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _volatility = Helper.toCell<double> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantCapFloorTermVolatility1 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantCapFloorTermVolatility>) l

                let source () = Helper.sourceFold "Fun.ConstantCapFloorTermVolatility1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantCapFloorTermVolatility> format
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility2", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="volatility",Description = "double")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _volatility = Helper.toCell<double> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantCapFloorTermVolatility2
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantCapFloorTermVolatility>) l

                let source () = Helper.sourceFold "Fun.ConstantCapFloorTermVolatility2" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantCapFloorTermVolatility> format
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility3", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantCapFloorTermVolatility3 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantCapFloorTermVolatility>) l

                let source () = Helper.sourceFold "Fun.ConstantCapFloorTermVolatility3" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantCapFloorTermVolatility> format
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bdc : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantCapFloorTermVolatility
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantCapFloorTermVolatility>) l

                let source () = Helper.sourceFold "Fun.ConstantCapFloorTermVolatility" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantCapFloorTermVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_maxDate", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_maxStrike", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_minStrike", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_volatility", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="length",Description = "Period")>] 
         length : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let _length = Helper.toCell<Period> length "length" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).Volatility
                                                            _length.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Volatility") 

                                               [| _length.source
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_volatility1", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let _t = Helper.toCell<double> t "t" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).Volatility1
                                                            _t.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Volatility1") 

                                               [| _t.source
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_volatility2", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="End",Description = "Date")>] 
         End : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let _End = Helper.toCell<Date> End "End" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).Volatility2
                                                            _End.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Volatility2") 

                                               [| _End.source
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_businessDayConvention", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_optionDateFromTenor", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".OptionDateFromTenor") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_calendar", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantCapFloorTermVolatility> format
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_dayCounter", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantCapFloorTermVolatility> format
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_maxTime", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_referenceDate", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_settlementDays", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_timeFromReference", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_update", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).Update
                                                       ) :> ICell
                let format (o : ConstantCapFloorTermVolatility) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_allowsExtrapolation", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_disableExtrapolation", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantCapFloorTermVolatility) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_enableExtrapolation", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantCapFloorTermVolatility) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_extrapolate", Description="Create a ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantCapFloorTermVolatility",Description = "ConstantCapFloorTermVolatility")>] 
         constantcapfloortermvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantCapFloorTermVolatility = Helper.toCell<ConstantCapFloorTermVolatility> constantcapfloortermvolatility "ConstantCapFloorTermVolatility"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantCapFloorTermVolatilityModel.Cast _ConstantCapFloorTermVolatility.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConstantCapFloorTermVolatility.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantCapFloorTermVolatility.cell
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
    [<ExcelFunction(Name="_ConstantCapFloorTermVolatility_Range", Description="Create a range of ConstantCapFloorTermVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantCapFloorTermVolatility_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConstantCapFloorTermVolatility> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ConstantCapFloorTermVolatility> (c)) :> ICell
                let format (i : Generic.List<ICell<ConstantCapFloorTermVolatility>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ConstantCapFloorTermVolatility>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
