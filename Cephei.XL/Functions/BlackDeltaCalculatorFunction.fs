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
  Class includes many operations needed for different applications in FX markets, which has special quoation mechanisms, since every price can be expressed in both numeraires.
  </summary> *)
[<AutoSerializable(true)>]
module BlackDeltaCalculatorFunction =

    (*
        The following function can be calculated without an explicit strike
    *)
    [<ExcelFunction(Name="_BlackDeltaCalculator_atmStrike", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_atmStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaCalculator",Description = "Reference to BlackDeltaCalculator")>] 
         blackdeltacalculator : obj)
        ([<ExcelArgument(Name="atmT",Description = "Reference to atmT")>] 
         atmT : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaCalculator = Helper.toCell<BlackDeltaCalculator> blackdeltacalculator "BlackDeltaCalculator"  
                let _atmT = Helper.toCell<DeltaVolQuote.AtmType> atmT "atmT" 
                let builder () = withMnemonic mnemonic ((BlackDeltaCalculatorModel.Cast _BlackDeltaCalculator.cell).AtmStrike
                                                            _atmT.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackDeltaCalculator.source + ".AtmStrike") 
                                               [| _BlackDeltaCalculator.source
                                               ;  _atmT.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaCalculator.cell
                                ;  _atmT.cell
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
        A parsimonious constructor is chosen, which for example doesn't need a strike. The reason for this is, that we'd like this class to calculate deltas for different strikes many times, e.g. in a numerical routine, which will be the case in the smile setup procedure.
    *)
    [<ExcelFunction(Name="_BlackDeltaCalculator", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ot",Description = "Reference to ot")>] 
         ot : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        ([<ExcelArgument(Name="dDiscount",Description = "Reference to dDiscount")>] 
         dDiscount : obj)
        ([<ExcelArgument(Name="fDiscount",Description = "Reference to fDiscount")>] 
         fDiscount : obj)
        ([<ExcelArgument(Name="stdDev",Description = "Reference to stdDev")>] 
         stdDev : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ot = Helper.toCell<Option.Type> ot "ot" 
                let _dt = Helper.toCell<DeltaVolQuote.DeltaType> dt "dt" 
                let _spot = Helper.toCell<double> spot "spot" 
                let _dDiscount = Helper.toCell<double> dDiscount "dDiscount" 
                let _fDiscount = Helper.toCell<double> fDiscount "fDiscount" 
                let _stdDev = Helper.toCell<double> stdDev "stdDev" 
                let builder () = withMnemonic mnemonic (Fun.BlackDeltaCalculator 
                                                            _ot.cell 
                                                            _dt.cell 
                                                            _spot.cell 
                                                            _dDiscount.cell 
                                                            _fDiscount.cell 
                                                            _stdDev.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackDeltaCalculator>) l

                let source = Helper.sourceFold "Fun.BlackDeltaCalculator" 
                                               [| _ot.source
                                               ;  _dt.source
                                               ;  _spot.source
                                               ;  _dDiscount.source
                                               ;  _fDiscount.source
                                               ;  _stdDev.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ot.cell
                                ;  _dt.cell
                                ;  _spot.cell
                                ;  _dDiscount.cell
                                ;  _fDiscount.cell
                                ;  _stdDev.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackDeltaCalculator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackDeltaCalculator_cumD1", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_cumD1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaCalculator",Description = "Reference to BlackDeltaCalculator")>] 
         blackdeltacalculator : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaCalculator = Helper.toCell<BlackDeltaCalculator> blackdeltacalculator "BlackDeltaCalculator"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((BlackDeltaCalculatorModel.Cast _BlackDeltaCalculator.cell).CumD1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackDeltaCalculator.source + ".CumD1") 
                                               [| _BlackDeltaCalculator.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaCalculator.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_BlackDeltaCalculator_cumD2", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_cumD2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaCalculator",Description = "Reference to BlackDeltaCalculator")>] 
         blackdeltacalculator : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaCalculator = Helper.toCell<BlackDeltaCalculator> blackdeltacalculator "BlackDeltaCalculator"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((BlackDeltaCalculatorModel.Cast _BlackDeltaCalculator.cell).CumD2
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackDeltaCalculator.source + ".CumD2") 
                                               [| _BlackDeltaCalculator.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaCalculator.cell
                                ;  _strike.cell
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
        Give strike, receive delta according to specified type
    *)
    [<ExcelFunction(Name="_BlackDeltaCalculator_deltaFromStrike", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_deltaFromStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaCalculator",Description = "Reference to BlackDeltaCalculator")>] 
         blackdeltacalculator : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaCalculator = Helper.toCell<BlackDeltaCalculator> blackdeltacalculator "BlackDeltaCalculator"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((BlackDeltaCalculatorModel.Cast _BlackDeltaCalculator.cell).DeltaFromStrike
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackDeltaCalculator.source + ".DeltaFromStrike") 
                                               [| _BlackDeltaCalculator.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaCalculator.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_BlackDeltaCalculator_nD1", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_nD1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaCalculator",Description = "Reference to BlackDeltaCalculator")>] 
         blackdeltacalculator : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaCalculator = Helper.toCell<BlackDeltaCalculator> blackdeltacalculator "BlackDeltaCalculator"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((BlackDeltaCalculatorModel.Cast _BlackDeltaCalculator.cell).ND1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackDeltaCalculator.source + ".ND1") 
                                               [| _BlackDeltaCalculator.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaCalculator.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_BlackDeltaCalculator_nD2", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_nD2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaCalculator",Description = "Reference to BlackDeltaCalculator")>] 
         blackdeltacalculator : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaCalculator = Helper.toCell<BlackDeltaCalculator> blackdeltacalculator "BlackDeltaCalculator"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((BlackDeltaCalculatorModel.Cast _BlackDeltaCalculator.cell).ND2
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackDeltaCalculator.source + ".ND2") 
                                               [| _BlackDeltaCalculator.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaCalculator.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_BlackDeltaCalculator_setDeltaType", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_setDeltaType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaCalculator",Description = "Reference to BlackDeltaCalculator")>] 
         blackdeltacalculator : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaCalculator = Helper.toCell<BlackDeltaCalculator> blackdeltacalculator "BlackDeltaCalculator"  
                let _dt = Helper.toCell<DeltaVolQuote.DeltaType> dt "dt" 
                let builder () = withMnemonic mnemonic ((BlackDeltaCalculatorModel.Cast _BlackDeltaCalculator.cell).SetDeltaType
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : BlackDeltaCalculator) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackDeltaCalculator.source + ".SetDeltaType") 
                                               [| _BlackDeltaCalculator.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaCalculator.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_BlackDeltaCalculator_setOptionType", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_setOptionType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaCalculator",Description = "Reference to BlackDeltaCalculator")>] 
         blackdeltacalculator : obj)
        ([<ExcelArgument(Name="ot",Description = "Reference to ot")>] 
         ot : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaCalculator = Helper.toCell<BlackDeltaCalculator> blackdeltacalculator "BlackDeltaCalculator"  
                let _ot = Helper.toCell<Option.Type> ot "ot" 
                let builder () = withMnemonic mnemonic ((BlackDeltaCalculatorModel.Cast _BlackDeltaCalculator.cell).SetOptionType
                                                            _ot.cell 
                                                       ) :> ICell
                let format (o : BlackDeltaCalculator) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackDeltaCalculator.source + ".SetOptionType") 
                                               [| _BlackDeltaCalculator.source
                                               ;  _ot.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaCalculator.cell
                                ;  _ot.cell
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
        Give delta according to specified type, receive strike
    *)
    [<ExcelFunction(Name="_BlackDeltaCalculator_strikeFromDelta", Description="Create a BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_strikeFromDelta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaCalculator",Description = "Reference to BlackDeltaCalculator")>] 
         blackdeltacalculator : obj)
        ([<ExcelArgument(Name="delta",Description = "Reference to delta")>] 
         delta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaCalculator = Helper.toCell<BlackDeltaCalculator> blackdeltacalculator "BlackDeltaCalculator"  
                let _delta = Helper.toCell<double> delta "delta" 
                let builder () = withMnemonic mnemonic ((BlackDeltaCalculatorModel.Cast _BlackDeltaCalculator.cell).StrikeFromDelta
                                                            _delta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackDeltaCalculator.source + ".StrikeFromDelta") 
                                               [| _BlackDeltaCalculator.source
                                               ;  _delta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaCalculator.cell
                                ;  _delta.cell
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
    [<ExcelFunction(Name="_BlackDeltaCalculator_Range", Description="Create a range of BlackDeltaCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackDeltaCalculator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackDeltaCalculator")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackDeltaCalculator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackDeltaCalculator>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackDeltaCalculator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackDeltaCalculator>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
