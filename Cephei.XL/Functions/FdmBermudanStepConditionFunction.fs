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
module FdmBermudanStepConditionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmBermudanStepCondition_applyTo", Description="Create a FdmBermudanStepCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBermudanStepCondition_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBermudanStepCondition",Description = "FdmBermudanStepCondition")>] 
         fdmbermudanstepcondition : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBermudanStepCondition = Helper.toModelReference<FdmBermudanStepCondition> fdmbermudanstepcondition "FdmBermudanStepCondition"  
                let _o = Helper.toCell<Object> o "o" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((FdmBermudanStepConditionModel.Cast _FdmBermudanStepCondition.cell).ApplyTo
                                                            _o.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FdmBermudanStepCondition) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmBermudanStepCondition.source + ".ApplyTo") 

                                               [| _o.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBermudanStepCondition.cell
                                ;  _o.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FdmBermudanStepCondition_exerciseTimes", Description="Create a FdmBermudanStepCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBermudanStepCondition_exerciseTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBermudanStepCondition",Description = "FdmBermudanStepCondition")>] 
         fdmbermudanstepcondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBermudanStepCondition = Helper.toModelReference<FdmBermudanStepCondition> fdmbermudanstepcondition "FdmBermudanStepCondition"  
                let builder (current : ICell) = ((FdmBermudanStepConditionModel.Cast _FdmBermudanStepCondition.cell).ExerciseTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FdmBermudanStepCondition.source + ".ExerciseTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmBermudanStepCondition.cell
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
    [<ExcelFunction(Name="_FdmBermudanStepCondition", Description="Create a FdmBermudanStepCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBermudanStepCondition_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="exerciseDate ranges",Description = "Date range")>] 
         exerciseDates : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="calculator",Description = "FdmInnerValueCalculator")>] 
         calculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _exerciseDates = Helper.toCell<Generic.List<Date>> exerciseDates "exerciseDates" 
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let _calculator = Helper.toCell<FdmInnerValueCalculator> calculator "calculator" 
                let builder (current : ICell) = (Fun.FdmBermudanStepCondition 
                                                            _exerciseDates.cell 
                                                            _referenceDate.cell 
                                                            _dayCounter.cell 
                                                            _mesher.cell 
                                                            _calculator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmBermudanStepCondition>) l

                let source () = Helper.sourceFold "Fun.FdmBermudanStepCondition" 
                                               [| _exerciseDates.source
                                               ;  _referenceDate.source
                                               ;  _dayCounter.source
                                               ;  _mesher.source
                                               ;  _calculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _exerciseDates.cell
                                ;  _referenceDate.cell
                                ;  _dayCounter.cell
                                ;  _mesher.cell
                                ;  _calculator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBermudanStepCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdmBermudanStepCondition_Range", Description="Create a range of FdmBermudanStepCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBermudanStepCondition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmBermudanStepCondition> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmBermudanStepCondition> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmBermudanStepCondition>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmBermudanStepCondition>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
