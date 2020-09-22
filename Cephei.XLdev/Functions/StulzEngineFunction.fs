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
  This class implements formulae from "Options on the Minimum or the Maximum of Two Risky Assets", Rene Stulz, Journal of Financial Ecomomics (1982) 10, 161-185.  basketengines  the correctness of the returned value is tested by reproducing results available in literature.
  </summary> *)
[<AutoSerializable(true)>]
module StulzEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_StulzEngine_calculate", Description="Create a StulzEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StulzEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StulzEngine",Description = "Reference to StulzEngine")>] 
         stulzengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StulzEngine = Helper.toCell<StulzEngine> stulzengine "StulzEngine" true 
                let builder () = withMnemonic mnemonic ((_StulzEngine.cell :?> StulzEngineModel).Calculate
                                                       ) :> ICell
                let format (o : StulzEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StulzEngine.source + ".Calculate") 
                                               [| _StulzEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StulzEngine.cell
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
    [<ExcelFunction(Name="_StulzEngine", Description="Create a StulzEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StulzEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="process1",Description = "Reference to process1")>] 
         process1 : obj)
        ([<ExcelArgument(Name="process2",Description = "Reference to process2")>] 
         process2 : obj)
        ([<ExcelArgument(Name="correlation",Description = "Reference to correlation")>] 
         correlation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _process1 = Helper.toCell<GeneralizedBlackScholesProcess> process1 "process1" true
                let _process2 = Helper.toCell<GeneralizedBlackScholesProcess> process2 "process2" true
                let _correlation = Helper.toCell<double> correlation "correlation" true
                let builder () = withMnemonic mnemonic (Fun.StulzEngine 
                                                            _process1.cell 
                                                            _process2.cell 
                                                            _correlation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<StulzEngine>) l

                let source = Helper.sourceFold "Fun.StulzEngine" 
                                               [| _process1.source
                                               ;  _process2.source
                                               ;  _correlation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _process1.cell
                                ;  _process2.cell
                                ;  _correlation.cell
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
    [<ExcelFunction(Name="_StulzEngine_Range", Description="Create a range of StulzEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StulzEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the StulzEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<StulzEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<StulzEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<StulzEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<StulzEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
