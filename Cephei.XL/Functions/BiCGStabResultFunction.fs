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
module BiCGStabResultFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BiCGStabResult", Description="Create a BiCGStabResult",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BiCGStabResult_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        ([<ExcelArgument(Name="xx",Description = "Reference to xx")>] 
         xx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _i = Helper.toCell<int> i "i" 
                let _e = Helper.toCell<double> e "e" 
                let _xx = Helper.toCell<Vector> xx "xx" 
                let builder () = withMnemonic mnemonic (Fun.BiCGStabResult 
                                                            _i.cell 
                                                            _e.cell 
                                                            _xx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BiCGStabResult>) l

                let source = Helper.sourceFold "Fun.BiCGStabResult" 
                                               [| _i.source
                                               ;  _e.source
                                               ;  _xx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _i.cell
                                ;  _e.cell
                                ;  _xx.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BiCGStabResult> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BiCGStabResult_Error", Description="Create a BiCGStabResult",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BiCGStabResult_Error
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BiCGStabResult",Description = "Reference to BiCGStabResult")>] 
         bicgstabresult : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BiCGStabResult = Helper.toCell<BiCGStabResult> bicgstabresult "BiCGStabResult"  
                let builder () = withMnemonic mnemonic ((_BiCGStabResult.cell :?> BiCGStabResultModel).Error
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BiCGStabResult.source + ".Error") 
                                               [| _BiCGStabResult.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BiCGStabResult.cell
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
    [<ExcelFunction(Name="_BiCGStabResult_Iterations", Description="Create a BiCGStabResult",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BiCGStabResult_Iterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BiCGStabResult",Description = "Reference to BiCGStabResult")>] 
         bicgstabresult : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BiCGStabResult = Helper.toCell<BiCGStabResult> bicgstabresult "BiCGStabResult"  
                let builder () = withMnemonic mnemonic ((_BiCGStabResult.cell :?> BiCGStabResultModel).Iterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BiCGStabResult.source + ".Iterations") 
                                               [| _BiCGStabResult.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BiCGStabResult.cell
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
    [<ExcelFunction(Name="_BiCGStabResult_X", Description="Create a BiCGStabResult",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BiCGStabResult_X
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BiCGStabResult",Description = "Reference to BiCGStabResult")>] 
         bicgstabresult : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BiCGStabResult = Helper.toCell<BiCGStabResult> bicgstabresult "BiCGStabResult"  
                let builder () = withMnemonic mnemonic ((_BiCGStabResult.cell :?> BiCGStabResultModel).X
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_BiCGStabResult.source + ".X") 
                                               [| _BiCGStabResult.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BiCGStabResult.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BiCGStabResult> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BiCGStabResult_Range", Description="Create a range of BiCGStabResult",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BiCGStabResult_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BiCGStabResult")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BiCGStabResult> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BiCGStabResult>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BiCGStabResult>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BiCGStabResult>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
