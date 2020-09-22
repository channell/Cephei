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
module ComboHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ComboHelper", Description="Create a ComboHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ComboHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="quadraticHelper",Description = "Reference to quadraticHelper")>] 
         quadraticHelper : obj)
        ([<ExcelArgument(Name="convMonoHelper",Description = "Reference to convMonoHelper")>] 
         convMonoHelper : obj)
        ([<ExcelArgument(Name="quadraticity",Description = "Reference to quadraticity")>] 
         quadraticity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _quadraticHelper = Helper.toCell<ISectionHelper> quadraticHelper "quadraticHelper" true
                let _convMonoHelper = Helper.toCell<ISectionHelper> convMonoHelper "convMonoHelper" true
                let _quadraticity = Helper.toCell<double> quadraticity "quadraticity" true
                let builder () = withMnemonic mnemonic (Fun.ComboHelper 
                                                            _quadraticHelper.cell 
                                                            _convMonoHelper.cell 
                                                            _quadraticity.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ComboHelper>) l

                let source = Helper.sourceFold "Fun.ComboHelper" 
                                               [| _quadraticHelper.source
                                               ;  _convMonoHelper.source
                                               ;  _quadraticity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _quadraticHelper.cell
                                ;  _convMonoHelper.cell
                                ;  _quadraticity.cell
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
    [<ExcelFunction(Name="_ComboHelper_fNext", Description="Create a ComboHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ComboHelper_fNext
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ComboHelper",Description = "Reference to ComboHelper")>] 
         combohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ComboHelper = Helper.toCell<ComboHelper> combohelper "ComboHelper" true 
                let builder () = withMnemonic mnemonic ((_ComboHelper.cell :?> ComboHelperModel).FNext
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ComboHelper.source + ".FNext") 
                                               [| _ComboHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ComboHelper.cell
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
    [<ExcelFunction(Name="_ComboHelper_primitive", Description="Create a ComboHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ComboHelper_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ComboHelper",Description = "Reference to ComboHelper")>] 
         combohelper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ComboHelper = Helper.toCell<ComboHelper> combohelper "ComboHelper" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_ComboHelper.cell :?> ComboHelperModel).Primitive
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ComboHelper.source + ".Primitive") 
                                               [| _ComboHelper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ComboHelper.cell
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
    [<ExcelFunction(Name="_ComboHelper_value", Description="Create a ComboHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ComboHelper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ComboHelper",Description = "Reference to ComboHelper")>] 
         combohelper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ComboHelper = Helper.toCell<ComboHelper> combohelper "ComboHelper" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_ComboHelper.cell :?> ComboHelperModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ComboHelper.source + ".Value") 
                                               [| _ComboHelper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ComboHelper.cell
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
    [<ExcelFunction(Name="_ComboHelper_Range", Description="Create a range of ComboHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ComboHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ComboHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ComboHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ComboHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ComboHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ComboHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
