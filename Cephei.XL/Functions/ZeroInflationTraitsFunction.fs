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
    [<ExcelFunction(Name="_ZeroInflationTraits_discountImpl", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".DiscountImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_forwardImpl", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".ForwardImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_guess", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
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

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".Guess") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_ZeroInflationTraits_initialDate", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="t",Description = "ZeroInflationTermStructure")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let _t = Helper.toCell<ZeroInflationTermStructure> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).InitialDate
                                                            _t.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".InitialDate") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_initialValue", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="t",Description = "ZeroInflationTermStructure")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let _t = Helper.toCell<ZeroInflationTermStructure> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).InitialValue
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".InitialValue") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_maxIterations", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".MaxIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_maxValueAfter", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
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

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".MaxValueAfter") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_ZeroInflationTraits_minValueAfter", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
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

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".MinValueAfter") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_ZeroInflationTraits_updateGuess", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="data",Description = "double range")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationTraits) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".UpdateGuess") 

                                               [| _data.source
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
    [<ExcelFunction(Name="_ZeroInflationTraits_zeroYieldImpl", Description="Create a ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationTraits",Description = "ZeroInflationTraits")>] 
         zeroinflationtraits : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationTraits = Helper.toCell<ZeroInflationTraits> zeroinflationtraits "ZeroInflationTraits"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationTraitsModel.Cast _ZeroInflationTraits.cell).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroInflationTraits.source + ".ZeroYieldImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationTraits.cell
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
    [<ExcelFunction(Name="_ZeroInflationTraits_Range", Description="Create a range of ZeroInflationTraits",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationTraits_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroInflationTraits> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ZeroInflationTraits> (c)) :> ICell
                let format (i : Generic.List<ICell<ZeroInflationTraits>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ZeroInflationTraits>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
