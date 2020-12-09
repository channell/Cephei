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
(*!! ommitted 
(* <summary>
  1-D stochastic process whose dynamics are expressed in the forward measure.  processes
  </summary> *)
[<AutoSerializable(true)>]
module ForwardMeasureProcess1DFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_diffusion", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Diffusion") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_drift", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Drift") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_getForwardMeasureTime", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_getForwardMeasureTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).GetForwardMeasureTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".GetForwardMeasureTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_setForwardMeasureTime", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_setForwardMeasureTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="T",Description = "double")>] 
         T : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _T = Helper.toCell<double> T "T" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).SetForwardMeasureTime
                                                            _T.cell 
                                                       ) :> ICell
                let format (o : ForwardMeasureProcess1D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".SetForwardMeasureTime") 

                                               [| _T.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _T.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_x0", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".X0") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_apply", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Vector")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dx = Helper.toCell<Vector> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Apply") 

                                               [| _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _x0.cell
                                ;  _dx.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        applies a change to the asset value.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_apply", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "double")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dx = Helper.toCell<double> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Apply1
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Apply") 

                                               [| _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _x0.cell
                                ;  _dx.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_evolve", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        ([<ExcelArgument(Name="dw",Description = "Vector")>] 
         dw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<Vector> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Evolve") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        returns the asset value after a time interval.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_evolve", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        ([<ExcelArgument(Name="dw",Description = "double")>] 
         dw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<double> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Evolve1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Evolve") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_expectation", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Expectation") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the expectation. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_expectation", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Expectation1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Expectation") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
        ! returns the initial values of the state variables
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_initialValues", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".InitialValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_size", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_stdDeviation", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".StdDeviation") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the standard deviation. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_stdDeviation", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).StdDeviation1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".StdDeviation") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_variance", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Variance") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the variance. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_variance", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Variance1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Variance") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
        ! returns the covariance. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_covariance", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Covariance") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardMeasureProcess1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the number of independent factors of the process
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_factors", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_registerWith", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ForwardMeasureProcess1D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _handler.cell
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
        ! returns the time value corresponding to the given date in the reference system of the stochastic process.  \note As a number of processes might not need this functionality, a default implementation is given which raises an exception.
    *)
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_time", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Time") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_unregisterWith", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ForwardMeasureProcess1D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_update", Description="Create a ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardMeasureProcess1D",Description = "ForwardMeasureProcess1D")>] 
         forwardmeasureprocess1d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardMeasureProcess1D = Helper.toCell<ForwardMeasureProcess1D> forwardmeasureprocess1d "ForwardMeasureProcess1D"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardMeasureProcess1DModel.Cast _ForwardMeasureProcess1D.cell).Update
                                                       ) :> ICell
                let format (o : ForwardMeasureProcess1D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardMeasureProcess1D.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardMeasureProcess1D.cell
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
    [<ExcelFunction(Name="_ForwardMeasureProcess1D_Range", Description="Create a range of ForwardMeasureProcess1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardMeasureProcess1D_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardMeasureProcess1D> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ForwardMeasureProcess1D> (c)) :> ICell
                let format (i : Generic.List<ICell<ForwardMeasureProcess1D>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ForwardMeasureProcess1D>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
