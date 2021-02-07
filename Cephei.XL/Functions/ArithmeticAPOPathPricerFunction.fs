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
module ArithmeticAPOPathPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ArithmeticAPOPathPricer", Description="Create a ArithmeticAPOPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ArithmeticAPOPathPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = (Fun.ArithmeticAPOPathPricer 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ArithmeticAPOPathPricer>) l

                let source () = Helper.sourceFold "Fun.ArithmeticAPOPathPricer" 
                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                ;  _discount.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArithmeticAPOPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ArithmeticAPOPathPricer1", Description="Create a ArithmeticAPOPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ArithmeticAPOPathPricer_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="runningSum",Description = "double")>] 
         runningSum : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _runningSum = Helper.toCell<double> runningSum "runningSum" 
                let builder (current : ICell) = (Fun.ArithmeticAPOPathPricer1 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _runningSum.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ArithmeticAPOPathPricer>) l

                let source () = Helper.sourceFold "Fun.ArithmeticAPOPathPricer1" 
                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               ;  _runningSum.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                ;  _discount.cell
                                ;  _runningSum.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArithmeticAPOPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ArithmeticAPOPathPricer2", Description="Create a ArithmeticAPOPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ArithmeticAPOPathPricer_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="runningSum",Description = "double")>] 
         runningSum : obj)
        ([<ExcelArgument(Name="pastFixings",Description = "int")>] 
         pastFixings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _runningSum = Helper.toCell<double> runningSum "runningSum" 
                let _pastFixings = Helper.toCell<int> pastFixings "pastFixings" 
                let builder (current : ICell) = (Fun.ArithmeticAPOPathPricer2 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _runningSum.cell 
                                                            _pastFixings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ArithmeticAPOPathPricer>) l

                let source () = Helper.sourceFold "Fun.ArithmeticAPOPathPricer2" 
                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               ;  _runningSum.source
                                               ;  _pastFixings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                ;  _discount.cell
                                ;  _runningSum.cell
                                ;  _pastFixings.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArithmeticAPOPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ArithmeticAPOPathPricer_value", Description="Create a ArithmeticAPOPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ArithmeticAPOPathPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArithmeticAPOPathPricer",Description = "ArithmeticAPOPathPricer")>] 
         arithmeticapopathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "IPath")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArithmeticAPOPathPricer = Helper.toCell<ArithmeticAPOPathPricer> arithmeticapopathpricer "ArithmeticAPOPathPricer"  
                let _path = Helper.toCell<IPath> path "path" 
                let builder (current : ICell) = ((ArithmeticAPOPathPricerModel.Cast _ArithmeticAPOPathPricer.cell).Value
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ArithmeticAPOPathPricer.source + ".Value") 

                                               [| _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArithmeticAPOPathPricer.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_ArithmeticAPOPathPricer_value1", Description="Create a ArithmeticAPOPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ArithmeticAPOPathPricer_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArithmeticAPOPathPricer",Description = "ArithmeticAPOPathPricer")>] 
         arithmeticapopathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "Path")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArithmeticAPOPathPricer = Helper.toCell<ArithmeticAPOPathPricer> arithmeticapopathpricer "ArithmeticAPOPathPricer"  
                let _path = Helper.toCell<Path> path "path" 
                let builder (current : ICell) = ((ArithmeticAPOPathPricerModel.Cast _ArithmeticAPOPathPricer.cell).Value1
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ArithmeticAPOPathPricer.source + ".Value1") 

                                               [| _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArithmeticAPOPathPricer.cell
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
    [<ExcelFunction(Name="_ArithmeticAPOPathPricer_Range", Description="Create a range of ArithmeticAPOPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ArithmeticAPOPathPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ArithmeticAPOPathPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ArithmeticAPOPathPricer> (c)) :> ICell
                let format (i : Cephei.Cell.List<ArithmeticAPOPathPricer>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ArithmeticAPOPathPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
