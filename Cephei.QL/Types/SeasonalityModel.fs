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
  This is an abstract class and contains the functions correctXXXRate which returns rates with the seasonality correction.  Currently only the price multiplicative version is implemented, but this covers stationary (1-year) and non-stationary (multi-year) seasonality depending on how many years of factors are given.  Seasonality is piecewise constant, hence it will work with un-interpolated inflation indices.  A seasonality assumption can be used to fill in inflation swap curves between maturities that are usually given in integer numbers of years, e.g. 8,9,10,15,20, etc.  Historical seasonality may be observed in reported CPI values, alternatively it may be affected by known future events, e.g. announced changes in VAT rates.  Thus seasonality may be stationary or non-stationary.  If seasonality is additive then both swap rates will show affects.  Additive seasonality is not implemented.
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type SeasonalityModel
    () as this =
    inherit Model<Seasonality> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Seasonality                               = cell (fun () -> new Seasonality ())
    let _correctYoYRate                            (d : ICell<Date>) (r : ICell<double>) (iTS : ICell<InflationTermStructure>)   
                                                   = triv (fun () -> _Seasonality.Value.correctYoYRate(d.Value, r.Value, iTS.Value))
    let _correctZeroRate                           (d : ICell<Date>) (r : ICell<double>) (iTS : ICell<InflationTermStructure>)   
                                                   = triv (fun () -> _Seasonality.Value.correctZeroRate(d.Value, r.Value, iTS.Value))
    let _isConsistent                              (iTS : ICell<InflationTermStructure>)   
                                                   = triv (fun () -> _Seasonality.Value.isConsistent(iTS.Value))
    do this.Bind(_Seasonality)
(* 
    casting 
*)
    
    member internal this.Inject v = _Seasonality.Value <- v
    static member Cast (p : ICell<Seasonality>) = 
        if p :? SeasonalityModel then 
            p :?> SeasonalityModel
        else
            let o = new SeasonalityModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.CorrectYoYRate                     d r iTS   
                                                   = _correctYoYRate d r iTS 
    member this.CorrectZeroRate                    d r iTS   
                                                   = _correctZeroRate d r iTS 
    member this.IsConsistent                       iTS   
                                                   = _isConsistent iTS 
