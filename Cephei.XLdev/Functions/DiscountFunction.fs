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
module DiscountFunction =

    (*
        upper bound for convergence loop
    *)
    [<ExcelFunction(Name="_Discount_discountImpl", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Discount.source + ".DiscountImpl") 
                                               [| _Discount.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_Discount_forwardImpl", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Discount.source + ".ForwardImpl") 
                                               [| _Discount.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_Discount_guess", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "Reference to validData")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _f = Helper.toCell<int> f "f" true
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Discount.source + ".Guess") 
                                               [| _Discount.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_Discount_initialDate", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let _c = Helper.toCell<YieldTermStructure> c "c" true
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Discount.source + ".InitialDate") 
                                               [| _Discount.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
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
        start of curve data
    *)
    [<ExcelFunction(Name="_Discount_initialValue", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let _c = Helper.toCell<YieldTermStructure> c "c" true
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).InitialValue
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Discount.source + ".InitialValue") 
                                               [| _Discount.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
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
    [<ExcelFunction(Name="_Discount_maxIterations", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Discount.source + ".MaxIterations") 
                                               [| _Discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
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
    [<ExcelFunction(Name="_Discount_maxValueAfter", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "Reference to validData")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _f = Helper.toCell<int> f "f" true
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Discount.source + ".MaxValueAfter") 
                                               [| _Discount.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_Discount_minValueAfter", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "Reference to validData")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _f = Helper.toCell<int> f "f" true
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Discount.source + ".MinValueAfter") 
                                               [| _Discount.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _f.cell
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
        value at reference date update with new guess
    *)
    [<ExcelFunction(Name="_Discount_updateGuess", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let _data = Helper.toCell<Generic.List<double>> data "data" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : Discount) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Discount.source + ".UpdateGuess") 
                                               [| _Discount.source
                                               ;  _data.source
                                               ;  _discount.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _data.cell
                                ;  _discount.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_Discount_zeroYieldImpl", Description="Create a Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Reference to Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_Discount.cell :?> DiscountModel).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Discount.source + ".ZeroYieldImpl") 
                                               [| _Discount.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_Discount_Range", Description="Create a range of Discount",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Discount_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Discount")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Discount> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Discount>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Discount>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Discount>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
