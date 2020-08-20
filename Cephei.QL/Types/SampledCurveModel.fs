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
  Initially the class will contain one indexed curve

  </summary> *)
[<AutoSerializable(true)>]
type SampledCurveModel
    ( grid                                         : ICell<Vector>
    ) as this =

    inherit Model<SampledCurve> ()
(*
    Parameters
*)
    let _grid                                      = grid
(*
    Functions
*)
    let _SampledCurve                              = cell (fun () -> new SampledCurve (grid.Value))
    let _Clone                                     = cell (fun () -> _SampledCurve.Value.Clone())
    let _empty                                     = cell (fun () -> _SampledCurve.Value.empty())
    let _firstDerivativeAtCenter                   = cell (fun () -> _SampledCurve.Value.firstDerivativeAtCenter())
    let _grid                                      = cell (fun () -> _SampledCurve.Value.grid())
    let _gridValue                                 (i : ICell<int>)   
                                                   = cell (fun () -> _SampledCurve.Value.gridValue(i.Value))
    let _regrid                                    (new_grid : ICell<Vector>) (func : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _SampledCurve.Value.regrid(new_grid.Value, func.Value)
                                                                     _SampledCurve.Value)
    let _regrid1                                   (new_grid : ICell<Vector>)   
                                                   = cell (fun () -> _SampledCurve.Value.regrid(new_grid.Value)
                                                                     _SampledCurve.Value)
    let _regridLogGrid                             (min : ICell<double>) (max : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.regridLogGrid(min.Value, max.Value)
                                                                     _SampledCurve.Value)
    let _sample                                    (f : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _SampledCurve.Value.sample(f.Value)
                                                                     _SampledCurve.Value)
    let _scaleGrid                                 (s : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.scaleGrid(s.Value)
                                                                     _SampledCurve.Value)
    let _secondDerivativeAtCenter                  = cell (fun () -> _SampledCurve.Value.secondDerivativeAtCenter())
    let _setGrid                                   (g : ICell<Vector>)   
                                                   = cell (fun () -> _SampledCurve.Value.setGrid(g.Value)
                                                                     _SampledCurve.Value)
    let _setLogGrid                                (min : ICell<double>) (max : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.setLogGrid(min.Value, max.Value)
                                                                     _SampledCurve.Value)
    let _setValue                                  (i : ICell<int>) (v : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.setValue(i.Value, v.Value)
                                                                     _SampledCurve.Value)
    let _setValues                                 (g : ICell<Vector>)   
                                                   = cell (fun () -> _SampledCurve.Value.setValues(g.Value)
                                                                     _SampledCurve.Value)
    let _shiftGrid                                 (s : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.shiftGrid(s.Value)
                                                                     _SampledCurve.Value)
    let _size                                      = cell (fun () -> _SampledCurve.Value.size())
    let _transform                                 (x : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _SampledCurve.Value.transform(x.Value))
    let _transformGrid                             (x : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _SampledCurve.Value.transformGrid(x.Value))
    let _value                                     (i : ICell<int>)   
                                                   = cell (fun () -> _SampledCurve.Value.value(i.Value))
    let _valueAtCenter                             = cell (fun () -> _SampledCurve.Value.valueAtCenter())
    let _values                                    = cell (fun () -> _SampledCurve.Value.values())
    do this.Bind(_SampledCurve)

(* 
    Externally visible/bindable properties
*)
    member this.grid                               = _grid 
    member this.Clone                              = _Clone
    member this.Empty                              = _empty
    member this.FirstDerivativeAtCenter            = _firstDerivativeAtCenter
    member this.Grid                               = _grid
    member this.GridValue                          i   
                                                   = _gridValue i 
    member this.Regrid                             new_grid func   
                                                   = _regrid new_grid func 
    member this.Regrid1                            new_grid   
                                                   = _regrid1 new_grid 
    member this.RegridLogGrid                      min max   
                                                   = _regridLogGrid min max 
    member this.Sample                             f   
                                                   = _sample f 
    member this.ScaleGrid                          s   
                                                   = _scaleGrid s 
    member this.SecondDerivativeAtCenter           = _secondDerivativeAtCenter
    member this.SetGrid                            g   
                                                   = _setGrid g 
    member this.SetLogGrid                         min max   
                                                   = _setLogGrid min max 
    member this.SetValue                           i v   
                                                   = _setValue i v 
    member this.SetValues                          g   
                                                   = _setValues g 
    member this.ShiftGrid                          s   
                                                   = _shiftGrid s 
    member this.Size                               = _size
    member this.Transform                          x   
                                                   = _transform x 
    member this.TransformGrid                      x   
                                                   = _transformGrid x 
    member this.Value                              i   
                                                   = _value i 
    member this.ValueAtCenter                      = _valueAtCenter
    member this.Values                             = _values
(* <summary>
  Initially the class will contain one indexed curve

  </summary> *)
[<AutoSerializable(true)>]
type SampledCurveModel1
    ( gridSize                                     : ICell<int>
    ) as this =

    inherit Model<SampledCurve> ()
(*
    Parameters
*)
    let _gridSize                                  = gridSize
(*
    Functions
*)
    let _SampledCurve                              = cell (fun () -> new SampledCurve (gridSize.Value))
    let _Clone                                     = cell (fun () -> _SampledCurve.Value.Clone())
    let _empty                                     = cell (fun () -> _SampledCurve.Value.empty())
    let _firstDerivativeAtCenter                   = cell (fun () -> _SampledCurve.Value.firstDerivativeAtCenter())
    let _grid                                      = cell (fun () -> _SampledCurve.Value.grid())
    let _gridValue                                 (i : ICell<int>)   
                                                   = cell (fun () -> _SampledCurve.Value.gridValue(i.Value))
    let _regrid                                    (new_grid : ICell<Vector>) (func : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _SampledCurve.Value.regrid(new_grid.Value, func.Value)
                                                                     _SampledCurve.Value)
    let _regrid1                                   (new_grid : ICell<Vector>)   
                                                   = cell (fun () -> _SampledCurve.Value.regrid(new_grid.Value)
                                                                     _SampledCurve.Value)
    let _regridLogGrid                             (min : ICell<double>) (max : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.regridLogGrid(min.Value, max.Value)
                                                                     _SampledCurve.Value)
    let _sample                                    (f : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _SampledCurve.Value.sample(f.Value)
                                                                     _SampledCurve.Value)
    let _scaleGrid                                 (s : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.scaleGrid(s.Value)
                                                                     _SampledCurve.Value)
    let _secondDerivativeAtCenter                  = cell (fun () -> _SampledCurve.Value.secondDerivativeAtCenter())
    let _setGrid                                   (g : ICell<Vector>)   
                                                   = cell (fun () -> _SampledCurve.Value.setGrid(g.Value)
                                                                     _SampledCurve.Value)
    let _setLogGrid                                (min : ICell<double>) (max : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.setLogGrid(min.Value, max.Value)
                                                                     _SampledCurve.Value)
    let _setValue                                  (i : ICell<int>) (v : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.setValue(i.Value, v.Value)
                                                                     _SampledCurve.Value)
    let _setValues                                 (g : ICell<Vector>)   
                                                   = cell (fun () -> _SampledCurve.Value.setValues(g.Value)
                                                                     _SampledCurve.Value)
    let _shiftGrid                                 (s : ICell<double>)   
                                                   = cell (fun () -> _SampledCurve.Value.shiftGrid(s.Value)
                                                                     _SampledCurve.Value)
    let _size                                      = cell (fun () -> _SampledCurve.Value.size())
    let _transform                                 (x : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _SampledCurve.Value.transform(x.Value))
    let _transformGrid                             (x : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _SampledCurve.Value.transformGrid(x.Value))
    let _value                                     (i : ICell<int>)   
                                                   = cell (fun () -> _SampledCurve.Value.value(i.Value))
    let _valueAtCenter                             = cell (fun () -> _SampledCurve.Value.valueAtCenter())
    let _values                                    = cell (fun () -> _SampledCurve.Value.values())
    do this.Bind(_SampledCurve)

(* 
    Externally visible/bindable properties
*)
    member this.gridSize                           = _gridSize 
    member this.Clone                              = _Clone
    member this.Empty                              = _empty
    member this.FirstDerivativeAtCenter            = _firstDerivativeAtCenter
    member this.Grid                               = _grid
    member this.GridValue                          i   
                                                   = _gridValue i 
    member this.Regrid                             new_grid func   
                                                   = _regrid new_grid func 
    member this.Regrid1                            new_grid   
                                                   = _regrid1 new_grid 
    member this.RegridLogGrid                      min max   
                                                   = _regridLogGrid min max 
    member this.Sample                             f   
                                                   = _sample f 
    member this.ScaleGrid                          s   
                                                   = _scaleGrid s 
    member this.SecondDerivativeAtCenter           = _secondDerivativeAtCenter
    member this.SetGrid                            g   
                                                   = _setGrid g 
    member this.SetLogGrid                         min max   
                                                   = _setLogGrid min max 
    member this.SetValue                           i v   
                                                   = _setValue i v 
    member this.SetValues                          g   
                                                   = _setValues g 
    member this.ShiftGrid                          s   
                                                   = _shiftGrid s 
    member this.Size                               = _size
    member this.Transform                          x   
                                                   = _transform x 
    member this.TransformGrid                      x   
                                                   = _transformGrid x 
    member this.Value                              i   
                                                   = _value i 
    member this.ValueAtCenter                      = _valueAtCenter
    member this.Values                             = _values
