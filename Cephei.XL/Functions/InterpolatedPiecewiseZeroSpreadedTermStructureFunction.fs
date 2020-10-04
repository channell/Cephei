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
(*!! generic 
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module InterpolatedPiecewiseZeroSpreadedTermStructureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedPiecewiseZeroSpreadedTermStructure_calendar", Description="Create a InterpolatedPiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedPiecewiseZeroSpreadedTermStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedPiecewiseZeroSpreadedTermStructure",Description = "Reference to InterpolatedPiecewiseZeroSpreadedTermStructure")>] 
         interpolatedpiecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedPiecewiseZeroSpreadedTermStructure = Helper.toCell<InterpolatedPiecewiseZeroSpreadedTermStructure> interpolatedpiecewisezerospreadedtermstructure "InterpolatedPiecewiseZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((InterpolatedPiecewiseZeroSpreadedTermStructureModel.Cast _InterpolatedPiecewiseZeroSpreadedTermStructure.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_InterpolatedPiecewiseZeroSpreadedTermStructure.source + ".Calendar") 
                                               [| _InterpolatedPiecewiseZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedPiecewiseZeroSpreadedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedPiecewiseZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedPiecewiseZeroSpreadedTermStructure_dayCounter", Description="Create a InterpolatedPiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedPiecewiseZeroSpreadedTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedPiecewiseZeroSpreadedTermStructure",Description = "Reference to InterpolatedPiecewiseZeroSpreadedTermStructure")>] 
         interpolatedpiecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedPiecewiseZeroSpreadedTermStructure = Helper.toCell<InterpolatedPiecewiseZeroSpreadedTermStructure> interpolatedpiecewisezerospreadedtermstructure "InterpolatedPiecewiseZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((InterpolatedPiecewiseZeroSpreadedTermStructureModel.Cast _InterpolatedPiecewiseZeroSpreadedTermStructure.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_InterpolatedPiecewiseZeroSpreadedTermStructure.source + ".DayCounter") 
                                               [| _InterpolatedPiecewiseZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedPiecewiseZeroSpreadedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedPiecewiseZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedPiecewiseZeroSpreadedTermStructure", Description="Create a InterpolatedPiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedPiecewiseZeroSpreadedTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="factory",Description = "Reference to factory")>] 
         factory : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let _spreads = Helper.toCell<Generic.List<Handle<Quote>>> spreads "spreads" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _compounding = Helper.toDefault<Compounding> compounding "compounding" Compounding.Continuous
                let _frequency = Helper.toDefault<Frequency> frequency "frequency" Frequency.NoFrequency
                let _dc = Helper.toDefault<DayCounter> dc "dc" default(DayCounter)
                let _factory = Helper.toDefault<'Interpolator> factory "factory" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedPiecewiseZeroSpreadedTermStructure 
                                                            _h.cell 
                                                            _spreads.cell 
                                                            _dates.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _dc.cell 
                                                            _factory.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedPiecewiseZeroSpreadedTermStructure>) l

                let source = Helper.sourceFold "Fun.InterpolatedPiecewiseZeroSpreadedTermStructure" 
                                               [| _h.source
                                               ;  _spreads.source
                                               ;  _dates.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _dc.source
                                               ;  _factory.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                ;  _spreads.cell
                                ;  _dates.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _dc.cell
                                ;  _factory.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedPiecewiseZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedPiecewiseZeroSpreadedTermStructure_maxDate", Description="Create a InterpolatedPiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedPiecewiseZeroSpreadedTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedPiecewiseZeroSpreadedTermStructure",Description = "Reference to InterpolatedPiecewiseZeroSpreadedTermStructure")>] 
         interpolatedpiecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedPiecewiseZeroSpreadedTermStructure = Helper.toCell<InterpolatedPiecewiseZeroSpreadedTermStructure> interpolatedpiecewisezerospreadedtermstructure "InterpolatedPiecewiseZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((InterpolatedPiecewiseZeroSpreadedTermStructureModel.Cast _InterpolatedPiecewiseZeroSpreadedTermStructure.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedPiecewiseZeroSpreadedTermStructure.source + ".MaxDate") 
                                               [| _InterpolatedPiecewiseZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedPiecewiseZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_InterpolatedPiecewiseZeroSpreadedTermStructure_referenceDate", Description="Create a InterpolatedPiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedPiecewiseZeroSpreadedTermStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedPiecewiseZeroSpreadedTermStructure",Description = "Reference to InterpolatedPiecewiseZeroSpreadedTermStructure")>] 
         interpolatedpiecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedPiecewiseZeroSpreadedTermStructure = Helper.toCell<InterpolatedPiecewiseZeroSpreadedTermStructure> interpolatedpiecewisezerospreadedtermstructure "InterpolatedPiecewiseZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((InterpolatedPiecewiseZeroSpreadedTermStructureModel.Cast _InterpolatedPiecewiseZeroSpreadedTermStructure.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedPiecewiseZeroSpreadedTermStructure.source + ".ReferenceDate") 
                                               [| _InterpolatedPiecewiseZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedPiecewiseZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_InterpolatedPiecewiseZeroSpreadedTermStructure_settlementDays", Description="Create a InterpolatedPiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedPiecewiseZeroSpreadedTermStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedPiecewiseZeroSpreadedTermStructure",Description = "Reference to InterpolatedPiecewiseZeroSpreadedTermStructure")>] 
         interpolatedpiecewisezerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedPiecewiseZeroSpreadedTermStructure = Helper.toCell<InterpolatedPiecewiseZeroSpreadedTermStructure> interpolatedpiecewisezerospreadedtermstructure "InterpolatedPiecewiseZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((InterpolatedPiecewiseZeroSpreadedTermStructureModel.Cast _InterpolatedPiecewiseZeroSpreadedTermStructure.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_InterpolatedPiecewiseZeroSpreadedTermStructure.source + ".SettlementDays") 
                                               [| _InterpolatedPiecewiseZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedPiecewiseZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_InterpolatedPiecewiseZeroSpreadedTermStructure_Range", Description="Create a range of InterpolatedPiecewiseZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedPiecewiseZeroSpreadedTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InterpolatedPiecewiseZeroSpreadedTermStructure")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedPiecewiseZeroSpreadedTermStructure> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InterpolatedPiecewiseZeroSpreadedTermStructure>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InterpolatedPiecewiseZeroSpreadedTermStructure>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InterpolatedPiecewiseZeroSpreadedTermStructure>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
