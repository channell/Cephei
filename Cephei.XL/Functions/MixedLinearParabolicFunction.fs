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
    [<ExcelFunction(Name="_MixedLinearParabolic", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_create
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
                let builder (current : ICell) = (Fun.MixedLinearParabolic 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _n.cell 
                                                            _behavior.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedLinearParabolic>) l

                let source () = Helper.sourceFold "Fun.MixedLinearParabolic" 
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
                    ; subscriber = Helper.subscriberModel<MixedLinearParabolic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearParabolic_derivative", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_empty", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_primitive", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_secondDerivative", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_update", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).Update
                                                       ) :> ICell
                let format (o : MixedLinearParabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_value1", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_value", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_xMax", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_xMin", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_allowsExtrapolation", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_disableExtrapolation", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearParabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_enableExtrapolation", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearParabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_extrapolate", Description="Create a MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearParabolic",Description = "MixedLinearParabolic")>] 
         mixedlinearparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearParabolic = Helper.toModelReference<MixedLinearParabolic> mixedlinearparabolic "MixedLinearParabolic"  
                let builder (current : ICell) = ((MixedLinearParabolicModel.Cast _MixedLinearParabolic.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MixedLinearParabolic.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MixedLinearParabolic.cell
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
    [<ExcelFunction(Name="_MixedLinearParabolic_Range", Description="Create a range of MixedLinearParabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearParabolic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearParabolic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MixedLinearParabolic> (c)) :> ICell
                let format (i : Cephei.Cell.List<MixedLinearParabolic>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MixedLinearParabolic>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
