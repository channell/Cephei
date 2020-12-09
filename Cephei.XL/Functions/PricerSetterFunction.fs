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
===========================================================================// CouponSelectorToSetPricer                         // ===========================================================================
  </summary> *)
[<AutoSerializable(true)>]
module PricerSetterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PricerSetter", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="pricer",Description = "FloatingRateCouponPricer")>] 
         pricer : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PricerSetter 
                                                            _pricer.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PricerSetter>) l

                let source () = Helper.sourceFold "Fun.PricerSetter" 
                                               [| _pricer.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _pricer.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PricerSetter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PricerSetter_visit8", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit8
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "CappedFlooredCoupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CappedFlooredCoupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit8
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit8") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit3", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit3
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit3") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit4", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "CashFlow")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CashFlow> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit4
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit4") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "RangeAccrualFloatersCoupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<RangeAccrualFloatersCoupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit7", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "FloatingRateCoupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<FloatingRateCoupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit7
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit7") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit9", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit9
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "IborCoupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<IborCoupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit9
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit9") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit10", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit10
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "DigitalIborCoupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<DigitalIborCoupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit10
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit10") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit2", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "CappedFlooredIborCoupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CappedFlooredIborCoupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit2
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit2") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit5", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "CmsCoupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CmsCoupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit5
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit5") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit11", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit11
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "CappedFlooredCmsCoupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CappedFlooredCmsCoupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit11
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit11") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit1", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "DigitalCmsCoupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<DigitalCmsCoupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit1
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit1") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit6", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Coupon")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<Coupon> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit6
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PricerSetter.source + ".Visit6") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_Range", Description="Create a range of PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PricerSetter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<PricerSetter> (c)) :> ICell
                let format (i : Generic.List<ICell<PricerSetter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<PricerSetter>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
