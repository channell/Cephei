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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic (Fun.PricerSetter 
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PricerSetter>) l

                let source = Helper.sourceFold "Fun.PricerSetter" 
                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _pricer.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CappedFlooredCoupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit8
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit8") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit3", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit3
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit3") 
                                               [| _PricerSetter.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit4", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CashFlow> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit4
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit4") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<RangeAccrualFloatersCoupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit7", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<FloatingRateCoupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit7
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit7") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit9", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit9
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<IborCoupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit9
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit9") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit10", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit10
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<DigitalIborCoupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit10
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit10") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit2", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CappedFlooredIborCoupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit2
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit2") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit5", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CmsCoupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit5
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit5") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit11", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit11
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<CappedFlooredCmsCoupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit11
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit11") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit1", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<DigitalCmsCoupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit1
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit1") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_visit6", Description="Create a PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_visit6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricerSetter",Description = "Reference to PricerSetter")>] 
         pricersetter : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricerSetter = Helper.toCell<PricerSetter> pricersetter "PricerSetter"  
                let _c = Helper.toCell<Coupon> c "c" 
                let builder () = withMnemonic mnemonic ((PricerSetterModel.Cast _PricerSetter.cell).Visit6
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : PricerSetter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PricerSetter.source + ".Visit6") 
                                               [| _PricerSetter.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricerSetter.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PricerSetter_Range", Description="Create a range of PricerSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PricerSetter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PricerSetter")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PricerSetter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PricerSetter>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PricerSetter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PricerSetter>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
