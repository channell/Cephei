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
  helper class building a sequence of overnight coupons
  </summary> *)
[<AutoSerializable(true)>]
module OvernightLegFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_OvernightLeg", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "OvernightLeg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="overnightIndex",Description = "OvernightIndex")>] 
         overnightIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _overnightIndex = Helper.toCell<OvernightIndex> overnightIndex "overnightIndex" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.OvernightLeg 
                                                            _schedule.cell 
                                                            _overnightIndex.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightLeg>) l

                let source () = Helper.sourceFold "Fun.OvernightLeg" 
                                               [| _schedule.source
                                               ;  _overnightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _overnightIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightLeg_value", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightLeg",Description = "OvernightLeg")>] 
         overnightleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightLeg = Helper.toCell<OvernightLeg> overnightleg "OvernightLeg"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightLegModel.Cast _OvernightLeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_OvernightLeg.source + ".Value") 
                                               [| _OvernightLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_OvernightLeg_withGearings", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_withGearings
        ([<ExcelArgument(Name="Mnemonic",Description = "OvernightLeg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightLeg",Description = "OvernightLeg")>] 
         overnightleg : obj)
        ([<ExcelArgument(Name="gearings",Description = "double")>] 
         gearings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightLeg = Helper.toCell<OvernightLeg> overnightleg "OvernightLeg"  
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightLegModel.Cast _OvernightLeg.cell).WithGearings
                                                            _gearings.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightLeg>) l

                let source () = Helper.sourceFold (_OvernightLeg.source + ".WithGearings") 
                                               [| _OvernightLeg.source
                                               ;  _gearings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightLeg.cell
                                ;  _gearings.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightLeg_withGearings1", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_withGearings1
        ([<ExcelArgument(Name="Mnemonic",Description = "OvernightLeg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightLeg",Description = "OvernightLeg")>] 
         overnightleg : obj)
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightLeg = Helper.toCell<OvernightLeg> overnightleg "OvernightLeg"  
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightLegModel.Cast _OvernightLeg.cell).WithGearings1
                                                            _gearing.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightLeg>) l

                let source () = Helper.sourceFold (_OvernightLeg.source + ".WithGearings1") 
                                               [| _OvernightLeg.source
                                               ;  _gearing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightLeg.cell
                                ;  _gearing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightLeg_withNotionals", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "OvernightLeg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightLeg",Description = "OvernightLeg")>] 
         overnightleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightLeg = Helper.toCell<OvernightLeg> overnightleg "OvernightLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightLegModel.Cast _OvernightLeg.cell).WithNotionals
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightLeg>) l

                let source () = Helper.sourceFold (_OvernightLeg.source + ".WithNotionals") 
                                               [| _OvernightLeg.source
                                               ;  _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightLeg_withNotionals1", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "OvernightLeg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightLeg",Description = "OvernightLeg")>] 
         overnightleg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightLeg = Helper.toCell<OvernightLeg> overnightleg "OvernightLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightLegModel.Cast _OvernightLeg.cell).WithNotionals1
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightLeg>) l

                let source () = Helper.sourceFold (_OvernightLeg.source + ".WithNotionals1") 
                                               [| _OvernightLeg.source
                                               ;  _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightLeg_withPaymentAdjustment", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "OvernightLeg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightLeg",Description = "OvernightLeg")>] 
         overnightleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightLeg = Helper.toCell<OvernightLeg> overnightleg "OvernightLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightLegModel.Cast _OvernightLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightLeg>) l

                let source () = Helper.sourceFold (_OvernightLeg.source + ".WithPaymentAdjustment") 
                                               [| _OvernightLeg.source
                                               ;  _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightLeg_withPaymentDayCounter", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "OvernightLeg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightLeg",Description = "OvernightLeg")>] 
         overnightleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightLeg = Helper.toCell<OvernightLeg> overnightleg "OvernightLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightLegModel.Cast _OvernightLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightLeg>) l

                let source () = Helper.sourceFold (_OvernightLeg.source + ".WithPaymentDayCounter") 
                                               [| _OvernightLeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightLeg_withSpreads1", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_withSpreads1
        ([<ExcelArgument(Name="Mnemonic",Description = "OvernightLeg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightLeg",Description = "OvernightLeg")>] 
         overnightleg : obj)
        ([<ExcelArgument(Name="spreads",Description = "double")>] 
         spreads : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightLeg = Helper.toCell<OvernightLeg> overnightleg "OvernightLeg"  
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightLegModel.Cast _OvernightLeg.cell).WithSpreads1
                                                            _spreads.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightLeg>) l

                let source () = Helper.sourceFold (_OvernightLeg.source + ".WithSpreads1") 
                                               [| _OvernightLeg.source
                                               ;  _spreads.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightLeg.cell
                                ;  _spreads.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightLeg_withSpreads", Description="Create a OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_withSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "OvernightLeg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightLeg",Description = "OvernightLeg")>] 
         overnightleg : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightLeg = Helper.toCell<OvernightLeg> overnightleg "OvernightLeg"  
                let _spread = Helper.toCell<double> spread "spread" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightLegModel.Cast _OvernightLeg.cell).WithSpreads
                                                            _spread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightLeg>) l

                let source () = Helper.sourceFold (_OvernightLeg.source + ".WithSpreads") 
                                               [| _OvernightLeg.source
                                               ;  _spread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightLeg.cell
                                ;  _spread.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_OvernightLeg_Range", Description="Create a range of OvernightLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OvernightLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<OvernightLeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<OvernightLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<OvernightLeg>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
