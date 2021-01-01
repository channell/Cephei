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
  Black volatility surface backed by Heston model

  </summary> *)
[<AutoSerializable(true)>]
type HestonBlackVolSurfaceModel
    ( hestonModel                                  : ICell<Handle<HestonModel>>
    ) as this =

    inherit Model<HestonBlackVolSurface> ()
(*
    Parameters
*)
    let _hestonModel                               = hestonModel
(*
    Functions
*)
    let mutable
        _HestonBlackVolSurface                     = make (fun () -> new HestonBlackVolSurface (hestonModel.Value))
    let _maxDate                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.maxDate())
    let _maxStrike                                 = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.maxStrike())
    let _minStrike                                 = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.minStrike())
    let _blackForwardVariance                      (time1 : ICell<double>) (time2 : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.blackForwardVariance(time1.Value, time2.Value, strike.Value, extrapolate.Value))
    let _blackForwardVariance1                     (date1 : ICell<Date>) (date2 : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.blackForwardVariance(date1.Value, date2.Value, strike.Value, extrapolate.Value))
    let _blackForwardVol                           (time1 : ICell<double>) (time2 : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.blackForwardVol(time1.Value, time2.Value, strike.Value, extrapolate.Value))
    let _blackForwardVol1                          (date1 : ICell<Date>) (date2 : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.blackForwardVol(date1.Value, date2.Value, strike.Value, extrapolate.Value))
    let _blackVariance                             (maturity : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.blackVariance(maturity.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (maturity : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.blackVariance(maturity.Value, strike.Value, extrapolate.Value))
    let _blackVol                                  (maturity : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.blackVol(maturity.Value, strike.Value, extrapolate.Value))
    let _blackVol1                                 (maturity : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.blackVol(maturity.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.calendar())
    let _dayCounter                                = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.dayCounter())
    let _maxTime                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.maxTime())
    let _referenceDate                             = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.referenceDate())
    let _settlementDays                            = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.timeFromReference(date.Value))
    let _update                                    = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.update()
                                                                                            _HestonBlackVolSurface.Value)
    let _allowsExtrapolation                       = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.disableExtrapolation(b.Value)
                                                                                            _HestonBlackVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.enableExtrapolation(b.Value)
                                                                                            _HestonBlackVolSurface.Value)
    let _extrapolate                               = triv _HestonBlackVolSurface (fun () -> _HestonBlackVolSurface.Value.extrapolate)
    do this.Bind(_HestonBlackVolSurface)
(* 
    casting 
*)
    internal new () = new HestonBlackVolSurfaceModel(null)
    member internal this.Inject v = _HestonBlackVolSurface <- v
    static member Cast (p : ICell<HestonBlackVolSurface>) = 
        if p :? HestonBlackVolSurfaceModel then 
            p :?> HestonBlackVolSurfaceModel
        else
            let o = new HestonBlackVolSurfaceModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.hestonModel                        = _hestonModel 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BlackForwardVariance               time1 time2 strike extrapolate   
                                                   = _blackForwardVariance time1 time2 strike extrapolate 
    member this.BlackForwardVariance1              date1 date2 strike extrapolate   
                                                   = _blackForwardVariance1 date1 date2 strike extrapolate 
    member this.BlackForwardVol                    time1 time2 strike extrapolate   
                                                   = _blackForwardVol time1 time2 strike extrapolate 
    member this.BlackForwardVol1                   date1 date2 strike extrapolate   
                                                   = _blackForwardVol1 date1 date2 strike extrapolate 
    member this.BlackVariance                      maturity strike extrapolate   
                                                   = _blackVariance maturity strike extrapolate 
    member this.BlackVariance1                     maturity strike extrapolate   
                                                   = _blackVariance1 maturity strike extrapolate 
    member this.BlackVol                           maturity strike extrapolate   
                                                   = _blackVol maturity strike extrapolate 
    member this.BlackVol1                          maturity strike extrapolate   
                                                   = _blackVol1 maturity strike extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxTime                            = _maxTime
    member this.ReferenceDate                      = _referenceDate
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
