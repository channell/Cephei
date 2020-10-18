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
type FdmDividendHandlerModel
    ( schedule                                     : ICell<DividendSchedule>
    , mesher                                       : ICell<FdmMesher>
    , referenceDate                                : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , equityDirection                              : ICell<int>
    ) as this =

    inherit Model<FdmDividendHandler> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _mesher                                    = mesher
    let _referenceDate                             = referenceDate
    let _dayCounter                                = dayCounter
    let _equityDirection                           = equityDirection
(*
    Functions
*)
    let mutable
        _FdmDividendHandler                        = cell (fun () -> new FdmDividendHandler (schedule.Value, mesher.Value, referenceDate.Value, dayCounter.Value, equityDirection.Value))
    let _applyTo                                   (o : ICell<Object>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmDividendHandler.Value.applyTo(o.Value, t.Value)
                                                                     _FdmDividendHandler.Value)
    let _dividendDates                             = triv (fun () -> _FdmDividendHandler.Value.dividendDates())
    let _dividends                                 = triv (fun () -> _FdmDividendHandler.Value.dividends())
    let _dividendTimes                             = triv (fun () -> _FdmDividendHandler.Value.dividendTimes())
    do this.Bind(_FdmDividendHandler)
(* 
    casting 
*)
    internal new () = new FdmDividendHandlerModel(null,null,null,null,null)
    member internal this.Inject v = _FdmDividendHandler <- v
    static member Cast (p : ICell<FdmDividendHandler>) = 
        if p :? FdmDividendHandlerModel then 
            p :?> FdmDividendHandlerModel
        else
            let o = new FdmDividendHandlerModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.mesher                             = _mesher 
    member this.referenceDate                      = _referenceDate 
    member this.dayCounter                         = _dayCounter 
    member this.equityDirection                    = _equityDirection 
    member this.ApplyTo                            o t   
                                                   = _applyTo o t 
    member this.DividendDates                      = _dividendDates
    member this.Dividends                          = _dividends
    member this.DividendTimes                      = _dividendTimes
