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
  Enhances implementation of the convex monotone method described in "Interpolation Methods for Curve Construction" by Hagan & West AMF Vol 13, No2 2006.  A setting of monotonicity = 1 and quadraticity = 0 will reproduce the basic Hagan/West method. However, this can produce excessive gradients which can mean P&L swings for some curves.  Setting monotonicity < 1 and/or quadraticity > 0 produces smoother curves.  Extra enhancement to avoid negative values (if required) is in place.
  </summary> *)
[<AutoSerializable(true)>]
module ConvexMonotoneInterpolationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="quadraticity",Description = "Reference to quadraticity")>] 
         quadraticity : obj)
        ([<ExcelArgument(Name="monotonicity",Description = "Reference to monotonicity")>] 
         monotonicity : obj)
        ([<ExcelArgument(Name="forcePositive",Description = "Reference to forcePositive")>] 
         forcePositive : obj)
        ([<ExcelArgument(Name="flatFinalPeriod",Description = "Reference to flatFinalPeriod")>] 
         flatFinalPeriod : obj)
        ([<ExcelArgument(Name="preExistingHelpers",Description = "Reference to preExistingHelpers")>] 
         preExistingHelpers : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _quadraticity = Helper.toCell<double> quadraticity "quadraticity" 
                let _monotonicity = Helper.toCell<double> monotonicity "monotonicity" 
                let _forcePositive = Helper.toCell<bool> forcePositive "forcePositive" 
                let _flatFinalPeriod = Helper.toCell<bool> flatFinalPeriod "flatFinalPeriod" 
                let _preExistingHelpers = Helper.toCell<System.Collections.Generic.Dictionary<double,ISectionHelper>> preExistingHelpers "preExistingHelpers" 
                let builder () = withMnemonic mnemonic (Fun.ConvexMonotoneInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _quadraticity.cell 
                                                            _monotonicity.cell 
                                                            _forcePositive.cell 
                                                            _flatFinalPeriod.cell 
                                                            _preExistingHelpers.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvexMonotoneInterpolation>) l

                let source = Helper.sourceFold "Fun.ConvexMonotoneInterpolation" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _quadraticity.source
                                               ;  _monotonicity.source
                                               ;  _forcePositive.source
                                               ;  _flatFinalPeriod.source
                                               ;  _preExistingHelpers.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _quadraticity.cell
                                ;  _monotonicity.cell
                                ;  _forcePositive.cell
                                ;  _flatFinalPeriod.cell
                                ;  _preExistingHelpers.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvexMonotoneInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation1", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="quadraticity",Description = "Reference to quadraticity")>] 
         quadraticity : obj)
        ([<ExcelArgument(Name="monotonicity",Description = "Reference to monotonicity")>] 
         monotonicity : obj)
        ([<ExcelArgument(Name="forcePositive",Description = "Reference to forcePositive")>] 
         forcePositive : obj)
        ([<ExcelArgument(Name="flatFinalPeriod",Description = "Reference to flatFinalPeriod")>] 
         flatFinalPeriod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _quadraticity = Helper.toCell<double> quadraticity "quadraticity" 
                let _monotonicity = Helper.toCell<double> monotonicity "monotonicity" 
                let _forcePositive = Helper.toCell<bool> forcePositive "forcePositive" 
                let _flatFinalPeriod = Helper.toCell<bool> flatFinalPeriod "flatFinalPeriod" 
                let builder () = withMnemonic mnemonic (Fun.ConvexMonotoneInterpolation1 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _quadraticity.cell 
                                                            _monotonicity.cell 
                                                            _forcePositive.cell 
                                                            _flatFinalPeriod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvexMonotoneInterpolation>) l

                let source = Helper.sourceFold "Fun.ConvexMonotoneInterpolation1" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _quadraticity.source
                                               ;  _monotonicity.source
                                               ;  _forcePositive.source
                                               ;  _flatFinalPeriod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _quadraticity.cell
                                ;  _monotonicity.cell
                                ;  _forcePositive.cell
                                ;  _flatFinalPeriod.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvexMonotoneInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_getExistingHelpers", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_getExistingHelpers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).GetExistingHelpers
                                                       ) :> ICell
                let format (o : System.Collections.Generic.Dictionary<double,ISectionHelper>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".GetExistingHelpers") 
                                               [| _ConvexMonotoneInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_derivative", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".Derivative") 
                                               [| _ConvexMonotoneInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_empty", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".Empty") 
                                               [| _ConvexMonotoneInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_primitive", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".Primitive") 
                                               [| _ConvexMonotoneInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_secondDerivative", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".SecondDerivative") 
                                               [| _ConvexMonotoneInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_update", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).Update
                                                       ) :> ICell
                let format (o : ConvexMonotoneInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".Update") 
                                               [| _ConvexMonotoneInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_value1", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".Value1") 
                                               [| _ConvexMonotoneInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_value", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".Value") 
                                               [| _ConvexMonotoneInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_xMax", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".XMax") 
                                               [| _ConvexMonotoneInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_xMin", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".XMin") 
                                               [| _ConvexMonotoneInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_allowsExtrapolation", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".AllowsExtrapolation") 
                                               [| _ConvexMonotoneInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_disableExtrapolation", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConvexMonotoneInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".DisableExtrapolation") 
                                               [| _ConvexMonotoneInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_enableExtrapolation", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConvexMonotoneInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".EnableExtrapolation") 
                                               [| _ConvexMonotoneInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_extrapolate", Description="Create a ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotoneInterpolation",Description = "Reference to ConvexMonotoneInterpolation")>] 
         convexmonotoneinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotoneInterpolation = Helper.toCell<ConvexMonotoneInterpolation> convexmonotoneinterpolation "ConvexMonotoneInterpolation"  
                let builder () = withMnemonic mnemonic ((_ConvexMonotoneInterpolation.cell :?> ConvexMonotoneInterpolationModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvexMonotoneInterpolation.source + ".Extrapolate") 
                                               [| _ConvexMonotoneInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotoneInterpolation.cell
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
    [<ExcelFunction(Name="_ConvexMonotoneInterpolation_Range", Description="Create a range of ConvexMonotoneInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotoneInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConvexMonotoneInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvexMonotoneInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConvexMonotoneInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConvexMonotoneInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConvexMonotoneInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
