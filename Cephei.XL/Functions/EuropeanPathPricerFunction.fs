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
module EuropeanPathPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EuropeanPathPricer", Description="Create a EuropeanPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuropeanPathPricer_create
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
                let builder (current : ICell) = (Fun.EuropeanPathPricer 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuropeanPathPricer>) l

                let source () = Helper.sourceFold "Fun.EuropeanPathPricer" 
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
                    ; subscriber = Helper.subscriberModel<EuropeanPathPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuropeanPathPricer_value", Description="Create a EuropeanPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuropeanPathPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanPathPricer",Description = "EuropeanPathPricer")>] 
         europeanpathpricer : obj)
        ([<ExcelArgument(Name="path",Description = "IPath")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanPathPricer = Helper.toCell<EuropeanPathPricer> europeanpathpricer "EuropeanPathPricer"  
                let _path = Helper.toCell<IPath> path "path" 
                let builder (current : ICell) = ((EuropeanPathPricerModel.Cast _EuropeanPathPricer.cell).Value
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EuropeanPathPricer.source + ".Value") 

                                               [| _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanPathPricer.cell
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
    [<ExcelFunction(Name="_EuropeanPathPricer_Range", Description="Create a range of EuropeanPathPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EuropeanPathPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EuropeanPathPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EuropeanPathPricer> (c)) :> ICell
                let format (i : Cephei.Cell.List<EuropeanPathPricer>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EuropeanPathPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
