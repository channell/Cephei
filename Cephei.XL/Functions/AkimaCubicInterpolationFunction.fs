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
module AkimaCubicInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_AkimaCubicInterpolation", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AkimaCubicInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AkimaCubicInterpolation>) l

                let source () = Helper.sourceFold "Fun.AkimaCubicInterpolation" 
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
                    ; subscriber = Helper.subscriberModel<AkimaCubicInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AkimaCubicInterpolation_aCoefficients", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".ACoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_bCoefficients", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".BCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_cCoefficients", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".CCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_derivative", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_empty", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_primitive", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_secondDerivative", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_update", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : AkimaCubicInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_value1", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".Value") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_value", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_xMax", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_xMin", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_allowsExtrapolation", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_disableExtrapolation", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : AkimaCubicInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_enableExtrapolation", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : AkimaCubicInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_extrapolate", Description="Create a AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AkimaCubicInterpolation",Description = "AkimaCubicInterpolation")>] 
         akimacubicinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AkimaCubicInterpolation = Helper.toCell<AkimaCubicInterpolation> akimacubicinterpolation "AkimaCubicInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((AkimaCubicInterpolationModel.Cast _AkimaCubicInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AkimaCubicInterpolation.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AkimaCubicInterpolation.cell
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
    [<ExcelFunction(Name="_AkimaCubicInterpolation_Range", Description="Create a range of AkimaCubicInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AkimaCubicInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AkimaCubicInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AkimaCubicInterpolation> (c)) :> ICell
                let format (i : Cephei.Cell.List<AkimaCubicInterpolation>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AkimaCubicInterpolation>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
