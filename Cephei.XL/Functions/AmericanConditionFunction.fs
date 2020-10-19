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
  unify the intrinsicValues/Payoff thing
  </summary> *)
[<AutoSerializable(true)>]
module AmericanConditionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmericanCondition1", Description="Create a AmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanCondition_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "AmericanCondition")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="intrinsicValues",Description = "Vector")>] 
         intrinsicValues : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _intrinsicValues = Helper.toCell<Vector> intrinsicValues "intrinsicValues" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AmericanCondition1 
                                                            _intrinsicValues.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmericanCondition>) l

                let source () = Helper.sourceFold "Fun.AmericanCondition" 
                                               [| _intrinsicValues.source
                                               |]
                let hash = Helper.hashFold 
                                [| _intrinsicValues.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmericanCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmericanCondition", Description="Create a AmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanCondition_create
        ([<ExcelArgument(Name="Mnemonic",Description = "AmericanCondition")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AmericanCondition
                                                            _Type.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmericanCondition>) l

                let source () = Helper.sourceFold "Fun.AmericanCondition1" 
                                               [| _Type.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmericanCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmericanCondition_applyTo", Description="Create a AmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanCondition_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanCondition",Description = "AmericanCondition")>] 
         americancondition : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanCondition = Helper.toCell<AmericanCondition> americancondition "AmericanCondition"  
                let _o = Helper.toCell<Object> o "o" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((AmericanConditionModel.Cast _AmericanCondition.cell).ApplyTo
                                                            _o.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : AmericanCondition) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AmericanCondition.source + ".ApplyTo") 
                                               [| _AmericanCondition.source
                                               ;  _o.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanCondition.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_AmericanCondition_Range", Description="Create a range of AmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanCondition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmericanCondition> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AmericanCondition>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AmericanCondition>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AmericanCondition>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
