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
module CouponConversionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CouponConversion", Description="Create a CouponConversion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CouponConversion_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _date = Helper.toCell<DateTime> date "date" 
                let _rate = Helper.toCell<double> rate "rate" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CouponConversion 
                                                            _date.cell 
                                                            _rate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CouponConversion>) l

                let source () = Helper.sourceFold "Fun.CouponConversion" 
                                               [| _date.source
                                               ;  _rate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _date.cell
                                ;  _rate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CouponConversion> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CouponConversion_Date", Description="Create a CouponConversion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CouponConversion_Date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CouponConversion",Description = "Reference to CouponConversion")>] 
         couponconversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CouponConversion = Helper.toCell<CouponConversion> couponconversion "CouponConversion"  
                let builder (current : ICell) = withMnemonic mnemonic ((CouponConversionModel.Cast _CouponConversion.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CouponConversion.source + ".Date") 
                                               [| _CouponConversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CouponConversion.cell
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
    [<ExcelFunction(Name="_CouponConversion_Rate", Description="Create a CouponConversion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CouponConversion_Rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CouponConversion",Description = "Reference to CouponConversion")>] 
         couponconversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CouponConversion = Helper.toCell<CouponConversion> couponconversion "CouponConversion"  
                let builder (current : ICell) = withMnemonic mnemonic ((CouponConversionModel.Cast _CouponConversion.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CouponConversion.source + ".Rate") 
                                               [| _CouponConversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CouponConversion.cell
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
    [<ExcelFunction(Name="_CouponConversion_ToString", Description="Create a CouponConversion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CouponConversion_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CouponConversion",Description = "Reference to CouponConversion")>] 
         couponconversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CouponConversion = Helper.toCell<CouponConversion> couponconversion "CouponConversion"  
                let builder (current : ICell) = withMnemonic mnemonic ((CouponConversionModel.Cast _CouponConversion.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CouponConversion.source + ".ToString") 
                                               [| _CouponConversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CouponConversion.cell
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
    [<ExcelFunction(Name="_CouponConversion_Range", Description="Create a range of CouponConversion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CouponConversion_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CouponConversion")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CouponConversion> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CouponConversion>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CouponConversion>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CouponConversion>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
