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
  interpolations
  </summary> *)
[<AutoSerializable(true)>]
module MixedLinearCubicFunction =

    (*
        fix below
    *)
    [<ExcelFunction(Name="_MixedLinearCubic_global", Description="Create a MixedLinearCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubic_global
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubic",Description = "Reference to MixedLinearCubic")>] 
         mixedlinearcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubic = Helper.toCell<MixedLinearCubic> mixedlinearcubic "MixedLinearCubic"  
                let builder () = withMnemonic mnemonic ((MixedLinearCubicModel.Cast _MixedLinearCubic.cell).Global
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearCubic.source + ".GLOBAL") 
                                               [| _MixedLinearCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_MixedLinearCubic_interpolate", Description="Create a MixedLinearCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubic_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubic",Description = "Reference to MixedLinearCubic")>] 
         mixedlinearcubic : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "Reference to xEnd")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubic = Helper.toCell<MixedLinearCubic> mixedlinearcubic "MixedLinearCubic"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xEnd = Helper.toCell<int> xEnd "xEnd" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder () = withMnemonic mnemonic ((MixedLinearCubicModel.Cast _MixedLinearCubic.cell).Interpolate
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_MixedLinearCubic.source + ".Interpolate") 
                                               [| _MixedLinearCubic.source
                                               ;  _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubic.cell
                                ;  _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MixedLinearCubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearCubic", Description="Create a MixedLinearCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubic_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="behavior",Description = "Reference to behavior")>] 
         behavior : obj)
        ([<ExcelArgument(Name="da",Description = "Reference to da")>] 
         da : obj)
        ([<ExcelArgument(Name="monotonic",Description = "Reference to monotonic")>] 
         monotonic : obj)
        ([<ExcelArgument(Name="leftCondition",Description = "Reference to leftCondition")>] 
         leftCondition : obj)
        ([<ExcelArgument(Name="leftConditionValue",Description = "Reference to leftConditionValue")>] 
         leftConditionValue : obj)
        ([<ExcelArgument(Name="rightCondition",Description = "Reference to rightCondition")>] 
         rightCondition : obj)
        ([<ExcelArgument(Name="rightConditionValue",Description = "Reference to rightConditionValue")>] 
         rightConditionValue : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _n = Helper.toCell<int> n "n" 
                let _behavior = Helper.toCell<Behavior> behavior "behavior" 
                let _da = Helper.toCell<CubicInterpolation.DerivativeApprox> da "da" 
                let _monotonic = Helper.toDefault<bool> monotonic "monotonic" true
                let _leftCondition = Helper.toDefault<CubicInterpolation.BoundaryCondition> leftCondition "leftCondition" QLNet.CubicInterpolation.BoundaryCondition.SecondDerivative
                let _leftConditionValue = Helper.toDefault<double> leftConditionValue "leftConditionValue" 0.0
                let _rightCondition = Helper.toDefault<CubicInterpolation.BoundaryCondition> rightCondition "rightCondition" CubicInterpolation.BoundaryCondition.SecondDerivative
                let _rightConditionValue = Helper.toDefault<double> rightConditionValue "rightConditionValue" 0.0
                let builder () = withMnemonic mnemonic (Fun.MixedLinearCubic 
                                                            _n.cell 
                                                            _behavior.cell 
                                                            _da.cell 
                                                            _monotonic.cell 
                                                            _leftCondition.cell 
                                                            _leftConditionValue.cell 
                                                            _rightCondition.cell 
                                                            _rightConditionValue.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedLinearCubic>) l

                let source = Helper.sourceFold "Fun.MixedLinearCubic" 
                                               [| _n.source
                                               ;  _behavior.source
                                               ;  _da.source
                                               ;  _monotonic.source
                                               ;  _leftCondition.source
                                               ;  _leftConditionValue.source
                                               ;  _rightCondition.source
                                               ;  _rightConditionValue.source
                                               |]
                let hash = Helper.hashFold 
                                [| _n.cell
                                ;  _behavior.cell
                                ;  _da.cell
                                ;  _monotonic.cell
                                ;  _leftCondition.cell
                                ;  _leftConditionValue.cell
                                ;  _rightCondition.cell
                                ;  _rightConditionValue.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MixedLinearCubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearCubic_requiredPoints", Description="Create a MixedLinearCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubic_requiredPoints
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearCubic",Description = "Reference to MixedLinearCubic")>] 
         mixedlinearcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearCubic = Helper.toCell<MixedLinearCubic> mixedlinearcubic "MixedLinearCubic"  
                let builder () = withMnemonic mnemonic ((MixedLinearCubicModel.Cast _MixedLinearCubic.cell).RequiredPoints
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearCubic.source + ".RequiredPoints") 
                                               [| _MixedLinearCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MixedLinearCubic_Range", Description="Create a range of MixedLinearCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearCubic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MixedLinearCubic")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearCubic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MixedLinearCubic>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MixedLinearCubic>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MixedLinearCubic>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
