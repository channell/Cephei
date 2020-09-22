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
    [<ExcelFunction(Name="_BulletPricipalLeg", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BulletPricipalLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let builder () = withMnemonic mnemonic (Fun.BulletPricipalLeg 
                                                            _schedule.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BulletPricipalLeg>) l

                let source = Helper.sourceFold "Fun.BulletPricipalLeg" 
                                               [| _schedule.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
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
        creator
    *)
    [<ExcelFunction(Name="_BulletPricipalLeg_value", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BulletPricipalLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "Reference to BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg" true 
                let builder () = withMnemonic mnemonic ((_BulletPricipalLeg.cell :?> BulletPricipalLegModel).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BulletPricipalLeg.source + ".Value") 
                                               [| _BulletPricipalLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
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
    [<ExcelFunction(Name="_BulletPricipalLeg_withNotionals", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "Reference to BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg" true 
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" true
                let builder () = withMnemonic mnemonic ((_BulletPricipalLeg.cell :?> BulletPricipalLegModel).WithNotionals
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_BulletPricipalLeg.source + ".WithNotionals") 
                                               [| _BulletPricipalLeg.source
                                               ;  _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _notionals.cell
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
        initializers
    *)
    [<ExcelFunction(Name="_BulletPricipalLeg_withNotionals", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "Reference to BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg" true 
                let _notional = Helper.toCell<double> notional "notional" true
                let builder () = withMnemonic mnemonic ((_BulletPricipalLeg.cell :?> BulletPricipalLegModel).WithNotionals1
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_BulletPricipalLeg.source + ".WithNotionals1") 
                                               [| _BulletPricipalLeg.source
                                               ;  _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _notional.cell
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
    [<ExcelFunction(Name="_BulletPricipalLeg_withPaymentAdjustment", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "Reference to BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg" true 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let builder () = withMnemonic mnemonic ((_BulletPricipalLeg.cell :?> BulletPricipalLegModel).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_BulletPricipalLeg.source + ".WithPaymentAdjustment") 
                                               [| _BulletPricipalLeg.source
                                               ;  _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _convention.cell
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
    [<ExcelFunction(Name="_BulletPricipalLeg_withPaymentDayCounter", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "Reference to BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg" true 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let builder () = withMnemonic mnemonic ((_BulletPricipalLeg.cell :?> BulletPricipalLegModel).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_BulletPricipalLeg.source + ".WithPaymentDayCounter") 
                                               [| _BulletPricipalLeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _dayCounter.cell
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
    [<ExcelFunction(Name="_BulletPricipalLeg_withSign", Description="Create a BulletPricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BulletPricipalLeg_withSign
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BulletPricipalLeg",Description = "Reference to BulletPricipalLeg")>] 
         bulletpricipalleg : obj)
        ([<ExcelArgument(Name="sign",Description = "Reference to sign")>] 
         sign : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BulletPricipalLeg = Helper.toCell<BulletPricipalLeg> bulletpricipalleg "BulletPricipalLeg" true 
                let _sign = Helper.toCell<int> sign "sign" true
                let builder () = withMnemonic mnemonic ((_BulletPricipalLeg.cell :?> BulletPricipalLegModel).WithSign
                                                            _sign.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_BulletPricipalLeg.source + ".WithSign") 
                                               [| _BulletPricipalLeg.source
                                               ;  _sign.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BulletPricipalLeg.cell
                                ;  _sign.cell
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
    [<ExcelFunction(Name="_BulletPricipalLeg_Range", Description="Create a range of BulletPricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BulletPricipalLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BulletPricipalLeg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BulletPricipalLeg> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BulletPricipalLeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BulletPricipalLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BulletPricipalLeg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
