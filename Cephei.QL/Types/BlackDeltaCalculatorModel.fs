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
  Class includes many operations needed for different applications in FX markets, which has special quoation mechanisms, since every price can be expressed in both numeraires.
A parsimonious constructor is chosen, which for example doesn't need a strike. The reason for this is, that we'd like this class to calculate deltas for different strikes many times, e.g. in a numerical routine, which will be the case in the smile setup procedure.
  </summary> *)
[<AutoSerializable(true)>]
type BlackDeltaCalculatorModel
    ( ot                                           : ICell<Option.Type>
    , dt                                           : ICell<DeltaVolQuote.DeltaType>
    , spot                                         : ICell<double>
    , dDiscount                                    : ICell<double>
    , fDiscount                                    : ICell<double>
    , stdDev                                       : ICell<double>
    ) as this =

    inherit Model<BlackDeltaCalculator> ()
(*
    Parameters
*)
    let _ot                                        = ot
    let _dt                                        = dt
    let _spot                                      = spot
    let _dDiscount                                 = dDiscount
    let _fDiscount                                 = fDiscount
    let _stdDev                                    = stdDev
(*
    Functions
*)
    let _BlackDeltaCalculator                      = cell (fun () -> new BlackDeltaCalculator (ot.Value, dt.Value, spot.Value, dDiscount.Value, fDiscount.Value, stdDev.Value))
    let _atmStrike                                 (atmT : ICell<DeltaVolQuote.AtmType>)   
                                                   = cell (fun () -> _BlackDeltaCalculator.Value.atmStrike(atmT.Value))
    let _cumD1                                     (strike : ICell<double>)   
                                                   = cell (fun () -> _BlackDeltaCalculator.Value.cumD1(strike.Value))
    let _cumD2                                     (strike : ICell<double>)   
                                                   = cell (fun () -> _BlackDeltaCalculator.Value.cumD2(strike.Value))
    let _deltaFromStrike                           (strike : ICell<double>)   
                                                   = cell (fun () -> _BlackDeltaCalculator.Value.deltaFromStrike(strike.Value))
    let _nD1                                       (strike : ICell<double>)   
                                                   = cell (fun () -> _BlackDeltaCalculator.Value.nD1(strike.Value))
    let _nD2                                       (strike : ICell<double>)   
                                                   = cell (fun () -> _BlackDeltaCalculator.Value.nD2(strike.Value))
    let _setDeltaType                              (dt : ICell<DeltaVolQuote.DeltaType>)   
                                                   = cell (fun () -> _BlackDeltaCalculator.Value.setDeltaType(dt.Value)
                                                                     _BlackDeltaCalculator.Value)
    let _setOptionType                             (ot : ICell<Option.Type>)   
                                                   = cell (fun () -> _BlackDeltaCalculator.Value.setOptionType(ot.Value)
                                                                     _BlackDeltaCalculator.Value)
    let _strikeFromDelta                           (delta : ICell<double>)   
                                                   = cell (fun () -> _BlackDeltaCalculator.Value.strikeFromDelta(delta.Value))
    do this.Bind(_BlackDeltaCalculator)

(* 
    Externally visible/bindable properties
*)
    member this.ot                                 = _ot 
    member this.dt                                 = _dt 
    member this.spot                               = _spot 
    member this.dDiscount                          = _dDiscount 
    member this.fDiscount                          = _fDiscount 
    member this.stdDev                             = _stdDev 
    member this.AtmStrike                          atmT   
                                                   = _atmStrike atmT 
    member this.CumD1                              strike   
                                                   = _cumD1 strike 
    member this.CumD2                              strike   
                                                   = _cumD2 strike 
    member this.DeltaFromStrike                    strike   
                                                   = _deltaFromStrike strike 
    member this.ND1                                strike   
                                                   = _nD1 strike 
    member this.ND2                                strike   
                                                   = _nD2 strike 
    member this.SetDeltaType                       dt   
                                                   = _setDeltaType dt 
    member this.SetOptionType                      ot   
                                                   = _setOptionType ot 
    member this.StrikeFromDelta                    delta   
                                                   = _strikeFromDelta delta 
