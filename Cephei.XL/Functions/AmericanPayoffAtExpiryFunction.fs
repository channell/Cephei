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
  Analytic formula for American exercise payoff at-expiry options   calculate greeks
  </summary> *)
[<AutoSerializable(true)>]
module AmericanPayoffAtExpiryFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmericanPayoffAtExpiry", Description="Create a AmericanPayoffAtExpiry",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanPayoffAtExpiry_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="dividendDiscount",Description = "Reference to dividendDiscount")>] 
         dividendDiscount : obj)
        ([<ExcelArgument(Name="variance",Description = "Reference to variance")>] 
         variance : obj)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="knock_in",Description = "Reference to knock_in")>] 
         knock_in : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _spot = Helper.toCell<double> spot "spot" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _dividendDiscount = Helper.toCell<double> dividendDiscount "dividendDiscount" 
                let _variance = Helper.toCell<double> variance "variance" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _knock_in = Helper.toDefault<bool> knock_in "knock_in" true
                let builder () = withMnemonic mnemonic (Fun.AmericanPayoffAtExpiry 
                                                            _spot.cell 
                                                            _discount.cell 
                                                            _dividendDiscount.cell 
                                                            _variance.cell 
                                                            _payoff.cell 
                                                            _knock_in.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmericanPayoffAtExpiry>) l

                let source = Helper.sourceFold "Fun.AmericanPayoffAtExpiry" 
                                               [| _spot.source
                                               ;  _discount.source
                                               ;  _dividendDiscount.source
                                               ;  _variance.source
                                               ;  _payoff.source
                                               ;  _knock_in.source
                                               |]
                let hash = Helper.hashFold 
                                [| _spot.cell
                                ;  _discount.cell
                                ;  _dividendDiscount.cell
                                ;  _variance.cell
                                ;  _payoff.cell
                                ;  _knock_in.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmericanPayoffAtExpiry> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmericanPayoffAtExpiry_value", Description="Create a AmericanPayoffAtExpiry",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanPayoffAtExpiry_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmericanPayoffAtExpiry",Description = "Reference to AmericanPayoffAtExpiry")>] 
         americanpayoffatexpiry : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmericanPayoffAtExpiry = Helper.toCell<AmericanPayoffAtExpiry> americanpayoffatexpiry "AmericanPayoffAtExpiry"  
                let builder () = withMnemonic mnemonic ((_AmericanPayoffAtExpiry.cell :?> AmericanPayoffAtExpiryModel).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmericanPayoffAtExpiry.source + ".Value") 
                                               [| _AmericanPayoffAtExpiry.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmericanPayoffAtExpiry.cell
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
    [<ExcelFunction(Name="_AmericanPayoffAtExpiry_Range", Description="Create a range of AmericanPayoffAtExpiry",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AmericanPayoffAtExpiry_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AmericanPayoffAtExpiry")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmericanPayoffAtExpiry> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AmericanPayoffAtExpiry>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AmericanPayoffAtExpiry>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AmericanPayoffAtExpiry>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
