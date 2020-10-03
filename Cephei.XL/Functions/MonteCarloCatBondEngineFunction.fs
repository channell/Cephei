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
module MonteCarloCatBondEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_MonteCarloCatBondEngine_discountCurve", Description="Create a MonteCarloCatBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonteCarloCatBondEngine_discountCurve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonteCarloCatBondEngine",Description = "Reference to MonteCarloCatBondEngine")>] 
         montecarlocatbondengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonteCarloCatBondEngine = Helper.toCell<MonteCarloCatBondEngine> montecarlocatbondengine "MonteCarloCatBondEngine"  
                let builder () = withMnemonic mnemonic ((MonteCarloCatBondEngineModel.Cast _MonteCarloCatBondEngine.cell).DiscountCurve
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_MonteCarloCatBondEngine.source + ".DiscountCurve") 
                                               [| _MonteCarloCatBondEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonteCarloCatBondEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MonteCarloCatBondEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MonteCarloCatBondEngine", Description="Create a MonteCarloCatBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonteCarloCatBondEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="catRisk",Description = "Reference to catRisk")>] 
         catRisk : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="includeSettlementDateFlows",Description = "Reference to includeSettlementDateFlows")>] 
         includeSettlementDateFlows : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _catRisk = Helper.toCell<CatRisk> catRisk "catRisk" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _includeSettlementDateFlows = Helper.toNullable<bool> includeSettlementDateFlows "includeSettlementDateFlows"
                let builder () = withMnemonic mnemonic (Fun.MonteCarloCatBondEngine 
                                                            _catRisk.cell 
                                                            _discountCurve.cell 
                                                            _includeSettlementDateFlows.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MonteCarloCatBondEngine>) l

                let source = Helper.sourceFold "Fun.MonteCarloCatBondEngine" 
                                               [| _catRisk.source
                                               ;  _discountCurve.source
                                               ;  _includeSettlementDateFlows.source
                                               |]
                let hash = Helper.hashFold 
                                [| _catRisk.cell
                                ;  _discountCurve.cell
                                ;  _includeSettlementDateFlows.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MonteCarloCatBondEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MonteCarloCatBondEngine_Range", Description="Create a range of MonteCarloCatBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonteCarloCatBondEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MonteCarloCatBondEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MonteCarloCatBondEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MonteCarloCatBondEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MonteCarloCatBondEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MonteCarloCatBondEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
