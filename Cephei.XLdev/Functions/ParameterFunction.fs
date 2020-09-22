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
  Base class for model arguments
  </summary> *)
[<AutoSerializable(true)>]
module ParameterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Parameter_constraint", Description="Create a Parameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Parameter_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parameter",Description = "Reference to Parameter")>] 
         parameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parameter = Helper.toCell<Parameter> parameter "Parameter" true 
                let builder () = withMnemonic mnemonic ((_Parameter.cell :?> ParameterModel).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_Parameter.source + ".CONSTRAINT") 
                                               [| _Parameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parameter.cell
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
    [<ExcelFunction(Name="_Parameter_implementation", Description="Create a Parameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Parameter_implementation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parameter",Description = "Reference to Parameter")>] 
         parameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parameter = Helper.toCell<Parameter> parameter "Parameter" true 
                let builder () = withMnemonic mnemonic ((_Parameter.cell :?> ParameterModel).Implementation
                                                       ) :> ICell
                let format (o : Impl) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Parameter.source + ".Implementation") 
                                               [| _Parameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parameter.cell
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
    [<ExcelFunction(Name="_Parameter", Description="Create a Parameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Parameter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Parameter 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Parameter>) l

                let source = Helper.sourceFold "Fun.Parameter" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_Parameter_parameters", Description="Create a Parameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Parameter_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parameter",Description = "Reference to Parameter")>] 
         parameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parameter = Helper.toCell<Parameter> parameter "Parameter" true 
                let builder () = withMnemonic mnemonic ((_Parameter.cell :?> ParameterModel).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Parameter.source + ".Parameters") 
                                               [| _Parameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parameter.cell
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
    [<ExcelFunction(Name="_Parameter_setParam", Description="Create a Parameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Parameter_setParam
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parameter",Description = "Reference to Parameter")>] 
         parameter : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parameter = Helper.toCell<Parameter> parameter "Parameter" true 
                let _i = Helper.toCell<int> i "i" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_Parameter.cell :?> ParameterModel).SetParam
                                                            _i.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : Parameter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Parameter.source + ".SetParam") 
                                               [| _Parameter.source
                                               ;  _i.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parameter.cell
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
    [<ExcelFunction(Name="_Parameter_size", Description="Create a Parameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Parameter_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parameter",Description = "Reference to Parameter")>] 
         parameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parameter = Helper.toCell<Parameter> parameter "Parameter" true 
                let builder () = withMnemonic mnemonic ((_Parameter.cell :?> ParameterModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Parameter.source + ".Size") 
                                               [| _Parameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parameter.cell
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
    [<ExcelFunction(Name="_Parameter_testParams", Description="Create a Parameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Parameter_testParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parameter",Description = "Reference to Parameter")>] 
         parameter : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parameter = Helper.toCell<Parameter> parameter "Parameter" true 
                let _p = Helper.toCell<Vector> p "p" true
                let builder () = withMnemonic mnemonic ((_Parameter.cell :?> ParameterModel).TestParams
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Parameter.source + ".TestParams") 
                                               [| _Parameter.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parameter.cell
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
    [<ExcelFunction(Name="_Parameter_value", Description="Create a Parameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Parameter_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Parameter",Description = "Reference to Parameter")>] 
         parameter : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Parameter = Helper.toCell<Parameter> parameter "Parameter" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_Parameter.cell :?> ParameterModel).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Parameter.source + ".Value") 
                                               [| _Parameter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Parameter.cell
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
    [<ExcelFunction(Name="_Parameter_Range", Description="Create a range of Parameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Parameter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Parameter")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Parameter> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Parameter>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Parameter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Parameter>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
