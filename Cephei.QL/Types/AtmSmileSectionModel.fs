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
type AtmSmileSectionModel
    ( source                                       : ICell<SmileSection>
    , atm                                          : ICell<Nullable<double>>
    ) as this =

    inherit Model<AtmSmileSection> ()
(*
    Parameters
*)
    let _source                                    = source
    let _atm                                       = atm
(*
    Functions
*)
    let mutable
        _AtmSmileSection                           = cell (fun () -> new AtmSmileSection (source.Value, atm.Value))
    let _atmLevel                                  = triv (fun () -> _AtmSmileSection.Value.atmLevel())
    let _dayCounter                                = triv (fun () -> _AtmSmileSection.Value.dayCounter())
    let _exerciseDate                              = triv (fun () -> _AtmSmileSection.Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> _AtmSmileSection.Value.exerciseTime())
    let _maxStrike                                 = triv (fun () -> _AtmSmileSection.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _AtmSmileSection.Value.minStrike())
    let _referenceDate                             = triv (fun () -> _AtmSmileSection.Value.referenceDate())
    let _shift                                     = triv (fun () -> _AtmSmileSection.Value.shift())
    let _volatilityType                            = triv (fun () -> _AtmSmileSection.Value.volatilityType())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _AtmSmileSection.Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _AtmSmileSection.Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> _AtmSmileSection.Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _update                                    = triv (fun () -> _AtmSmileSection.Value.update()
                                                                     _AtmSmileSection.Value)
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> _AtmSmileSection.Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> _AtmSmileSection.Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> _AtmSmileSection.Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> _AtmSmileSection.Value.volatility(strike.Value))
    do this.Bind(_AtmSmileSection)
(* 
    casting 
*)
    internal new () = new AtmSmileSectionModel(null,null)
    member internal this.Inject v = _AtmSmileSection <- v
    static member Cast (p : ICell<AtmSmileSection>) = 
        if p :? AtmSmileSectionModel then 
            p :?> AtmSmileSectionModel
        else
            let o = new AtmSmileSectionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.source                             = _source 
    member this.atm                                = _atm 
    member this.AtmLevel                           = _atmLevel
    member this.DayCounter                         = _dayCounter
    member this.ExerciseDate                       = _exerciseDate
    member this.ExerciseTime                       = _exerciseTime
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.ReferenceDate                      = _referenceDate
    member this.Shift                              = _shift
    member this.VolatilityType                     = _volatilityType
    member this.Density                            strike discount gap   
                                                   = _density strike discount gap 
    member this.DigitalOptionPrice                 strike Type discount gap   
                                                   = _digitalOptionPrice strike Type discount gap 
    member this.OptionPrice                        strike Type discount   
                                                   = _optionPrice strike Type discount 
    member this.Update                             = _update
    member this.Variance                           strike   
                                                   = _variance strike 
    member this.Vega                               strike discount   
                                                   = _vega strike discount 
    member this.Volatility                         strike volatilityType shift   
                                                   = _volatility strike volatilityType shift 
    member this.Volatility1                        strike   
                                                   = _volatility1 strike 
