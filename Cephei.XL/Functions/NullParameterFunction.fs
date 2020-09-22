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
(*!! ignored for excel 
(* <summary>
  %Parameter which is always zero a(t) = 0
  </summary> *)
[<AutoSerializable(true)>]
module NullParameterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NullParameter", Description="Create a NullParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullParameter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.NullParameter 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NullParameter>) l

                let source = Helper.sourceFold "Fun.NullParameter" 
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
    [<ExcelFunction(Name="_NullParameter_constraint", Description="Create a NullParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullParameter_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullParameter",Description = "Reference to NullParameter")>] 
         nullparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullParameter = Helper.toCell<NullParameter> nullparameter "NullParameter" true 
                let builder () = withMnemonic mnemonic ((_NullParameter.cell :?> NullParameterModel).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_NullParameter.source + ".CONSTRAINT") 
                                               [| _NullParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullParameter.cell
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
    [<ExcelFunction(Name="_NullParameter_implementation", Description="Create a NullParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullParameter_implementation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullParameter",Description = "Reference to NullParameter")>] 
         nullparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullParameter = Helper.toCell<NullParameter> nullparameter "NullParameter" true 
                let builder () = withMnemonic mnemonic ((_NullParameter.cell :?> NullParameterModel).Implementation
                                                       ) :> ICell
                let format (o : Impl) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullParameter.source + ".Implementation") 
                                               [| _NullParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullParameter.cell
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
    [<ExcelFunction(Name="_NullParameter_parameters", Description="Create a NullParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullParameter_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullParameter",Description = "Reference to NullParameter")>] 
         nullparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullParameter = Helper.toCell<NullParameter> nullparameter "NullParameter" true 
                let builder () = withMnemonic mnemonic ((_NullParameter.cell :?> NullParameterModel).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NullParameter.source + ".Parameters") 
                                               [| _NullParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullParameter.cell
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
    [<ExcelFunction(Name="_NullParameter_setParam", Description="Create a NullParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullParameter_setParam
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullParameter",Description = "Reference to NullParameter")>] 
         nullparameter : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullParameter = Helper.toCell<NullParameter> nullparameter "NullParameter" true 
                let _i = Helper.toCell<int> i "i" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_NullParameter.cell :?> NullParameterModel).SetParam
                                                            _i.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : NullParameter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullParameter.source + ".SetParam") 
                                               [| _NullParameter.source
                                               ;  _i.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullParameter.cell
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
    [<ExcelFunction(Name="_NullParameter_size", Description="Create a NullParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullParameter_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullParameter",Description = "Reference to NullParameter")>] 
         nullparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullParameter = Helper.toCell<NullParameter> nullparameter "NullParameter" true 
                let builder () = withMnemonic mnemonic ((_NullParameter.cell :?> NullParameterModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NullParameter.source + ".Size") 
                                               [| _NullParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullParameter.cell
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
    [<ExcelFunction(Name="_NullParameter_testParams", Description="Create a NullParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullParameter_testParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullParameter",Description = "Reference to NullParameter")>] 
         nullparameter : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullParameter = Helper.toCell<NullParameter> nullparameter "NullParameter" true 
                let _p = Helper.toCell<Vector> p "p" true
                let builder () = withMnemonic mnemonic ((_NullParameter.cell :?> NullParameterModel).TestParams
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullParameter.source + ".TestParams") 
                                               [| _NullParameter.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullParameter.cell
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
    [<ExcelFunction(Name="_NullParameter_value", Description="Create a NullParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullParameter_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullParameter",Description = "Reference to NullParameter")>] 
         nullparameter : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullParameter = Helper.toCell<NullParameter> nullparameter "NullParameter" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_NullParameter.cell :?> NullParameterModel).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NullParameter.source + ".Value") 
                                               [| _NullParameter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullParameter.cell
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
    [<ExcelFunction(Name="_NullParameter_Range", Description="Create a range of NullParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullParameter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NullParameter")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NullParameter> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NullParameter>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NullParameter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NullParameter>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)