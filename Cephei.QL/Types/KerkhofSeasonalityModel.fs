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
type KerkhofSeasonalityModel
    ( seasonalityBaseDate                          : ICell<Date>
    , seasonalityFactors                           : ICell<Generic.List<double>>
    ) as this =

    inherit Model<KerkhofSeasonality> ()
(*
    Parameters
*)
    let _seasonalityBaseDate                       = seasonalityBaseDate
    let _seasonalityFactors                        = seasonalityFactors
(*
    Functions
*)
    let mutable
        _KerkhofSeasonality                        = cell (fun () -> new KerkhofSeasonality (seasonalityBaseDate.Value, seasonalityFactors.Value))
    let _seasonalityFactor                         (To : ICell<Date>)   
                                                   = triv (fun () -> _KerkhofSeasonality.Value.seasonalityFactor(To.Value))
    let _correctYoYRate                            (d : ICell<Date>) (r : ICell<double>) (iTS : ICell<InflationTermStructure>)   
                                                   = triv (fun () -> _KerkhofSeasonality.Value.correctYoYRate(d.Value, r.Value, iTS.Value))
    let _correctZeroRate                           (d : ICell<Date>) (r : ICell<double>) (iTS : ICell<InflationTermStructure>)   
                                                   = triv (fun () -> _KerkhofSeasonality.Value.correctZeroRate(d.Value, r.Value, iTS.Value))
    let _frequency                                 = triv (fun () -> _KerkhofSeasonality.Value.frequency())
    let _isConsistent                              (iTS : ICell<InflationTermStructure>)   
                                                   = triv (fun () -> _KerkhofSeasonality.Value.isConsistent(iTS.Value))
    let _seasonalityBaseDate                       = triv (fun () -> _KerkhofSeasonality.Value.seasonalityBaseDate())
    let _seasonalityFactors                        = triv (fun () -> _KerkhofSeasonality.Value.seasonalityFactors())
    let _set                                       (seasonalityBaseDate : ICell<Date>) (frequency : ICell<Frequency>) (seasonalityFactors : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _KerkhofSeasonality.Value.set(seasonalityBaseDate.Value, frequency.Value, seasonalityFactors.Value)
                                                                     _KerkhofSeasonality.Value)
    do this.Bind(_KerkhofSeasonality)
(* 
    casting 
*)
    internal new () = new KerkhofSeasonalityModel(null,null)
    member internal this.Inject v = _KerkhofSeasonality <- v
    static member Cast (p : ICell<KerkhofSeasonality>) = 
        if p :? KerkhofSeasonalityModel then 
            p :?> KerkhofSeasonalityModel
        else
            let o = new KerkhofSeasonalityModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.seasonalityBaseDate                = _seasonalityBaseDate 
    member this.seasonalityFactors                 = _seasonalityFactors 
    member this.SeasonalityFactor                  To   
                                                   = _seasonalityFactor To 
    member this.CorrectYoYRate                     d r iTS   
                                                   = _correctYoYRate d r iTS 
    member this.CorrectZeroRate                    d r iTS   
                                                   = _correctZeroRate d r iTS 
    member this.Frequency                          = _frequency
    member this.IsConsistent                       iTS   
                                                   = _isConsistent iTS 
    member this.SeasonalityBaseDate                = _seasonalityBaseDate
    member this.SeasonalityFactors                 = _seasonalityFactors
    member this.Set                                seasonalityBaseDate frequency seasonalityFactors   
                                                   = _set seasonalityBaseDate frequency seasonalityFactors 
