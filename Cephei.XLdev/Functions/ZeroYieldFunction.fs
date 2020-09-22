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
  Zero-curve traits
  </summary> *)
[<AutoSerializable(true)>]
module ZeroYieldFunction =

    (*
        upper bound for convergence loop
    *)
    [<ExcelFunction(Name="_ZeroYield_discountImpl", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".DiscountImpl") 
                                               [| _ZeroYield.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
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
    [<ExcelFunction(Name="_ZeroYield_forwardImpl", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".ForwardImpl") 
                                               [| _ZeroYield.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
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
    [<ExcelFunction(Name="_ZeroYield_guess", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
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

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _f = Helper.toCell<int> f "f" true
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".Guess") 
                                               [| _ZeroYield.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
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
    [<ExcelFunction(Name="_ZeroYield_initialDate", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let _c = Helper.toCell<YieldTermStructure> c "c" true
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".InitialDate") 
                                               [| _ZeroYield.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
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
    [<ExcelFunction(Name="_ZeroYield_initialValue", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let _c = Helper.toCell<YieldTermStructure> c "c" true
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).InitialValue
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".InitialValue") 
                                               [| _ZeroYield.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
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
    [<ExcelFunction(Name="_ZeroYield_maxIterations", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".MaxIterations") 
                                               [| _ZeroYield.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
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
    [<ExcelFunction(Name="_ZeroYield_maxValueAfter", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
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

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _f = Helper.toCell<int> f "f" true
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".MaxValueAfter") 
                                               [| _ZeroYield.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
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
    [<ExcelFunction(Name="_ZeroYield_minValueAfter", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
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

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _f = Helper.toCell<int> f "f" true
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".MinValueAfter") 
                                               [| _ZeroYield.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
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
    [<ExcelFunction(Name="_ZeroYield_updateGuess", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let _data = Helper.toCell<Generic.List<double>> data "data" true
                let _rate = Helper.toCell<double> rate "rate" true
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).UpdateGuess
                                                            _data.cell 
                                                            _rate.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : ZeroYield) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".UpdateGuess") 
                                               [| _ZeroYield.source
                                               ;  _data.source
                                               ;  _rate.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
                                ;  _data.cell
                                ;  _rate.cell
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
    [<ExcelFunction(Name="_ZeroYield_zeroYieldImpl", Description="Create a ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroYield",Description = "Reference to ZeroYield")>] 
         zeroyield : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroYield = Helper.toCell<ZeroYield> zeroyield "ZeroYield" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_ZeroYield.cell :?> ZeroYieldModel).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroYield.source + ".ZeroYieldImpl") 
                                               [| _ZeroYield.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroYield.cell
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
    [<ExcelFunction(Name="_ZeroYield_Range", Description="Create a range of ZeroYield",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroYield_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ZeroYield")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroYield> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ZeroYield>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ZeroYield>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ZeroYield>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
