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
module BackwardflatLinearInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ and \f$ y \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "int")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="yEnd",Description = "int")>] 
         yEnd : obj)
        ([<ExcelArgument(Name="zData",Description = "Matrix")>] 
         zData : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xEnd = Helper.toCell<int> xEnd "xEnd" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _yEnd = Helper.toCell<int> yEnd "yEnd" 
                let _zData = Helper.toCell<Matrix> zData "zData" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BackwardflatLinearInterpolation 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _yEnd.cell 
                                                            _zData.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BackwardflatLinearInterpolation>) l

                let source () = Helper.sourceFold "Fun.BackwardflatLinearInterpolation" 
                                               [| _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               ;  _yEnd.source
                                               ;  _zData.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                ;  _yEnd.cell
                                ;  _zData.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BackwardflatLinearInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_isInRange", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_isInRange
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).IsInRange
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".IsInRange") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_locateX", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_locateX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).LocateX
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".LocateX") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_locateY", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_locateY
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).LocateY
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".LocateY") 

                                               [| _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_update", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : BackwardflatLinearInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_value1", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).Value1
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".Value1") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_value", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).Value
                                                            _x.cell 
                                                            _y.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".Value") 

                                               [| _x.source
                                               ;  _y.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_xMax", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_xMin", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_xValues", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_xValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).XValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".XValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_yMax", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_yMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).YMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".YMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_yMin", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_yMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).YMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".YMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_yValues", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_yValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).YValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".YValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_zData", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_zData
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).ZData
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".ZData") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BackwardflatLinearInterpolation> format
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_allowsExtrapolation", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_disableExtrapolation", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BackwardflatLinearInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_enableExtrapolation", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BackwardflatLinearInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_extrapolate", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation"  
                let builder (current : ICell) = withMnemonic mnemonic ((BackwardflatLinearInterpolationModel.Cast _BackwardflatLinearInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_Range", Description="Create a range of BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BackwardflatLinearInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BackwardflatLinearInterpolation> (c)) :> ICell
                let format (i : Generic.List<ICell<BackwardflatLinearInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BackwardflatLinearInterpolation>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
