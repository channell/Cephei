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
type InterpolatedCPICapFloorTermPriceSurfaceModel<'Interpolator2D when 'Interpolator2D :> IInterpolationFactory2D and 'Interpolator2D : (new : unit -> 'Interpolator2D)>
    ( nominal                                      : ICell<double>
    , startRate                                    : ICell<double>
    , observationLag                               : ICell<Period>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , dc                                           : ICell<DayCounter>
    , zii                                          : ICell<Handle<ZeroInflationIndex>>
    , yts                                          : ICell<Handle<YieldTermStructure>>
    , cStrikes                                     : ICell<Generic.List<double>>
    , fStrikes                                     : ICell<Generic.List<double>>
    , cfMaturities                                 : ICell<Generic.List<Period>>
    , cPrice                                       : ICell<Matrix>
    , fPrice                                       : ICell<Matrix>
    ) as this =

    inherit Model<InterpolatedCPICapFloorTermPriceSurface<'Interpolator2D>> ()
(*
    Parameters
*)
    let _nominal                                   = nominal
    let _startRate                                 = startRate
    let _observationLag                            = observationLag
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _dc                                        = dc
    let _zii                                       = zii
    let _yts                                       = yts
    let _cStrikes                                  = cStrikes
    let _fStrikes                                  = fStrikes
    let _cfMaturities                              = cfMaturities
    let _cPrice                                    = cPrice
    let _fPrice                                    = fPrice
(*
    Functions
*)
    let _InterpolatedCPICapFloorTermPriceSurface   = cell (fun () -> new InterpolatedCPICapFloorTermPriceSurface<'Interpolator2D> (nominal.Value, startRate.Value, observationLag.Value, cal.Value, bdc.Value, dc.Value, zii.Value, yts.Value, cStrikes.Value, fStrikes.Value, cfMaturities.Value, cPrice.Value, fPrice.Value))
    let _capPrice                                  (d : ICell<Date>) (k : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.capPrice(d.Value, k.Value))
    let _floorPrice                                (d : ICell<Date>) (k : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.floorPrice(d.Value, k.Value))
    let _price                                     (d : ICell<Date>) (k : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.price(d.Value, k.Value))
    let _update                                    = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.update()
                                                                     _InterpolatedCPICapFloorTermPriceSurface.Value)
    let _baseDate                                  = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.baseDate())
    let _businessDayConvention                     = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.businessDayConvention())
    let _capPrices                                 = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.capPrices())
    let _capStrikes                                = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.capStrikes())
    let _cpiOptionDateFromTenor                    (p : ICell<Period>)   
                                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.cpiOptionDateFromTenor(p.Value))
    let _floorPrices                               = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.floorPrices())
    let _floorStrikes                              = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.floorStrikes())
    let _maturities                                = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.maturities())
    let _maxDate                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.maxStrike())
    let _minDate                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.minDate())
    let _minStrike                                 = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.minStrike())
    let _nominal                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.nominal())
    let _observationLag                            = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.observationLag())
    let _strikes                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.strikes())
    let _zeroInflationIndex                        = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.zeroInflationIndex())
    let _baseRate                                  = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.baseRate())
    let _frequency                                 = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.frequency())
    let _hasSeasonality                            = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.hasSeasonality())
    let _indexIsInterpolated                       = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.indexIsInterpolated())
    let _nominalTermStructure                      = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.nominalTermStructure())
    let _seasonality                               = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.setSeasonality(seasonality.Value)
                                                                     _InterpolatedCPICapFloorTermPriceSurface.Value)
    let _calendar                                  = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.calendar())
    let _dayCounter                                = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.disableExtrapolation(b.Value)
                                                                     _InterpolatedCPICapFloorTermPriceSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.enableExtrapolation(b.Value)
                                                                     _InterpolatedCPICapFloorTermPriceSurface.Value)
    let _extrapolate                               = triv (fun () -> _InterpolatedCPICapFloorTermPriceSurface.Value.extrapolate)
    do this.Bind(_InterpolatedCPICapFloorTermPriceSurface)

(* 
    Externally visible/bindable properties
*)
    member this.nominal                            = _nominal 
    member this.startRate                          = _startRate 
    member this.observationLag                     = _observationLag 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.dc                                 = _dc 
    member this.zii                                = _zii 
    member this.yts                                = _yts 
    member this.cStrikes                           = _cStrikes 
    member this.fStrikes                           = _fStrikes 
    member this.cfMaturities                       = _cfMaturities 
    member this.cPrice                             = _cPrice 
    member this.fPrice                             = _fPrice 
    member this.CapPrice                           d k   
                                                   = _capPrice d k 
    member this.FloorPrice                         d k   
                                                   = _floorPrice d k 
    member this.Price                              d k   
                                                   = _price d k 
    member this.Update                             = _update
    member this.BaseDate                           = _baseDate
    member this.BusinessDayConvention              = _businessDayConvention
    member this.CapPrices                          = _capPrices
    member this.CapStrikes                         = _capStrikes
    member this.CpiOptionDateFromTenor             p   
                                                   = _cpiOptionDateFromTenor p 
    member this.FloorPrices                        = _floorPrices
    member this.FloorStrikes                       = _floorStrikes
    member this.Maturities                         = _maturities
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinDate                            = _minDate
    member this.MinStrike                          = _minStrike
    member this.Nominal                            = _nominal
    member this.ObservationLag                     = _observationLag
    member this.Strikes                            = _strikes
    member this.ZeroInflationIndex                 = _zeroInflationIndex
    member this.BaseRate                           = _baseRate
    member this.Frequency                          = _frequency
    member this.HasSeasonality                     = _hasSeasonality
    member this.IndexIsInterpolated                = _indexIsInterpolated
    member this.NominalTermStructure               = _nominalTermStructure
    member this.Seasonality                        = _seasonality
    member this.SetSeasonality                     seasonality   
                                                   = _setSeasonality seasonality 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxTime                            = _maxTime
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
