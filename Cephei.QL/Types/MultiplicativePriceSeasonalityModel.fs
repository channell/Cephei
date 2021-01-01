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
  Stationary multiplicative seasonality in CPI/RPI/HICP (i.e. in price) implies that zero inflation swap rates are affected, but that year-on-year inflation swap rates show no effect.  Of course, if the seasonality in CPI/RPI/HICP is non-stationary then both swap rates will be affected.  Factors must be in multiples of the minimum required for one year, e.g. 12 for monthly, and these factors are reused for as long as is required, i.e. they wrap around.  So, for example, if 24 factors are given this repeats every two years.  True stationary seasonality can be obtained by giving the same number of factors as the frequency dictates e.g. 12 for monthly seasonality.  Multi-year seasonality (i.e. non-stationary) is fragile: the user <b>must</b> ensure that corrections at whole years before and after the inflation term structure base date are the same.  Otherwise there can be an inconsistency with quoted rates.  This is enforced if the frequency is lower than daily.  This is not enforced for daily seasonality because this will always be inconsistent due to weekends, holidays, leap years, etc.  If you use multi-year daily seasonality it is up to you to check.  Factors are normalized relative to their appropriate reference dates.  For zero inflation this is the inflation curve true base date: since you have a fixing for that date the seasonality factor must be one.  For YoY inflation the reference is always one year earlier.  Seasonality is treated as piecewise constant, hence it works correctly with uninterpolated indices if the seasonality correction factor frequency is the same as the index frequency (or less).

  </summary> *)
[<AutoSerializable(true)>]
type MultiplicativePriceSeasonalityModel
    ( seasonalityBaseDate                          : ICell<Date>
    , frequency                                    : ICell<Frequency>
    , seasonalityFactors                           : ICell<Generic.List<double>>
    ) as this =

    inherit Model<MultiplicativePriceSeasonality> ()
(*
    Parameters
*)
    let _seasonalityBaseDate                       = seasonalityBaseDate
    let _frequency                                 = frequency
    let _seasonalityFactors                        = seasonalityFactors
(*
    Functions
*)
    let mutable
        _MultiplicativePriceSeasonality            = make (fun () -> new MultiplicativePriceSeasonality (seasonalityBaseDate.Value, frequency.Value, seasonalityFactors.Value))
    let _correctYoYRate                            (d : ICell<Date>) (r : ICell<double>) (iTS : ICell<InflationTermStructure>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.correctYoYRate(d.Value, r.Value, iTS.Value))
    let _correctZeroRate                           (d : ICell<Date>) (r : ICell<double>) (iTS : ICell<InflationTermStructure>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.correctZeroRate(d.Value, r.Value, iTS.Value))
    let _frequency                                 = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.frequency())
    let _isConsistent                              (iTS : ICell<InflationTermStructure>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.isConsistent(iTS.Value))
    let _seasonalityBaseDate                       = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.seasonalityBaseDate())
    let _seasonalityFactor                         (To : ICell<Date>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.seasonalityFactor(To.Value))
    let _seasonalityFactors                        = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.seasonalityFactors())
    let _set                                       (seasonalityBaseDate : ICell<Date>) (frequency : ICell<Frequency>) (seasonalityFactors : ICell<Generic.List<double>>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.set(seasonalityBaseDate.Value, frequency.Value, seasonalityFactors.Value)
                                                                                                     _MultiplicativePriceSeasonality.Value)
    do this.Bind(_MultiplicativePriceSeasonality)
(* 
    casting 
*)
    internal new () = new MultiplicativePriceSeasonalityModel(null,null,null)
    member internal this.Inject v = _MultiplicativePriceSeasonality <- v
    static member Cast (p : ICell<MultiplicativePriceSeasonality>) = 
        if p :? MultiplicativePriceSeasonalityModel then 
            p :?> MultiplicativePriceSeasonalityModel
        else
            let o = new MultiplicativePriceSeasonalityModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.seasonalityBaseDate                = _seasonalityBaseDate 
    member this.frequency                          = _frequency 
    member this.seasonalityFactors                 = _seasonalityFactors 
    member this.CorrectYoYRate                     d r iTS   
                                                   = _correctYoYRate d r iTS 
    member this.CorrectZeroRate                    d r iTS   
                                                   = _correctZeroRate d r iTS 
    member this.Frequency                          = _frequency
    member this.IsConsistent                       iTS   
                                                   = _isConsistent iTS 
    member this.SeasonalityBaseDate                = _seasonalityBaseDate
    member this.SeasonalityFactor                  To   
                                                   = _seasonalityFactor To 
    member this.SeasonalityFactors                 = _seasonalityFactors
    member this.Set                                seasonalityBaseDate frequency seasonalityFactors   
                                                   = _set seasonalityBaseDate frequency seasonalityFactors 
(* <summary>
  Stationary multiplicative seasonality in CPI/RPI/HICP (i.e. in price) implies that zero inflation swap rates are affected, but that year-on-year inflation swap rates show no effect.  Of course, if the seasonality in CPI/RPI/HICP is non-stationary then both swap rates will be affected.  Factors must be in multiples of the minimum required for one year, e.g. 12 for monthly, and these factors are reused for as long as is required, i.e. they wrap around.  So, for example, if 24 factors are given this repeats every two years.  True stationary seasonality can be obtained by giving the same number of factors as the frequency dictates e.g. 12 for monthly seasonality.  Multi-year seasonality (i.e. non-stationary) is fragile: the user <b>must</b> ensure that corrections at whole years before and after the inflation term structure base date are the same.  Otherwise there can be an inconsistency with quoted rates.  This is enforced if the frequency is lower than daily.  This is not enforced for daily seasonality because this will always be inconsistent due to weekends, holidays, leap years, etc.  If you use multi-year daily seasonality it is up to you to check.  Factors are normalized relative to their appropriate reference dates.  For zero inflation this is the inflation curve true base date: since you have a fixing for that date the seasonality factor must be one.  For YoY inflation the reference is always one year earlier.  Seasonality is treated as piecewise constant, hence it works correctly with uninterpolated indices if the seasonality correction factor frequency is the same as the index frequency (or less).
Constructors
  </summary> *)
[<AutoSerializable(true)>]
type MultiplicativePriceSeasonalityModel1
    () as this =
    inherit Model<MultiplicativePriceSeasonality> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _MultiplicativePriceSeasonality            = make (fun () -> new MultiplicativePriceSeasonality ())
    let _correctYoYRate                            (d : ICell<Date>) (r : ICell<double>) (iTS : ICell<InflationTermStructure>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.correctYoYRate(d.Value, r.Value, iTS.Value))
    let _correctZeroRate                           (d : ICell<Date>) (r : ICell<double>) (iTS : ICell<InflationTermStructure>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.correctZeroRate(d.Value, r.Value, iTS.Value))
    let _frequency                                 = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.frequency())
    let _isConsistent                              (iTS : ICell<InflationTermStructure>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.isConsistent(iTS.Value))
    let _seasonalityBaseDate                       = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.seasonalityBaseDate())
    let _seasonalityFactor                         (To : ICell<Date>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.seasonalityFactor(To.Value))
    let _seasonalityFactors                        = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.seasonalityFactors())
    let _set                                       (seasonalityBaseDate : ICell<Date>) (frequency : ICell<Frequency>) (seasonalityFactors : ICell<Generic.List<double>>)   
                                                   = triv _MultiplicativePriceSeasonality (fun () -> _MultiplicativePriceSeasonality.Value.set(seasonalityBaseDate.Value, frequency.Value, seasonalityFactors.Value)
                                                                                                     _MultiplicativePriceSeasonality.Value)
    do this.Bind(_MultiplicativePriceSeasonality)
(* 
    casting 
*)
    
    member internal this.Inject v = _MultiplicativePriceSeasonality <- v
    static member Cast (p : ICell<MultiplicativePriceSeasonality>) = 
        if p :? MultiplicativePriceSeasonalityModel1 then 
            p :?> MultiplicativePriceSeasonalityModel1
        else
            let o = new MultiplicativePriceSeasonalityModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.CorrectYoYRate                     d r iTS   
                                                   = _correctYoYRate d r iTS 
    member this.CorrectZeroRate                    d r iTS   
                                                   = _correctZeroRate d r iTS 
    member this.Frequency                          = _frequency
    member this.IsConsistent                       iTS   
                                                   = _isConsistent iTS 
    member this.SeasonalityBaseDate                = _seasonalityBaseDate
    member this.SeasonalityFactor                  To   
                                                   = _seasonalityFactor To 
    member this.SeasonalityFactors                 = _seasonalityFactors
    member this.Set                                seasonalityBaseDate frequency seasonalityFactors   
                                                   = _set seasonalityBaseDate frequency seasonalityFactors 
