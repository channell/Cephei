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
  Forward-flat interpolation between discrete points
  </summary> *)
[<AutoSerializable(true)>]
module ForwardFlatInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_ForwardFlatInterpolation", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "ForwardFlatInterpolation")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ForwardFlatInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ForwardFlatInterpolation>) l

                let source () = Helper.sourceFold "Fun.ForwardFlatInterpolation" 
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
                    ; subscriber = Helper.subscriberModel<ForwardFlatInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardFlatInterpolation_derivative", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_empty", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_primitive", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_secondDerivative", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_update", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : ForwardFlatInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_value1", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_value", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_xMax", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_xMin", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_allowsExtrapolation", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_disableExtrapolation", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ForwardFlatInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_enableExtrapolation", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ForwardFlatInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_extrapolate", Description="Create a ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardFlatInterpolation",Description = "ForwardFlatInterpolation")>] 
         forwardflatinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardFlatInterpolation = Helper.toCell<ForwardFlatInterpolation> forwardflatinterpolation "ForwardFlatInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardFlatInterpolationModel.Cast _ForwardFlatInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardFlatInterpolation.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardFlatInterpolation.cell
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
    [<ExcelFunction(Name="_ForwardFlatInterpolation_Range", Description="Create a range of ForwardFlatInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardFlatInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardFlatInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ForwardFlatInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<ForwardFlatInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ForwardFlatInterpolation>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
