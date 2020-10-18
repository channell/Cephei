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


  </summary> *)
[<AutoSerializable(true)>]
type ShiftedBlackVolTermStructureModel
    ( varianceOffset                               : ICell<double>
    , volTS                                        : ICell<Handle<BlackVolTermStructure>>
    ) as this =

    inherit Model<ShiftedBlackVolTermStructure> ()
(*
    Parameters
*)
    let _varianceOffset                            = varianceOffset
    let _volTS                                     = volTS
(*
    Functions
*)
    let mutable
        _ShiftedBlackVolTermStructure              = cell (fun () -> new ShiftedBlackVolTermStructure (varianceOffset.Value, volTS.Value))
    let _maxDate                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ShiftedBlackVolTermStructure.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _ShiftedBlackVolTermStructure.Value.minStrike())
    let _blackForwardVariance                      (time1 : ICell<double>) (time2 : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.blackForwardVariance(time1.Value, time2.Value, strike.Value, extrapolate.Value))
    let _blackForwardVariance1                     (date1 : ICell<Date>) (date2 : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.blackForwardVariance(date1.Value, date2.Value, strike.Value, extrapolate.Value))
    let _blackForwardVol                           (time1 : ICell<double>) (time2 : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.blackForwardVol(time1.Value, time2.Value, strike.Value, extrapolate.Value))
    let _blackForwardVol1                          (date1 : ICell<Date>) (date2 : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.blackForwardVol(date1.Value, date2.Value, strike.Value, extrapolate.Value))
    let _blackVariance                             (maturity : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.blackVariance(maturity.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (maturity : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.blackVariance(maturity.Value, strike.Value, extrapolate.Value))
    let _blackVol                                  (maturity : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.blackVol(maturity.Value, strike.Value, extrapolate.Value))
    let _blackVol1                                 (maturity : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.blackVol(maturity.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _ShiftedBlackVolTermStructure.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ShiftedBlackVolTermStructure.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ShiftedBlackVolTermStructure.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ShiftedBlackVolTermStructure.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ShiftedBlackVolTermStructure.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ShiftedBlackVolTermStructure.Value.update()
                                                                     _ShiftedBlackVolTermStructure.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ShiftedBlackVolTermStructure.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.disableExtrapolation(b.Value)
                                                                     _ShiftedBlackVolTermStructure.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ShiftedBlackVolTermStructure.Value.enableExtrapolation(b.Value)
                                                                     _ShiftedBlackVolTermStructure.Value)
    let _extrapolate                               = triv (fun () -> _ShiftedBlackVolTermStructure.Value.extrapolate)
    do this.Bind(_ShiftedBlackVolTermStructure)
(* 
    casting 
*)
    internal new () = new ShiftedBlackVolTermStructureModel(null,null)
    member internal this.Inject v = _ShiftedBlackVolTermStructure <- v
    static member Cast (p : ICell<ShiftedBlackVolTermStructure>) = 
        if p :? ShiftedBlackVolTermStructureModel then 
            p :?> ShiftedBlackVolTermStructureModel
        else
            let o = new ShiftedBlackVolTermStructureModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.varianceOffset                     = _varianceOffset 
    member this.volTS                              = _volTS 
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
