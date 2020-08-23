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
open System.Numerics

(* <summary>
FFT implementation

  </summary> *)
[<AutoSerializable(true)>]
type FastFourierTransformModel
    ( order                                        : ICell<int>
    ) as this =

    inherit Model<FastFourierTransform> ()
(*
    Parameters
*)
    let _order                                     = order
(*
    Functions
*)
    let _FastFourierTransform                      = cell (fun () -> new FastFourierTransform (order.Value))
    let _inverse_transform                         (input : ICell<Generic.List<Complex>>) (inputBeg : ICell<int>) (inputEnd : ICell<int>) (output : ICell<Generic.List<Complex>>)   
                                                   = triv (fun () -> _FastFourierTransform.Value.inverse_transform(input.Value, inputBeg.Value, inputEnd.Value, output.Value)
                                                                     _FastFourierTransform.Value)
    let _output_size                               = triv (fun () -> _FastFourierTransform.Value.output_size())
    let _transform                                 (input : ICell<Generic.List<Complex>>) (inputBeg : ICell<int>) (inputEnd : ICell<int>) (output : ICell<Generic.List<Complex>>)   
                                                   = triv (fun () -> _FastFourierTransform.Value.transform(input.Value, inputBeg.Value, inputEnd.Value, output.Value)
                                                                     _FastFourierTransform.Value)
    do this.Bind(_FastFourierTransform)

(* 
    Externally visible/bindable properties
*)
    member this.order                              = _order 
    member this.Inverse_transform                  input inputBeg inputEnd output   
                                                   = _inverse_transform input inputBeg inputEnd output 
    member this.Output_size                        = _output_size
    member this.Transform                          input inputBeg inputEnd output   
                                                   = _transform input inputBeg inputEnd output 
