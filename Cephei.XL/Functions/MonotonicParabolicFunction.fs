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
module MonotonicParabolicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MonotonicParabolic", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_create
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
                let builder () = withMnemonic mnemonic (Fun.MonotonicParabolic 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MonotonicParabolic>) l

                let source = Helper.sourceFold "Fun.MonotonicParabolic" 
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
                    ; subscriber = Helper.subscriberModel<MonotonicParabolic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MonotonicParabolic_aCoefficients", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_aCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).ACoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".ACoefficients") 
                                               [| _MonotonicParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_bCoefficients", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_bCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).BCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".BCoefficients") 
                                               [| _MonotonicParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_cCoefficients", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_cCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).CCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".CCoefficients") 
                                               [| _MonotonicParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_derivative", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".Derivative") 
                                               [| _MonotonicParabolic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_empty", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".Empty") 
                                               [| _MonotonicParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_primitive", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".Primitive") 
                                               [| _MonotonicParabolic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_secondDerivative", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".SecondDerivative") 
                                               [| _MonotonicParabolic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_update", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Update
                                                       ) :> ICell
                let format (o : MonotonicParabolic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".Update") 
                                               [| _MonotonicParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_value1", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".Value1") 
                                               [| _MonotonicParabolic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_value", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".Value") 
                                               [| _MonotonicParabolic.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_xMax", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".XMax") 
                                               [| _MonotonicParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_xMin", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".XMin") 
                                               [| _MonotonicParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_allowsExtrapolation", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".AllowsExtrapolation") 
                                               [| _MonotonicParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_disableExtrapolation", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MonotonicParabolic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".DisableExtrapolation") 
                                               [| _MonotonicParabolic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_enableExtrapolation", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MonotonicParabolic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".EnableExtrapolation") 
                                               [| _MonotonicParabolic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_extrapolate", Description="Create a MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonotonicParabolic",Description = "Reference to MonotonicParabolic")>] 
         monotonicparabolic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonotonicParabolic = Helper.toCell<MonotonicParabolic> monotonicparabolic "MonotonicParabolic"  
                let builder () = withMnemonic mnemonic ((MonotonicParabolicModel.Cast _MonotonicParabolic.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MonotonicParabolic.source + ".Extrapolate") 
                                               [| _MonotonicParabolic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonotonicParabolic.cell
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
    [<ExcelFunction(Name="_MonotonicParabolic_Range", Description="Create a range of MonotonicParabolic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonotonicParabolic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MonotonicParabolic")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MonotonicParabolic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MonotonicParabolic>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MonotonicParabolic>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MonotonicParabolic>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
