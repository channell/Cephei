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
module AverageBMALegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMALeg", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _index = Helper.toCell<BMAIndex> index "index" 
                let builder () = withMnemonic mnemonic (Fun.AverageBMALeg 
                                                            _schedule.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AverageBMALeg>) l

                let source = Helper.sourceFold "Fun.AverageBMALeg" 
                                               [| _schedule.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _index.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMALeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMALeg_value", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMALeg",Description = "Reference to AverageBMALeg")>] 
         averagebmaleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMALeg = Helper.toCell<AverageBMALeg> averagebmaleg "AverageBMALeg"  
                let builder () = withMnemonic mnemonic ((_AverageBMALeg.cell :?> AverageBMALegModel).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AverageBMALeg.source + ".Value") 
                                               [| _AverageBMALeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMALeg.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMALeg_withGearings", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMALeg",Description = "Reference to AverageBMALeg")>] 
         averagebmaleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMALeg = Helper.toCell<AverageBMALeg> averagebmaleg "AverageBMALeg"  
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let builder () = withMnemonic mnemonic ((_AverageBMALeg.cell :?> AverageBMALegModel).WithGearings
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AverageBMALeg>) l

                let source = Helper.sourceFold (_AverageBMALeg.source + ".WithGearings") 
                                               [| _AverageBMALeg.source
                                               ;  _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMALeg.cell
                                ;  _gearings.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMALeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMALeg_withGearings1", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMALeg",Description = "Reference to AverageBMALeg")>] 
         averagebmaleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMALeg = Helper.toCell<AverageBMALeg> averagebmaleg "AverageBMALeg"  
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let builder () = withMnemonic mnemonic ((_AverageBMALeg.cell :?> AverageBMALegModel).WithGearings1
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AverageBMALeg>) l

                let source = Helper.sourceFold (_AverageBMALeg.source + ".WithGearings1") 
                                               [| _AverageBMALeg.source
                                               ;  _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMALeg.cell
                                ;  _gearing.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMALeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMALeg_withPaymentDayCounter", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMALeg",Description = "Reference to AverageBMALeg")>] 
         averagebmaleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMALeg = Helper.toCell<AverageBMALeg> averagebmaleg "AverageBMALeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic ((_AverageBMALeg.cell :?> AverageBMALegModel).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AverageBMALeg>) l

                let source = Helper.sourceFold (_AverageBMALeg.source + ".WithPaymentDayCounter") 
                                               [| _AverageBMALeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMALeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMALeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMALeg_withSpreads1", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMALeg",Description = "Reference to AverageBMALeg")>] 
         averagebmaleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMALeg = Helper.toCell<AverageBMALeg> averagebmaleg "AverageBMALeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder () = withMnemonic mnemonic ((_AverageBMALeg.cell :?> AverageBMALegModel).WithSpreads1
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AverageBMALeg>) l

                let source = Helper.sourceFold (_AverageBMALeg.source + ".WithSpreads1") 
                                               [| _AverageBMALeg.source
                                               ;  _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMALeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMALeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMALeg_withSpreads", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMALeg",Description = "Reference to AverageBMALeg")>] 
         averagebmaleg : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMALeg = Helper.toCell<AverageBMALeg> averagebmaleg "AverageBMALeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder () = withMnemonic mnemonic ((_AverageBMALeg.cell :?> AverageBMALegModel).WithSpreads
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AverageBMALeg>) l

                let source = Helper.sourceFold (_AverageBMALeg.source + ".WithSpreads") 
                                               [| _AverageBMALeg.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMALeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMALeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMALeg_withNotionals1", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMALeg",Description = "Reference to AverageBMALeg")>] 
         averagebmaleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMALeg = Helper.toCell<AverageBMALeg> averagebmaleg "AverageBMALeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder () = withMnemonic mnemonic ((_AverageBMALeg.cell :?> AverageBMALegModel).WithNotionals1
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_AverageBMALeg.source + ".WithNotionals1") 
                                               [| _AverageBMALeg.source
                                               ;  _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMALeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMALeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        initializers
    *)
    [<ExcelFunction(Name="_AverageBMALeg_withNotionals", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMALeg",Description = "Reference to AverageBMALeg")>] 
         averagebmaleg : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMALeg = Helper.toCell<AverageBMALeg> averagebmaleg "AverageBMALeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder () = withMnemonic mnemonic ((_AverageBMALeg.cell :?> AverageBMALegModel).WithNotionals
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_AverageBMALeg.source + ".WithNotionals") 
                                               [| _AverageBMALeg.source
                                               ;  _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMALeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMALeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMALeg_withPaymentAdjustment", Description="Create a AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMALeg",Description = "Reference to AverageBMALeg")>] 
         averagebmaleg : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMALeg = Helper.toCell<AverageBMALeg> averagebmaleg "AverageBMALeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder () = withMnemonic mnemonic ((_AverageBMALeg.cell :?> AverageBMALegModel).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RateLegBase>) l

                let source = Helper.sourceFold (_AverageBMALeg.source + ".WithPaymentAdjustment") 
                                               [| _AverageBMALeg.source
                                               ;  _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMALeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMALeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_AverageBMALeg_Range", Description="Create a range of AverageBMALeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMALeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AverageBMALeg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AverageBMALeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AverageBMALeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AverageBMALeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AverageBMALeg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
