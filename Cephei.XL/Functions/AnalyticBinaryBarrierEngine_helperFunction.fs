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
calc helper obj
  </summary> *)
[<AutoSerializable(true)>]
module AnalyticBinaryBarrierEngine_helperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticBinaryBarrierEngine_helper", Description="Create a AnalyticBinaryBarrierEngine_helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBinaryBarrierEngine_helper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="payoff",Description = "StrikedTypePayoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="exercise",Description = "AmericanExercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="arguments",Description = "BarrierOption.Arguments")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<AmericanExercise> exercise "exercise" 
                let _arguments = Helper.toCell<BarrierOption.Arguments> arguments "arguments" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AnalyticBinaryBarrierEngine_helper 
                                                            _Process.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticBinaryBarrierEngine_helper>) l

                let source () = Helper.sourceFold "Fun.AnalyticBinaryBarrierEngine_helper" 
                                               [| _Process.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
                                ;  _arguments.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticBinaryBarrierEngine_helper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticBinaryBarrierEngine_helper_payoffAtExpiry", Description="Create a AnalyticBinaryBarrierEngine_helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBinaryBarrierEngine_helper_payoffAtExpiry
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBinaryBarrierEngine_helper",Description = "AnalyticBinaryBarrierEngine_helper")>] 
         analyticbinarybarrierengine_helper : obj)
        ([<ExcelArgument(Name="spot",Description = "double")>] 
         spot : obj)
        ([<ExcelArgument(Name="variance",Description = "double")>] 
         variance : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBinaryBarrierEngine_helper = Helper.toCell<AnalyticBinaryBarrierEngine_helper> analyticbinarybarrierengine_helper "AnalyticBinaryBarrierEngine_helper"  
                let _spot = Helper.toCell<double> spot "spot" 
                let _variance = Helper.toCell<double> variance "variance" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticBinaryBarrierEngine_helperModel.Cast _AnalyticBinaryBarrierEngine_helper.cell).PayoffAtExpiry
                                                            _spot.cell 
                                                            _variance.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticBinaryBarrierEngine_helper.source + ".PayoffAtExpiry") 

                                               [| _spot.source
                                               ;  _variance.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBinaryBarrierEngine_helper.cell
                                ;  _spot.cell
                                ;  _variance.cell
                                ;  _discount.cell
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
    [<ExcelFunction(Name="_AnalyticBinaryBarrierEngine_helper_Range", Description="Create a range of AnalyticBinaryBarrierEngine_helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBinaryBarrierEngine_helper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticBinaryBarrierEngine_helper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<AnalyticBinaryBarrierEngine_helper> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<AnalyticBinaryBarrierEngine_helper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AnalyticBinaryBarrierEngine_helper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
