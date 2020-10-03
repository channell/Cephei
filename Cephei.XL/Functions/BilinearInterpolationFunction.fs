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
  %bilinear interpolation between discrete points
  </summary> *)
[<AutoSerializable(true)>]
module BilinearInterpolationFunction =

    (*
        ! \pre the \f$ x \f$ and \f$ y \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_BilinearInterpolation", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xSize",Description = "Reference to xSize")>] 
         xSize : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="ySize",Description = "Reference to ySize")>] 
         ySize : obj)
        ([<ExcelArgument(Name="zData",Description = "Reference to zData")>] 
         zData : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xSize = Helper.toCell<int> xSize "xSize" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _ySize = Helper.toCell<int> ySize "ySize" 
                let _zData = Helper.toCell<Matrix> zData "zData" 
                let builder () = withMnemonic mnemonic (Fun.BilinearInterpolation 
                                                            _xBegin.cell 
                                                            _xSize.cell 
                                                            _yBegin.cell 
                                                            _ySize.cell 
                                                            _zData.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BilinearInterpolation>) l

                let source = Helper.sourceFold "Fun.BilinearInterpolation" 
                                               [| _xBegin.source
                                               ;  _xSize.source
                                               ;  _yBegin.source
                                               ;  _ySize.source
                                               ;  _zData.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _xSize.cell
                                ;  _yBegin.cell
                                ;  _ySize.cell
                                ;  _zData.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BilinearInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BilinearInterpolation_isInRange", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_isInRange
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).IsInRange
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".IsInRange") 
                                               [| _BilinearInterpolation.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_locateX", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_locateX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).LocateX
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".LocateX") 
                                               [| _BilinearInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_locateY", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_locateY
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).LocateY
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".LocateY") 
                                               [| _BilinearInterpolation.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_update", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : BilinearInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".Update") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_value1", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).Value1
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".Value") 
                                               [| _BilinearInterpolation.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_value", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).Value
                                                            _x.cell 
                                                            _y.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".Value") 
                                               [| _BilinearInterpolation.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_xMax", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".XMax") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_xMin", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".XMin") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_xValues", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_xValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).XValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".XValues") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_yMax", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_yMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).YMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".YMax") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_yMin", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_yMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).YMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".YMin") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_yValues", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_yValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).YValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".YValues") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_zData", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_zData
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).ZData
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".ZData") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BilinearInterpolation> format
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
    [<ExcelFunction(Name="_BilinearInterpolation_allowsExtrapolation", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".AllowsExtrapolation") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_disableExtrapolation", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BilinearInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".DisableExtrapolation") 
                                               [| _BilinearInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_enableExtrapolation", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : BilinearInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".EnableExtrapolation") 
                                               [| _BilinearInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_extrapolate", Description="Create a BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BilinearInterpolation",Description = "Reference to BilinearInterpolation")>] 
         bilinearinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BilinearInterpolation = Helper.toCell<BilinearInterpolation> bilinearinterpolation "BilinearInterpolation"  
                let builder () = withMnemonic mnemonic ((BilinearInterpolationModel.Cast _BilinearInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BilinearInterpolation.source + ".Extrapolate") 
                                               [| _BilinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BilinearInterpolation.cell
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
    [<ExcelFunction(Name="_BilinearInterpolation_Range", Description="Create a range of BilinearInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BilinearInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BilinearInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BilinearInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BilinearInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BilinearInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BilinearInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
