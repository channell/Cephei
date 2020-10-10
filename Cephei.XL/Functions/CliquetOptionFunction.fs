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
  A cliquet option, also known as Ratchet option, is a series of forward-starting (a.k.a. deferred strike) options where the strike for each forward start option is set equal to a fixed percentage of the spot price at the beginning of each period.  - add local/global caps/floors - add accrued coupon and last fixing  instruments
  </summary> *)
[<AutoSerializable(true)>]
module CliquetOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CliquetOption", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="resetDates",Description = "Reference to resetDates")>] 
         resetDates : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payoff = Helper.toCell<PercentageStrikePayoff> payoff "payoff" 
                let _maturity = Helper.toCell<EuropeanExercise> maturity "maturity" 
                let _resetDates = Helper.toCell<Generic.List<Date>> resetDates "resetDates" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CliquetOption 
                                                            _payoff.cell 
                                                            _maturity.cell 
                                                            _resetDates.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CliquetOption>) l

                let source () = Helper.sourceFold "Fun.CliquetOption" 
                                               [| _payoff.source
                                               ;  _maturity.source
                                               ;  _resetDates.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payoff.cell
                                ;  _maturity.cell
                                ;  _resetDates.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CliquetOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CliquetOption_delta", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".Delta") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_deltaForward", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".DeltaForward") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_dividendRho", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".DividendRho") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_elasticity", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".Elasticity") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_gamma", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".Gamma") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_isExpired", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".IsExpired") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_itmCashProbability", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".ItmCashProbability") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_rho", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".Rho") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_strikeSensitivity", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".StrikeSensitivity") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_theta", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".Theta") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_thetaPerDay", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".ThetaPerDay") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_vega", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".Vega") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_exercise", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_CliquetOption.source + ".Exercise") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CliquetOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CliquetOption_payoff", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_CliquetOption.source + ".Payoff") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CliquetOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CliquetOption_CASH", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".CASH") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_errorEstimate", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".ErrorEstimate") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_NPV", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".NPV") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_CliquetOption_result", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".Result") 
                                               [| _CliquetOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_CliquetOption_setPricingEngine", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CliquetOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".SetPricingEngine") 
                                               [| _CliquetOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_CliquetOption_valuationDate", Description="Create a CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CliquetOption",Description = "Reference to CliquetOption")>] 
         cliquetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CliquetOption = Helper.toCell<CliquetOption> cliquetoption "CliquetOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((CliquetOptionModel.Cast _CliquetOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CliquetOption.source + ".ValuationDate") 
                                               [| _CliquetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CliquetOption.cell
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
    [<ExcelFunction(Name="_CliquetOption_Range", Description="Create a range of CliquetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CliquetOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CliquetOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CliquetOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CliquetOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CliquetOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CliquetOption>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
