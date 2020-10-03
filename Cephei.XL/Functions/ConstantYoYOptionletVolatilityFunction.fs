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
  Constant surface, no K or T dependence.
  </summary> *)
[<AutoSerializable(true)>]
module ConstantYoYOptionletVolatilityFunction =

    (*
        Constructor ! calculate the reference date based on the global evaluation date
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "Reference to indexIsInterpolated")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="minStrike",Description = "Reference to minStrike")>] 
         minStrike : obj)
        ([<ExcelArgument(Name="maxStrike",Description = "Reference to maxStrike")>] 
         maxStrike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _v = Helper.toCell<double> v "v" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" 
                let _minStrike = Helper.toDefault<double> minStrike "minStrike" -1.0
                let _maxStrike = Helper.toDefault<double> maxStrike "maxStrike" 100.0
                let builder () = withMnemonic mnemonic (Fun.ConstantYoYOptionletVolatility 
                                                            _v.cell 
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _dc.cell 
                                                            _observationLag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _minStrike.cell 
                                                            _maxStrike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantYoYOptionletVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantYoYOptionletVolatility" 
                                               [| _v.source
                                               ;  _settlementDays.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _dc.source
                                               ;  _observationLag.source
                                               ;  _frequency.source
                                               ;  _indexIsInterpolated.source
                                               ;  _minStrike.source
                                               ;  _maxStrike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _v.cell
                                ;  _settlementDays.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _dc.cell
                                ;  _observationLag.cell
                                ;  _frequency.cell
                                ;  _indexIsInterpolated.cell
                                ;  _minStrike.cell
                                ;  _maxStrike.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantYoYOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Limits
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_maxDate", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".MaxDate") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
        ! the maximum strike for which the term structure can return vols
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_maxStrike", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".MaxStrike") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
        ! the minimum strike for which the term structure can return vols
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_minStrike", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".MinStrike") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_baseDate", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".BaseDate") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
        acts as zero time value for boostrapping
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_baseLevel", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_baseLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).BaseLevel
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".BaseLevel") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_frequency", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Frequency") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_indexIsInterpolated", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".IndexIsInterpolated") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
        ! The TS observes with a lag that is usually different from the ! availability lag of the index.  An inflation rate is given, ! by default, for the maturity requested assuming this lag.
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_observationLag", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".ObservationLag") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantYoYOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! needed for total variance calculations
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_timeFromBase", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_timeFromBase
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="obsLag",Description = "Reference to obsLag")>] 
         obsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _obsLag = Helper.toCell<Period> obsLag "obsLag" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).TimeFromBase
                                                            _maturityDate.cell 
                                                            _obsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".TimeFromBase") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _maturityDate.source
                                               ;  _obsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _maturityDate.cell
                                ;  _obsLag.cell
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
        ! base date will be in the past because of observation lag
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_timeFromBase1", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_timeFromBase1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).TimeFromBase1
                                                            _maturityDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".TimeFromBase") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _maturityDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _maturityDate.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_totalVariance", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_totalVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="obsLag",Description = "Reference to obsLag")>] 
         obsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _obsLag = Helper.toCell<Period> obsLag "obsLag" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).TotalVariance
                                                            _maturityDate.cell 
                                                            _strike.cell 
                                                            _obsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".TotalVariance") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _maturityDate.source
                                               ;  _strike.source
                                               ;  _obsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _maturityDate.cell
                                ;  _strike.cell
                                ;  _obsLag.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_totalVariance4", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_totalVariance4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="obsLag",Description = "Reference to obsLag")>] 
         obsLag : obj)
        ([<ExcelArgument(Name="extrap",Description = "Reference to extrap")>] 
         extrap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _obsLag = Helper.toCell<Period> obsLag "obsLag" 
                let _extrap = Helper.toCell<bool> extrap "extrap" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).TotalVariance4
                                                            _tenor.cell 
                                                            _strike.cell 
                                                            _obsLag.cell 
                                                            _extrap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".TotalVariance4") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _tenor.source
                                               ;  _strike.source
                                               ;  _obsLag.source
                                               ;  _extrap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _tenor.cell
                                ;  _strike.cell
                                ;  _obsLag.cell
                                ;  _extrap.cell
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
        ! Total integrated variance is useful because it scales out t for the optionlet pricing formulae.  Note that it is called "total" because the surface does not know whether it represents Black, Bachelier or Displaced Diffusion variance.  These are virtual so alternate connections between const vol and total var are possible.  Because inflation is highly linked to dates (for interpolation, periods, etc) we do NOT provide a time version
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_totalVariance5", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_totalVariance5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).TotalVariance5
                                                            _maturityDate.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".TotalVariance5") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _maturityDate.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _maturityDate.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_totalVariance2", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_totalVariance2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).TotalVariance2
                                                            _tenor.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".TotalVariance2") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _tenor.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _tenor.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_totalVariance3", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_totalVariance3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="obsLag",Description = "Reference to obsLag")>] 
         obsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _obsLag = Helper.toCell<Period> obsLag "obsLag" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).TotalVariance3
                                                            _tenor.cell 
                                                            _strike.cell 
                                                            _obsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".TotalVariance3") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _tenor.source
                                               ;  _strike.source
                                               ;  _obsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _tenor.cell
                                ;  _strike.cell
                                ;  _obsLag.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_totalVariance1", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_totalVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="obsLag",Description = "Reference to obsLag")>] 
         obsLag : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _obsLag = Helper.toCell<Period> obsLag "obsLag" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).TotalVariance1
                                                            _maturityDate.cell 
                                                            _strike.cell 
                                                            _obsLag.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".TotalVariance1") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _maturityDate.source
                                               ;  _strike.source
                                               ;  _obsLag.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _maturityDate.cell
                                ;  _strike.cell
                                ;  _obsLag.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_volatility2", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="obsLag",Description = "Reference to obsLag")>] 
         obsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _obsLag = Helper.toCell<Period> obsLag "obsLag" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Volatility2
                                                            _maturityDate.cell 
                                                            _strike.cell 
                                                            _obsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Volatility2") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _maturityDate.source
                                               ;  _strike.source
                                               ;  _obsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _maturityDate.cell
                                ;  _strike.cell
                                ;  _obsLag.cell
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
        Volatility (only) ! Returns the volatility for a given maturity date and strike rate ! that observes inflation, by default, with the observation lag ! of the term structure. ! Because inflation is highly linked to dates (for interpolation, periods, etc) ! we do NOT provide a time version.
    *)
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_volatility4", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_volatility4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Volatility4
                                                            _maturityDate.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Volatility4") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _maturityDate.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _maturityDate.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_volatility", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="obsLag",Description = "Reference to obsLag")>] 
         obsLag : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _obsLag = Helper.toCell<Period> obsLag "obsLag" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Volatility
                                                            _maturityDate.cell 
                                                            _strike.cell 
                                                            _obsLag.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Volatility") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _maturityDate.source
                                               ;  _strike.source
                                               ;  _obsLag.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _maturityDate.cell
                                ;  _strike.cell
                                ;  _obsLag.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_volatility5", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_volatility5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Volatility5
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Volatility5") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _optionTenor.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _optionTenor.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_volatility1", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="obsLag",Description = "Reference to obsLag")>] 
         obsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _obsLag = Helper.toCell<Period> obsLag "obsLag" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Volatility1
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _obsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Volatility1") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _optionTenor.source
                                               ;  _strike.source
                                               ;  _obsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _optionTenor.cell
                                ;  _strike.cell
                                ;  _obsLag.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_volatility3", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_volatility3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="obsLag",Description = "Reference to obsLag")>] 
         obsLag : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _obsLag = Helper.toCell<Period> obsLag "obsLag" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Volatility3
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _obsLag.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Volatility3") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _optionTenor.source
                                               ;  _strike.source
                                               ;  _obsLag.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                ;  _optionTenor.cell
                                ;  _strike.cell
                                ;  _obsLag.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_businessDayConvention", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".BusinessDayConvention") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_optionDateFromTenor", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _p = Helper.toCell<Period> p "p" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".OptionDateFromTenor") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_calendar", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Calendar") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantYoYOptionletVolatility> format
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_dayCounter", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".DayCounter") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantYoYOptionletVolatility> format
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_maxTime", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".MaxTime") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_referenceDate", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".ReferenceDate") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_settlementDays", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".SettlementDays") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_timeFromReference", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".TimeFromReference") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_update", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Update
                                                       ) :> ICell
                let format (o : ConstantYoYOptionletVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Update") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_allowsExtrapolation", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".AllowsExtrapolation") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_disableExtrapolation", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantYoYOptionletVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".DisableExtrapolation") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_enableExtrapolation", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantYoYOptionletVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".EnableExtrapolation") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_extrapolate", Description="Create a ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantYoYOptionletVolatility",Description = "Reference to ConstantYoYOptionletVolatility")>] 
         constantyoyoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantYoYOptionletVolatility = Helper.toCell<ConstantYoYOptionletVolatility> constantyoyoptionletvolatility "ConstantYoYOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((_ConstantYoYOptionletVolatility.cell :?> ConstantYoYOptionletVolatilityModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantYoYOptionletVolatility.source + ".Extrapolate") 
                                               [| _ConstantYoYOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantYoYOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantYoYOptionletVolatility_Range", Description="Create a range of ConstantYoYOptionletVolatility",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConstantYoYOptionletVolatility_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConstantYoYOptionletVolatility")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConstantYoYOptionletVolatility> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConstantYoYOptionletVolatility>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConstantYoYOptionletVolatility>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConstantYoYOptionletVolatility>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
