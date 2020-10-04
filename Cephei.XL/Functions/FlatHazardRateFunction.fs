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
  defaultprobabilitytermstructures
  </summary> *)
[<AutoSerializable(true)>]
module FlatHazardRateFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FlatHazardRate3", Description="Create a FlatHazardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatHazardRate_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="hazardRate",Description = "Reference to hazardRate")>] 
         hazardRate : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _hazardRate = Helper.toCell<double> hazardRate "hazardRate" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder () = withMnemonic mnemonic (Fun.FlatHazardRate3 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _hazardRate.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatHazardRate>) l

                let source = Helper.sourceFold "Fun.FlatHazardRate3" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _hazardRate.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _hazardRate.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatHazardRate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatHazardRat1", Description="Create a FlatHazardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatHazardRate_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="hazardRate",Description = "Reference to hazardRate")>] 
         hazardRate : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _hazardRate = Helper.toHandle<Quote> hazardRate "hazardRate" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder () = withMnemonic mnemonic (Fun.FlatHazardRate
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _hazardRate.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatHazardRate>) l

                let source = Helper.sourceFold "Fun.FlatHazardRate" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _hazardRate.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _hazardRate.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatHazardRate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatHazardRate1", Description="Create a FlatHazardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatHazardRate_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="hazardRate",Description = "Reference to hazardRate")>] 
         hazardRate : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _hazardRate = Helper.toCell<double> hazardRate "hazardRate" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder () = withMnemonic mnemonic (Fun.FlatHazardRate1
                                                            _referenceDate.cell 
                                                            _hazardRate.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatHazardRate>) l

                let source = Helper.sourceFold "Fun.FlatHazardRate1" 
                                               [| _referenceDate.source
                                               ;  _hazardRate.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _hazardRate.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatHazardRate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatHazardRate2", Description="Create a FlatHazardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatHazardRate_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="hazardRate",Description = "Reference to hazardRate")>] 
         hazardRate : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _hazardRate = Helper.toHandle<Quote> hazardRate "hazardRate" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder () = withMnemonic mnemonic (Fun.FlatHazardRate2
                                                            _referenceDate.cell 
                                                            _hazardRate.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FlatHazardRate>) l

                let source = Helper.sourceFold "Fun.FlatHazardRate2" 
                                               [| _referenceDate.source
                                               ;  _hazardRate.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _hazardRate.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FlatHazardRate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FlatHazardRate_maxDate", Description="Create a FlatHazardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatHazardRate_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FlatHazardRate",Description = "Reference to FlatHazardRate")>] 
         flathazardrate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FlatHazardRate = Helper.toCell<FlatHazardRate> flathazardrate "FlatHazardRate"  
                let builder () = withMnemonic mnemonic ((FlatHazardRateModel.Cast _FlatHazardRate.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FlatHazardRate.source + ".MaxDate") 
                                               [| _FlatHazardRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FlatHazardRate.cell
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
    [<ExcelFunction(Name="_FlatHazardRate_Range", Description="Create a range of FlatHazardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FlatHazardRate_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FlatHazardRate")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FlatHazardRate> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FlatHazardRate>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FlatHazardRate>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FlatHazardRate>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
