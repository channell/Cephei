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
  It includes the various delta quotation types in FX markets as well as ATM types.
Additional constructor, if special atm quote is used
  </summary> *)
[<AutoSerializable(true)>]
type DeltaVolQuoteModel
    ( vol                                          : ICell<Handle<Quote>>
    , deltaType                                    : ICell<DeltaVolQuote.DeltaType>
    , maturity                                     : ICell<double>
    , atmType                                      : ICell<DeltaVolQuote.AtmType>
    ) as this =

    inherit Model<DeltaVolQuote> ()
(*
    Parameters
*)
    let _vol                                       = vol
    let _deltaType                                 = deltaType
    let _maturity                                  = maturity
    let _atmType                                   = atmType
(*
    Functions
*)
    let mutable
        _DeltaVolQuote                             = make (fun () -> new DeltaVolQuote (vol.Value, deltaType.Value, maturity.Value, atmType.Value))
    let _atmType                                   = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.atmType())
    let _delta                                     = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.delta())
    let _deltaType                                 = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.deltaType())
    let _isValid                                   = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.isValid())
    let _maturity                                  = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.maturity())
    let _update                                    = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.update()
                                                                                    _DeltaVolQuote.Value)
    let _value                                     = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.value())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.registerWith(handler.Value)
                                                                                    _DeltaVolQuote.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.unregisterWith(handler.Value)
                                                                                    _DeltaVolQuote.Value)
    do this.Bind(_DeltaVolQuote)
(* 
    casting 
*)
    internal new () = new DeltaVolQuoteModel(null,null,null,null)
    member internal this.Inject v = _DeltaVolQuote <- v
    static member Cast (p : ICell<DeltaVolQuote>) = 
        if p :? DeltaVolQuoteModel then 
            p :?> DeltaVolQuoteModel
        else
            let o = new DeltaVolQuoteModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.vol                                = _vol 
    member this.deltaType                          = _deltaType 
    member this.maturity                           = _maturity 
    member this.atmType                            = _atmType 
    member this.AtmType                            = _atmType
    member this.Delta                              = _delta
    member this.DeltaType                          = _deltaType
    member this.IsValid                            = _isValid
    member this.Maturity                           = _maturity
    member this.Update                             = _update
    member this.Value                              = _value
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  It includes the various delta quotation types in FX markets as well as ATM types.
Standard constructor delta vs vol.
  </summary> *)
[<AutoSerializable(true)>]
type DeltaVolQuoteModel1
    ( delta                                        : ICell<double>
    , vol                                          : ICell<Handle<Quote>>
    , maturity                                     : ICell<double>
    , deltaType                                    : ICell<DeltaVolQuote.DeltaType>
    ) as this =

    inherit Model<DeltaVolQuote> ()
(*
    Parameters
*)
    let _delta                                     = delta
    let _vol                                       = vol
    let _maturity                                  = maturity
    let _deltaType                                 = deltaType
(*
    Functions
*)
    let mutable
        _DeltaVolQuote                             = make (fun () -> new DeltaVolQuote (delta.Value, vol.Value, maturity.Value, deltaType.Value))
    let _atmType                                   = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.atmType())
    let _delta                                     = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.delta())
    let _deltaType                                 = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.deltaType())
    let _isValid                                   = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.isValid())
    let _maturity                                  = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.maturity())
    let _update                                    = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.update()
                                                                                    _DeltaVolQuote.Value)
    let _value                                     = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.value())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.registerWith(handler.Value)
                                                                                    _DeltaVolQuote.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _DeltaVolQuote (fun () -> _DeltaVolQuote.Value.unregisterWith(handler.Value)
                                                                                    _DeltaVolQuote.Value)
    do this.Bind(_DeltaVolQuote)
(* 
    casting 
*)
    internal new () = new DeltaVolQuoteModel1(null,null,null,null)
    member internal this.Inject v = _DeltaVolQuote <- v
    static member Cast (p : ICell<DeltaVolQuote>) = 
        if p :? DeltaVolQuoteModel1 then 
            p :?> DeltaVolQuoteModel1
        else
            let o = new DeltaVolQuoteModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.delta                              = _delta 
    member this.vol                                = _vol 
    member this.maturity                           = _maturity 
    member this.deltaType                          = _deltaType 
    member this.AtmType                            = _atmType
    member this.Delta                              = _delta
    member this.DeltaType                          = _deltaType
    member this.IsValid                            = _isValid
    member this.Maturity                           = _maturity
    member this.Update                             = _update
    member this.Value                              = _value
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
