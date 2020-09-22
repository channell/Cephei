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
module EuropeanHestonPathPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EuropeanHestonPathPricer", Description="Create a EuropeanHestonPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanHestonPathPricer_create
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

                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _discount = Helper.toCell<double> discount "discount" true
                let builder () = withMnemonic mnemonic (Fun.EuropeanHestonPathPricer 
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuropeanHestonPathPricer>) l

                let source = Helper.sourceFold "Fun.EuropeanHestonPathPricer" 
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
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EuropeanHestonPathPricer_value", Description="Create a EuropeanHestonPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanHestonPathPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanHestonPathPricer",Description = "Reference to EuropeanHestonPathPricer")>] 
         europeanhestonpathpricer : obj)
        ([<ExcelArgument(Name="multiPath",Description = "Reference to multiPath")>] 
         multiPath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanHestonPathPricer = Helper.toCell<EuropeanHestonPathPricer> europeanhestonpathpricer "EuropeanHestonPathPricer" true 
                let _multiPath = Helper.toCell<IPath> multiPath "multiPath" true
                let builder () = withMnemonic mnemonic ((_EuropeanHestonPathPricer.cell :?> EuropeanHestonPathPricerModel).Value
                                                            _multiPath.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanHestonPathPricer.source + ".Value") 
                                               [| _EuropeanHestonPathPricer.source
                                               ;  _multiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanHestonPathPricer.cell
                                ;  _multiPath.cell
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
    [<ExcelFunction(Name="_EuropeanHestonPathPricer_Range", Description="Create a range of EuropeanHestonPathPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanHestonPathPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EuropeanHestonPathPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EuropeanHestonPathPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EuropeanHestonPathPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EuropeanHestonPathPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EuropeanHestonPathPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
