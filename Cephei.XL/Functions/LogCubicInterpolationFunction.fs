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
  %log-cubic interpolation between discrete points
  </summary> *)
[<AutoSerializable(true)>]
module LogCubicInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_LogCubicInterpolation", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="da",Description = "Reference to da")>] 
         da : obj)
        ([<ExcelArgument(Name="monotonic",Description = "Reference to monotonic")>] 
         monotonic : obj)
        ([<ExcelArgument(Name="leftC",Description = "Reference to leftC")>] 
         leftC : obj)
        ([<ExcelArgument(Name="leftConditionValue",Description = "Reference to leftConditionValue")>] 
         leftConditionValue : obj)
        ([<ExcelArgument(Name="rightC",Description = "Reference to rightC")>] 
         rightC : obj)
        ([<ExcelArgument(Name="rightConditionValue",Description = "Reference to rightConditionValue")>] 
         rightConditionValue : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _da = Helper.toCell<CubicInterpolation.DerivativeApprox> da "da" 
                let _monotonic = Helper.toCell<bool> monotonic "monotonic" 
                let _leftC = Helper.toCell<CubicInterpolation.BoundaryCondition> leftC "leftC" 
                let _leftConditionValue = Helper.toCell<double> leftConditionValue "leftConditionValue" 
                let _rightC = Helper.toCell<CubicInterpolation.BoundaryCondition> rightC "rightC" 
                let _rightConditionValue = Helper.toCell<double> rightConditionValue "rightConditionValue" 
                let builder () = withMnemonic mnemonic (Fun.LogCubicInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _da.cell 
                                                            _monotonic.cell 
                                                            _leftC.cell 
                                                            _leftConditionValue.cell 
                                                            _rightC.cell 
                                                            _rightConditionValue.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LogCubicInterpolation>) l

                let source = Helper.sourceFold "Fun.LogCubicInterpolation" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _da.source
                                               ;  _monotonic.source
                                               ;  _leftC.source
                                               ;  _leftConditionValue.source
                                               ;  _rightC.source
                                               ;  _rightConditionValue.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _da.cell
                                ;  _monotonic.cell
                                ;  _leftC.cell
                                ;  _leftConditionValue.cell
                                ;  _rightC.cell
                                ;  _rightConditionValue.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LogCubicInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LogCubicInterpolation_derivative", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".Derivative") 
                                               [| _LogCubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_LogCubicInterpolation_empty", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".Empty") 
                                               [| _LogCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
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
    [<ExcelFunction(Name="_LogCubicInterpolation_primitive", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".Primitive") 
                                               [| _LogCubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_LogCubicInterpolation_secondDerivative", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".SecondDerivative") 
                                               [| _LogCubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_LogCubicInterpolation_update", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : LogCubicInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".Update") 
                                               [| _LogCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
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
    [<ExcelFunction(Name="_LogCubicInterpolation_value1", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".Value1") 
                                               [| _LogCubicInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_LogCubicInterpolation_value", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".Value") 
                                               [| _LogCubicInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_LogCubicInterpolation_xMax", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".XMax") 
                                               [| _LogCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
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
    [<ExcelFunction(Name="_LogCubicInterpolation_xMin", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".XMin") 
                                               [| _LogCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_LogCubicInterpolation_allowsExtrapolation", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".AllowsExtrapolation") 
                                               [| _LogCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_LogCubicInterpolation_disableExtrapolation", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LogCubicInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".DisableExtrapolation") 
                                               [| _LogCubicInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_LogCubicInterpolation_enableExtrapolation", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LogCubicInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".EnableExtrapolation") 
                                               [| _LogCubicInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_LogCubicInterpolation_extrapolate", Description="Create a LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogCubicInterpolation",Description = "Reference to LogCubicInterpolation")>] 
         logcubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogCubicInterpolation = Helper.toCell<LogCubicInterpolation> logcubicinterpolation "LogCubicInterpolation"  
                let builder () = withMnemonic mnemonic ((LogCubicInterpolationModel.Cast _LogCubicInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LogCubicInterpolation.source + ".Extrapolate") 
                                               [| _LogCubicInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogCubicInterpolation.cell
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
    [<ExcelFunction(Name="_LogCubicInterpolation_Range", Description="Create a range of LogCubicInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LogCubicInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LogCubicInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LogCubicInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LogCubicInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LogCubicInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LogCubicInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
