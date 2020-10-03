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
module ConvexMonotone3HelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone3Helper", Description="Create a ConvexMonotone3Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone3Helper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xPrev",Description = "Reference to xPrev")>] 
         xPrev : obj)
        ([<ExcelArgument(Name="xNext",Description = "Reference to xNext")>] 
         xNext : obj)
        ([<ExcelArgument(Name="gPrev",Description = "Reference to gPrev")>] 
         gPrev : obj)
        ([<ExcelArgument(Name="gNext",Description = "Reference to gNext")>] 
         gNext : obj)
        ([<ExcelArgument(Name="fAverage",Description = "Reference to fAverage")>] 
         fAverage : obj)
        ([<ExcelArgument(Name="eta3",Description = "Reference to eta3")>] 
         eta3 : obj)
        ([<ExcelArgument(Name="prevPrimitive",Description = "Reference to prevPrimitive")>] 
         prevPrimitive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xPrev = Helper.toCell<double> xPrev "xPrev" 
                let _xNext = Helper.toCell<double> xNext "xNext" 
                let _gPrev = Helper.toCell<double> gPrev "gPrev" 
                let _gNext = Helper.toCell<double> gNext "gNext" 
                let _fAverage = Helper.toCell<double> fAverage "fAverage" 
                let _eta3 = Helper.toCell<double> eta3 "eta3" 
                let _prevPrimitive = Helper.toCell<double> prevPrimitive "prevPrimitive" 
                let builder () = withMnemonic mnemonic (Fun.ConvexMonotone3Helper 
                                                            _xPrev.cell 
                                                            _xNext.cell 
                                                            _gPrev.cell 
                                                            _gNext.cell 
                                                            _fAverage.cell 
                                                            _eta3.cell 
                                                            _prevPrimitive.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvexMonotone3Helper>) l

                let source = Helper.sourceFold "Fun.ConvexMonotone3Helper" 
                                               [| _xPrev.source
                                               ;  _xNext.source
                                               ;  _gPrev.source
                                               ;  _gNext.source
                                               ;  _fAverage.source
                                               ;  _eta3.source
                                               ;  _prevPrimitive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xPrev.cell
                                ;  _xNext.cell
                                ;  _gPrev.cell
                                ;  _gNext.cell
                                ;  _fAverage.cell
                                ;  _eta3.cell
                                ;  _prevPrimitive.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvexMonotone3Helper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone3Helper_fNext", Description="Create a ConvexMonotone3Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone3Helper_fNext
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone3Helper",Description = "Reference to ConvexMonotone3Helper")>] 
         convexmonotone3helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone3Helper = Helper.toCell<ConvexMonotone3Helper> convexmonotone3helper "ConvexMonotone3Helper"  
                let builder () = withMnemonic mnemonic ((ConvexMonotone3HelperModel.Cast _ConvexMonotone3Helper.cell).FNext
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotone3Helper.source + ".FNext") 
                                               [| _ConvexMonotone3Helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone3Helper.cell
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
    [<ExcelFunction(Name="_ConvexMonotone3Helper_primitive", Description="Create a ConvexMonotone3Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone3Helper_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone3Helper",Description = "Reference to ConvexMonotone3Helper")>] 
         convexmonotone3helper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone3Helper = Helper.toCell<ConvexMonotone3Helper> convexmonotone3helper "ConvexMonotone3Helper"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((ConvexMonotone3HelperModel.Cast _ConvexMonotone3Helper.cell).Primitive
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotone3Helper.source + ".Primitive") 
                                               [| _ConvexMonotone3Helper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone3Helper.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_ConvexMonotone3Helper_value", Description="Create a ConvexMonotone3Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone3Helper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone3Helper",Description = "Reference to ConvexMonotone3Helper")>] 
         convexmonotone3helper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone3Helper = Helper.toCell<ConvexMonotone3Helper> convexmonotone3helper "ConvexMonotone3Helper"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((ConvexMonotone3HelperModel.Cast _ConvexMonotone3Helper.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotone3Helper.source + ".Value") 
                                               [| _ConvexMonotone3Helper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone3Helper.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_ConvexMonotone3Helper_Range", Description="Create a range of ConvexMonotone3Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone3Helper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConvexMonotone3Helper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvexMonotone3Helper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConvexMonotone3Helper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConvexMonotone3Helper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConvexMonotone3Helper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
