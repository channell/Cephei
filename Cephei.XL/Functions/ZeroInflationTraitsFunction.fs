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
module ZeroInflationTraitsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ZeroInflationTraits_discountImpl", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".DiscountImpl") 
                                               [| _ZeroInflationTraits.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_forwardImpl", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".ForwardImpl") 
                                               [| _ZeroInflationTraits.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_guess", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
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

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _f = Helper.toCell<int> f "f" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".Guess") 
                                               [| _ZeroInflationTraits.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_initialDate", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let _t = Helper.toCell<ZeroInflationTermStructure> t "t" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).InitialDate
                                                            _t.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".InitialDate") 
                                               [| _ZeroInflationTraits.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_initialValue", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let _t = Helper.toCell<ZeroInflationTermStructure> t "t" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).InitialValue
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".InitialValue") 
                                               [| _ZeroInflationTraits.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_maxIterations", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".MaxIterations") 
                                               [| _ZeroInflationTraits.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_maxValueAfter", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
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

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _f = Helper.toCell<int> f "f" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".MaxValueAfter") 
                                               [| _ZeroInflationTraits.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_minValueAfter", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
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

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _f = Helper.toCell<int> f "f" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".MinValueAfter") 
                                               [| _ZeroInflationTraits.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_updateGuess", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let _data = Helper.toCell<Generic.List<double>> data "data" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationTraits) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".UpdateGuess") 
                                               [| _ZeroInflationTraits.source
                                               ;  _data.source
                                               ;  _discount.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_zeroYieldImpl", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "Reference to ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationTraits.cell :?> ZeroInflationTraitsModel).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroInflationTraits.source + ".ZeroYieldImpl") 
                                               [| _ZeroInflationTraits.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_Range", Description="Create a range of ZeroInflationTraits",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationTraits_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ZeroInflationTraits")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroInflationTraits> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ZeroInflationTraits>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ZeroInflationTraits>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ZeroInflationTraits>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
