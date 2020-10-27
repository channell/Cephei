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
    [<ExcelFunction(Name="_NotionalPath_addReduction", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NotionalPath_addReduction
        ([<ExcelArgument(Name="Mnemonic",Description = "NotionalPath")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NotionalPath",Description = "NotionalPath")>] 
         notionalpath : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        ([<ExcelArgument(Name="newRate",Description = "double")>] 
         newRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NotionalPath = Helper.toCell<NotionalPath> notionalpath "NotionalPath"  
                let _date = Helper.toCell<Date> date "date" 
                let _newRate = Helper.toCell<double> newRate "newRate" 
                let builder (current : ICell) = withMnemonic mnemonic ((NotionalPathModel.Cast _NotionalPath.cell).AddReduction
                                                            _date.cell 
                                                            _newRate.cell 
                                                       ) :> ICell
                let format (o : NotionalPath) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NotionalPath.source + ".AddReduction") 

                                               [| _date.source
                                               ;  _newRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NotionalPath.cell
                                ;  _date.cell
                                ;  _newRate.cell
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
    [<ExcelFunction(Name="_NotionalPath_loss", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NotionalPath_loss
        ([<ExcelArgument(Name="Mnemonic",Description = "NotionalPath")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NotionalPath",Description = "NotionalPath")>] 
         notionalpath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NotionalPath = Helper.toCell<NotionalPath> notionalpath "NotionalPath"  
                let builder (current : ICell) = withMnemonic mnemonic ((NotionalPathModel.Cast _NotionalPath.cell).Loss
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NotionalPath.source + ".Loss") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NotionalPath.cell
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
    [<ExcelFunction(Name="_NotionalPath", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NotionalPath_create
        ([<ExcelArgument(Name="Mnemonic",Description = "NotionalPath")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.NotionalPath ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NotionalPath>) l

                let source () = Helper.sourceFold "Fun.NotionalPath" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NotionalPath> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NotionalPath_notionalRate", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NotionalPath_notionalRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NotionalPath",Description = "NotionalPath")>] 
         notionalpath : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NotionalPath = Helper.toCell<NotionalPath> notionalpath "NotionalPath"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((NotionalPathModel.Cast _NotionalPath.cell).NotionalRate
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NotionalPath.source + ".NotionalRate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NotionalPath.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_NotionalPath_reset", Description="Create a NotionalPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NotionalPath_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NotionalPath",Description = "NotionalPath")>] 
         notionalpath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NotionalPath = Helper.toCell<NotionalPath> notionalpath "NotionalPath"  
                let builder (current : ICell) = withMnemonic mnemonic ((NotionalPathModel.Cast _NotionalPath.cell).Reset
                                                       ) :> ICell
                let format (o : NotionalPath) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NotionalPath.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NotionalPath.cell
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
    [<ExcelFunction(Name="_NotionalPath_Range", Description="Create a range of NotionalPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NotionalPath_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NotionalPath> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NotionalPath>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<NotionalPath>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<NotionalPath>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
