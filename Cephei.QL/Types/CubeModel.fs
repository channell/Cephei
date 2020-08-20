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
type CubeModel
    ( o                                            : ICell<Cube.Cube>
    ) as this =

    inherit Model<Cube> ()
(*
    Parameters
*)
    let _o                                         = o
(*
    Functions
*)
    let _Cube                                      = cell (fun () -> new Cube (o.Value))
    let _browse                                    = cell (fun () -> _Cube.Value.browse())
    let _clone                                     (o : ICell<Cube.Cube>)   
                                                   = cell (fun () -> _Cube.Value.clone(o.Value))
    let _expandLayers                              (i : ICell<int>) (expandOptionTimes : ICell<bool>) (j : ICell<int>) (expandSwapLengths : ICell<bool>)   
                                                   = cell (fun () -> _Cube.Value.expandLayers(i.Value, expandOptionTimes.Value, j.Value, expandSwapLengths.Value)
                                                                     _Cube.Value)
    let _optionDates                               = cell (fun () -> _Cube.Value.optionDates())
    let _optionTimes                               = cell (fun () -> _Cube.Value.optionTimes())
    let _points                                    = cell (fun () -> _Cube.Value.points())
    let _setElement                                (IndexOfLayer : ICell<int>) (IndexOfRow : ICell<int>) (IndexOfColumn : ICell<int>) (x : ICell<double>)   
                                                   = cell (fun () -> _Cube.Value.setElement(IndexOfLayer.Value, IndexOfRow.Value, IndexOfColumn.Value, x.Value)
                                                                     _Cube.Value)
    let _setLayer                                  (i : ICell<int>) (x : ICell<Matrix>)   
                                                   = cell (fun () -> _Cube.Value.setLayer(i.Value, x.Value)
                                                                     _Cube.Value)
    let _setPoint                                  (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (optionTime : ICell<double>) (swapLength : ICell<double>) (point : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _Cube.Value.setPoint(optionDate.Value, swapTenor.Value, optionTime.Value, swapLength.Value, point.Value)
                                                                     _Cube.Value)
    let _setPoints                                 (x : ICell<Generic.List<Matrix>>)   
                                                   = cell (fun () -> _Cube.Value.setPoints(x.Value)
                                                                     _Cube.Value)
    let _swapLengths                               = cell (fun () -> _Cube.Value.swapLengths())
    let _swapTenors                                = cell (fun () -> _Cube.Value.swapTenors())
    let _updateInterpolators                       = cell (fun () -> _Cube.Value.updateInterpolators()
                                                                     _Cube.Value)
    let _value                                     (optionTime : ICell<double>) (swapLength : ICell<double>)   
                                                   = cell (fun () -> _Cube.Value.value(optionTime.Value, swapLength.Value))
    do this.Bind(_Cube)

(* 
    Externally visible/bindable properties
*)
    member this.o                                  = _o 
    member this.Browse                             = _browse
    member this.Clone                              o   
                                                   = _clone o 
    member this.ExpandLayers                       i expandOptionTimes j expandSwapLengths   
                                                   = _expandLayers i expandOptionTimes j expandSwapLengths 
    member this.OptionDates                        = _optionDates
    member this.OptionTimes                        = _optionTimes
    member this.Points                             = _points
    member this.SetElement                         IndexOfLayer IndexOfRow IndexOfColumn x   
                                                   = _setElement IndexOfLayer IndexOfRow IndexOfColumn x 
    member this.SetLayer                           i x   
                                                   = _setLayer i x 
    member this.SetPoint                           optionDate swapTenor optionTime swapLength point   
                                                   = _setPoint optionDate swapTenor optionTime swapLength point 
    member this.SetPoints                          x   
                                                   = _setPoints x 
    member this.SwapLengths                        = _swapLengths
    member this.SwapTenors                         = _swapTenors
    member this.UpdateInterpolators                = _updateInterpolators
    member this.Value                              optionTime swapLength   
                                                   = _value optionTime swapLength 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type CubeModel1
    ( optionDates                                  : ICell<Generic.List<Date>>
    , swapTenors                                   : ICell<Generic.List<Period>>
    , optionTimes                                  : ICell<Generic.List<double>>
    , swapLengths                                  : ICell<Generic.List<double>>
    , nLayers                                      : ICell<int>
    , extrapolation                                : ICell<bool>
    , backwardFlat                                 : ICell<bool>
    ) as this =

    inherit Model<Cube> ()
(*
    Parameters
*)
    let _optionDates                               = optionDates
    let _swapTenors                                = swapTenors
    let _optionTimes                               = optionTimes
    let _swapLengths                               = swapLengths
    let _nLayers                                   = nLayers
    let _extrapolation                             = extrapolation
    let _backwardFlat                              = backwardFlat
(*
    Functions
*)
    let _Cube                                      = cell (fun () -> new Cube (optionDates.Value, swapTenors.Value, optionTimes.Value, swapLengths.Value, nLayers.Value, extrapolation.Value, backwardFlat.Value))
    let _browse                                    = cell (fun () -> _Cube.Value.browse())
    let _clone                                     (o : ICell<Cube.Cube>)   
                                                   = cell (fun () -> _Cube.Value.clone(o.Value))
    let _expandLayers                              (i : ICell<int>) (expandOptionTimes : ICell<bool>) (j : ICell<int>) (expandSwapLengths : ICell<bool>)   
                                                   = cell (fun () -> _Cube.Value.expandLayers(i.Value, expandOptionTimes.Value, j.Value, expandSwapLengths.Value)
                                                                     _Cube.Value)
    let _optionDates                               = cell (fun () -> _Cube.Value.optionDates())
    let _optionTimes                               = cell (fun () -> _Cube.Value.optionTimes())
    let _points                                    = cell (fun () -> _Cube.Value.points())
    let _setElement                                (IndexOfLayer : ICell<int>) (IndexOfRow : ICell<int>) (IndexOfColumn : ICell<int>) (x : ICell<double>)   
                                                   = cell (fun () -> _Cube.Value.setElement(IndexOfLayer.Value, IndexOfRow.Value, IndexOfColumn.Value, x.Value)
                                                                     _Cube.Value)
    let _setLayer                                  (i : ICell<int>) (x : ICell<Matrix>)   
                                                   = cell (fun () -> _Cube.Value.setLayer(i.Value, x.Value)
                                                                     _Cube.Value)
    let _setPoint                                  (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (optionTime : ICell<double>) (swapLength : ICell<double>) (point : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _Cube.Value.setPoint(optionDate.Value, swapTenor.Value, optionTime.Value, swapLength.Value, point.Value)
                                                                     _Cube.Value)
    let _setPoints                                 (x : ICell<Generic.List<Matrix>>)   
                                                   = cell (fun () -> _Cube.Value.setPoints(x.Value)
                                                                     _Cube.Value)
    let _swapLengths                               = cell (fun () -> _Cube.Value.swapLengths())
    let _swapTenors                                = cell (fun () -> _Cube.Value.swapTenors())
    let _updateInterpolators                       = cell (fun () -> _Cube.Value.updateInterpolators()
                                                                     _Cube.Value)
    let _value                                     (optionTime : ICell<double>) (swapLength : ICell<double>)   
                                                   = cell (fun () -> _Cube.Value.value(optionTime.Value, swapLength.Value))
    do this.Bind(_Cube)

(* 
    Externally visible/bindable properties
*)
    member this.optionDates                        = _optionDates 
    member this.swapTenors                         = _swapTenors 
    member this.optionTimes                        = _optionTimes 
    member this.swapLengths                        = _swapLengths 
    member this.nLayers                            = _nLayers 
    member this.extrapolation                      = _extrapolation 
    member this.backwardFlat                       = _backwardFlat 
    member this.Browse                             = _browse
    member this.Clone                              o   
                                                   = _clone o 
    member this.ExpandLayers                       i expandOptionTimes j expandSwapLengths   
                                                   = _expandLayers i expandOptionTimes j expandSwapLengths 
    member this.OptionDates                        = _optionDates
    member this.OptionTimes                        = _optionTimes
    member this.Points                             = _points
    member this.SetElement                         IndexOfLayer IndexOfRow IndexOfColumn x   
                                                   = _setElement IndexOfLayer IndexOfRow IndexOfColumn x 
    member this.SetLayer                           i x   
                                                   = _setLayer i x 
    member this.SetPoint                           optionDate swapTenor optionTime swapLength point   
                                                   = _setPoint optionDate swapTenor optionTime swapLength point 
    member this.SetPoints                          x   
                                                   = _setPoints x 
    member this.SwapLengths                        = _swapLengths
    member this.SwapTenors                         = _swapTenors
    member this.UpdateInterpolators                = _updateInterpolators
    member this.Value                              optionTime swapLength   
                                                   = _value optionTime swapLength 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type CubeModel2
    () as this =
    inherit Model<Cube> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Cube                                      = cell (fun () -> new Cube ())
    let _browse                                    = cell (fun () -> _Cube.Value.browse())
    let _clone                                     (o : ICell<Cube.Cube>)   
                                                   = cell (fun () -> _Cube.Value.clone(o.Value))
    let _expandLayers                              (i : ICell<int>) (expandOptionTimes : ICell<bool>) (j : ICell<int>) (expandSwapLengths : ICell<bool>)   
                                                   = cell (fun () -> _Cube.Value.expandLayers(i.Value, expandOptionTimes.Value, j.Value, expandSwapLengths.Value)
                                                                     _Cube.Value)
    let _optionDates                               = cell (fun () -> _Cube.Value.optionDates())
    let _optionTimes                               = cell (fun () -> _Cube.Value.optionTimes())
    let _points                                    = cell (fun () -> _Cube.Value.points())
    let _setElement                                (IndexOfLayer : ICell<int>) (IndexOfRow : ICell<int>) (IndexOfColumn : ICell<int>) (x : ICell<double>)   
                                                   = cell (fun () -> _Cube.Value.setElement(IndexOfLayer.Value, IndexOfRow.Value, IndexOfColumn.Value, x.Value)
                                                                     _Cube.Value)
    let _setLayer                                  (i : ICell<int>) (x : ICell<Matrix>)   
                                                   = cell (fun () -> _Cube.Value.setLayer(i.Value, x.Value)
                                                                     _Cube.Value)
    let _setPoint                                  (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (optionTime : ICell<double>) (swapLength : ICell<double>) (point : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _Cube.Value.setPoint(optionDate.Value, swapTenor.Value, optionTime.Value, swapLength.Value, point.Value)
                                                                     _Cube.Value)
    let _setPoints                                 (x : ICell<Generic.List<Matrix>>)   
                                                   = cell (fun () -> _Cube.Value.setPoints(x.Value)
                                                                     _Cube.Value)
    let _swapLengths                               = cell (fun () -> _Cube.Value.swapLengths())
    let _swapTenors                                = cell (fun () -> _Cube.Value.swapTenors())
    let _updateInterpolators                       = cell (fun () -> _Cube.Value.updateInterpolators()
                                                                     _Cube.Value)
    let _value                                     (optionTime : ICell<double>) (swapLength : ICell<double>)   
                                                   = cell (fun () -> _Cube.Value.value(optionTime.Value, swapLength.Value))
    do this.Bind(_Cube)

(* 
    Externally visible/bindable properties
*)
    member this.Browse                             = _browse
    member this.Clone                              o   
                                                   = _clone o 
    member this.ExpandLayers                       i expandOptionTimes j expandSwapLengths   
                                                   = _expandLayers i expandOptionTimes j expandSwapLengths 
    member this.OptionDates                        = _optionDates
    member this.OptionTimes                        = _optionTimes
    member this.Points                             = _points
    member this.SetElement                         IndexOfLayer IndexOfRow IndexOfColumn x   
                                                   = _setElement IndexOfLayer IndexOfRow IndexOfColumn x 
    member this.SetLayer                           i x   
                                                   = _setLayer i x 
    member this.SetPoint                           optionDate swapTenor optionTime swapLength point   
                                                   = _setPoint optionDate swapTenor optionTime swapLength point 
    member this.SetPoints                          x   
                                                   = _setPoints x 
    member this.SwapLengths                        = _swapLengths
    member this.SwapTenors                         = _swapTenors
    member this.UpdateInterpolators                = _updateInterpolators
    member this.Value                              optionTime swapLength   
                                                   = _value optionTime swapLength 
