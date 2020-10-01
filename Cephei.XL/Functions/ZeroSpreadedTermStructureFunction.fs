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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_calendar", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "Reference to ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((_ZeroSpreadedTermStructure.cell :?> ZeroSpreadedTermStructureModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".Calendar") 
                                               [| _ZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_dayCounter", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "Reference to ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((_ZeroSpreadedTermStructure.cell :?> ZeroSpreadedTermStructureModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".DayCounter") 
                                               [| _ZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_maxDate", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "Reference to ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((_ZeroSpreadedTermStructure.cell :?> ZeroSpreadedTermStructureModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".MaxDate") 
                                               [| _ZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_maxTime", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "Reference to ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((_ZeroSpreadedTermStructure.cell :?> ZeroSpreadedTermStructureModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".MaxTime") 
                                               [| _ZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_referenceDate", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "Reference to ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((_ZeroSpreadedTermStructure.cell :?> ZeroSpreadedTermStructureModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".ReferenceDate") 
                                               [| _ZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_settlementDays", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroSpreadedTermStructure",Description = "Reference to ZeroSpreadedTermStructure")>] 
         zerospreadedtermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroSpreadedTermStructure = Helper.toCell<ZeroSpreadedTermStructure> zerospreadedtermstructure "ZeroSpreadedTermStructure"  
                let builder () = withMnemonic mnemonic ((_ZeroSpreadedTermStructure.cell :?> ZeroSpreadedTermStructureModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroSpreadedTermStructure.source + ".SettlementDays") 
                                               [| _ZeroSpreadedTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroSpreadedTermStructure.cell
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
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure", Description="Create a ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let _spread = Helper.toHandle<Quote> spread "spread" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder () = withMnemonic mnemonic (Fun.ZeroSpreadedTermStructure 
                                                            _h.cell 
                                                            _spread.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroSpreadedTermStructure>) l

                let source = Helper.sourceFold "Fun.ZeroSpreadedTermStructure" 
                                               [| _h.source
                                               ;  _spread.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                ;  _spread.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroSpreadedTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ZeroSpreadedTermStructure_Range", Description="Create a range of ZeroSpreadedTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroSpreadedTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ZeroSpreadedTermStructure")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroSpreadedTermStructure> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ZeroSpreadedTermStructure>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ZeroSpreadedTermStructure>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ZeroSpreadedTermStructure>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
