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
module MonthlyYieldFinderFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MonthlyYieldFinder", Description="Create a MonthlyYieldFinder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonthlyYieldFinder_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="cashflows",Description = "Reference to cashflows")>] 
         cashflows : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" true
                let _cashflows = Helper.toCell<Generic.List<CashFlow>> cashflows "cashflows" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic (Fun.MonthlyYieldFinder 
                                                            _faceAmount.cell 
                                                            _cashflows.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MonthlyYieldFinder>) l

                let source = Helper.sourceFold "Fun.MonthlyYieldFinder" 
                                               [| _faceAmount.source
                                               ;  _cashflows.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _faceAmount.cell
                                ;  _cashflows.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_MonthlyYieldFinder_value", Description="Create a MonthlyYieldFinder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonthlyYieldFinder_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonthlyYieldFinder",Description = "Reference to MonthlyYieldFinder")>] 
         monthlyyieldfinder : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonthlyYieldFinder = Helper.toCell<MonthlyYieldFinder> monthlyyieldfinder "MonthlyYieldFinder" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let builder () = withMnemonic mnemonic ((_MonthlyYieldFinder.cell :?> MonthlyYieldFinderModel).Value
                                                            _Yield.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MonthlyYieldFinder.source + ".Value") 
                                               [| _MonthlyYieldFinder.source
                                               ;  _Yield.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonthlyYieldFinder.cell
                                ;  _Yield.cell
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
        
    *)
    [<ExcelFunction(Name="_MonthlyYieldFinder_derivative", Description="Create a MonthlyYieldFinder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonthlyYieldFinder_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonthlyYieldFinder",Description = "Reference to MonthlyYieldFinder")>] 
         monthlyyieldfinder : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonthlyYieldFinder = Helper.toCell<MonthlyYieldFinder> monthlyyieldfinder "MonthlyYieldFinder" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_MonthlyYieldFinder.cell :?> MonthlyYieldFinderModel).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MonthlyYieldFinder.source + ".Derivative") 
                                               [| _MonthlyYieldFinder.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonthlyYieldFinder.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_MonthlyYieldFinder_Range", Description="Create a range of MonthlyYieldFinder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MonthlyYieldFinder_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MonthlyYieldFinder")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MonthlyYieldFinder> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MonthlyYieldFinder>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MonthlyYieldFinder>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MonthlyYieldFinder>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
