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
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>
  %Cubic interpolation factory and traits
  </summary> *)
[<AutoSerializable(true)>]
module CubicFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Cubic", Description="Create a Cubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cubic_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="da",Description = "CubicInterpolation.DerivativeApprox: Spline, SplineOM1, SplineOM2, FourthOrder, Parabolic, FritschButland, Akima, Kruger, Harmonic")>] 
         da : obj)
        ([<ExcelArgument(Name="monotonic",Description = "bool")>] 
         monotonic : obj)
        ([<ExcelArgument(Name="leftCondition",Description = "CubicInterpolation.BoundaryCondition: NotAKnot, FirstDerivative, SecondDerivative, Periodic, Lagrange")>] 
         leftCondition : obj)
        ([<ExcelArgument(Name="leftConditionValue",Description = "double")>] 
         leftConditionValue : obj)
        ([<ExcelArgument(Name="rightCondition",Description = "CubicInterpolation.BoundaryCondition: NotAKnot, FirstDerivative, SecondDerivative, Periodic, Lagrange")>] 
         rightCondition : obj)
        ([<ExcelArgument(Name="rightConditionValue",Description = "double")>] 
         rightConditionValue : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _da = Helper.toCell<CubicInterpolation.DerivativeApprox> da "da" 
                let _monotonic = Helper.toCell<bool> monotonic "monotonic" 
                let _leftCondition = Helper.toCell<CubicInterpolation.BoundaryCondition> leftCondition "leftCondition" 
                let _leftConditionValue = Helper.toCell<double> leftConditionValue "leftConditionValue" 
                let _rightCondition = Helper.toCell<CubicInterpolation.BoundaryCondition> rightCondition "rightCondition" 
                let _rightConditionValue = Helper.toCell<double> rightConditionValue "rightConditionValue" 
                let builder (current : ICell) = (Fun.Cubic 
                                                            _da.cell 
                                                            _monotonic.cell 
                                                            _leftCondition.cell 
                                                            _leftConditionValue.cell 
                                                            _rightCondition.cell 
                                                            _rightConditionValue.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Cubic>) l

                let source () = Helper.sourceFold "Fun.Cubic" 
                                               [| _da.source
                                               ;  _monotonic.source
                                               ;  _leftCondition.source
                                               ;  _leftConditionValue.source
                                               ;  _rightCondition.source
                                               ;  _rightConditionValue.source
                                               |]
                let hash = Helper.hashFold 
                                [| _da.cell
                                ;  _monotonic.cell
                                ;  _leftCondition.cell
                                ;  _leftConditionValue.cell
                                ;  _rightCondition.cell
                                ;  _rightConditionValue.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cubic1", Description="Create a Cubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cubic_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.Cubic1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Cubic>) l

                let source () = Helper.sourceFold "Fun.Cubic1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cubic_global", Description="Create a Cubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cubic_global
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cubic",Description = "Cubic")>] 
         cubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cubic = Helper.toCell<Cubic> cubic "Cubic"  
                let builder (current : ICell) = ((CubicModel.Cast _Cubic.cell).Global
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Cubic.source + ".GLOBAL") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cubic.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cubic_interpolate", Description="Create a Cubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cubic_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cubic",Description = "Cubic")>] 
         cubic : obj)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cubic = Helper.toCell<Cubic> cubic "Cubic"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = ((CubicModel.Cast _Cubic.cell).Interpolate
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_Cubic.source + ".Interpolate") 

                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Cubic.cell
                                ;  _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Cubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Cubic_requiredPoints", Description="Create a Cubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cubic_requiredPoints
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Cubic",Description = "Cubic")>] 
         cubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Cubic = Helper.toCell<Cubic> cubic "Cubic"  
                let builder (current : ICell) = ((CubicModel.Cast _Cubic.cell).RequiredPoints
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Cubic.source + ".RequiredPoints") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Cubic.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Cubic_Range", Description="Create a range of Cubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Cubic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Cubic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Cubic> (c)) :> ICell
                let format (i : Cephei.Cell.List<Cubic>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Cubic>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
