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
    [<ExcelFunction(Name="_MonthlyYieldFinder", Description="Create a MonthlyYieldFinder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonthlyYieldFinder_create
        ([<ExcelArgument(Name="Mnemonic",Description = "MonthlyYieldFinder")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="cashflows",Description = "CashFlow")>] 
         cashflows : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _cashflows = Helper.toCell<Generic.List<CashFlow>> cashflows "cashflows" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MonthlyYieldFinder 
                                                            _faceAmount.cell 
                                                            _cashflows.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MonthlyYieldFinder>) l

                let source () = Helper.sourceFold "Fun.MonthlyYieldFinder" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MonthlyYieldFinder> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MonthlyYieldFinder_value", Description="Create a MonthlyYieldFinder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonthlyYieldFinder_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonthlyYieldFinder",Description = "MonthlyYieldFinder")>] 
         monthlyyieldfinder : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonthlyYieldFinder = Helper.toCell<MonthlyYieldFinder> monthlyyieldfinder "MonthlyYieldFinder"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let builder (current : ICell) = withMnemonic mnemonic ((MonthlyYieldFinderModel.Cast _MonthlyYieldFinder.cell).Value
                                                            _Yield.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonthlyYieldFinder.source + ".Value") 

                                               [| _Yield.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonthlyYieldFinder.cell
                                ;  _Yield.cell
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
    [<ExcelFunction(Name="_MonthlyYieldFinder_derivative", Description="Create a MonthlyYieldFinder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonthlyYieldFinder_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MonthlyYieldFinder",Description = "MonthlyYieldFinder")>] 
         monthlyyieldfinder : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MonthlyYieldFinder = Helper.toCell<MonthlyYieldFinder> monthlyyieldfinder "MonthlyYieldFinder"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((MonthlyYieldFinderModel.Cast _MonthlyYieldFinder.cell).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MonthlyYieldFinder.source + ".Derivative") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MonthlyYieldFinder.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_MonthlyYieldFinder_Range", Description="Create a range of MonthlyYieldFinder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MonthlyYieldFinder_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MonthlyYieldFinder> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MonthlyYieldFinder>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<MonthlyYieldFinder>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<MonthlyYieldFinder>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
