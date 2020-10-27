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
module PSACurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PSACurve_getCPR", Description="Create a PSACurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PSACurve_getCPR
        ([<ExcelArgument(Name="Mnemonic",Description = "PSACurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PSACurve",Description = "PSACurve")>] 
         psacurve : obj)
        ([<ExcelArgument(Name="valDate",Description = "Date")>] 
         valDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PSACurve = Helper.toCell<PSACurve> psacurve "PSACurve"  
                let _valDate = Helper.toCell<Date> valDate "valDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PSACurveModel.Cast _PSACurve.cell).GetCPR
                                                            _valDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PSACurve.source + ".GetCPR") 

                                               [| _valDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PSACurve.cell
                                ;  _valDate.cell
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
    [<ExcelFunction(Name="_PSACurve_getSMM", Description="Create a PSACurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PSACurve_getSMM
        ([<ExcelArgument(Name="Mnemonic",Description = "PSACurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PSACurve",Description = "PSACurve")>] 
         psacurve : obj)
        ([<ExcelArgument(Name="valDate",Description = "Date")>] 
         valDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PSACurve = Helper.toCell<PSACurve> psacurve "PSACurve"  
                let _valDate = Helper.toCell<Date> valDate "valDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PSACurveModel.Cast _PSACurve.cell).GetSMM
                                                            _valDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PSACurve.source + ".GetSMM") 

                                               [| _valDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PSACurve.cell
                                ;  _valDate.cell
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
    [<ExcelFunction(Name="_PSACurve", Description="Create a PSACurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PSACurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "PSACurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="startdate",Description = "Date")>] 
         startdate : obj)
        ([<ExcelArgument(Name="multiplier",Description = "double")>] 
         multiplier : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _startdate = Helper.toCell<Date> startdate "startdate" 
                let _multiplier = Helper.toCell<double> multiplier "multiplier" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PSACurve 
                                                            _startdate.cell 
                                                            _multiplier.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PSACurve>) l

                let source () = Helper.sourceFold "Fun.PSACurve" 
                                               [| _startdate.source
                                               ;  _multiplier.source
                                               |]
                let hash = Helper.hashFold 
                                [| _startdate.cell
                                ;  _multiplier.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PSACurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PSACurve1", Description="Create a PSACurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PSACurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "PSACurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="startdate",Description = "Date")>] 
         startdate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _startdate = Helper.toCell<Date> startdate "startdate" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PSACurve1 
                                                            _startdate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PSACurve>) l

                let source () = Helper.sourceFold "Fun.PSACurve1" 
                                               [| _startdate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _startdate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PSACurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PSACurve_Range", Description="Create a range of PSACurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PSACurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PSACurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PSACurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<PSACurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PSACurve>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
