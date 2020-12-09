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
  Standard constant parameter a(t) = a
  </summary> *)
[<AutoSerializable(true)>]
module ConstantParameterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConstantParameter1", Description="Create a ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        ([<ExcelArgument(Name="Constraint",Description = "Constraint")>] 
         Constraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _value = Helper.toCell<double> value "value" 
                let _Constraint = Helper.toCell<Constraint> Constraint "Constraint" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantParameter1 
                                                            _value.cell 
                                                            _Constraint.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantParameter>) l

                let source () = Helper.sourceFold "Fun.ConstantParameter1" 
                                               [| _value.source
                                               ;  _Constraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _value.cell
                                ;  _Constraint.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantParameter", Description="Create a ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Constraint",Description = "Constraint")>] 
         Constraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Constraint = Helper.toCell<Constraint> Constraint "Constraint" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantParameter
                                                            _Constraint.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantParameter>) l

                let source () = Helper.sourceFold "Fun.ConstantParameter" 
                                               [| _Constraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Constraint.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantParameter_constraint", Description="Create a ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantParameter",Description = "ConstantParameter")>] 
         constantparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantParameter = Helper.toCell<ConstantParameter> constantparameter "ConstantParameter"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantParameterModel.Cast _ConstantParameter.cell).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source () = Helper.sourceFold (_ConstantParameter.source + ".CONSTRAINT") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantParameter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! Impl unresolved
    [<ExcelFunction(Name="_ConstantParameter_implementation", Description="Create a ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_implementation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantParameter",Description = "ConstantParameter")>] 
         constantparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantParameter = Helper.toCell<ConstantParameter> constantparameter "ConstantParameter"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantParameterModel.Cast _ConstantParameter.cell).Implementation
                                                       ) :> ICell
                let format (o : Impl) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConstantParameter.source + ".Implementation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantParameter.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantParameter_parameters", Description="Create a ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantParameter",Description = "ConstantParameter")>] 
         constantparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantParameter = Helper.toCell<ConstantParameter> constantparameter "ConstantParameter"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantParameterModel.Cast _ConstantParameter.cell).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ConstantParameter.source + ".Parameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantParameter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantParameter_setParam", Description="Create a ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_setParam
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantParameter",Description = "ConstantParameter")>] 
         constantparameter : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantParameter = Helper.toCell<ConstantParameter> constantparameter "ConstantParameter"  
                let _i = Helper.toCell<int> i "i" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantParameterModel.Cast _ConstantParameter.cell).SetParam
                                                            _i.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : ConstantParameter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConstantParameter.source + ".SetParam") 

                                               [| _i.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantParameter.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_ConstantParameter_size", Description="Create a ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantParameter",Description = "ConstantParameter")>] 
         constantparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantParameter = Helper.toCell<ConstantParameter> constantparameter "ConstantParameter"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantParameterModel.Cast _ConstantParameter.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantParameter.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantParameter.cell
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
    [<ExcelFunction(Name="_ConstantParameter_testParams", Description="Create a ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_testParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantParameter",Description = "ConstantParameter")>] 
         constantparameter : obj)
        ([<ExcelArgument(Name="p",Description = "Vector")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantParameter = Helper.toCell<ConstantParameter> constantparameter "ConstantParameter"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantParameterModel.Cast _ConstantParameter.cell).TestParams
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConstantParameter.source + ".TestParams") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantParameter.cell
                                ;  _p.cell
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
    [<ExcelFunction(Name="_ConstantParameter_value", Description="Create a ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantParameter",Description = "ConstantParameter")>] 
         constantparameter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantParameter = Helper.toCell<ConstantParameter> constantparameter "ConstantParameter"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantParameterModel.Cast _ConstantParameter.cell).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantParameter.source + ".Value") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantParameter.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_ConstantParameter_Range", Description="Create a range of ConstantParameter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantParameter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConstantParameter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ConstantParameter> (c)) :> ICell
                let format (i : Generic.List<ICell<ConstantParameter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ConstantParameter>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
