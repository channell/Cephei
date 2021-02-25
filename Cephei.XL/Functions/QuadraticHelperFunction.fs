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
module QuadraticHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_QuadraticHelper_fNext", Description="Create a QuadraticHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let QuadraticHelper_fNext
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="QuadraticHelper",Description = "QuadraticHelper")>] 
         quadratichelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _QuadraticHelper = Helper.toModelReference<QuadraticHelper> quadratichelper "QuadraticHelper"  
                let builder (current : ICell) = ((QuadraticHelperModel.Cast _QuadraticHelper.cell).FNext
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_QuadraticHelper.source + ".FNext") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _QuadraticHelper.cell
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
    [<ExcelFunction(Name="_QuadraticHelper_primitive", Description="Create a QuadraticHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let QuadraticHelper_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="QuadraticHelper",Description = "QuadraticHelper")>] 
         quadratichelper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _QuadraticHelper = Helper.toModelReference<QuadraticHelper> quadratichelper "QuadraticHelper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((QuadraticHelperModel.Cast _QuadraticHelper.cell).Primitive
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_QuadraticHelper.source + ".Primitive") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _QuadraticHelper.cell
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
    [<ExcelFunction(Name="_QuadraticHelper", Description="Create a QuadraticHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let QuadraticHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xPrev",Description = "double")>] 
         xPrev : obj)
        ([<ExcelArgument(Name="xNext",Description = "double")>] 
         xNext : obj)
        ([<ExcelArgument(Name="fPrev",Description = "double")>] 
         fPrev : obj)
        ([<ExcelArgument(Name="fNext",Description = "double")>] 
         fNext : obj)
        ([<ExcelArgument(Name="fAverage",Description = "double")>] 
         fAverage : obj)
        ([<ExcelArgument(Name="prevPrimitive",Description = "double")>] 
         prevPrimitive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xPrev = Helper.toCell<double> xPrev "xPrev" 
                let _xNext = Helper.toCell<double> xNext "xNext" 
                let _fPrev = Helper.toCell<double> fPrev "fPrev" 
                let _fNext = Helper.toCell<double> fNext "fNext" 
                let _fAverage = Helper.toCell<double> fAverage "fAverage" 
                let _prevPrimitive = Helper.toCell<double> prevPrimitive "prevPrimitive" 
                let builder (current : ICell) = (Fun.QuadraticHelper 
                                                            _xPrev.cell 
                                                            _xNext.cell 
                                                            _fPrev.cell 
                                                            _fNext.cell 
                                                            _fAverage.cell 
                                                            _prevPrimitive.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<QuadraticHelper>) l

                let source () = Helper.sourceFold "Fun.QuadraticHelper" 
                                               [| _xPrev.source
                                               ;  _xNext.source
                                               ;  _fPrev.source
                                               ;  _fNext.source
                                               ;  _fAverage.source
                                               ;  _prevPrimitive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xPrev.cell
                                ;  _xNext.cell
                                ;  _fPrev.cell
                                ;  _fNext.cell
                                ;  _fAverage.cell
                                ;  _prevPrimitive.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QuadraticHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_QuadraticHelper_value", Description="Create a QuadraticHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let QuadraticHelper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="QuadraticHelper",Description = "QuadraticHelper")>] 
         quadratichelper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _QuadraticHelper = Helper.toModelReference<QuadraticHelper> quadratichelper "QuadraticHelper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((QuadraticHelperModel.Cast _QuadraticHelper.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_QuadraticHelper.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _QuadraticHelper.cell
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
    [<ExcelFunction(Name="_QuadraticHelper_Range", Description="Create a range of QuadraticHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let QuadraticHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<QuadraticHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<QuadraticHelper> (c)) :> ICell
                let format (i : Cephei.Cell.List<QuadraticHelper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<QuadraticHelper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
