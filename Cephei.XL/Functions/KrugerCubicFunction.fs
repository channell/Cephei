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
module KrugerCubicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_KrugerCubic", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_create
        ([<ExcelArgument(Name="Mnemonic",Description = "KrugerCubic")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.KrugerCubic 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<KrugerCubic>) l

                let source () = Helper.sourceFold "Fun.KrugerCubic" 
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
                    ; subscriber = Helper.subscriberModel<KrugerCubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_KrugerCubic_aCoefficients", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_KrugerCubic.source + ".ACoefficients") 
                                               [| _KrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_bCoefficients", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_KrugerCubic.source + ".BCoefficients") 
                                               [| _KrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_cCoefficients", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_KrugerCubic.source + ".CCoefficients") 
                                               [| _KrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_derivative", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".Derivative") 
                                               [| _KrugerCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_empty", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".Empty") 
                                               [| _KrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_primitive", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".Primitive") 
                                               [| _KrugerCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_secondDerivative", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".SecondDerivative") 
                                               [| _KrugerCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_update", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).Update
                                                       ) :> ICell
                let format (o : KrugerCubic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".Update") 
                                               [| _KrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_value1", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".Value1") 
                                               [| _KrugerCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_value", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".Value") 
                                               [| _KrugerCubic.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_xMax", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".XMax") 
                                               [| _KrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_xMin", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".XMin") 
                                               [| _KrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_allowsExtrapolation", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".AllowsExtrapolation") 
                                               [| _KrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_disableExtrapolation", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : KrugerCubic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".DisableExtrapolation") 
                                               [| _KrugerCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_enableExtrapolation", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : KrugerCubic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".EnableExtrapolation") 
                                               [| _KrugerCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_extrapolate", Description="Create a KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KrugerCubic",Description = "KrugerCubic")>] 
         krugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KrugerCubic = Helper.toCell<KrugerCubic> krugercubic "KrugerCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((KrugerCubicModel.Cast _KrugerCubic.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KrugerCubic.source + ".Extrapolate") 
                                               [| _KrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KrugerCubic.cell
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
    [<ExcelFunction(Name="_KrugerCubic_Range", Description="Create a range of KrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KrugerCubic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<KrugerCubic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<KrugerCubic>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<KrugerCubic>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<KrugerCubic>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
