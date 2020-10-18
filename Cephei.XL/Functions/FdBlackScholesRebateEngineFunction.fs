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
module FdBlackScholesRebateEngineFunction =


    (*
        Constructor
    *)
    [<ExcelFunction(Name="_FdBlackScholesRebateEngine", Description="Create a FdBlackScholesRebateEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdBlackScholesRebateEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FdBlackScholesRebateEngine")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="tGrid",Description = "FdBlackScholesRebateEngine")>] 
         tGrid : obj)
        ([<ExcelArgument(Name="xGrid",Description = "FdBlackScholesRebateEngine")>] 
         xGrid : obj)
        ([<ExcelArgument(Name="dampingSteps",Description = "FdBlackScholesRebateEngine")>] 
         dampingSteps : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "FdBlackScholesRebateEngine")>] 
         schemeDesc : obj)
        ([<ExcelArgument(Name="localVol",Description = "FdBlackScholesRebateEngine")>] 
         localVol : obj)
        ([<ExcelArgument(Name="illegalLocalVolOverwrite",Description = "double")>] 
         illegalLocalVolOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _tGrid = Helper.toDefault<int> tGrid "tGrid" 100
                let _xGrid = Helper.toDefault<int> xGrid "xGrid" 100
                let _dampingSteps = Helper.toDefault<int> dampingSteps "dampingSteps" 0
                let _schemeDesc = Helper.toDefault<FdmSchemeDesc> schemeDesc "schemeDesc" null
                let _localVol = Helper.toDefault<bool> localVol "localVol" false
                let _illegalLocalVolOverwrite = Helper.toNullable<double> illegalLocalVolOverwrite "illegalLocalVolOverwrite"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdBlackScholesRebateEngine 
                                                            _Process.cell 
                                                            _tGrid.cell 
                                                            _xGrid.cell 
                                                            _dampingSteps.cell 
                                                            _schemeDesc.cell 
                                                            _localVol.cell 
                                                            _illegalLocalVolOverwrite.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdBlackScholesRebateEngine>) l

                let source () = Helper.sourceFold "Fun.FdBlackScholesRebateEngine" 
                                               [| _Process.source
                                               ;  _tGrid.source
                                               ;  _xGrid.source
                                               ;  _dampingSteps.source
                                               ;  _schemeDesc.source
                                               ;  _localVol.source
                                               ;  _illegalLocalVolOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _tGrid.cell
                                ;  _xGrid.cell
                                ;  _dampingSteps.cell
                                ;  _schemeDesc.cell
                                ;  _localVol.cell
                                ;  _illegalLocalVolOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdBlackScholesRebateEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdBlackScholesRebateEngine_Range", Description="Create a range of FdBlackScholesRebateEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdBlackScholesRebateEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdBlackScholesRebateEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdBlackScholesRebateEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdBlackScholesRebateEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdBlackScholesRebateEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
