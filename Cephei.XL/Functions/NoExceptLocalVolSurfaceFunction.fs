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
module NoExceptLocalVolSurfaceFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NoExceptLocalVolSurface", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_create
        ([<ExcelArgument(Name="Mnemonic",Description = "NoExceptLocalVolSurface")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="blackTS",Description = "BlackVolTermStructure")>] 
         blackTS : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "YieldTermStructure")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="dividendTS",Description = "YieldTermStructure")>] 
         dividendTS : obj)
        ([<ExcelArgument(Name="underlying",Description = "double")>] 
         underlying : obj)
        ([<ExcelArgument(Name="illegalLocalVolOverwrite",Description = "double")>] 
         illegalLocalVolOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _blackTS = Helper.toHandle<BlackVolTermStructure> blackTS "blackTS" 
                let _riskFreeTS = Helper.toHandle<YieldTermStructure> riskFreeTS "riskFreeTS" 
                let _dividendTS = Helper.toHandle<YieldTermStructure> dividendTS "dividendTS" 
                let _underlying = Helper.toCell<double> underlying "underlying" 
                let _illegalLocalVolOverwrite = Helper.toCell<double> illegalLocalVolOverwrite "illegalLocalVolOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.NoExceptLocalVolSurface 
                                                            _blackTS.cell 
                                                            _riskFreeTS.cell 
                                                            _dividendTS.cell 
                                                            _underlying.cell 
                                                            _illegalLocalVolOverwrite.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NoExceptLocalVolSurface>) l

                let source () = Helper.sourceFold "Fun.NoExceptLocalVolSurface" 
                                               [| _blackTS.source
                                               ;  _riskFreeTS.source
                                               ;  _dividendTS.source
                                               ;  _underlying.source
                                               ;  _illegalLocalVolOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _blackTS.cell
                                ;  _riskFreeTS.cell
                                ;  _dividendTS.cell
                                ;  _underlying.cell
                                ;  _illegalLocalVolOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoExceptLocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NoExceptLocalVolSurface1", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "NoExceptLocalVolSurface")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="blackTS",Description = "BlackVolTermStructure")>] 
         blackTS : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "YieldTermStructure")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="dividendTS",Description = "YieldTermStructure")>] 
         dividendTS : obj)
        ([<ExcelArgument(Name="underlying",Description = "Quote")>] 
         underlying : obj)
        ([<ExcelArgument(Name="illegalLocalVolOverwrite",Description = "double")>] 
         illegalLocalVolOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _blackTS = Helper.toHandle<BlackVolTermStructure> blackTS "blackTS" 
                let _riskFreeTS = Helper.toHandle<YieldTermStructure> riskFreeTS "riskFreeTS" 
                let _dividendTS = Helper.toHandle<YieldTermStructure> dividendTS "dividendTS" 
                let _underlying = Helper.toHandle<Quote> underlying "underlying" 
                let _illegalLocalVolOverwrite = Helper.toCell<double> illegalLocalVolOverwrite "illegalLocalVolOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.NoExceptLocalVolSurface1 
                                                            _blackTS.cell 
                                                            _riskFreeTS.cell 
                                                            _dividendTS.cell 
                                                            _underlying.cell 
                                                            _illegalLocalVolOverwrite.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NoExceptLocalVolSurface>) l

                let source () = Helper.sourceFold "Fun.NoExceptLocalVolSurface1" 
                                               [| _blackTS.source
                                               ;  _riskFreeTS.source
                                               ;  _dividendTS.source
                                               ;  _underlying.source
                                               ;  _illegalLocalVolOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _blackTS.cell
                                ;  _riskFreeTS.cell
                                ;  _dividendTS.cell
                                ;  _underlying.cell
                                ;  _illegalLocalVolOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoExceptLocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_dayCounter", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoExceptLocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_maxDate", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_maxStrike", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_minStrike", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
        TermStructure interface
    *)
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_referenceDate", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_localVol", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_localVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "double")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let _t = Helper.toCell<double> t "t" 
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).LocalVol
                                                            _t.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".LocalVol") 

                                               [| _t.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
                                ;  _t.cell
                                ;  _underlyingLevel.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_localVol1", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_localVol1
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "double")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let _d = Helper.toCell<Date> d "d" 
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).LocalVol1
                                                            _d.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".LocalVol1") 

                                               [| _d.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
                                ;  _d.cell
                                ;  _underlyingLevel.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_businessDayConvention", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_optionDateFromTenor", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".OptionDateFromTenor") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_calendar", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoExceptLocalVolSurface> format
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_maxTime", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_settlementDays", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_timeFromReference", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_update", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).Update
                                                       ) :> ICell
                let format (o : NoExceptLocalVolSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_allowsExtrapolation", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_disableExtrapolation", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : NoExceptLocalVolSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_enableExtrapolation", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : NoExceptLocalVolSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_extrapolate", Description="Create a NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoExceptLocalVolSurface",Description = "NoExceptLocalVolSurface")>] 
         noexceptlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoExceptLocalVolSurface = Helper.toCell<NoExceptLocalVolSurface> noexceptlocalvolsurface "NoExceptLocalVolSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoExceptLocalVolSurfaceModel.Cast _NoExceptLocalVolSurface.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NoExceptLocalVolSurface.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NoExceptLocalVolSurface.cell
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
    [<ExcelFunction(Name="_NoExceptLocalVolSurface_Range", Description="Create a range of NoExceptLocalVolSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoExceptLocalVolSurface_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NoExceptLocalVolSurface> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NoExceptLocalVolSurface>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<NoExceptLocalVolSurface>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<NoExceptLocalVolSurface>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
