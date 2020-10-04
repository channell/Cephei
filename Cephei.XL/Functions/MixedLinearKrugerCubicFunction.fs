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
module MixedLinearKrugerCubicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MixedLinearKrugerCubic", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_create
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

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xEnd = Helper.toCell<int> xEnd "xEnd" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _n = Helper.toCell<int> n "n" 
                let _behavior = Helper.toDefault<Behavior> behavior "behavior" Behavior.ShareRanges
                let builder () = withMnemonic mnemonic (Fun.MixedLinearKrugerCubic 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _n.cell 
                                                            _behavior.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedLinearKrugerCubic>) l

                let source = Helper.sourceFold "Fun.MixedLinearKrugerCubic" 
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
                    ; subscriber = Helper.subscriberModel<MixedLinearKrugerCubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_derivative", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".Derivative") 
                                               [| _MixedLinearKrugerCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_empty", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".Empty") 
                                               [| _MixedLinearKrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_primitive", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".Primitive") 
                                               [| _MixedLinearKrugerCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_secondDerivative", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".SecondDerivative") 
                                               [| _MixedLinearKrugerCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_update", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).Update
                                                       ) :> ICell
                let format (o : MixedLinearKrugerCubic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".Update") 
                                               [| _MixedLinearKrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_value1", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".Value1") 
                                               [| _MixedLinearKrugerCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_value", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".Value") 
                                               [| _MixedLinearKrugerCubic.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_xMax", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".XMax") 
                                               [| _MixedLinearKrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_xMin", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".XMin") 
                                               [| _MixedLinearKrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_allowsExtrapolation", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".AllowsExtrapolation") 
                                               [| _MixedLinearKrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_disableExtrapolation", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearKrugerCubic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".DisableExtrapolation") 
                                               [| _MixedLinearKrugerCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_enableExtrapolation", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearKrugerCubic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".EnableExtrapolation") 
                                               [| _MixedLinearKrugerCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_extrapolate", Description="Create a MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearKrugerCubic",Description = "Reference to MixedLinearKrugerCubic")>] 
         mixedlinearkrugercubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearKrugerCubic = Helper.toCell<MixedLinearKrugerCubic> mixedlinearkrugercubic "MixedLinearKrugerCubic"  
                let builder () = withMnemonic mnemonic ((MixedLinearKrugerCubicModel.Cast _MixedLinearKrugerCubic.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearKrugerCubic.source + ".Extrapolate") 
                                               [| _MixedLinearKrugerCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearKrugerCubic.cell
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
    [<ExcelFunction(Name="_MixedLinearKrugerCubic_Range", Description="Create a range of MixedLinearKrugerCubic",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MixedLinearKrugerCubic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MixedLinearKrugerCubic")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearKrugerCubic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MixedLinearKrugerCubic>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MixedLinearKrugerCubic>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MixedLinearKrugerCubic>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
