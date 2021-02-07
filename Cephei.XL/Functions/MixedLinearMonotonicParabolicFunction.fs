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
module MixedLinearMonotonicParabolicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "int")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="behavior",Description = "Behavior: ShareRanges, SplitRanges or empty")>] 
         behavior : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xEnd = Helper.toCell<int> xEnd "xEnd" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _n = Helper.toCell<int> n "n" 
                let _behavior = Helper.toDefault<Behavior> behavior "behavior" Behavior.ShareRanges
                let builder (current : ICell) = (Fun.MixedLinearMonotonicParabolic 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _n.cell 
                                                            _behavior.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedLinearMonotonicParabolic>) l

                let source () = Helper.sourceFold "Fun.MixedLinearMonotonicParabolic" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MixedLinearMonotonicParabolic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_derivative", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_empty", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_primitive", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_secondDerivative", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_update", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).Update
                                                       ) :> ICell
                let format (o : MixedLinearMonotonicParabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_value1", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_value", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_xMax", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_xMin", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_allowsExtrapolation", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_disableExtrapolation", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearMonotonicParabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_enableExtrapolation", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearMonotonicParabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_extrapolate", Description="Create a MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearMonotonicParabolic",Description = "MixedLinearMonotonicParabolic")>] 
         mixedlinearmonotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearMonotonicParabolic = Helper.toCell<MixedLinearMonotonicParabolic> mixedlinearmonotonicparabolic "MixedLinearMonotonicParabolic"  
                let builder (current : ICell) = ((MixedLinearMonotonicParabolicModel.Cast _MixedLinearMonotonicParabolic.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearMonotonicParabolic.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearMonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearMonotonicParabolic_Range", Description="Create a range of MixedLinearMonotonicParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearMonotonicParabolic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearMonotonicParabolic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MixedLinearMonotonicParabolic> (c)) :> ICell
                let format (i : Cephei.Cell.List<MixedLinearMonotonicParabolic>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MixedLinearMonotonicParabolic>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
