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
  Analytic formula for American exercise payoff at-hit options   calculate greeks
  </summary> *)
[<AutoSerializable(true)>]
module AmericanPayoffAtHitFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmericanPayoffAtHit", Description="Create a AmericanPayoffAtHit",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPayoffAtHit_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="spot",Description = "double")>] 
         spot : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="dividendDiscount",Description = "double")>] 
         dividendDiscount : obj)
        ([<ExcelArgument(Name="variance",Description = "double")>] 
         variance : obj)
        ([<ExcelArgument(Name="payoff",Description = "StrikedTypePayoff")>] 
         payoff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _spot = Helper.toCell<double> spot "spot" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _dividendDiscount = Helper.toCell<double> dividendDiscount "dividendDiscount" 
                let _variance = Helper.toCell<double> variance "variance" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let builder (current : ICell) = (Fun.AmericanPayoffAtHit 
                                                            _spot.cell 
                                                            _discount.cell 
                                                            _dividendDiscount.cell 
                                                            _variance.cell 
                                                            _payoff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmericanPayoffAtHit>) l

                let source () = Helper.sourceFold "Fun.AmericanPayoffAtHit" 
                                               [| _spot.source
                                               ;  _discount.source
                                               ;  _dividendDiscount.source
                                               ;  _variance.source
                                               ;  _payoff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _spot.cell
                                ;  _discount.cell
                                ;  _dividendDiscount.cell
                                ;  _variance.cell
                                ;  _payoff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmericanPayoffAtHit> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmericanPayoffAtHit_delta", Description="Create a AmericanPayoffAtHit",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPayoffAtHit_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanPayoffAtHit",Description = "AmericanPayoffAtHit")>] 
         americanpayoffathit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanPayoffAtHit = Helper.toModelReference<AmericanPayoffAtHit> americanpayoffathit "AmericanPayoffAtHit"  
                let builder (current : ICell) = ((AmericanPayoffAtHitModel.Cast _AmericanPayoffAtHit.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmericanPayoffAtHit.source + ".Delta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmericanPayoffAtHit.cell
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
    [<ExcelFunction(Name="_AmericanPayoffAtHit_gamma", Description="Create a AmericanPayoffAtHit",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPayoffAtHit_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanPayoffAtHit",Description = "AmericanPayoffAtHit")>] 
         americanpayoffathit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanPayoffAtHit = Helper.toModelReference<AmericanPayoffAtHit> americanpayoffathit "AmericanPayoffAtHit"  
                let builder (current : ICell) = ((AmericanPayoffAtHitModel.Cast _AmericanPayoffAtHit.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmericanPayoffAtHit.source + ".Gamma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmericanPayoffAtHit.cell
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
    [<ExcelFunction(Name="_AmericanPayoffAtHit_rho", Description="Create a AmericanPayoffAtHit",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPayoffAtHit_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanPayoffAtHit",Description = "AmericanPayoffAtHit")>] 
         americanpayoffathit : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanPayoffAtHit = Helper.toModelReference<AmericanPayoffAtHit> americanpayoffathit "AmericanPayoffAtHit"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder (current : ICell) = ((AmericanPayoffAtHitModel.Cast _AmericanPayoffAtHit.cell).Rho
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmericanPayoffAtHit.source + ".Rho") 

                                               [| _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanPayoffAtHit.cell
                                ;  _maturity.cell
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
        inline definitions
    *)
    [<ExcelFunction(Name="_AmericanPayoffAtHit_value", Description="Create a AmericanPayoffAtHit",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPayoffAtHit_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanPayoffAtHit",Description = "AmericanPayoffAtHit")>] 
         americanpayoffathit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanPayoffAtHit = Helper.toModelReference<AmericanPayoffAtHit> americanpayoffathit "AmericanPayoffAtHit"  
                let builder (current : ICell) = ((AmericanPayoffAtHitModel.Cast _AmericanPayoffAtHit.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AmericanPayoffAtHit.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AmericanPayoffAtHit.cell
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
    [<ExcelFunction(Name="_AmericanPayoffAtHit_Range", Description="Create a range of AmericanPayoffAtHit",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmericanPayoffAtHit_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmericanPayoffAtHit> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AmericanPayoffAtHit> (c)) :> ICell
                let format (i : Cephei.Cell.List<AmericanPayoffAtHit>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AmericanPayoffAtHit>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
