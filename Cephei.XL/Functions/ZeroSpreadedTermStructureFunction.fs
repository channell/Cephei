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
  This term structure will remain linked to the original structure, i.e., any changes in the latter will be reflected in this structure as well.  yieldtermstructures  - the correctness of the returned values is tested by checking them against numerical calculations. - observability against changes in the underlying term structure and in the added spread is checked.
  </summary> *)
[<AutoSerializable(true)>]
module ZeroSpreadedTermStructureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_calendar", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((ZeroSpreadedTermStructureModel.Cast _ZeroSpreadedTermStructure.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_dayCounter", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((ZeroSpreadedTermStructureModel.Cast _ZeroSpreadedTermStructure.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_maxDate", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((ZeroSpreadedTermStructureModel.Cast _ZeroSpreadedTermStructure.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_maxTime", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((ZeroSpreadedTermStructureModel.Cast _ZeroSpreadedTermStructure.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_referenceDate", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((ZeroSpreadedTermStructureModel.Cast _ZeroSpreadedTermStructure.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_settlementDays", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder (current : ICell) = ((ZeroSpreadedTermStructureModel.Cast _ZeroSpreadedTermStructure.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        ([<ExcelArgument(Name="spread",Description = "Quote")>] 
         spread : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded or empty")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency or empty")>] 
         freq : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let _spread = Helper.toHandle<Quote> spread "spread" 
                let _comp = Helper.toDefault<Compounding> comp "comp" Compounding.Continuous
                let _freq = Helper.toDefault<Frequency> freq "freq" Frequency.NoFrequency
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.ZeroSpreadedTermStructure 
                                                            _h.cell 
                                                            _spread.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _dc.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroSpreadedTermStructure>) l

                let source () = Helper.sourceFold "Fun.ZeroSpreadedTermStructure" 
                                               [| _h.source
                                               ;  _spread.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _dc.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                ;  _spread.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _dc.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_Range", Description="Create a range of ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroSpreadedTermStructure> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ZeroSpreadedTermStructure> (c)) :> ICell
                let format (i : Cephei.Cell.List<ZeroSpreadedTermStructure>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ZeroSpreadedTermStructure>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
