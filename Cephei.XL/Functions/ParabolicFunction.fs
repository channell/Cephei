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
module ParabolicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_Parabolic", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = (Fun.Parabolic 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Parabolic>) l

                let source () = Helper.sourceFold "Fun.Parabolic" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Parabolic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Parabolic_aCoefficients", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_Parabolic.source + ".ACoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Parabolic_bCoefficients", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_Parabolic.source + ".BCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Parabolic_cCoefficients", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_Parabolic.source + ".CCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Parabolic_derivative", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_empty", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_primitive", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_secondDerivative", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_update", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).Update
                                                       ) :> ICell
                let format (o : Parabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_value1", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_value", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_xMax", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_xMin", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_allowsExtrapolation", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_disableExtrapolation", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : Parabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_enableExtrapolation", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : Parabolic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_extrapolate", Description="Create a Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parabolic",Description = "Parabolic")>] 
         parabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parabolic = Helper.toCell<Parabolic> parabolic "Parabolic"  
                let builder (current : ICell) = ((ParabolicModel.Cast _Parabolic.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Parabolic.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Parabolic.cell
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
    [<ExcelFunction(Name="_Parabolic_Range", Description="Create a range of Parabolic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Parabolic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Parabolic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Parabolic> (c)) :> ICell
                let format (i : Cephei.Cell.List<Parabolic>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Parabolic>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
