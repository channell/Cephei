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
  Discrete-averaging Asian option   instruments
  </summary> *)
[<AutoSerializable(true)>]
module DiscreteAveragingAsianOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="averageType",Description = "Reference to averageType")>] 
         averageType : obj)
        ([<ExcelArgument(Name="runningAccumulator",Description = "Reference to runningAccumulator")>] 
         runningAccumulator : obj)
        ([<ExcelArgument(Name="pastFixings",Description = "Reference to pastFixings")>] 
         pastFixings : obj)
        ([<ExcelArgument(Name="fixingDates",Description = "Reference to fixingDates")>] 
         fixingDates : obj)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="exercise",Description = "Reference to exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _averageType = Helper.toCell<Average.Type> averageType "averageType" 
                let _runningAccumulator = Helper.toNullable<double> runningAccumulator "runningAccumulator"
                let _pastFixings = Helper.toNullable<int> pastFixings "pastFixings"
                let _fixingDates = Helper.toCell<Generic.List<Date>> fixingDates "fixingDates" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.DiscreteAveragingAsianOption 
                                                            _averageType.cell 
                                                            _runningAccumulator.cell 
                                                            _pastFixings.cell 
                                                            _fixingDates.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscreteAveragingAsianOption>) l

                let source = Helper.sourceFold "Fun.DiscreteAveragingAsianOption" 
                                               [| _averageType.source
                                               ;  _runningAccumulator.source
                                               ;  _pastFixings.source
                                               ;  _fixingDates.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _averageType.cell
                                ;  _runningAccumulator.cell
                                ;  _pastFixings.cell
                                ;  _fixingDates.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscreteAveragingAsianOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_delta", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".Delta") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_deltaForward", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".DeltaForward") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_dividendRho", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".DividendRho") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_elasticity", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".Elasticity") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_gamma", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".Gamma") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_isExpired", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".IsExpired") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_itmCashProbability", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".ItmCashProbability") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_rho", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".Rho") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_strikeSensitivity", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".StrikeSensitivity") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_theta", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".Theta") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_thetaPerDay", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".ThetaPerDay") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_vega", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".Vega") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_exercise", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".Exercise") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscreteAveragingAsianOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_payoff", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".Payoff") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscreteAveragingAsianOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_CASH", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".CASH") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_errorEstimate", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".ErrorEstimate") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_NPV", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".NPV") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_result", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".Result") 
                                               [| _DiscreteAveragingAsianOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_setPricingEngine", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : DiscreteAveragingAsianOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".SetPricingEngine") 
                                               [| _DiscreteAveragingAsianOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_valuationDate", Description="Create a DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteAveragingAsianOption",Description = "Reference to DiscreteAveragingAsianOption")>] 
         discreteaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteAveragingAsianOption = Helper.toCell<DiscreteAveragingAsianOption> discreteaveragingasianoption "DiscreteAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((DiscreteAveragingAsianOptionModel.Cast _DiscreteAveragingAsianOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DiscreteAveragingAsianOption.source + ".ValuationDate") 
                                               [| _DiscreteAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_DiscreteAveragingAsianOption_Range", Description="Create a range of DiscreteAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteAveragingAsianOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscreteAveragingAsianOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscreteAveragingAsianOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscreteAveragingAsianOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscreteAveragingAsianOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DiscreteAveragingAsianOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
