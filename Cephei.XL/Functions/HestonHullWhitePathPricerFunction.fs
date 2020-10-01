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
module HestonHullWhitePathPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HestonHullWhitePathPricer", Description="Create a HestonHullWhitePathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonHullWhitePathPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="exerciseTime",Description = "Reference to exerciseTime")>] 
         exerciseTime : obj)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _exerciseTime = Helper.toCell<double> exerciseTime "exerciseTime" 
                let _payoff = Helper.toCell<Payoff> payoff "payoff" 
                let _Process = Helper.toCell<HybridHestonHullWhiteProcess> Process "Process" 
                let builder () = withMnemonic mnemonic (Fun.HestonHullWhitePathPricer 
                                                            _exerciseTime.cell 
                                                            _payoff.cell 
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HestonHullWhitePathPricer>) l

                let source = Helper.sourceFold "Fun.HestonHullWhitePathPricer" 
                                               [| _exerciseTime.source
                                               ;  _payoff.source
                                               ;  _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _exerciseTime.cell
                                ;  _payoff.cell
                                ;  _Process.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonHullWhitePathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonHullWhitePathPricer_value", Description="Create a HestonHullWhitePathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonHullWhitePathPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonHullWhitePathPricer",Description = "Reference to HestonHullWhitePathPricer")>] 
         hestonhullwhitepathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "Reference to path")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonHullWhitePathPricer = Helper.toCell<HestonHullWhitePathPricer> hestonhullwhitepathpricer "HestonHullWhitePathPricer"  
                let _path = Helper.toCell<IPath> path "path" 
                let builder () = withMnemonic mnemonic ((_HestonHullWhitePathPricer.cell :?> HestonHullWhitePathPricerModel).Value
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonHullWhitePathPricer.source + ".Value") 
                                               [| _HestonHullWhitePathPricer.source
                                               ;  _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonHullWhitePathPricer.cell
                                ;  _path.cell
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
    [<ExcelFunction(Name="_HestonHullWhitePathPricer_Range", Description="Create a range of HestonHullWhitePathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonHullWhitePathPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HestonHullWhitePathPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HestonHullWhitePathPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HestonHullWhitePathPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<HestonHullWhitePathPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<HestonHullWhitePathPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
