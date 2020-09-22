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
module NotionalPathFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NotionalPath_addReduction", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotionalPath_addReduction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NotionalPath",Description = "Reference to NotionalPath")>] 
         notionalpath : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        ([<ExcelArgument(Name="newRate",Description = "Reference to newRate")>] 
         newRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NotionalPath = Helper.toCell<NotionalPath> notionalpath "NotionalPath" true 
                let _date = Helper.toCell<Date> date "date" true
                let _newRate = Helper.toCell<double> newRate "newRate" true
                let builder () = withMnemonic mnemonic ((_NotionalPath.cell :?> NotionalPathModel).AddReduction
                                                            _date.cell 
                                                            _newRate.cell 
                                                       ) :> ICell
                let format (o : NotionalPath) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NotionalPath.source + ".AddReduction") 
                                               [| _NotionalPath.source
                                               ;  _date.source
                                               ;  _newRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NotionalPath.cell
                                ;  _date.cell
                                ;  _newRate.cell
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
    [<ExcelFunction(Name="_NotionalPath_loss", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotionalPath_loss
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NotionalPath",Description = "Reference to NotionalPath")>] 
         notionalpath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NotionalPath = Helper.toCell<NotionalPath> notionalpath "NotionalPath" true 
                let builder () = withMnemonic mnemonic ((_NotionalPath.cell :?> NotionalPathModel).Loss
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NotionalPath.source + ".Loss") 
                                               [| _NotionalPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NotionalPath.cell
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
    [<ExcelFunction(Name="_NotionalPath", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotionalPath_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.NotionalPath ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NotionalPath>) l

                let source = Helper.sourceFold "Fun.NotionalPath" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
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
        
    *)
    [<ExcelFunction(Name="_NotionalPath_notionalRate", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotionalPath_notionalRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NotionalPath",Description = "Reference to NotionalPath")>] 
         notionalpath : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NotionalPath = Helper.toCell<NotionalPath> notionalpath "NotionalPath" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_NotionalPath.cell :?> NotionalPathModel).NotionalRate
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NotionalPath.source + ".NotionalRate") 
                                               [| _NotionalPath.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NotionalPath.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_NotionalPath_reset", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotionalPath_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NotionalPath",Description = "Reference to NotionalPath")>] 
         notionalpath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NotionalPath = Helper.toCell<NotionalPath> notionalpath "NotionalPath" true 
                let builder () = withMnemonic mnemonic ((_NotionalPath.cell :?> NotionalPathModel).Reset
                                                       ) :> ICell
                let format (o : NotionalPath) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NotionalPath.source + ".Reset") 
                                               [| _NotionalPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NotionalPath.cell
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
    [<ExcelFunction(Name="_NotionalPath_Range", Description="Create a range of NotionalPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotionalPath_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NotionalPath")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NotionalPath> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NotionalPath>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NotionalPath>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NotionalPath>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
