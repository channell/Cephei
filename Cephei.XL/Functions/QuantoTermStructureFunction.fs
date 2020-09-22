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
  Quanto term structure for modelling quanto effect in option pricing.  This term structure will remain linked to the original structures, i.e., any changes in the latters will be reflected in this structure as well.
  </summary> *)
[<AutoSerializable(true)>]
module QuantoTermStructureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_QuantoTermStructure_calendar", Description="Create a QuantoTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let QuantoTermStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="QuantoTermStructure",Description = "Reference to QuantoTermStructure")>] 
         quantotermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _QuantoTermStructure = Helper.toCell<QuantoTermStructure> quantotermstructure "QuantoTermStructure" true 
                let builder () = withMnemonic mnemonic ((_QuantoTermStructure.cell :?> QuantoTermStructureModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_QuantoTermStructure.source + ".Calendar") 
                                               [| _QuantoTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _QuantoTermStructure.cell
                                |]
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
    [<ExcelFunction(Name="_QuantoTermStructure_dayCounter", Description="Create a QuantoTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let QuantoTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="QuantoTermStructure",Description = "Reference to QuantoTermStructure")>] 
         quantotermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _QuantoTermStructure = Helper.toCell<QuantoTermStructure> quantotermstructure "QuantoTermStructure" true 
                let builder () = withMnemonic mnemonic ((_QuantoTermStructure.cell :?> QuantoTermStructureModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_QuantoTermStructure.source + ".DayCounter") 
                                               [| _QuantoTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _QuantoTermStructure.cell
                                |]
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
    [<ExcelFunction(Name="_QuantoTermStructure_maxDate", Description="Create a QuantoTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let QuantoTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="QuantoTermStructure",Description = "Reference to QuantoTermStructure")>] 
         quantotermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _QuantoTermStructure = Helper.toCell<QuantoTermStructure> quantotermstructure "QuantoTermStructure" true 
                let builder () = withMnemonic mnemonic ((_QuantoTermStructure.cell :?> QuantoTermStructureModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_QuantoTermStructure.source + ".MaxDate") 
                                               [| _QuantoTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _QuantoTermStructure.cell
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
    [<ExcelFunction(Name="_QuantoTermStructure", Description="Create a QuantoTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let QuantoTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="underlyingDividendTS",Description = "Reference to underlyingDividendTS")>] 
         underlyingDividendTS : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "Reference to riskFreeTS")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="foreignRiskFreeTS",Description = "Reference to foreignRiskFreeTS")>] 
         foreignRiskFreeTS : obj)
        ([<ExcelArgument(Name="underlyingBlackVolTS",Description = "Reference to underlyingBlackVolTS")>] 
         underlyingBlackVolTS : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="exchRateBlackVolTS",Description = "Reference to exchRateBlackVolTS")>] 
         exchRateBlackVolTS : obj)
        ([<ExcelArgument(Name="exchRateATMlevel",Description = "Reference to exchRateATMlevel")>] 
         exchRateATMlevel : obj)
        ([<ExcelArgument(Name="underlyingExchRateCorrelation",Description = "Reference to underlyingExchRateCorrelation")>] 
         underlyingExchRateCorrelation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _underlyingDividendTS = Helper.toHandle<YieldTermStructure> underlyingDividendTS "underlyingDividendTS" 
                let _riskFreeTS = Helper.toHandle<YieldTermStructure> riskFreeTS "riskFreeTS" 
                let _foreignRiskFreeTS = Helper.toHandle<YieldTermStructure> foreignRiskFreeTS "foreignRiskFreeTS" 
                let _underlyingBlackVolTS = Helper.toHandle<BlackVolTermStructure> underlyingBlackVolTS "underlyingBlackVolTS" 
                let _strike = Helper.toCell<double> strike "strike" true
                let _exchRateBlackVolTS = Helper.toHandle<BlackVolTermStructure> exchRateBlackVolTS "exchRateBlackVolTS" 
                let _exchRateATMlevel = Helper.toCell<double> exchRateATMlevel "exchRateATMlevel" true
                let _underlyingExchRateCorrelation = Helper.toCell<double> underlyingExchRateCorrelation "underlyingExchRateCorrelation" true
                let builder () = withMnemonic mnemonic (Fun.QuantoTermStructure 
                                                            _underlyingDividendTS.cell 
                                                            _riskFreeTS.cell 
                                                            _foreignRiskFreeTS.cell 
                                                            _underlyingBlackVolTS.cell 
                                                            _strike.cell 
                                                            _exchRateBlackVolTS.cell 
                                                            _exchRateATMlevel.cell 
                                                            _underlyingExchRateCorrelation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<QuantoTermStructure>) l

                let source = Helper.sourceFold "Fun.QuantoTermStructure" 
                                               [| _underlyingDividendTS.source
                                               ;  _riskFreeTS.source
                                               ;  _foreignRiskFreeTS.source
                                               ;  _underlyingBlackVolTS.source
                                               ;  _strike.source
                                               ;  _exchRateBlackVolTS.source
                                               ;  _exchRateATMlevel.source
                                               ;  _underlyingExchRateCorrelation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _underlyingDividendTS.cell
                                ;  _riskFreeTS.cell
                                ;  _foreignRiskFreeTS.cell
                                ;  _underlyingBlackVolTS.cell
                                ;  _strike.cell
                                ;  _exchRateBlackVolTS.cell
                                ;  _exchRateATMlevel.cell
                                ;  _underlyingExchRateCorrelation.cell
                                |]
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
    [<ExcelFunction(Name="_QuantoTermStructure_referenceDate", Description="Create a QuantoTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let QuantoTermStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="QuantoTermStructure",Description = "Reference to QuantoTermStructure")>] 
         quantotermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _QuantoTermStructure = Helper.toCell<QuantoTermStructure> quantotermstructure "QuantoTermStructure" true 
                let builder () = withMnemonic mnemonic ((_QuantoTermStructure.cell :?> QuantoTermStructureModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_QuantoTermStructure.source + ".ReferenceDate") 
                                               [| _QuantoTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _QuantoTermStructure.cell
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
    [<ExcelFunction(Name="_QuantoTermStructure_settlementDays", Description="Create a QuantoTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let QuantoTermStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="QuantoTermStructure",Description = "Reference to QuantoTermStructure")>] 
         quantotermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _QuantoTermStructure = Helper.toCell<QuantoTermStructure> quantotermstructure "QuantoTermStructure" true 
                let builder () = withMnemonic mnemonic ((_QuantoTermStructure.cell :?> QuantoTermStructureModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_QuantoTermStructure.source + ".SettlementDays") 
                                               [| _QuantoTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _QuantoTermStructure.cell
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
    [<ExcelFunction(Name="_QuantoTermStructure_Range", Description="Create a range of QuantoTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let QuantoTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the QuantoTermStructure")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<QuantoTermStructure> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<QuantoTermStructure>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<QuantoTermStructure>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<QuantoTermStructure>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
