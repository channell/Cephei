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
module FritschButlandCubicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_FritschButlandCubic", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_create
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
                let builder () = withMnemonic mnemonic (Fun.FritschButlandCubic 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FritschButlandCubic>) l

                let source = Helper.sourceFold "Fun.FritschButlandCubic" 
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
                    ; subscriber = Helper.subscriberModel<FritschButlandCubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FritschButlandCubic_aCoefficients", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".ACoefficients") 
                                               [| _FritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FritschButlandCubic_bCoefficients", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".BCoefficients") 
                                               [| _FritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FritschButlandCubic_cCoefficients", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".CCoefficients") 
                                               [| _FritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_FritschButlandCubic_derivative", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".Derivative") 
                                               [| _FritschButlandCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_empty", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".Empty") 
                                               [| _FritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_primitive", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".Primitive") 
                                               [| _FritschButlandCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_secondDerivative", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".SecondDerivative") 
                                               [| _FritschButlandCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_update", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).Update
                                                       ) :> ICell
                let format (o : FritschButlandCubic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".Update") 
                                               [| _FritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_value1", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".Value1") 
                                               [| _FritschButlandCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_value", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".Value") 
                                               [| _FritschButlandCubic.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_xMax", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".XMax") 
                                               [| _FritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_xMin", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".XMin") 
                                               [| _FritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_allowsExtrapolation", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".AllowsExtrapolation") 
                                               [| _FritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_disableExtrapolation", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FritschButlandCubic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".DisableExtrapolation") 
                                               [| _FritschButlandCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_enableExtrapolation", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FritschButlandCubic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".EnableExtrapolation") 
                                               [| _FritschButlandCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_extrapolate", Description="Create a FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FritschButlandCubic",Description = "Reference to FritschButlandCubic")>] 
         fritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FritschButlandCubic = Helper.toCell<FritschButlandCubic> fritschbutlandcubic "FritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((FritschButlandCubicModel.Cast _FritschButlandCubic.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FritschButlandCubic.source + ".Extrapolate") 
                                               [| _FritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FritschButlandCubic.cell
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
    [<ExcelFunction(Name="_FritschButlandCubic_Range", Description="Create a range of FritschButlandCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FritschButlandCubic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FritschButlandCubic")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FritschButlandCubic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FritschButlandCubic>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FritschButlandCubic>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FritschButlandCubic>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
