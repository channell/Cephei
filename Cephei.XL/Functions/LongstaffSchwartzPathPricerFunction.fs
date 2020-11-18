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
(*!! generic 
(* <summary>
  References:  Francis Longstaff, Eduardo Schwartz, 2001. Valuing American Options by Simulation: A Simple Least-Squares Approach, The Review of Financial Studies, Volume 14, No. 1, 113-147  mcarlo  the correctness of the returned value is tested by reproducing results available in web/literature
  </summary> *)
[<AutoSerializable(true)>]
module LongstaffSchwartzPathPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LongstaffSchwartzPathPricer_calibrate", Description="Create a LongstaffSchwartzPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LongstaffSchwartzPathPricer_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LongstaffSchwartzPathPricer",Description = "LongstaffSchwartzPathPricer")>] 
         longstaffschwartzpathpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LongstaffSchwartzPathPricer = Helper.toCell<LongstaffSchwartzPathPricer> longstaffschwartzpathpricer "LongstaffSchwartzPathPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((LongstaffSchwartzPathPricerModel.Cast _LongstaffSchwartzPathPricer.cell).Calibrate
                                                       ) :> ICell
                let format (o : LongstaffSchwartzPathPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LongstaffSchwartzPathPricer.source + ".Calibrate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LongstaffSchwartzPathPricer.cell
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
        
    *)
    [<ExcelFunction(Name="_LongstaffSchwartzPathPricer", Description="Create a LongstaffSchwartzPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LongstaffSchwartzPathPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="times",Description = "TimeGrid")>] 
         times : obj)
        ([<ExcelArgument(Name="pathPricer",Description = "PathType,double")>] 
         pathPricer : obj)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _times = Helper.toCell<TimeGrid> times "times" 
                let _pathPricer = Helper.toCell<IEarlyExercisePathPricer<PathType,double>> pathPricer "pathPricer" 
                let _termStructure = Helper.toCell<YieldTermStructure> termStructure "termStructure" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LongstaffSchwartzPathPricer 
                                                            _times.cell 
                                                            _pathPricer.cell 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LongstaffSchwartzPathPricer>) l

                let source () = Helper.sourceFold "Fun.LongstaffSchwartzPathPricer" 
                                               [| _times.source
                                               ;  _pathPricer.source
                                               ;  _termStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _times.cell
                                ;  _pathPricer.cell
                                ;  _termStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LongstaffSchwartzPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LongstaffSchwartzPathPricer_value", Description="Create a LongstaffSchwartzPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LongstaffSchwartzPathPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LongstaffSchwartzPathPricer",Description = "LongstaffSchwartzPathPricer")>] 
         longstaffschwartzpathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "'PathType")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LongstaffSchwartzPathPricer = Helper.toCell<LongstaffSchwartzPathPricer> longstaffschwartzpathpricer "LongstaffSchwartzPathPricer"  
                let _path = Helper.toCell<'PathType> path "path" 
                let builder (current : ICell) = withMnemonic mnemonic ((LongstaffSchwartzPathPricerModel.Cast _LongstaffSchwartzPathPricer.cell).Value
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LongstaffSchwartzPathPricer.source + ".Value") 

                                               [| _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LongstaffSchwartzPathPricer.cell
                                ;  _path.cell
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
    [<ExcelFunction(Name="_LongstaffSchwartzPathPricer_Range", Description="Create a range of LongstaffSchwartzPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LongstaffSchwartzPathPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LongstaffSchwartzPathPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<LongstaffSchwartzPathPricer> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<LongstaffSchwartzPathPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<LongstaffSchwartzPathPricer>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
