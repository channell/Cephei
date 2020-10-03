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
module PricipalLegFunction =

    (*
        constructor
    *)
    [<ExcelFunction(Name="_PricipalLeg", Description="Create a PricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PricipalLeg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let builder () = withMnemonic mnemonic (Fun.PricipalLeg 
                                                            _schedule.cell 
                                                            _paymentDayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PricipalLeg>) l

                let source = Helper.sourceFold "Fun.PricipalLeg" 
                                               [| _schedule.source
                                               ;  _paymentDayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _paymentDayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PricipalLeg> format
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
    [<ExcelFunction(Name="_PricipalLeg_value", Description="Create a PricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PricipalLeg_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricipalLeg",Description = "Reference to PricipalLeg")>] 
         pricipalleg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricipalLeg = Helper.toCell<PricipalLeg> pricipalleg "PricipalLeg"  
                let builder () = withMnemonic mnemonic ((PricipalLegModel.Cast _PricipalLeg.cell).Value
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PricipalLeg.source + ".Value") 
                                               [| _PricipalLeg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricipalLeg.cell
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
    [<ExcelFunction(Name="_PricipalLeg_withNotionals", Description="Create a PricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PricipalLeg_withNotionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricipalLeg",Description = "Reference to PricipalLeg")>] 
         pricipalleg : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricipalLeg = Helper.toCell<PricipalLeg> pricipalleg "PricipalLeg"  
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let builder () = withMnemonic mnemonic ((PricipalLegModel.Cast _PricipalLeg.cell).WithNotionals
                                                            _notionals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_PricipalLeg.source + ".WithNotionals") 
                                               [| _PricipalLeg.source
                                               ;  _notionals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricipalLeg.cell
                                ;  _notionals.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PricipalLeg> format
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
    [<ExcelFunction(Name="_PricipalLeg_withNotionals1", Description="Create a PricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PricipalLeg_withNotionals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricipalLeg",Description = "Reference to PricipalLeg")>] 
         pricipalleg : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricipalLeg = Helper.toCell<PricipalLeg> pricipalleg "PricipalLeg"  
                let _notional = Helper.toCell<double> notional "notional" 
                let builder () = withMnemonic mnemonic ((PricipalLegModel.Cast _PricipalLeg.cell).WithNotionals1
                                                            _notional.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_PricipalLeg.source + ".WithNotionals1") 
                                               [| _PricipalLeg.source
                                               ;  _notional.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricipalLeg.cell
                                ;  _notional.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PricipalLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PricipalLeg_withPaymentAdjustment", Description="Create a PricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PricipalLeg_withPaymentAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricipalLeg",Description = "Reference to PricipalLeg")>] 
         pricipalleg : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricipalLeg = Helper.toCell<PricipalLeg> pricipalleg "PricipalLeg"  
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let builder () = withMnemonic mnemonic ((PricipalLegModel.Cast _PricipalLeg.cell).WithPaymentAdjustment
                                                            _convention.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_PricipalLeg.source + ".WithPaymentAdjustment") 
                                               [| _PricipalLeg.source
                                               ;  _convention.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricipalLeg.cell
                                ;  _convention.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PricipalLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PricipalLeg_withPaymentDayCounter", Description="Create a PricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PricipalLeg_withPaymentDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricipalLeg",Description = "Reference to PricipalLeg")>] 
         pricipalleg : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricipalLeg = Helper.toCell<PricipalLeg> pricipalleg "PricipalLeg"  
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic ((PricipalLegModel.Cast _PricipalLeg.cell).WithPaymentDayCounter
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_PricipalLeg.source + ".WithPaymentDayCounter") 
                                               [| _PricipalLeg.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricipalLeg.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PricipalLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PricipalLeg_withSign", Description="Create a PricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PricipalLeg_withSign
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PricipalLeg",Description = "Reference to PricipalLeg")>] 
         pricipalleg : obj)
        ([<ExcelArgument(Name="sign",Description = "Reference to sign")>] 
         sign : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PricipalLeg = Helper.toCell<PricipalLeg> pricipalleg "PricipalLeg"  
                let _sign = Helper.toCell<int> sign "sign" 
                let builder () = withMnemonic mnemonic ((PricipalLegModel.Cast _PricipalLeg.cell).WithSign
                                                            _sign.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PrincipalLegBase>) l

                let source = Helper.sourceFold (_PricipalLeg.source + ".WithSign") 
                                               [| _PricipalLeg.source
                                               ;  _sign.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PricipalLeg.cell
                                ;  _sign.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PricipalLeg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PricipalLeg_Range", Description="Create a range of PricipalLeg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PricipalLeg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PricipalLeg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PricipalLeg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PricipalLeg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PricipalLeg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PricipalLeg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
