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
module FdBlackScholesBarrierEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdBlackScholesBarrierEngine_calculate", Description="Create a FdBlackScholesBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdBlackScholesBarrierEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdBlackScholesBarrierEngine",Description = "Reference to FdBlackScholesBarrierEngine")>] 
         fdblackscholesbarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdBlackScholesBarrierEngine = Helper.toCell<FdBlackScholesBarrierEngine> fdblackscholesbarrierengine "FdBlackScholesBarrierEngine" true 
                let builder () = withMnemonic mnemonic ((_FdBlackScholesBarrierEngine.cell :?> FdBlackScholesBarrierEngineModel).Calculate
                                                       ) :> ICell
                let format (o : FdBlackScholesBarrierEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdBlackScholesBarrierEngine.source + ".Calculate") 
                                               [| _FdBlackScholesBarrierEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdBlackScholesBarrierEngine.cell
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
        Constructor
    *)
    [<ExcelFunction(Name="_FdBlackScholesBarrierEngine", Description="Create a FdBlackScholesBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdBlackScholesBarrierEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="tGrid",Description = "Reference to tGrid")>] 
         tGrid : obj)
        ([<ExcelArgument(Name="xGrid",Description = "Reference to xGrid")>] 
         xGrid : obj)
        ([<ExcelArgument(Name="dampingSteps",Description = "Reference to dampingSteps")>] 
         dampingSteps : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "Reference to schemeDesc")>] 
         schemeDesc : obj)
        ([<ExcelArgument(Name="localVol",Description = "Reference to localVol")>] 
         localVol : obj)
        ([<ExcelArgument(Name="illegalLocalVolOverwrite",Description = "Reference to illegalLocalVolOverwrite")>] 
         illegalLocalVolOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _tGrid = Helper.toCell<int> tGrid "tGrid" true
                let _xGrid = Helper.toCell<int> xGrid "xGrid" true
                let _dampingSteps = Helper.toCell<int> dampingSteps "dampingSteps" true
                let _schemeDesc = Helper.toCell<FdmSchemeDesc> schemeDesc "schemeDesc" true
                let _localVol = Helper.toCell<bool> localVol "localVol" true
                let _illegalLocalVolOverwrite = Helper.toNullable<Nullable<double>> illegalLocalVolOverwrite "illegalLocalVolOverwrite"
                let builder () = withMnemonic mnemonic (Fun.FdBlackScholesBarrierEngine 
                                                            _Process.cell 
                                                            _tGrid.cell 
                                                            _xGrid.cell 
                                                            _dampingSteps.cell 
                                                            _schemeDesc.cell 
                                                            _localVol.cell 
                                                            _illegalLocalVolOverwrite.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdBlackScholesBarrierEngine>) l

                let source = Helper.sourceFold "Fun.FdBlackScholesBarrierEngine" 
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
    [<ExcelFunction(Name="_FdBlackScholesBarrierEngine_Range", Description="Create a range of FdBlackScholesBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdBlackScholesBarrierEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdBlackScholesBarrierEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdBlackScholesBarrierEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdBlackScholesBarrierEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdBlackScholesBarrierEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdBlackScholesBarrierEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
