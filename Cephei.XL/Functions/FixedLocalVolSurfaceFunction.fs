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
module FixedLocalVolSurfaceFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FixedLocalVolSurface2", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="localVolMatrix",Description = "Reference to localVolMatrix")>] 
         localVolMatrix : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="lowerExtrapolation",Description = "Reference to lowerExtrapolation")>] 
         lowerExtrapolation : obj)
        ([<ExcelArgument(Name="upperExtrapolation",Description = "Reference to upperExtrapolation")>] 
         upperExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _localVolMatrix = Helper.toCell<Matrix> localVolMatrix "localVolMatrix" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _lowerExtrapolation = Helper.toDefault<FixedLocalVolSurface.Extrapolation> lowerExtrapolation "lowerExtrapolation" FixedLocalVolSurface.Extrapolation.ConstantExtrapolation
                let _upperExtrapolation = Helper.toDefault<FixedLocalVolSurface.Extrapolation> upperExtrapolation "upperExtrapolation" FixedLocalVolSurface.Extrapolation.ConstantExtrapolation
                let builder () = withMnemonic mnemonic (Fun.FixedLocalVolSurface2 
                                                            _referenceDate.cell 
                                                            _dates.cell 
                                                            _strikes.cell 
                                                            _localVolMatrix.cell 
                                                            _dayCounter.cell 
                                                            _lowerExtrapolation.cell 
                                                            _upperExtrapolation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedLocalVolSurface>) l

                let source = Helper.sourceFold "Fun.FixedLocalVolSurface2" 
                                               [| _referenceDate.source
                                               ;  _dates.source
                                               ;  _strikes.source
                                               ;  _localVolMatrix.source
                                               ;  _dayCounter.source
                                               ;  _lowerExtrapolation.source
                                               ;  _upperExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _dates.cell
                                ;  _strikes.cell
                                ;  _localVolMatrix.cell
                                ;  _dayCounter.cell
                                ;  _lowerExtrapolation.cell
                                ;  _upperExtrapolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedLocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedLocalVolSurface", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="times",Description = "Reference to times")>] 
         times : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="localVolMatrix",Description = "Reference to localVolMatrix")>] 
         localVolMatrix : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="lowerExtrapolation",Description = "Reference to lowerExtrapolation")>] 
         lowerExtrapolation : obj)
        ([<ExcelArgument(Name="upperExtrapolation",Description = "Reference to upperExtrapolation")>] 
         upperExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _times = Helper.toCell<Generic.List<double>> times "times" 
                let _strikes = Helper.toCell<Generic.List<Generic.List<double>>> strikes "strikes" 
                let _localVolMatrix = Helper.toCell<Matrix> localVolMatrix "localVolMatrix" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _lowerExtrapolation = Helper.toDefault<FixedLocalVolSurface.Extrapolation> lowerExtrapolation "lowerExtrapolation" FixedLocalVolSurface.Extrapolation.ConstantExtrapolation
                let _upperExtrapolation = Helper.toDefault<FixedLocalVolSurface.Extrapolation> upperExtrapolation "upperExtrapolation" FixedLocalVolSurface.Extrapolation.ConstantExtrapolation
                let builder () = withMnemonic mnemonic (Fun.FixedLocalVolSurface 
                                                            _referenceDate.cell 
                                                            _times.cell 
                                                            _strikes.cell 
                                                            _localVolMatrix.cell 
                                                            _dayCounter.cell 
                                                            _lowerExtrapolation.cell 
                                                            _upperExtrapolation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedLocalVolSurface>) l

                let source = Helper.sourceFold "Fun.FixedLocalVolSurface" 
                                               [| _referenceDate.source
                                               ;  _times.source
                                               ;  _strikes.source
                                               ;  _localVolMatrix.source
                                               ;  _dayCounter.source
                                               ;  _lowerExtrapolation.source
                                               ;  _upperExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _times.cell
                                ;  _strikes.cell
                                ;  _localVolMatrix.cell
                                ;  _dayCounter.cell
                                ;  _lowerExtrapolation.cell
                                ;  _upperExtrapolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedLocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedLocalVolSurface1", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="times",Description = "Reference to times")>] 
         times : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="localVolMatrix",Description = "Reference to localVolMatrix")>] 
         localVolMatrix : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="lowerExtrapolation",Description = "Reference to lowerExtrapolation")>] 
         lowerExtrapolation : obj)
        ([<ExcelArgument(Name="upperExtrapolation",Description = "Reference to upperExtrapolation")>] 
         upperExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _times = Helper.toCell<Generic.List<double>> times "times" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _localVolMatrix = Helper.toCell<Matrix> localVolMatrix "localVolMatrix" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _lowerExtrapolation = Helper.toDefault<FixedLocalVolSurface.Extrapolation> lowerExtrapolation "lowerExtrapolation" FixedLocalVolSurface.Extrapolation.ConstantExtrapolation
                let _upperExtrapolation = Helper.toDefault<FixedLocalVolSurface.Extrapolation> upperExtrapolation "upperExtrapolation" FixedLocalVolSurface.Extrapolation.ConstantExtrapolation
                let builder () = withMnemonic mnemonic (Fun.FixedLocalVolSurface1
                                                            _referenceDate.cell 
                                                            _times.cell 
                                                            _strikes.cell 
                                                            _localVolMatrix.cell 
                                                            _dayCounter.cell 
                                                            _lowerExtrapolation.cell 
                                                            _upperExtrapolation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedLocalVolSurface>) l

                let source = Helper.sourceFold "Fun.FixedLocalVolSurface1" 
                                               [| _referenceDate.source
                                               ;  _times.source
                                               ;  _strikes.source
                                               ;  _localVolMatrix.source
                                               ;  _dayCounter.source
                                               ;  _lowerExtrapolation.source
                                               ;  _upperExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _times.cell
                                ;  _strikes.cell
                                ;  _localVolMatrix.cell
                                ;  _dayCounter.cell
                                ;  _lowerExtrapolation.cell
                                ;  _upperExtrapolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedLocalVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedLocalVolSurface_maxDate", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".MaxDate") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_maxStrike", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".MaxStrike") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_maxTime", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".MaxTime") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_minStrike", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".MinStrike") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    (*!!generic 
    [<ExcelFunction(Name="_FixedLocalVolSurface_setInterpolation", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_setInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let _i = Helper.toDefault<Interpolator> i "i" default(Interpolator)
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).SetInterpolation
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : FixedLocalVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".SetInterpolation") 
                                               [| _FixedLocalVolSurface.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
                                ;  _i.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_FixedLocalVolSurface_localVol", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_localVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "Reference to underlyingLevel")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let _t = Helper.toCell<double> t "t" 
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).LocalVol
                                                            _t.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".LocalVol") 
                                               [| _FixedLocalVolSurface.source
                                               ;  _t.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
                                ;  _t.cell
                                ;  _underlyingLevel.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_localVol1", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_localVol1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="underlyingLevel",Description = "Reference to underlyingLevel")>] 
         underlyingLevel : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let _d = Helper.toCell<Date> d "d" 
                let _underlyingLevel = Helper.toCell<double> underlyingLevel "underlyingLevel" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).LocalVol1
                                                            _d.cell 
                                                            _underlyingLevel.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".LocalVol1") 
                                               [| _FixedLocalVolSurface.source
                                               ;  _d.source
                                               ;  _underlyingLevel.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
                                ;  _d.cell
                                ;  _underlyingLevel.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_businessDayConvention", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".BusinessDayConvention") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_optionDateFromTenor", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let _p = Helper.toCell<Period> p "p" 
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".OptionDateFromTenor") 
                                               [| _FixedLocalVolSurface.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_calendar", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".Calendar") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedLocalVolSurface> format
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_dayCounter", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".DayCounter") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedLocalVolSurface> format
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_referenceDate", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".ReferenceDate") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_settlementDays", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".SettlementDays") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_timeFromReference", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".TimeFromReference") 
                                               [| _FixedLocalVolSurface.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_update", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).Update
                                                       ) :> ICell
                let format (o : FixedLocalVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".Update") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_allowsExtrapolation", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".AllowsExtrapolation") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_disableExtrapolation", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FixedLocalVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".DisableExtrapolation") 
                                               [| _FixedLocalVolSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_enableExtrapolation", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FixedLocalVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".EnableExtrapolation") 
                                               [| _FixedLocalVolSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_extrapolate", Description="Create a FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedLocalVolSurface",Description = "Reference to FixedLocalVolSurface")>] 
         fixedlocalvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedLocalVolSurface = Helper.toCell<FixedLocalVolSurface> fixedlocalvolsurface "FixedLocalVolSurface"  
                let builder () = withMnemonic mnemonic ((_FixedLocalVolSurface.cell :?> FixedLocalVolSurfaceModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedLocalVolSurface.source + ".Extrapolate") 
                                               [| _FixedLocalVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedLocalVolSurface.cell
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
    [<ExcelFunction(Name="_FixedLocalVolSurface_Range", Description="Create a range of FixedLocalVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedLocalVolSurface_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FixedLocalVolSurface")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedLocalVolSurface> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FixedLocalVolSurface>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FixedLocalVolSurface>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FixedLocalVolSurface>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
