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
  This engine only adds timing functionality (e.g. different lag)   w.r.t. an existing interpolated price surface.
  </summary> *)
[<AutoSerializable(true)>]
module InterpolatingCPICapFloorEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatingCPICapFloorEngine", Description="Create a InterpolatingCPICapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatingCPICapFloorEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="priceSurf",Description = "CPICapFloorTermPriceSurface")>] 
         priceSurf : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _priceSurf = Helper.toHandle<CPICapFloorTermPriceSurface> priceSurf "priceSurf" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatingCPICapFloorEngine 
                                                            _priceSurf.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatingCPICapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.InterpolatingCPICapFloorEngine" 
                                               [| _priceSurf.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _priceSurf.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatingCPICapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatingCPICapFloorEngine_name", Description="Create a InterpolatingCPICapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatingCPICapFloorEngine_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatingCPICapFloorEngine",Description = "InterpolatingCPICapFloorEngine")>] 
         interpolatingcpicapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatingCPICapFloorEngine = Helper.toCell<InterpolatingCPICapFloorEngine> interpolatingcpicapfloorengine "InterpolatingCPICapFloorEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatingCPICapFloorEngineModel.Cast _InterpolatingCPICapFloorEngine.cell).Name
                                                       ) :> ICell
                let format (o : String) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatingCPICapFloorEngine.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InterpolatingCPICapFloorEngine.cell
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
    [<ExcelFunction(Name="_InterpolatingCPICapFloorEngine_Range", Description="Create a range of InterpolatingCPICapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatingCPICapFloorEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatingCPICapFloorEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<InterpolatingCPICapFloorEngine> (c)) :> ICell
                let format (i : Generic.List<ICell<InterpolatingCPICapFloorEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<InterpolatingCPICapFloorEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
