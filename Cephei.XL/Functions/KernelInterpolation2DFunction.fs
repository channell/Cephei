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
  Implementation of the 2D kernel interpolation approach, which can be found in "Foreign Exchange Risk" by Hakala, Wystup page 256.  The kernel in the implementation is kept general, although a Gaussian is considered in the cited text.
  </summary> *)
[<AutoSerializable(true)>]
module KernelInterpolation2DFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_KernelInterpolation2D", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="ySize",Description = "Reference to ySize")>] 
         ySize : obj)
        ([<ExcelArgument(Name="zData",Description = "Reference to zData")>] 
         zData : obj)
        ([<ExcelArgument(Name="kernel",Description = "Reference to kernel")>] 
         kernel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _ySize = Helper.toCell<int> ySize "ySize" 
                let _zData = Helper.toCell<Matrix> zData "zData" 
                let _kernel = Helper.toCell<IKernelFunction> kernel "kernel" 
                let builder () = withMnemonic mnemonic (Fun.KernelInterpolation2D 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _ySize.cell 
                                                            _zData.cell 
                                                            _kernel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<KernelInterpolation2D>) l

                let source = Helper.sourceFold "Fun.KernelInterpolation2D" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _ySize.source
                                               ;  _zData.source
                                               ;  _kernel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _ySize.cell
                                ;  _zData.cell
                                ;  _kernel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KernelInterpolation2D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_KernelInterpolation2D_isInRange", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_isInRange
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).IsInRange
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".IsInRange") 
                                               [| _KernelInterpolation2D.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_locateX", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_locateX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).LocateX
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".LocateX") 
                                               [| _KernelInterpolation2D.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_locateY", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_locateY
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).LocateY
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".LocateY") 
                                               [| _KernelInterpolation2D.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_update", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).Update
                                                       ) :> ICell
                let format (o : KernelInterpolation2D) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".Update") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_value1", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).Value1
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".Value1") 
                                               [| _KernelInterpolation2D.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_value", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).Value
                                                            _x.cell 
                                                            _y.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".Value") 
                                               [| _KernelInterpolation2D.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_xMax", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".XMax") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_xMin", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".XMin") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_xValues", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_xValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).XValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".XValues") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_yMax", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_yMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).YMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".YMax") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_yMin", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_yMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).YMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".YMin") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_yValues", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_yValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).YValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".YValues") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_zData", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_zData
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).ZData
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".ZData") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KernelInterpolation2D> format
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
    [<ExcelFunction(Name="_KernelInterpolation2D_allowsExtrapolation", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".AllowsExtrapolation") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_disableExtrapolation", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : KernelInterpolation2D) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".DisableExtrapolation") 
                                               [| _KernelInterpolation2D.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_enableExtrapolation", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : KernelInterpolation2D) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".EnableExtrapolation") 
                                               [| _KernelInterpolation2D.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_extrapolate", Description="Create a KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KernelInterpolation2D",Description = "Reference to KernelInterpolation2D")>] 
         kernelinterpolation2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KernelInterpolation2D = Helper.toCell<KernelInterpolation2D> kernelinterpolation2d "KernelInterpolation2D"  
                let builder () = withMnemonic mnemonic ((KernelInterpolation2DModel.Cast _KernelInterpolation2D.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_KernelInterpolation2D.source + ".Extrapolate") 
                                               [| _KernelInterpolation2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KernelInterpolation2D.cell
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
    [<ExcelFunction(Name="_KernelInterpolation2D_Range", Description="Create a range of KernelInterpolation2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KernelInterpolation2D_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the KernelInterpolation2D")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<KernelInterpolation2D> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<KernelInterpolation2D>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<KernelInterpolation2D>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<KernelInterpolation2D>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
