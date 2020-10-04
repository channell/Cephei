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
  Initially the class will contain one indexed curve
  </summary> *)
[<AutoSerializable(true)>]
module SampledCurveFunction =

    (*
        instead of "=" overload
    *)
    [<ExcelFunction(Name="_SampledCurve_Clone", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".Clone") 
                                               [| _SampledCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
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
    [<ExcelFunction(Name="_SampledCurve_empty", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".Empty") 
                                               [| _SampledCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
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
        ! \todo replace or complement with a more general function firstDerivativeAt(spot)
    *)
    [<ExcelFunction(Name="_SampledCurve_firstDerivativeAtCenter", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_firstDerivativeAtCenter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).FirstDerivativeAtCenter
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".FirstDerivativeAtCenter") 
                                               [| _SampledCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
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
    [<ExcelFunction(Name="_SampledCurve_grid", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SampledCurve.source + ".Grid") 
                                               [| _SampledCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SampledCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SampledCurve_gridValue", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_gridValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).GridValue
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".GridValue") 
                                               [| _SampledCurve.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_SampledCurve_regrid", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_regrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="new_grid",Description = "Reference to new_grid")>] 
         new_grid : obj)
        ([<ExcelArgument(Name="func",Description = "Reference to func")>] 
         func : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _new_grid = Helper.toCell<Vector> new_grid "new_grid" 
                let _func = Helper.toCell<Func<double,double>> func "func" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Regrid
                                                            _new_grid.cell 
                                                            _func.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".Regrid") 
                                               [| _SampledCurve.source
                                               ;  _new_grid.source
                                               ;  _func.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _new_grid.cell
                                ;  _func.cell
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
    [<ExcelFunction(Name="_SampledCurve_regrid1", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_regrid1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="new_grid",Description = "Reference to new_grid")>] 
         new_grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _new_grid = Helper.toCell<Vector> new_grid "new_grid" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Regrid1
                                                            _new_grid.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".Regrid1") 
                                               [| _SampledCurve.source
                                               ;  _new_grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _new_grid.cell
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
    [<ExcelFunction(Name="_SampledCurve_regridLogGrid", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_regridLogGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="min",Description = "Reference to min")>] 
         min : obj)
        ([<ExcelArgument(Name="max",Description = "Reference to max")>] 
         max : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _min = Helper.toCell<double> min "min" 
                let _max = Helper.toCell<double> max "max" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).RegridLogGrid
                                                            _min.cell 
                                                            _max.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".RegridLogGrid") 
                                               [| _SampledCurve.source
                                               ;  _min.source
                                               ;  _max.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _min.cell
                                ;  _max.cell
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
    [<ExcelFunction(Name="_SampledCurve_sample", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_sample
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Sample
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".Sample") 
                                               [| _SampledCurve.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_SampledCurve", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _grid = Helper.toCell<Vector> grid "grid" 
                let builder () = withMnemonic mnemonic (Fun.SampledCurve 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold "Fun.SampledCurve" 
                                               [| _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _grid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SampledCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SampledCurve1", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="gridSize",Description = "Reference to gridSize")>] 
         gridSize : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _gridSize = Helper.toCell<int> gridSize "gridSize" 
                let builder () = withMnemonic mnemonic (Fun.SampledCurve1 
                                                            _gridSize.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold "Fun.SampledCurve1" 
                                               [| _gridSize.source
                                               |]
                let hash = Helper.hashFold 
                                [| _gridSize.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SampledCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SampledCurve_scaleGrid", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_scaleGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _s = Helper.toCell<double> s "s" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).ScaleGrid
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".ScaleGrid") 
                                               [| _SampledCurve.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _s.cell
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
        ! \todo replace or complement with a more general function secondDerivativeAt(spot)
    *)
    [<ExcelFunction(Name="_SampledCurve_secondDerivativeAtCenter", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_secondDerivativeAtCenter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).SecondDerivativeAtCenter
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".SecondDerivativeAtCenter") 
                                               [| _SampledCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
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
        modifiers
    *)
    [<ExcelFunction(Name="_SampledCurve_setGrid", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_setGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="g",Description = "Reference to g")>] 
         g : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _g = Helper.toCell<Vector> g "g" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).SetGrid
                                                            _g.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".SetGrid") 
                                               [| _SampledCurve.source
                                               ;  _g.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _g.cell
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
        utilities
    *)
    [<ExcelFunction(Name="_SampledCurve_setLogGrid", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_setLogGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="min",Description = "Reference to min")>] 
         min : obj)
        ([<ExcelArgument(Name="max",Description = "Reference to max")>] 
         max : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _min = Helper.toCell<double> min "min" 
                let _max = Helper.toCell<double> max "max" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).SetLogGrid
                                                            _min.cell 
                                                            _max.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".SetLogGrid") 
                                               [| _SampledCurve.source
                                               ;  _min.source
                                               ;  _max.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _min.cell
                                ;  _max.cell
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
    [<ExcelFunction(Name="_SampledCurve_setValue", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_setValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _v = Helper.toCell<double> v "v" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).SetValue
                                                            _i.cell 
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".SetValue") 
                                               [| _SampledCurve.source
                                               ;  _i.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _i.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_SampledCurve_setValues", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="g",Description = "Reference to g")>] 
         g : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _g = Helper.toCell<Vector> g "g" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).SetValues
                                                            _g.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".SetValues") 
                                               [| _SampledCurve.source
                                               ;  _g.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _g.cell
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
    [<ExcelFunction(Name="_SampledCurve_shiftGrid", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_shiftGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _s = Helper.toCell<double> s "s" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).ShiftGrid
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : SampledCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".ShiftGrid") 
                                               [| _SampledCurve.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_SampledCurve_size", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".Size") 
                                               [| _SampledCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
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
    [<ExcelFunction(Name="_SampledCurve_transform", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_transform
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _x = Helper.toCell<Func<double,double>> x "x" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Transform
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold (_SampledCurve.source + ".Transform") 
                                               [| _SampledCurve.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SampledCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SampledCurve_transformGrid", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_transformGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _x = Helper.toCell<Func<double,double>> x "x" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).TransformGrid
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold (_SampledCurve.source + ".TransformGrid") 
                                               [| _SampledCurve.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SampledCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SampledCurve_value", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Value
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".Value") 
                                               [| _SampledCurve.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                ;  _i.cell
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
        ! \todo replace or complement with a more general function valueAt(spot)
    *)
    [<ExcelFunction(Name="_SampledCurve_valueAtCenter", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_valueAtCenter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).ValueAtCenter
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SampledCurve.source + ".ValueAtCenter") 
                                               [| _SampledCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
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
    [<ExcelFunction(Name="_SampledCurve_values", Description="Create a SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SampledCurve",Description = "Reference to SampledCurve")>] 
         sampledcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SampledCurve = Helper.toCell<SampledCurve> sampledcurve "SampledCurve"  
                let builder () = withMnemonic mnemonic ((SampledCurveModel.Cast _SampledCurve.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SampledCurve.source + ".Values") 
                                               [| _SampledCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SampledCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SampledCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SampledCurve_Range", Description="Create a range of SampledCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SampledCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SampledCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SampledCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SampledCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SampledCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SampledCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
