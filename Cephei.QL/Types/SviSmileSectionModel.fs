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
type SviSmileSectionModel
    ( timeToExpiry                                 : ICell<double>
    , forward                                      : ICell<double>
    , sviParameters                                : ICell<Generic.List<double>>
    ) as this =

    inherit Model<SviSmileSection> ()
(*
    Parameters
*)
    let _timeToExpiry                              = timeToExpiry
    let _forward                                   = forward
    let _sviParameters                             = sviParameters
(*
    Functions
*)
    let _SviSmileSection                           = cell (fun () -> new SviSmileSection (timeToExpiry.Value, forward.Value, sviParameters.Value))
    let _atmLevel                                  = triv (fun () -> _SviSmileSection.Value.atmLevel())
    let _init                                      = triv (fun () -> _SviSmileSection.Value.init()
                                                                     _SviSmileSection.Value)
    let _maxStrike                                 = triv (fun () -> _SviSmileSection.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _SviSmileSection.Value.minStrike())
    let _dayCounter                                = triv (fun () -> _SviSmileSection.Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> _SviSmileSection.Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> _SviSmileSection.Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> _SviSmileSection.Value.referenceDate())
    let _shift                                     = triv (fun () -> _SviSmileSection.Value.shift())
    let _update                                    = triv (fun () -> _SviSmileSection.Value.update()
                                                                     _SviSmileSection.Value)
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> _SviSmileSection.Value.volatilityType())
    do this.Bind(_SviSmileSection)
(* 
    casting 
*)
    internal new () = new SviSmileSectionModel(null,null,null)
    member internal this.Inject v = _SviSmileSection.Value <- v
    static member Cast (p : ICell<SviSmileSection>) = 
        if p :? SviSmileSectionModel then 
            p :?> SviSmileSectionModel
        else
            let o = new SviSmileSectionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.timeToExpiry                       = _timeToExpiry 
    member this.forward                            = _forward 
    member this.sviParameters                      = _sviParameters 
    member this.AtmLevel                           = _atmLevel
    member this.Init                               = _init
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.DayCounter                         = _dayCounter
    member this.Density                            strike discount gap   
                                                   = _density strike discount gap 
    member this.DigitalOptionPrice                 strike Type discount gap   
                                                   = _digitalOptionPrice strike Type discount gap 
    member this.ExerciseDate                       = _exerciseDate
    member this.ExerciseTime                       = _exerciseTime
    member this.OptionPrice                        strike Type discount   
                                                   = _optionPrice strike Type discount 
    member this.ReferenceDate                      = _referenceDate
    member this.Shift                              = _shift
    member this.Update                             = _update
    member this.Variance                           strike   
                                                   = _variance strike 
    member this.Vega                               strike discount   
                                                   = _vega strike discount 
    member this.Volatility                         strike volatilityType shift   
                                                   = _volatility strike volatilityType shift 
    member this.Volatility1                        strike   
                                                   = _volatility1 strike 
    member this.VolatilityType                     = _volatilityType
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type SviSmileSectionModel1
    ( d                                            : ICell<Date>
    , forward                                      : ICell<double>
    , sviParameters                                : ICell<Generic.List<double>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<SviSmileSection> ()
(*
    Parameters
*)
    let _d                                         = d
    let _forward                                   = forward
    let _sviParameters                             = sviParameters
    let _dc                                        = dc
(*
    Functions
*)
    let _SviSmileSection                           = cell (fun () -> new SviSmileSection (d.Value, forward.Value, sviParameters.Value, dc.Value))
    let _atmLevel                                  = triv (fun () -> _SviSmileSection.Value.atmLevel())
    let _init                                      = triv (fun () -> _SviSmileSection.Value.init()
                                                                     _SviSmileSection.Value)
    let _maxStrike                                 = triv (fun () -> _SviSmileSection.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _SviSmileSection.Value.minStrike())
    let _dayCounter                                = triv (fun () -> _SviSmileSection.Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> _SviSmileSection.Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> _SviSmileSection.Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> _SviSmileSection.Value.referenceDate())
    let _shift                                     = triv (fun () -> _SviSmileSection.Value.shift())
    let _update                                    = triv (fun () -> _SviSmileSection.Value.update()
                                                                     _SviSmileSection.Value)
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> _SviSmileSection.Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> _SviSmileSection.Value.volatilityType())
    do this.Bind(_SviSmileSection)
(* 
    casting 
*)
    internal new () = new SviSmileSectionModel1(null,null,null,null)
    member internal this.Inject v = _SviSmileSection.Value <- v
    static member Cast (p : ICell<SviSmileSection>) = 
        if p :? SviSmileSectionModel1 then 
            p :?> SviSmileSectionModel1
        else
            let o = new SviSmileSectionModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.forward                            = _forward 
    member this.sviParameters                      = _sviParameters 
    member this.dc                                 = _dc 
    member this.AtmLevel                           = _atmLevel
    member this.Init                               = _init
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.DayCounter                         = _dayCounter
    member this.Density                            strike discount gap   
                                                   = _density strike discount gap 
    member this.DigitalOptionPrice                 strike Type discount gap   
                                                   = _digitalOptionPrice strike Type discount gap 
    member this.ExerciseDate                       = _exerciseDate
    member this.ExerciseTime                       = _exerciseTime
    member this.OptionPrice                        strike Type discount   
                                                   = _optionPrice strike Type discount 
    member this.ReferenceDate                      = _referenceDate
    member this.Shift                              = _shift
    member this.Update                             = _update
    member this.Variance                           strike   
                                                   = _variance strike 
    member this.Vega                               strike discount   
                                                   = _vega strike discount 
    member this.Volatility                         strike volatilityType shift   
                                                   = _volatility strike volatilityType shift 
    member this.Volatility1                        strike   
                                                   = _volatility1 strike 
    member this.VolatilityType                     = _volatilityType
