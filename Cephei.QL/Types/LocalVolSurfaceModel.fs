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
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>
  For details about this implementation refer to "Stochastic Volatility and Local Volatility," in "Case Studies and Financial Modelling Course Notes," by Jim Gatheral, Fall Term, 2003  see www.math.nyu.edu/fellows_fin_math/gatheral/Lecture1_Fall02.pdf  this class is untested, probably unreliable.

  </summary> *)
[<AutoSerializable(true)>]
type LocalVolSurfaceModel
    ( blackTS                                      : ICell<Handle<BlackVolTermStructure>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , dividendTS                                   : ICell<Handle<YieldTermStructure>>
    , underlying                                   : ICell<Handle<Quote>>
    ) as this =

    inherit Model<LocalVolSurface> ()
(*
    Parameters
*)
    let _blackTS                                   = blackTS
    let _riskFreeTS                                = riskFreeTS
    let _dividendTS                                = dividendTS
    let _underlying                                = underlying
(*
    Functions
*)
    let mutable
        _LocalVolSurface                           = cell (fun () -> new LocalVolSurface (blackTS.Value, riskFreeTS.Value, dividendTS.Value, underlying.Value))
    let _dayCounter                                = triv (fun () -> _LocalVolSurface.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _LocalVolSurface.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _LocalVolSurface.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _LocalVolSurface.Value.minStrike())
    let _referenceDate                             = triv (fun () -> _LocalVolSurface.Value.referenceDate())
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _LocalVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _LocalVolSurface.Value.calendar())
    let _maxTime                                   = triv (fun () -> _LocalVolSurface.Value.maxTime())
    let _settlementDays                            = triv (fun () -> _LocalVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _LocalVolSurface.Value.update()
                                                                     _LocalVolSurface.Value)
    let _allowsExtrapolation                       = triv (fun () -> _LocalVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _LocalVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _LocalVolSurface.Value)
    let _extrapolate                               = triv (fun () -> _LocalVolSurface.Value.extrapolate)
    do this.Bind(_LocalVolSurface)
(* 
    casting 
*)
    internal new () = new LocalVolSurfaceModel(null,null,null,null)
    member internal this.Inject v = _LocalVolSurface <- v
    static member Cast (p : ICell<LocalVolSurface>) = 
        if p :? LocalVolSurfaceModel then 
            p :?> LocalVolSurfaceModel
        else
            let o = new LocalVolSurfaceModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.blackTS                            = _blackTS 
    member this.riskFreeTS                         = _riskFreeTS 
    member this.dividendTS                         = _dividendTS 
    member this.underlying                         = _underlying 
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.ReferenceDate                      = _referenceDate
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.Calendar                           = _calendar
    member this.MaxTime                            = _maxTime
    member this.SettlementDays                     = _settlementDays
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
(* <summary>
  For details about this implementation refer to "Stochastic Volatility and Local Volatility," in "Case Studies and Financial Modelling Course Notes," by Jim Gatheral, Fall Term, 2003  see www.math.nyu.edu/fellows_fin_math/gatheral/Lecture1_Fall02.pdf  this class is untested, probably unreliable.

  </summary> *)
[<AutoSerializable(true)>]
type LocalVolSurfaceModel1
    ( blackTS                                      : ICell<Handle<BlackVolTermStructure>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , dividendTS                                   : ICell<Handle<YieldTermStructure>>
    , underlying                                   : ICell<double>
    ) as this =

    inherit Model<LocalVolSurface> ()
(*
    Parameters
*)
    let _blackTS                                   = blackTS
    let _riskFreeTS                                = riskFreeTS
    let _dividendTS                                = dividendTS
    let _underlying                                = underlying
(*
    Functions
*)
    let mutable
        _LocalVolSurface                           = cell (fun () -> new LocalVolSurface (blackTS.Value, riskFreeTS.Value, dividendTS.Value, underlying.Value))
    let _dayCounter                                = triv (fun () -> _LocalVolSurface.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _LocalVolSurface.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _LocalVolSurface.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _LocalVolSurface.Value.minStrike())
    let _referenceDate                             = triv (fun () -> _LocalVolSurface.Value.referenceDate())
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _LocalVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _LocalVolSurface.Value.calendar())
    let _maxTime                                   = triv (fun () -> _LocalVolSurface.Value.maxTime())
    let _settlementDays                            = triv (fun () -> _LocalVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _LocalVolSurface.Value.update()
                                                                     _LocalVolSurface.Value)
    let _allowsExtrapolation                       = triv (fun () -> _LocalVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _LocalVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _LocalVolSurface.Value)
    let _extrapolate                               = triv (fun () -> _LocalVolSurface.Value.extrapolate)
    do this.Bind(_LocalVolSurface)
(* 
    casting 
*)
    internal new () = new LocalVolSurfaceModel1(null,null,null,null)
    member internal this.Inject v = _LocalVolSurface <- v
    static member Cast (p : ICell<LocalVolSurface>) = 
        if p :? LocalVolSurfaceModel1 then 
            p :?> LocalVolSurfaceModel1
        else
            let o = new LocalVolSurfaceModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.blackTS                            = _blackTS 
    member this.riskFreeTS                         = _riskFreeTS 
    member this.dividendTS                         = _dividendTS 
    member this.underlying                         = _underlying 
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.ReferenceDate                      = _referenceDate
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.Calendar                           = _calendar
    member this.MaxTime                            = _maxTime
    member this.SettlementDays                     = _settlementDays
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
