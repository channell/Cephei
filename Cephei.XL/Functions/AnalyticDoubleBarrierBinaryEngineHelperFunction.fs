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
module AnalyticDoubleBarrierBinaryEngineHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticDoubleBarrierBinaryEngineHelper", Description="Create a AnalyticDoubleBarrierBinaryEngineHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDoubleBarrierBinaryEngineHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="payoff",Description = "CashOrNothingPayoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="arguments",Description = "DoubleBarrierOption.Arguments")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _payoff = Helper.toCell<CashOrNothingPayoff> payoff "payoff" 
                let _arguments = Helper.toCell<DoubleBarrierOption.Arguments> arguments "arguments" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AnalyticDoubleBarrierBinaryEngineHelper 
                                                            _Process.cell 
                                                            _payoff.cell 
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticDoubleBarrierBinaryEngineHelper>) l

                let source () = Helper.sourceFold "Fun.AnalyticDoubleBarrierBinaryEngineHelper" 
                                               [| _Process.source
                                               ;  _payoff.source
                                               ;  _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _payoff.cell
                                ;  _arguments.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticDoubleBarrierBinaryEngineHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        helper obj methods
    *)
    [<ExcelFunction(Name="_AnalyticDoubleBarrierBinaryEngineHelper_payoffAtExpiry", Description="Create a AnalyticDoubleBarrierBinaryEngineHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDoubleBarrierBinaryEngineHelper_payoffAtExpiry
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticDoubleBarrierBinaryEngineHelper",Description = "AnalyticDoubleBarrierBinaryEngineHelper")>] 
         analyticdoublebarrierbinaryenginehelper : obj)
        ([<ExcelArgument(Name="spot",Description = "double")>] 
         spot : obj)
        ([<ExcelArgument(Name="variance",Description = "double")>] 
         variance : obj)
        ([<ExcelArgument(Name="barrierType",Description = "DoubleBarrier.Type")>] 
         barrierType : obj)
        ([<ExcelArgument(Name="maxIteration",Description = "int or empty")>] 
         maxIteration : obj)
        ([<ExcelArgument(Name="requiredConvergence",Description = "double or empty")>] 
         requiredConvergence : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticDoubleBarrierBinaryEngineHelper = Helper.toCell<AnalyticDoubleBarrierBinaryEngineHelper> analyticdoublebarrierbinaryenginehelper "AnalyticDoubleBarrierBinaryEngineHelper"  
                let _spot = Helper.toCell<double> spot "spot" 
                let _variance = Helper.toCell<double> variance "variance" 
                let _barrierType = Helper.toCell<DoubleBarrier.Type> barrierType "barrierType" 
                let _maxIteration = Helper.toDefault<int> maxIteration "maxIteration" 100
                let _requiredConvergence = Helper.toDefault<double> requiredConvergence "requiredConvergence" 1e-8
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticDoubleBarrierBinaryEngineHelperModel.Cast _AnalyticDoubleBarrierBinaryEngineHelper.cell).PayoffAtExpiry
                                                            _spot.cell 
                                                            _variance.cell 
                                                            _barrierType.cell 
                                                            _maxIteration.cell 
                                                            _requiredConvergence.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticDoubleBarrierBinaryEngineHelper.source + ".PayoffAtExpiry") 

                                               [| _spot.source
                                               ;  _variance.source
                                               ;  _barrierType.source
                                               ;  _maxIteration.source
                                               ;  _requiredConvergence.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticDoubleBarrierBinaryEngineHelper.cell
                                ;  _spot.cell
                                ;  _variance.cell
                                ;  _barrierType.cell
                                ;  _maxIteration.cell
                                ;  _requiredConvergence.cell
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
        helper obj methods
    *)
    [<ExcelFunction(Name="_AnalyticDoubleBarrierBinaryEngineHelper_payoffKIKO", Description="Create a AnalyticDoubleBarrierBinaryEngineHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDoubleBarrierBinaryEngineHelper_payoffKIKO
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticDoubleBarrierBinaryEngineHelper",Description = "AnalyticDoubleBarrierBinaryEngineHelper")>] 
         analyticdoublebarrierbinaryenginehelper : obj)
        ([<ExcelArgument(Name="spot",Description = "double")>] 
         spot : obj)
        ([<ExcelArgument(Name="variance",Description = "double")>] 
         variance : obj)
        ([<ExcelArgument(Name="barrierType",Description = "DoubleBarrier.Type")>] 
         barrierType : obj)
        ([<ExcelArgument(Name="maxIteration",Description = "int or empty")>] 
         maxIteration : obj)
        ([<ExcelArgument(Name="requiredConvergence",Description = "double or empty")>] 
         requiredConvergence : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticDoubleBarrierBinaryEngineHelper = Helper.toCell<AnalyticDoubleBarrierBinaryEngineHelper> analyticdoublebarrierbinaryenginehelper "AnalyticDoubleBarrierBinaryEngineHelper"  
                let _spot = Helper.toCell<double> spot "spot" 
                let _variance = Helper.toCell<double> variance "variance" 
                let _barrierType = Helper.toCell<DoubleBarrier.Type> barrierType "barrierType" 
                let _maxIteration = Helper.toDefault<int> maxIteration "maxIteration" 100
                let _requiredConvergence = Helper.toDefault<double> requiredConvergence "requiredConvergence" 1e-8
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticDoubleBarrierBinaryEngineHelperModel.Cast _AnalyticDoubleBarrierBinaryEngineHelper.cell).PayoffKIKO
                                                            _spot.cell 
                                                            _variance.cell 
                                                            _barrierType.cell 
                                                            _maxIteration.cell 
                                                            _requiredConvergence.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticDoubleBarrierBinaryEngineHelper.source + ".PayoffKIKO") 

                                               [| _spot.source
                                               ;  _variance.source
                                               ;  _barrierType.source
                                               ;  _maxIteration.source
                                               ;  _requiredConvergence.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticDoubleBarrierBinaryEngineHelper.cell
                                ;  _spot.cell
                                ;  _variance.cell
                                ;  _barrierType.cell
                                ;  _maxIteration.cell
                                ;  _requiredConvergence.cell
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
    [<ExcelFunction(Name="_AnalyticDoubleBarrierBinaryEngineHelper_Range", Description="Create a range of AnalyticDoubleBarrierBinaryEngineHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticDoubleBarrierBinaryEngineHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticDoubleBarrierBinaryEngineHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AnalyticDoubleBarrierBinaryEngineHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AnalyticDoubleBarrierBinaryEngineHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AnalyticDoubleBarrierBinaryEngineHelper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
