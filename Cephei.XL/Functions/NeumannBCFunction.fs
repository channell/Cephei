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
NeumanBC works on TridiagonalOperator. IOperator here is for type compatobility with options
  </summary> *)
[<AutoSerializable(true)>]
module NeumannBCFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NeumannBC_applyAfterApplying", Description="Create a NeumannBC",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NeumannBC_applyAfterApplying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NeumannBC",Description = "Reference to NeumannBC")>] 
         neumannbc : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NeumannBC = Helper.toCell<NeumannBC> neumannbc "NeumannBC"  
                let _u = Helper.toCell<Vector> u "u" 
                let builder () = withMnemonic mnemonic ((NeumannBCModel.Cast _NeumannBC.cell).ApplyAfterApplying
                                                            _u.cell 
                                                       ) :> ICell
                let format (o : NeumannBC) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NeumannBC.source + ".ApplyAfterApplying") 
                                               [| _NeumannBC.source
                                               ;  _u.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NeumannBC.cell
                                ;  _u.cell
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
    [<ExcelFunction(Name="_NeumannBC_applyAfterSolving", Description="Create a NeumannBC",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NeumannBC_applyAfterSolving
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NeumannBC",Description = "Reference to NeumannBC")>] 
         neumannbc : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NeumannBC = Helper.toCell<NeumannBC> neumannbc "NeumannBC"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder () = withMnemonic mnemonic ((NeumannBCModel.Cast _NeumannBC.cell).ApplyAfterSolving
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : NeumannBC) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NeumannBC.source + ".ApplyAfterSolving") 
                                               [| _NeumannBC.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NeumannBC.cell
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
        interface
    *)
    [<ExcelFunction(Name="_NeumannBC_applyBeforeApplying", Description="Create a NeumannBC",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NeumannBC_applyBeforeApplying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NeumannBC",Description = "Reference to NeumannBC")>] 
         neumannbc : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NeumannBC = Helper.toCell<NeumannBC> neumannbc "NeumannBC"  
                let _o = Helper.toCell<IOperator> o "o" 
                let builder () = withMnemonic mnemonic ((NeumannBCModel.Cast _NeumannBC.cell).ApplyBeforeApplying
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : NeumannBC) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NeumannBC.source + ".ApplyBeforeApplying") 
                                               [| _NeumannBC.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NeumannBC.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_NeumannBC_applyBeforeSolving", Description="Create a NeumannBC",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NeumannBC_applyBeforeSolving
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NeumannBC",Description = "Reference to NeumannBC")>] 
         neumannbc : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        ([<ExcelArgument(Name="rhs",Description = "Reference to rhs")>] 
         rhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NeumannBC = Helper.toCell<NeumannBC> neumannbc "NeumannBC"  
                let _o = Helper.toCell<IOperator> o "o" 
                let _rhs = Helper.toCell<Vector> rhs "rhs" 
                let builder () = withMnemonic mnemonic ((NeumannBCModel.Cast _NeumannBC.cell).ApplyBeforeSolving
                                                            _o.cell 
                                                            _rhs.cell 
                                                       ) :> ICell
                let format (o : NeumannBC) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NeumannBC.source + ".ApplyBeforeSolving") 
                                               [| _NeumannBC.source
                                               ;  _o.source
                                               ;  _rhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NeumannBC.cell
                                ;  _o.cell
                                ;  _rhs.cell
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
    [<ExcelFunction(Name="_NeumannBC", Description="Create a NeumannBC",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NeumannBC_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        ([<ExcelArgument(Name="side",Description = "Reference to side")>] 
         side : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _value = Helper.toCell<double> value "value" 
                let _side = Helper.toCell<BoundaryCondition<IOperator>.Side> side "side" 
                let builder () = withMnemonic mnemonic (Fun.NeumannBC 
                                                            _value.cell 
                                                            _side.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NeumannBC>) l

                let source = Helper.sourceFold "Fun.NeumannBC" 
                                               [| _value.source
                                               ;  _side.source
                                               |]
                let hash = Helper.hashFold 
                                [| _value.cell
                                ;  _side.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NeumannBC> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NeumannBC_setTime", Description="Create a NeumannBC",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NeumannBC_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NeumannBC",Description = "Reference to NeumannBC")>] 
         neumannbc : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NeumannBC = Helper.toCell<NeumannBC> neumannbc "NeumannBC"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((NeumannBCModel.Cast _NeumannBC.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : NeumannBC) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NeumannBC.source + ".SetTime") 
                                               [| _NeumannBC.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NeumannBC.cell
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
    [<ExcelFunction(Name="_NeumannBC_Range", Description="Create a range of NeumannBC",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NeumannBC_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NeumannBC")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NeumannBC> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NeumannBC>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NeumannBC>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NeumannBC>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
