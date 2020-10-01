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
  Backward-flat interpolation between discrete points
  </summary> *)
[<AutoSerializable(true)>]
module BackwardFlatInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_BackwardFlatInterpolation", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder () = withMnemonic mnemonic (Fun.BackwardFlatInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BackwardFlatInterpolation>) l

                let source = Helper.sourceFold "Fun.BackwardFlatInterpolation" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BackwardFlatInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BackwardFlatInterpolation_derivative", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".Derivative") 
                                               [| _BackwardFlatInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_empty", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".Empty") 
                                               [| _BackwardFlatInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_primitive", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".Primitive") 
                                               [| _BackwardFlatInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_secondDerivative", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".SecondDerivative") 
                                               [| _BackwardFlatInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_update", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).Update
                                                       ) :> ICell
                let format (o : BackwardFlatInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".Update") 
                                               [| _BackwardFlatInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_value1", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".Value1") 
                                               [| _BackwardFlatInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_value", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".Value") 
                                               [| _BackwardFlatInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_xMax", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".XMax") 
                                               [| _BackwardFlatInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_xMin", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".XMin") 
                                               [| _BackwardFlatInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_allowsExtrapolation", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".AllowsExtrapolation") 
                                               [| _BackwardFlatInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_disableExtrapolation", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BackwardFlatInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".DisableExtrapolation") 
                                               [| _BackwardFlatInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_enableExtrapolation", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BackwardFlatInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".EnableExtrapolation") 
                                               [| _BackwardFlatInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_extrapolate", Description="Create a BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardFlatInterpolation",Description = "Reference to BackwardFlatInterpolation")>] 
         backwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardFlatInterpolation = Helper.toCell<BackwardFlatInterpolation> backwardflatinterpolation "BackwardFlatInterpolation"  
                let builder () = withMnemonic mnemonic ((_BackwardFlatInterpolation.cell :?> BackwardFlatInterpolationModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardFlatInterpolation.source + ".Extrapolate") 
                                               [| _BackwardFlatInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardFlatInterpolation_Range", Description="Create a range of BackwardFlatInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardFlatInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BackwardFlatInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BackwardFlatInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BackwardFlatInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BackwardFlatInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BackwardFlatInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
