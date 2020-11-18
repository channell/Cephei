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
module ConvexMonotone2HelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone2Helper", Description="Create a ConvexMonotone2Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone2Helper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xPrev",Description = "double")>] 
         xPrev : obj)
        ([<ExcelArgument(Name="xNext",Description = "double")>] 
         xNext : obj)
        ([<ExcelArgument(Name="gPrev",Description = "double")>] 
         gPrev : obj)
        ([<ExcelArgument(Name="gNext",Description = "double")>] 
         gNext : obj)
        ([<ExcelArgument(Name="fAverage",Description = "double")>] 
         fAverage : obj)
        ([<ExcelArgument(Name="eta2",Description = "double")>] 
         eta2 : obj)
        ([<ExcelArgument(Name="prevPrimitive",Description = "double")>] 
         prevPrimitive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xPrev = Helper.toCell<double> xPrev "xPrev" 
                let _xNext = Helper.toCell<double> xNext "xNext" 
                let _gPrev = Helper.toCell<double> gPrev "gPrev" 
                let _gNext = Helper.toCell<double> gNext "gNext" 
                let _fAverage = Helper.toCell<double> fAverage "fAverage" 
                let _eta2 = Helper.toCell<double> eta2 "eta2" 
                let _prevPrimitive = Helper.toCell<double> prevPrimitive "prevPrimitive" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConvexMonotone2Helper 
                                                            _xPrev.cell 
                                                            _xNext.cell 
                                                            _gPrev.cell 
                                                            _gNext.cell 
                                                            _fAverage.cell 
                                                            _eta2.cell 
                                                            _prevPrimitive.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvexMonotone2Helper>) l

                let source () = Helper.sourceFold "Fun.ConvexMonotone2Helper" 
                                               [| _xPrev.source
                                               ;  _xNext.source
                                               ;  _gPrev.source
                                               ;  _gNext.source
                                               ;  _fAverage.source
                                               ;  _eta2.source
                                               ;  _prevPrimitive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xPrev.cell
                                ;  _xNext.cell
                                ;  _gPrev.cell
                                ;  _gNext.cell
                                ;  _fAverage.cell
                                ;  _eta2.cell
                                ;  _prevPrimitive.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvexMonotone2Helper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone2Helper_fNext", Description="Create a ConvexMonotone2Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone2Helper_fNext
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone2Helper",Description = "ConvexMonotone2Helper")>] 
         convexmonotone2helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone2Helper = Helper.toCell<ConvexMonotone2Helper> convexmonotone2helper "ConvexMonotone2Helper"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvexMonotone2HelperModel.Cast _ConvexMonotone2Helper.cell).FNext
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvexMonotone2Helper.source + ".FNext") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone2Helper.cell
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
    [<ExcelFunction(Name="_ConvexMonotone2Helper_primitive", Description="Create a ConvexMonotone2Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone2Helper_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone2Helper",Description = "ConvexMonotone2Helper")>] 
         convexmonotone2helper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone2Helper = Helper.toCell<ConvexMonotone2Helper> convexmonotone2helper "ConvexMonotone2Helper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvexMonotone2HelperModel.Cast _ConvexMonotone2Helper.cell).Primitive
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvexMonotone2Helper.source + ".Primitive") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone2Helper.cell
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
    [<ExcelFunction(Name="_ConvexMonotone2Helper_value", Description="Create a ConvexMonotone2Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone2Helper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone2Helper",Description = "ConvexMonotone2Helper")>] 
         convexmonotone2helper : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone2Helper = Helper.toCell<ConvexMonotone2Helper> convexmonotone2helper "ConvexMonotone2Helper"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvexMonotone2HelperModel.Cast _ConvexMonotone2Helper.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvexMonotone2Helper.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone2Helper.cell
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
    [<ExcelFunction(Name="_ConvexMonotone2Helper_Range", Description="Create a range of ConvexMonotone2Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone2Helper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvexMonotone2Helper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<ConvexMonotone2Helper> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<ConvexMonotone2Helper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ConvexMonotone2Helper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
