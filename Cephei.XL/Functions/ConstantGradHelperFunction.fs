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
module ConstantGradHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConstantGradHelper", Description="Create a ConstantGradHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantGradHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "ConstantGradHelper")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="fPrev",Description = "double")>] 
         fPrev : obj)
        ([<ExcelArgument(Name="prevPrimitive",Description = "double")>] 
         prevPrimitive : obj)
        ([<ExcelArgument(Name="xPrev",Description = "double")>] 
         xPrev : obj)
        ([<ExcelArgument(Name="xNext",Description = "double")>] 
         xNext : obj)
        ([<ExcelArgument(Name="fNext",Description = "double")>] 
         fNext : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _fPrev = Helper.toCell<double> fPrev "fPrev" 
                let _prevPrimitive = Helper.toCell<double> prevPrimitive "prevPrimitive" 
                let _xPrev = Helper.toCell<double> xPrev "xPrev" 
                let _xNext = Helper.toCell<double> xNext "xNext" 
                let _fNext = Helper.toCell<double> fNext "fNext" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantGradHelper 
                                                            _fPrev.cell 
                                                            _prevPrimitive.cell 
                                                            _xPrev.cell 
                                                            _xNext.cell 
                                                            _fNext.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantGradHelper>) l

                let source () = Helper.sourceFold "Fun.ConstantGradHelper" 
                                               [| _fPrev.source
                                               ;  _prevPrimitive.source
                                               ;  _xPrev.source
                                               ;  _xNext.source
                                               ;  _fNext.source
                                               |]
                let hash = Helper.hashFold 
                                [| _fPrev.cell
                                ;  _prevPrimitive.cell
                                ;  _xPrev.cell
                                ;  _xNext.cell
                                ;  _fNext.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantGradHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantGradHelper_fNext", Description="Create a ConstantGradHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantGradHelper_fNext
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantGradHelper",Description = "ConstantGradHelper")>] 
         constantgradhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantGradHelper = Helper.toCell<ConstantGradHelper> constantgradhelper "ConstantGradHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantGradHelperModel.Cast _ConstantGradHelper.cell).FNext
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantGradHelper.source + ".FNext") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConstantGradHelper.cell
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
    [<ExcelFunction(Name="_ConstantGradHelper_primitive", Description="Create a ConstantGradHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantGradHelper_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantGradHelper",Description = "ConstantGradHelper")>] 
         constantgradhelper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantGradHelper = Helper.toCell<ConstantGradHelper> constantgradhelper "ConstantGradHelper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantGradHelperModel.Cast _ConstantGradHelper.cell).Primitive
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantGradHelper.source + ".Primitive") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantGradHelper.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_ConstantGradHelper_value", Description="Create a ConstantGradHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantGradHelper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantGradHelper",Description = "ConstantGradHelper")>] 
         constantgradhelper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantGradHelper = Helper.toCell<ConstantGradHelper> constantgradhelper "ConstantGradHelper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantGradHelperModel.Cast _ConstantGradHelper.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantGradHelper.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantGradHelper.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_ConstantGradHelper_Range", Description="Create a range of ConstantGradHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantGradHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConstantGradHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConstantGradHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConstantGradHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ConstantGradHelper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
