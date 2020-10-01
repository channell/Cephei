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
  Piecewise-constant parameter   a(t) = a_i if t_{i-1} t < t_i This kind of parameter is usually used to enhance the fitting of a model
  </summary> *)
[<AutoSerializable(true)>]
module PiecewiseConstantParameterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseConstantParameter", Description="Create a PiecewiseConstantParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseConstantParameter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="times",Description = "Reference to times")>] 
         times : obj)
        ([<ExcelArgument(Name="Constraint",Description = "Reference to Constraint")>] 
         Constraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _times = Helper.toCell<Generic.List<double>> times "times" 
                let _Constraint = Helper.toCell<Constraint> Constraint "Constraint" 
                let builder () = withMnemonic mnemonic (Fun.PiecewiseConstantParameter 
                                                            _times.cell 
                                                            _Constraint.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseConstantParameter>) l

                let source = Helper.sourceFold "Fun.PiecewiseConstantParameter" 
                                               [| _times.source
                                               ;  _Constraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _times.cell
                                ;  _Constraint.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseConstantParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseConstantParameter_constraint", Description="Create a PiecewiseConstantParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseConstantParameter_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseConstantParameter",Description = "Reference to PiecewiseConstantParameter")>] 
         piecewiseconstantparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseConstantParameter = Helper.toCell<PiecewiseConstantParameter> piecewiseconstantparameter "PiecewiseConstantParameter"  
                let builder () = withMnemonic mnemonic ((_PiecewiseConstantParameter.cell :?> PiecewiseConstantParameterModel).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_PiecewiseConstantParameter.source + ".CONSTRAINT") 
                                               [| _PiecewiseConstantParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseConstantParameter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseConstantParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! irnored 
    [<ExcelFunction(Name="_PiecewiseConstantParameter_implementation", Description="Create a PiecewiseConstantParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseConstantParameter_implementation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseConstantParameter",Description = "Reference to PiecewiseConstantParameter")>] 
         piecewiseconstantparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseConstantParameter = Helper.toCell<PiecewiseConstantParameter> piecewiseconstantparameter "PiecewiseConstantParameter"  
                let builder () = withMnemonic mnemonic ((_PiecewiseConstantParameter.cell :?> PiecewiseConstantParameterModel).Implementation
                                                       ) :> ICell
                let format (o : Parameter.Impl) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseConstantParameter.source + ".Implementation") 
                                               [| _PiecewiseConstantParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseConstantParameter.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseConstantParameter_parameters", Description="Create a PiecewiseConstantParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseConstantParameter_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseConstantParameter",Description = "Reference to PiecewiseConstantParameter")>] 
         piecewiseconstantparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseConstantParameter = Helper.toCell<PiecewiseConstantParameter> piecewiseconstantparameter "PiecewiseConstantParameter"  
                let builder () = withMnemonic mnemonic ((_PiecewiseConstantParameter.cell :?> PiecewiseConstantParameterModel).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_PiecewiseConstantParameter.source + ".Parameters") 
                                               [| _PiecewiseConstantParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseConstantParameter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseConstantParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseConstantParameter_setParam", Description="Create a PiecewiseConstantParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseConstantParameter_setParam
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseConstantParameter",Description = "Reference to PiecewiseConstantParameter")>] 
         piecewiseconstantparameter : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseConstantParameter = Helper.toCell<PiecewiseConstantParameter> piecewiseconstantparameter "PiecewiseConstantParameter"  
                let _i = Helper.toCell<int> i "i" 
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_PiecewiseConstantParameter.cell :?> PiecewiseConstantParameterModel).SetParam
                                                            _i.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : PiecewiseConstantParameter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseConstantParameter.source + ".SetParam") 
                                               [| _PiecewiseConstantParameter.source
                                               ;  _i.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseConstantParameter.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_PiecewiseConstantParameter_size", Description="Create a PiecewiseConstantParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseConstantParameter_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseConstantParameter",Description = "Reference to PiecewiseConstantParameter")>] 
         piecewiseconstantparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseConstantParameter = Helper.toCell<PiecewiseConstantParameter> piecewiseconstantparameter "PiecewiseConstantParameter"  
                let builder () = withMnemonic mnemonic ((_PiecewiseConstantParameter.cell :?> PiecewiseConstantParameterModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseConstantParameter.source + ".Size") 
                                               [| _PiecewiseConstantParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseConstantParameter.cell
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
    [<ExcelFunction(Name="_PiecewiseConstantParameter_testParams", Description="Create a PiecewiseConstantParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseConstantParameter_testParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseConstantParameter",Description = "Reference to PiecewiseConstantParameter")>] 
         piecewiseconstantparameter : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseConstantParameter = Helper.toCell<PiecewiseConstantParameter> piecewiseconstantparameter "PiecewiseConstantParameter"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder () = withMnemonic mnemonic ((_PiecewiseConstantParameter.cell :?> PiecewiseConstantParameterModel).TestParams
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseConstantParameter.source + ".TestParams") 
                                               [| _PiecewiseConstantParameter.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseConstantParameter.cell
                                ;  _p.cell
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
    [<ExcelFunction(Name="_PiecewiseConstantParameter_value", Description="Create a PiecewiseConstantParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseConstantParameter_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseConstantParameter",Description = "Reference to PiecewiseConstantParameter")>] 
         piecewiseconstantparameter : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseConstantParameter = Helper.toCell<PiecewiseConstantParameter> piecewiseconstantparameter "PiecewiseConstantParameter"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_PiecewiseConstantParameter.cell :?> PiecewiseConstantParameterModel).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseConstantParameter.source + ".Value") 
                                               [| _PiecewiseConstantParameter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseConstantParameter.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_PiecewiseConstantParameter_Range", Description="Create a range of PiecewiseConstantParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseConstantParameter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PiecewiseConstantParameter")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PiecewiseConstantParameter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PiecewiseConstantParameter>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PiecewiseConstantParameter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PiecewiseConstantParameter>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
