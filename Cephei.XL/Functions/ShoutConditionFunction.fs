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
  A shout option is an option where the holder has the right to lock in a minimum value for the payoff at one (shout) time during the option's life. The minimum value is the option's intrinsic value at the shout time.
  </summary> *)
[<AutoSerializable(true)>]
module ShoutConditionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ShoutCondition_applyTo", Description="Create a ShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ShoutCondition_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShoutCondition",Description = "Reference to ShoutCondition")>] 
         shoutcondition : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShoutCondition = Helper.toCell<ShoutCondition> shoutcondition "ShoutCondition" true 
                let _a = Helper.toCell<Vector> a "a" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_ShoutCondition.cell :?> ShoutConditionModel).ApplyTo
                                                            _a.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : ShoutCondition) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ShoutCondition.source + ".ApplyTo") 
                                               [| _ShoutCondition.source
                                               ;  _a.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShoutCondition.cell
                                ;  _a.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_ShoutCondition", Description="Create a ShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ShoutCondition_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="resTime",Description = "Reference to resTime")>] 
         resTime : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _resTime = Helper.toCell<double> resTime "resTime" true
                let _rate = Helper.toCell<double> rate "rate" true
                let builder () = withMnemonic mnemonic (Fun.ShoutCondition 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _resTime.cell 
                                                            _rate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ShoutCondition>) l

                let source = Helper.sourceFold "Fun.ShoutCondition" 
                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _resTime.source
                                               ;  _rate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                ;  _resTime.cell
                                ;  _rate.cell
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
    [<ExcelFunction(Name="_ShoutCondition1", Description="Create a ShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ShoutCondition_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="intrinsicValues",Description = "Reference to intrinsicValues")>] 
         intrinsicValues : obj)
        ([<ExcelArgument(Name="resTime",Description = "Reference to resTime")>] 
         resTime : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _intrinsicValues = Helper.toCell<Vector> intrinsicValues "intrinsicValues" true
                let _resTime = Helper.toCell<double> resTime "resTime" true
                let _rate = Helper.toCell<double> rate "rate" true
                let builder () = withMnemonic mnemonic (Fun.ShoutCondition1 
                                                            _intrinsicValues.cell 
                                                            _resTime.cell 
                                                            _rate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ShoutCondition>) l

                let source = Helper.sourceFold "Fun.ShoutCondition1" 
                                               [| _intrinsicValues.source
                                               ;  _resTime.source
                                               ;  _rate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _intrinsicValues.cell
                                ;  _resTime.cell
                                ;  _rate.cell
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
    [<ExcelFunction(Name="_ShoutCondition_Range", Description="Create a range of ShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ShoutCondition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ShoutCondition")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ShoutCondition> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ShoutCondition>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ShoutCondition>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ShoutCondition>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
