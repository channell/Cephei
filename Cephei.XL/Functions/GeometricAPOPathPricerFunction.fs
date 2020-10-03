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
module GeometricAPOPathPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GeometricAPOPathPricer", Description="Create a GeometricAPOPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricAPOPathPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder () = withMnemonic mnemonic (Fun.GeometricAPOPathPricer 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GeometricAPOPathPricer>) l

                let source = Helper.sourceFold "Fun.GeometricAPOPathPricer" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GeometricAPOPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GeometricAPOPathPricer2", Description="Create a GeometricAPOPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricAPOPathPricer_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="runningProduct",Description = "Reference to runningProduct")>] 
         runningProduct : obj)
        ([<ExcelArgument(Name="pastFixings",Description = "Reference to pastFixings")>] 
         pastFixings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _runningProduct = Helper.toCell<double> runningProduct "runningProduct" 
                let _pastFixings = Helper.toCell<int> pastFixings "pastFixings" 
                let builder () = withMnemonic mnemonic (Fun.GeometricAPOPathPricer2
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _runningProduct.cell 
                                                            _pastFixings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GeometricAPOPathPricer>) l

                let source = Helper.sourceFold "Fun.GeometricAPOPathPricer2" 
                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               ;  _runningProduct.source
                                               ;  _pastFixings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                ;  _discount.cell
                                ;  _runningProduct.cell
                                ;  _pastFixings.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GeometricAPOPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GeometricAPOPathPricer1", Description="Create a GeometricAPOPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricAPOPathPricer_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="runningProduct",Description = "Reference to runningProduct")>] 
         runningProduct : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _runningProduct = Helper.toCell<double> runningProduct "runningProduct" 
                let builder () = withMnemonic mnemonic (Fun.GeometricAPOPathPricer1
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _runningProduct.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GeometricAPOPathPricer>) l

                let source = Helper.sourceFold "Fun.GeometricAPOPathPricer1" 
                                               [| _Type.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               ;  _runningProduct.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _strike.cell
                                ;  _discount.cell
                                ;  _runningProduct.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GeometricAPOPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GeometricAPOPathPricer_value", Description="Create a GeometricAPOPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricAPOPathPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricAPOPathPricer",Description = "Reference to GeometricAPOPathPricer")>] 
         geometricapopathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "Reference to path")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricAPOPathPricer = Helper.toCell<GeometricAPOPathPricer> geometricapopathpricer "GeometricAPOPathPricer"  
                let _path = Helper.toCell<Path> path "path" 
                let builder () = withMnemonic mnemonic ((GeometricAPOPathPricerModel.Cast _GeometricAPOPathPricer.cell).Value
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricAPOPathPricer.source + ".Value") 
                                               [| _GeometricAPOPathPricer.source
                                               ;  _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricAPOPathPricer.cell
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
    [<ExcelFunction(Name="_GeometricAPOPathPricer_Range", Description="Create a range of GeometricAPOPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricAPOPathPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GeometricAPOPathPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GeometricAPOPathPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GeometricAPOPathPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GeometricAPOPathPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GeometricAPOPathPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
