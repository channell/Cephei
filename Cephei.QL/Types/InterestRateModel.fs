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
  This class encapsulate the interest rate compounding algebra. It manages day-counting conventions, compounding conventions, conversion between different conventions, discount/compound factor calculations, and implied/equivalent rate calculations.  Converted rates are checked against known good results
! Standard constructor
  </summary> *)
[<AutoSerializable(true)>]
type InterestRateModel
    ( r                                            : ICell<double>
    , dc                                           : ICell<DayCounter>
    , comp                                         : ICell<Compounding>
    , freq                                         : ICell<Frequency>
    ) as this =

    inherit Model<InterestRate> ()
(*
    Parameters
*)
    let _r                                         = r
    let _dc                                        = dc
    let _comp                                      = comp
    let _freq                                      = freq
(*
    Functions
*)
    let _InterestRate                              = cell (fun () -> new InterestRate (r.Value, dc.Value, comp.Value, freq.Value))
    let _compoundFactor                            (t : ICell<double>)   
                                                   = triv (fun () -> _InterestRate.Value.compoundFactor(t.Value))
    let _compoundFactor1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (refStart : ICell<Date>) (refEnd : ICell<Date>)   
                                                   = triv (fun () -> _InterestRate.Value.compoundFactor(d1.Value, d2.Value, refStart.Value, refEnd.Value))
    let _compounding                               = triv (fun () -> _InterestRate.Value.compounding())
    let _dayCounter                                = triv (fun () -> _InterestRate.Value.dayCounter())
    let _discountFactor                            (d1 : ICell<Date>) (d2 : ICell<Date>) (refStart : ICell<Date>) (refEnd : ICell<Date>)   
                                                   = triv (fun () -> _InterestRate.Value.discountFactor(d1.Value, d2.Value, refStart.Value, refEnd.Value))
    let _discountFactor1                           (t : ICell<double>)   
                                                   = triv (fun () -> _InterestRate.Value.discountFactor(t.Value))
    let _equivalentRate                            (resultDC : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (d1 : ICell<Date>) (d2 : ICell<Date>) (refStart : ICell<Date>) (refEnd : ICell<Date>)   
                                                   = triv (fun () -> _InterestRate.Value.equivalentRate(resultDC.Value, comp.Value, freq.Value, d1.Value, d2.Value, refStart.Value, refEnd.Value))
    let _equivalentRate1                           (comp : ICell<Compounding>) (freq : ICell<Frequency>) (t : ICell<double>)   
                                                   = triv (fun () -> _InterestRate.Value.equivalentRate(comp.Value, freq.Value, t.Value))
    let _frequency                                 = triv (fun () -> _InterestRate.Value.frequency())
    let _rate                                      = triv (fun () -> _InterestRate.Value.rate())
    let _ToString                                  = triv (fun () -> _InterestRate.Value.ToString())
    let _value                                     = triv (fun () -> _InterestRate.Value.value())
    do this.Bind(_InterestRate)

(* 
    Externally visible/bindable properties
*)
    member this.r                                  = _r 
    member this.dc                                 = _dc 
    member this.comp                               = _comp 
    member this.freq                               = _freq 
    member this.CompoundFactor                     t   
                                                   = _compoundFactor t 
    member this.CompoundFactor1                    d1 d2 refStart refEnd   
                                                   = _compoundFactor1 d1 d2 refStart refEnd 
    member this.Compounding                        = _compounding
    member this.DayCounter                         = _dayCounter
    member this.DiscountFactor                     d1 d2 refStart refEnd   
                                                   = _discountFactor d1 d2 refStart refEnd 
    member this.DiscountFactor1                    t   
                                                   = _discountFactor1 t 
    member this.EquivalentRate                     resultDC comp freq d1 d2 refStart refEnd   
                                                   = _equivalentRate resultDC comp freq d1 d2 refStart refEnd 
    member this.EquivalentRate1                    comp freq t   
                                                   = _equivalentRate1 comp freq t 
    member this.Frequency                          = _frequency
    member this.Rate                               = _rate
    member this.ToString                           = _ToString
    member this.Value                              = _value
(* <summary>
  This class encapsulate the interest rate compounding algebra. It manages day-counting conventions, compounding conventions, conversion between different conventions, discount/compound factor calculations, and implied/equivalent rate calculations.  Converted rates are checked against known good results
! Default constructor returning a null interest rate.
  </summary> *)
[<AutoSerializable(true)>]
type InterestRateModel1
    () as this =
    inherit Model<InterestRate> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _InterestRate                              = cell (fun () -> new InterestRate ())
    let _compoundFactor                            (t : ICell<double>)   
                                                   = triv (fun () -> _InterestRate.Value.compoundFactor(t.Value))
    let _compoundFactor1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (refStart : ICell<Date>) (refEnd : ICell<Date>)   
                                                   = triv (fun () -> _InterestRate.Value.compoundFactor(d1.Value, d2.Value, refStart.Value, refEnd.Value))
    let _compounding                               = triv (fun () -> _InterestRate.Value.compounding())
    let _dayCounter                                = triv (fun () -> _InterestRate.Value.dayCounter())
    let _discountFactor                            (d1 : ICell<Date>) (d2 : ICell<Date>) (refStart : ICell<Date>) (refEnd : ICell<Date>)   
                                                   = triv (fun () -> _InterestRate.Value.discountFactor(d1.Value, d2.Value, refStart.Value, refEnd.Value))
    let _discountFactor1                           (t : ICell<double>)   
                                                   = triv (fun () -> _InterestRate.Value.discountFactor(t.Value))
    let _equivalentRate                            (resultDC : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (d1 : ICell<Date>) (d2 : ICell<Date>) (refStart : ICell<Date>) (refEnd : ICell<Date>)   
                                                   = triv (fun () -> _InterestRate.Value.equivalentRate(resultDC.Value, comp.Value, freq.Value, d1.Value, d2.Value, refStart.Value, refEnd.Value))
    let _equivalentRate1                           (comp : ICell<Compounding>) (freq : ICell<Frequency>) (t : ICell<double>)   
                                                   = triv (fun () -> _InterestRate.Value.equivalentRate(comp.Value, freq.Value, t.Value))
    let _frequency                                 = triv (fun () -> _InterestRate.Value.frequency())
    let _rate                                      = triv (fun () -> _InterestRate.Value.rate())
    let _ToString                                  = triv (fun () -> _InterestRate.Value.ToString())
    let _value                                     = triv (fun () -> _InterestRate.Value.value())
    do this.Bind(_InterestRate)

(* 
    Externally visible/bindable properties
*)
    member this.CompoundFactor                     t   
                                                   = _compoundFactor t 
    member this.CompoundFactor1                    d1 d2 refStart refEnd   
                                                   = _compoundFactor1 d1 d2 refStart refEnd 
    member this.Compounding                        = _compounding
    member this.DayCounter                         = _dayCounter
    member this.DiscountFactor                     d1 d2 refStart refEnd   
                                                   = _discountFactor d1 d2 refStart refEnd 
    member this.DiscountFactor1                    t   
                                                   = _discountFactor1 t 
    member this.EquivalentRate                     resultDC comp freq d1 d2 refStart refEnd   
                                                   = _equivalentRate resultDC comp freq d1 d2 refStart refEnd 
    member this.EquivalentRate1                    comp freq t   
                                                   = _equivalentRate1 comp freq t 
    member this.Frequency                          = _frequency
    member this.Rate                               = _rate
    member this.ToString                           = _ToString
    member this.Value                              = _value
