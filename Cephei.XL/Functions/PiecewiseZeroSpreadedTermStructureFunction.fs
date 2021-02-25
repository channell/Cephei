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
module PiecewiseZeroSpreadedTermStructureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroSpreadedTermStructure", Description="Create a PiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroSpreadedTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        ([<ExcelArgument(Name="spreads",Description = "Quote range")>] 
         spreads : obj)
        ([<ExcelArgument(Name="dates",Description = "Date range")>] 
         dates : obj)
        ([<ExcelArgument(Name="compounding",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded or empty")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency or empty")>] 
         frequency : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let _spreads = Helper.toCell<Generic.List<Handle<Quote>>> spreads "spreads" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _compounding = Helper.toDefault<Compounding> compounding "compounding" Compounding.Continuous
                let _frequency = Helper.toDefault<Frequency> frequency "frequency" Frequency.NoFrequency
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.PiecewiseZeroSpreadedTermStructure 
                                                            _h.cell 
                                                            _spreads.cell 
                                                            _dates.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _dc.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseZeroSpreadedTermStructure>) l

                let source () = Helper.sourceFold "Fun.PiecewiseZeroSpreadedTermStructure" 
                                               [| _h.source
                                               ;  _spreads.source
                                               ;  _dates.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _dc.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                ;  _spreads.cell
                                ;  _dates.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _dc.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroSpreadedTermStructure_calendar", Description="Create a PiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroSpreadedTermStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroSpreadedTermStructure",Description = "PiecewiseZeroSpreadedTermStructure")>] 
         piecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroSpreadedTermStructure = Helper.toModelReference<PiecewiseZeroSpreadedTermStructure> piecewisezerospreadedtermstructure "PiecewiseZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((PiecewiseZeroSpreadedTermStructureModel.Cast _PiecewiseZeroSpreadedTermStructure.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_PiecewiseZeroSpreadedTermStructure.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroSpreadedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroSpreadedTermStructure_dayCounter", Description="Create a PiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroSpreadedTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroSpreadedTermStructure",Description = "PiecewiseZeroSpreadedTermStructure")>] 
         piecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroSpreadedTermStructure = Helper.toModelReference<PiecewiseZeroSpreadedTermStructure> piecewisezerospreadedtermstructure "PiecewiseZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((PiecewiseZeroSpreadedTermStructureModel.Cast _PiecewiseZeroSpreadedTermStructure.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_PiecewiseZeroSpreadedTermStructure.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroSpreadedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroSpreadedTermStructure_maxDate", Description="Create a PiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroSpreadedTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroSpreadedTermStructure",Description = "PiecewiseZeroSpreadedTermStructure")>] 
         piecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroSpreadedTermStructure = Helper.toModelReference<PiecewiseZeroSpreadedTermStructure> piecewisezerospreadedtermstructure "PiecewiseZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((PiecewiseZeroSpreadedTermStructureModel.Cast _PiecewiseZeroSpreadedTermStructure.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroSpreadedTermStructure.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroSpreadedTermStructure_referenceDate", Description="Create a PiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroSpreadedTermStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroSpreadedTermStructure",Description = "PiecewiseZeroSpreadedTermStructure")>] 
         piecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroSpreadedTermStructure = Helper.toModelReference<PiecewiseZeroSpreadedTermStructure> piecewisezerospreadedtermstructure "PiecewiseZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((PiecewiseZeroSpreadedTermStructureModel.Cast _PiecewiseZeroSpreadedTermStructure.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroSpreadedTermStructure.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroSpreadedTermStructure_settlementDays", Description="Create a PiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroSpreadedTermStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroSpreadedTermStructure",Description = "PiecewiseZeroSpreadedTermStructure")>] 
         piecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroSpreadedTermStructure = Helper.toModelReference<PiecewiseZeroSpreadedTermStructure> piecewisezerospreadedtermstructure "PiecewiseZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((PiecewiseZeroSpreadedTermStructureModel.Cast _PiecewiseZeroSpreadedTermStructure.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroSpreadedTermStructure.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroSpreadedTermStructure_Range", Description="Create a range of PiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroSpreadedTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PiecewiseZeroSpreadedTermStructure> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<PiecewiseZeroSpreadedTermStructure> (c)) :> ICell
                let format (i : Cephei.Cell.List<PiecewiseZeroSpreadedTermStructure>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<PiecewiseZeroSpreadedTermStructure>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
