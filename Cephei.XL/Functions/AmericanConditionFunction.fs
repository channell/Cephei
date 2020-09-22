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
    [<ExcelFunction(Name="_AmericanCondition1", Description="Create a AmericanCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanCondition_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="intrinsicValues",Description = "Reference to intrinsicValues")>] 
         intrinsicValues : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _intrinsicValues = Helper.toCell<Vector> intrinsicValues "intrinsicValues" true
                let builder () = withMnemonic mnemonic (Fun.AmericanCondition1 
                                                            _intrinsicValues.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmericanCondition>) l

                let source = Helper.sourceFold "Fun.AmericanCondition" 
                                               [| _intrinsicValues.source
                                               |]
                let hash = Helper.hashFold 
                                [| _intrinsicValues.cell
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
    [<ExcelFunction(Name="_AmericanCondition", Description="Create a AmericanCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanCondition_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic (Fun.AmericanCondition
                                                            _Type.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmericanCondition>) l

                let source = Helper.sourceFold "Fun.AmericanCondition1" 
                                               [| _Type.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_AmericanCondition_applyTo", Description="Create a AmericanCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanCondition_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanCondition",Description = "Reference to AmericanCondition")>] 
         americancondition : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanCondition = Helper.toCell<AmericanCondition> americancondition "AmericanCondition" true 
                let _o = Helper.toCell<Object> o "o" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_AmericanCondition.cell :?> AmericanConditionModel).ApplyTo
                                                            _o.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : AmericanCondition) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmericanCondition.source + ".ApplyTo") 
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
    [<ExcelFunction(Name="_AmericanCondition_Range", Description="Create a range of AmericanCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanCondition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AmericanCondition")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmericanCondition> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AmericanCondition>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AmericanCondition>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AmericanCondition>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
