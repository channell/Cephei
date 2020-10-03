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

Constructor
  </summary> *)
[<AutoSerializable(true)>]
type FdBlackScholesRebateEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , tGrid                                        : ICell<int>
    , xGrid                                        : ICell<int>
    , dampingSteps                                 : ICell<int>
    , schemeDesc                                   : ICell<FdmSchemeDesc>
    , localVol                                     : ICell<bool>
    , illegalLocalVolOverwrite                     : ICell<Nullable<double>>
    ) as this =

    inherit Model<FdBlackScholesRebateEngine> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _tGrid                                     = tGrid
    let _xGrid                                     = xGrid
    let _dampingSteps                              = dampingSteps
    let _schemeDesc                                = schemeDesc
    let _localVol                                  = localVol
    let _illegalLocalVolOverwrite                  = illegalLocalVolOverwrite
(*
    Functions
*)
    let _FdBlackScholesRebateEngine                = cell (fun () -> new FdBlackScholesRebateEngine (Process.Value, tGrid.Value, xGrid.Value, dampingSteps.Value, schemeDesc.Value, localVol.Value, illegalLocalVolOverwrite.Value))
    do this.Bind(_FdBlackScholesRebateEngine)
(* 
    casting 
*)
    internal new () = FdBlackScholesRebateEngineModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _FdBlackScholesRebateEngine.Value <- v
    static member Cast (p : ICell<FdBlackScholesRebateEngine>) = 
        if p :? FdBlackScholesRebateEngineModel then 
            p :?> FdBlackScholesRebateEngineModel
        else
            let o = new FdBlackScholesRebateEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.tGrid                              = _tGrid 
    member this.xGrid                              = _xGrid 
    member this.dampingSteps                       = _dampingSteps 
    member this.schemeDesc                         = _schemeDesc 
    member this.localVol                           = _localVol 
    member this.illegalLocalVolOverwrite           = _illegalLocalVolOverwrite 
