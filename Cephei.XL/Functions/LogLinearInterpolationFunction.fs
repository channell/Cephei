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
  %log-linear interpolation between discrete points
  </summary> *)
[<AutoSerializable(true)>]
module LogLinearInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_LogLinearInterpolation", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_create
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
                let builder (current : ICell) = (Fun.LogLinearInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LogLinearInterpolation>) l

                let source () = Helper.sourceFold "Fun.LogLinearInterpolation" 
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
                    ; subscriber = Helper.subscriberModel<LogLinearInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LogLinearInterpolation_derivative", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_empty", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_primitive", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_secondDerivative", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_update", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : LogLinearInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_value1", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_value", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_xMax", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_xMin", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_allowsExtrapolation", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_disableExtrapolation", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LogLinearInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_enableExtrapolation", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : LogLinearInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_extrapolate", Description="Create a LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LogLinearInterpolation",Description = "LogLinearInterpolation")>] 
         loglinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LogLinearInterpolation = Helper.toModelReference<LogLinearInterpolation> loglinearinterpolation "LogLinearInterpolation"  
                let builder (current : ICell) = ((LogLinearInterpolationModel.Cast _LogLinearInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LogLinearInterpolation.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LogLinearInterpolation.cell
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
    [<ExcelFunction(Name="_LogLinearInterpolation_Range", Description="Create a range of LogLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LogLinearInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LogLinearInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<LogLinearInterpolation> (c)) :> ICell
                let format (i : Cephei.Cell.List<LogLinearInterpolation>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<LogLinearInterpolation>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
