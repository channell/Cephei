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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "Reference to xEnd")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="yEnd",Description = "Reference to yEnd")>] 
         yEnd : obj)
        ([<ExcelArgument(Name="zData",Description = "Reference to zData")>] 
         zData : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" true
                let _xEnd = Helper.toCell<int> xEnd "xEnd" true
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" true
                let _yEnd = Helper.toCell<int> yEnd "yEnd" true
                let _zData = Helper.toCell<Matrix> zData "zData" true
                let builder () = withMnemonic mnemonic (Fun.BackwardflatLinearInterpolation 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _yEnd.cell 
                                                            _zData.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BackwardflatLinearInterpolation>) l

                let source = Helper.sourceFold "Fun.BackwardflatLinearInterpolation" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_isInRange", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_isInRange
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _y = Helper.toCell<double> y "y" true
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).IsInRange
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".IsInRange") 
                                               [| _BackwardflatLinearInterpolation.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_locateX", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_locateX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).LocateX
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".LocateX") 
                                               [| _BackwardflatLinearInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_locateY", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_locateY
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let _y = Helper.toCell<double> y "y" true
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).LocateY
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".LocateY") 
                                               [| _BackwardflatLinearInterpolation.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_update", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).Update
                                                       ) :> ICell
                let format (o : BackwardflatLinearInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".Update") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_value", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _y = Helper.toCell<double> y "y" true
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).Value
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".Value") 
                                               [| _BackwardflatLinearInterpolation.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_value", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let _x = Helper.toCell<double> x "x" true
                let _y = Helper.toCell<double> y "y" true
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" true
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).Value1
                                                            _x.cell 
                                                            _y.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".Value1") 
                                               [| _BackwardflatLinearInterpolation.source
                                               ;  _x.source
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_xMax", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".XMax") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_xMin", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".XMin") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_xValues", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_xValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).XValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".XValues") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_yMax", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_yMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).YMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".YMax") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_yMin", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_yMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).YMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".YMin") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_yValues", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_yValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).YValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".YValues") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_zData", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_zData
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).ZData
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".ZData") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_allowsExtrapolation", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".AllowsExtrapolation") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_disableExtrapolation", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BackwardflatLinearInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".DisableExtrapolation") 
                                               [| _BackwardflatLinearInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_enableExtrapolation", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BackwardflatLinearInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".EnableExtrapolation") 
                                               [| _BackwardflatLinearInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_extrapolate", Description="Create a BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BackwardflatLinearInterpolation",Description = "Reference to BackwardflatLinearInterpolation")>] 
         backwardflatlinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BackwardflatLinearInterpolation = Helper.toCell<BackwardflatLinearInterpolation> backwardflatlinearinterpolation "BackwardflatLinearInterpolation" true 
                let builder () = withMnemonic mnemonic ((_BackwardflatLinearInterpolation.cell :?> BackwardflatLinearInterpolationModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BackwardflatLinearInterpolation.source + ".Extrapolate") 
                                               [| _BackwardflatLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BackwardflatLinearInterpolation.cell
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
    [<ExcelFunction(Name="_BackwardflatLinearInterpolation_Range", Description="Create a range of BackwardflatLinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BackwardflatLinearInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BackwardflatLinearInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BackwardflatLinearInterpolation> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BackwardflatLinearInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BackwardflatLinearInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BackwardflatLinearInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
