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
  helper class building a Bullet Principal leg
  </summary> *)
[<AutoSerializable(true)>]
module BulletPricipalLegFunction =

    (*
        constructor
    *)
    [<ExcelFunction(Name="_BulletPricipalLeg", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BulletPricipalLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let builder (current : ICell) = (Fun.BulletPricipalLeg 
                                                            _schedule.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BulletPricipalLeg>) l

                let source () = Helper.sourceFold "Fun.BulletPricipalLeg" 
                                               [| _schedule.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BulletPricipalLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        creator
    *)
    [<ExcelFunction(Name="_BulletPricipalLeg_value", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BulletPricipalLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg"  
                let builder (current : ICell) = ((BulletPricipalLegModel.Cast _BulletPricipalLeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<CashFlow>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_BulletPricipalLeg.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BulletPricipalLeg_withNotionals", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "double range")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder (current : ICell) = ((BulletPricipalLegModel.Cast _BulletPricipalLeg.cell).WithNotionals
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source () = Helper.sourceFold (_BulletPricipalLeg.source + ".WithNotionals") 

                                               [| _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BulletPricipalLeg> format
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
    [<ExcelFunction(Name="_BulletPricipalLeg_withNotionals1", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder (current : ICell) = ((BulletPricipalLegModel.Cast _BulletPricipalLeg.cell).WithNotionals1
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source () = Helper.sourceFold (_BulletPricipalLeg.source + ".WithNotionals1") 

                                               [| _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BulletPricipalLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BulletPricipalLeg_withPaymentAdjustment", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder (current : ICell) = ((BulletPricipalLegModel.Cast _BulletPricipalLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source () = Helper.sourceFold (_BulletPricipalLeg.source + ".WithPaymentAdjustment") 

                                               [| _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BulletPricipalLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BulletPricipalLeg_withPaymentDayCounter", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = ((BulletPricipalLegModel.Cast _BulletPricipalLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source () = Helper.sourceFold (_BulletPricipalLeg.source + ".WithPaymentDayCounter") 

                                               [| _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BulletPricipalLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BulletPricipalLeg_withSign", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withSign
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="sign",Description = "int")>] 
         sign : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg"  
                let _sign = Helper.toCell<int> sign "sign" 
                let builder (current : ICell) = ((BulletPricipalLegModel.Cast _BulletPricipalLeg.cell).WithSign
                                                            _sign.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source () = Helper.sourceFold (_BulletPricipalLeg.source + ".WithSign") 

                                               [| _sign.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _sign.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BulletPricipalLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BulletPricipalLeg_Range", Description="Create a range of BulletPricipalLeg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BulletPricipalLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BulletPricipalLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BulletPricipalLeg> (c)) :> ICell
                let format (i : Cephei.Cell.List<BulletPricipalLeg>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BulletPricipalLeg>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
