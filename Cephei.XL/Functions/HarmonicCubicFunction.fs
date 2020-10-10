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
module HarmonicCubicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_HarmonicCubic", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.HarmonicCubic 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HarmonicCubic>) l

                let source () = Helper.sourceFold "Fun.HarmonicCubic" 
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
                    ; subscriber = Helper.subscriberModel<HarmonicCubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HarmonicCubic_aCoefficients", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".ACoefficients") 
                                               [| _HarmonicCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_bCoefficients", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".BCoefficients") 
                                               [| _HarmonicCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_cCoefficients", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".CCoefficients") 
                                               [| _HarmonicCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_derivative", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".Derivative") 
                                               [| _HarmonicCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_empty", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".Empty") 
                                               [| _HarmonicCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_primitive", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".Primitive") 
                                               [| _HarmonicCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_secondDerivative", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".SecondDerivative") 
                                               [| _HarmonicCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_update", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).Update
                                                       ) :> ICell
                let format (o : HarmonicCubic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".Update") 
                                               [| _HarmonicCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_value1", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".Value1") 
                                               [| _HarmonicCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_value", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".Value") 
                                               [| _HarmonicCubic.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_xMax", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".XMax") 
                                               [| _HarmonicCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_xMin", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".XMin") 
                                               [| _HarmonicCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_allowsExtrapolation", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".AllowsExtrapolation") 
                                               [| _HarmonicCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_disableExtrapolation", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : HarmonicCubic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".DisableExtrapolation") 
                                               [| _HarmonicCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_enableExtrapolation", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : HarmonicCubic) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".EnableExtrapolation") 
                                               [| _HarmonicCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_extrapolate", Description="Create a HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HarmonicCubic",Description = "Reference to HarmonicCubic")>] 
         harmoniccubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HarmonicCubic = Helper.toCell<HarmonicCubic> harmoniccubic "HarmonicCubic"  
                let builder (current : ICell) = withMnemonic mnemonic ((HarmonicCubicModel.Cast _HarmonicCubic.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HarmonicCubic.source + ".Extrapolate") 
                                               [| _HarmonicCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HarmonicCubic.cell
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
    [<ExcelFunction(Name="_HarmonicCubic_Range", Description="Create a range of HarmonicCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HarmonicCubic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HarmonicCubic")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HarmonicCubic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HarmonicCubic>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<HarmonicCubic>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<HarmonicCubic>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
