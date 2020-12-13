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
module FlatExtrapolator2DFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FlatExtrapolator2D", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="decoratedInterpolation",Description = "Interpolation2D")>] 
         decoratedInterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _decoratedInterpolation = Helper.toCell<Interpolation2D> decoratedInterpolation "decoratedInterpolation" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FlatExtrapolator2D 
                                                            _decoratedInterpolation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatExtrapolator2D>) l

                let source () = Helper.sourceFold "Fun.FlatExtrapolator2D" 
                                               [| _decoratedInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _decoratedInterpolation.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatExtrapolator2D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatExtrapolator2D_isInRange", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_isInRange
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).IsInRange
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".IsInRange") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_locateX", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_locateX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).LocateX
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".LocateX") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_locateY", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_locateY
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).LocateY
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".LocateY") 

                                               [| _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_update", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).Update
                                                       ) :> ICell
                let format (o : FlatExtrapolator2D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_value1", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).Value1
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".Value1") 

                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_value", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double")>] 
         y : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).Value
                                                            _x.cell 
                                                            _y.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".Value") 

                                               [| _x.source
                                               ;  _y.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_xMax", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_xMin", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_xValues", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_xValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).XValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".XValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_yMax", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_yMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).YMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".YMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_yMin", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_yMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).YMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".YMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_yValues", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_yValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).YValues
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".YValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_zData", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_zData
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).ZData
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".ZData") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatExtrapolator2D> format
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_allowsExtrapolation", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_disableExtrapolation", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FlatExtrapolator2D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_enableExtrapolation", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FlatExtrapolator2D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_extrapolate", Description="Create a FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatExtrapolator2D",Description = "FlatExtrapolator2D")>] 
         flatextrapolator2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatExtrapolator2D = Helper.toCell<FlatExtrapolator2D> flatextrapolator2d "FlatExtrapolator2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((FlatExtrapolator2DModel.Cast _FlatExtrapolator2D.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FlatExtrapolator2D.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FlatExtrapolator2D.cell
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
    [<ExcelFunction(Name="_FlatExtrapolator2D_Range", Description="Create a range of FlatExtrapolator2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatExtrapolator2D_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FlatExtrapolator2D> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FlatExtrapolator2D> (c)) :> ICell
                let format (i : Cephei.Cell.List<FlatExtrapolator2D>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FlatExtrapolator2D>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
