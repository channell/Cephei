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
        create a Discount object
    *)
    [<ExcelFunction(Name="_Discount", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Discount ()) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Discount>) l

                let source () = "Fun.Discount ()"
                let hash = 0
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
        upper bound for convergence loop
    *)
    [<ExcelFunction(Name="_Discount_discountImpl", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Discount.source + ".DiscountImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_Discount_forwardImpl", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Discount.source + ".ForwardImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_Discount_guess", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "InterpolatedCurve")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "bool")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "int")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Discount.source + ".Guess") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_Discount_initialDate", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="c",Description = "YieldTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount"  
                let _c = Helper.toCell<YieldTermStructure> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Discount.source + ".InitialDate") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
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
        start of curve data
    *)
    [<ExcelFunction(Name="_Discount_initialValue", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="c",Description = "YieldTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount"  
                let _c = Helper.toCell<YieldTermStructure> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).InitialValue
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Discount.source + ".InitialValue") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
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
    [<ExcelFunction(Name="_Discount_maxIterations", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Discount.source + ".MaxIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Discount.cell
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
    [<ExcelFunction(Name="_Discount_maxValueAfter", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "InterpolatedCurve")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "bool")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "int")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Discount.source + ".MaxValueAfter") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_Discount_minValueAfter", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "InterpolatedCurve")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "bool")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "int")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Discount.source + ".MinValueAfter") 

                                               [| _i.source
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
        value at reference date update with new guess
    *)
    [<ExcelFunction(Name="_Discount_updateGuess", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discountMnemonic : obj)
        ([<ExcelArgument(Name="data",Description = "double range")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discountMnemonic "Discount"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : Discount) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Discount.source + ".UpdateGuess") 

                                               [| _data.source
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
    [<ExcelFunction(Name="_Discount_zeroYieldImpl", Description="Create a Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Discount",Description = "Discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Discount = Helper.toCell<Discount> discount "Discount"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscountModel.Cast _Discount.cell).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Discount.source + ".ZeroYieldImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Discount.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_Discount_Range", Description="Create a range of Discount",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Discount_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Discount> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Discount> (c)) :> ICell
                let format (i : Generic.List<ICell<Discount>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Discount>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
