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

  </summary> *)
[<AutoSerializable(true)>]
module MixedLinearParabolicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MixedLinearParabolic", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "Reference to xEnd")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="behavior",Description = "Reference to behavior")>] 
         behavior : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" true
                let _xEnd = Helper.toCell<int> xEnd "xEnd" true
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" true
                let _n = Helper.toCell<int> n "n" true
                let _behavior = Helper.toCell<Behavior> behavior "behavior" true
                let builder () = withMnemonic mnemonic (Fun.MixedLinearParabolic 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _n.cell 
                                                            _behavior.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedLinearParabolic>) l

                let source = Helper.sourceFold "Fun.MixedLinearParabolic" 
                                               [| _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               ;  _n.source
                                               ;  _behavior.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                ;  _n.cell
                                ;  _behavior.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearParabolic_derivative", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".Derivative") 
                                               [| _MixedLinearParabolic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_empty", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".Empty") 
                                               [| _MixedLinearParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_primitive", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".Primitive") 
                                               [| _MixedLinearParabolic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_secondDerivative", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".SecondDerivative") 
                                               [| _MixedLinearParabolic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_update", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).Update
                                                       ) :> ICell
                let format (o : MixedLinearParabolic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".Update") 
                                               [| _MixedLinearParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_value", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let _x = Helper.toCell<double> x "x" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).Value
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".Value") 
                                               [| _MixedLinearParabolic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_value", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).Value1
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".Value1") 
                                               [| _MixedLinearParabolic.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_xMax", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".XMax") 
                                               [| _MixedLinearParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_xMin", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".XMin") 
                                               [| _MixedLinearParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_allowsExtrapolation", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".AllowsExtrapolation") 
                                               [| _MixedLinearParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_disableExtrapolation", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearParabolic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".DisableExtrapolation") 
                                               [| _MixedLinearParabolic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_enableExtrapolation", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearParabolic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".EnableExtrapolation") 
                                               [| _MixedLinearParabolic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_extrapolate", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "Reference to MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toCell<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic" true 
                let builder () = withMnemonic mnemonic ((_MixedLinearParabolic.cell :?> MixedLinearParabolicModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearParabolic.source + ".Extrapolate") 
                                               [| _MixedLinearParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_Range", Description="Create a range of MixedLinearParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearParabolic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MixedLinearParabolic")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearParabolic> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MixedLinearParabolic>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MixedLinearParabolic>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MixedLinearParabolic>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
