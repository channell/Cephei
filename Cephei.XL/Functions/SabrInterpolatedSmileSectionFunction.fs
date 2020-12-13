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
module SabrInterpolatedSmileSectionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_alpha", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Alpha
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Alpha") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_atmLevel", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".AtmLevel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_beta", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Beta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Beta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_endCriteria", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".EndCriteria") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_maxError", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_maxError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).MaxError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".MaxError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_maxStrike", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_minStrike", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_nu", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_nu
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Nu
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Nu") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_rho", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_rmsError", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_rmsError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).RmsError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".RmsError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection1", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="hasFloatingStrikes",Description = "bool")>] 
         hasFloatingStrikes : obj)
        ([<ExcelArgument(Name="atmVolatility",Description = "double")>] 
         atmVolatility : obj)
        ([<ExcelArgument(Name="volHandles",Description = "double range")>] 
         volHandles : obj)
        ([<ExcelArgument(Name="alpha",Description = "double")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "double")>] 
         beta : obj)
        ([<ExcelArgument(Name="nu",Description = "double")>] 
         nu : obj)
        ([<ExcelArgument(Name="rho",Description = "double")>] 
         rho : obj)
        ([<ExcelArgument(Name="isAlphaFixed",Description = "bool")>] 
         isAlphaFixed : obj)
        ([<ExcelArgument(Name="isBetaFixed",Description = "bool")>] 
         isBetaFixed : obj)
        ([<ExcelArgument(Name="isNuFixed",Description = "bool")>] 
         isNuFixed : obj)
        ([<ExcelArgument(Name="isRhoFixed",Description = "bool")>] 
         isRhoFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "bool")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria or empty")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "OptimizationMethod")>] 
         Method : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _hasFloatingStrikes = Helper.toCell<bool> hasFloatingStrikes "hasFloatingStrikes" 
                let _atmVolatility = Helper.toCell<double> atmVolatility "atmVolatility" 
                let _volHandles = Helper.toCell<Generic.List<double>> volHandles "volHandles" 
                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _beta = Helper.toCell<double> beta "beta" 
                let _nu = Helper.toCell<double> nu "nu" 
                let _rho = Helper.toCell<double> rho "rho" 
                let _isAlphaFixed = Helper.toCell<bool> isAlphaFixed "isAlphaFixed" 
                let _isBetaFixed = Helper.toCell<bool> isBetaFixed "isBetaFixed" 
                let _isNuFixed = Helper.toCell<bool> isNuFixed "isNuFixed" 
                let _isRhoFixed = Helper.toCell<bool> isRhoFixed "isRhoFixed" 
                let _vegaWeighted = Helper.toCell<bool> vegaWeighted "vegaWeighted" 
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SabrInterpolatedSmileSection1 
                                                            _optionDate.cell 
                                                            _forward.cell 
                                                            _strikes.cell 
                                                            _hasFloatingStrikes.cell 
                                                            _atmVolatility.cell 
                                                            _volHandles.cell 
                                                            _alpha.cell 
                                                            _beta.cell 
                                                            _nu.cell 
                                                            _rho.cell 
                                                            _isAlphaFixed.cell 
                                                            _isBetaFixed.cell 
                                                            _isNuFixed.cell 
                                                            _isRhoFixed.cell 
                                                            _vegaWeighted.cell 
                                                            _endCriteria.cell 
                                                            _Method.cell 
                                                            _dc.cell 
                                                            _shift.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SabrInterpolatedSmileSection>) l

                let source () = Helper.sourceFold "Fun.SabrInterpolatedSmileSection1" 
                                               [| _optionDate.source
                                               ;  _forward.source
                                               ;  _strikes.source
                                               ;  _hasFloatingStrikes.source
                                               ;  _atmVolatility.source
                                               ;  _volHandles.source
                                               ;  _alpha.source
                                               ;  _beta.source
                                               ;  _nu.source
                                               ;  _rho.source
                                               ;  _isAlphaFixed.source
                                               ;  _isBetaFixed.source
                                               ;  _isNuFixed.source
                                               ;  _isRhoFixed.source
                                               ;  _vegaWeighted.source
                                               ;  _endCriteria.source
                                               ;  _Method.source
                                               ;  _dc.source
                                               ;  _shift.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _optionDate.cell
                                ;  _forward.cell
                                ;  _strikes.cell
                                ;  _hasFloatingStrikes.cell
                                ;  _atmVolatility.cell
                                ;  _volHandles.cell
                                ;  _alpha.cell
                                ;  _beta.cell
                                ;  _nu.cell
                                ;  _rho.cell
                                ;  _isAlphaFixed.cell
                                ;  _isBetaFixed.cell
                                ;  _isNuFixed.cell
                                ;  _isRhoFixed.cell
                                ;  _vegaWeighted.cell
                                ;  _endCriteria.cell
                                ;  _Method.cell
                                ;  _dc.cell
                                ;  _shift.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SabrInterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \name Constructors
@{ ! all market data are quotes
    *)
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="forward",Description = "Quote")>] 
         forward : obj)
        ([<ExcelArgument(Name="strikes",Description = "double range")>] 
         strikes : obj)
        ([<ExcelArgument(Name="hasFloatingStrikes",Description = "bool")>] 
         hasFloatingStrikes : obj)
        ([<ExcelArgument(Name="atmVolatility",Description = "Quote")>] 
         atmVolatility : obj)
        ([<ExcelArgument(Name="volHandles",Description = "Quote range")>] 
         volHandles : obj)
        ([<ExcelArgument(Name="alpha",Description = "double")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "double")>] 
         beta : obj)
        ([<ExcelArgument(Name="nu",Description = "double")>] 
         nu : obj)
        ([<ExcelArgument(Name="rho",Description = "double")>] 
         rho : obj)
        ([<ExcelArgument(Name="isAlphaFixed",Description = "bool")>] 
         isAlphaFixed : obj)
        ([<ExcelArgument(Name="isBetaFixed",Description = "bool")>] 
         isBetaFixed : obj)
        ([<ExcelArgument(Name="isNuFixed",Description = "bool")>] 
         isNuFixed : obj)
        ([<ExcelArgument(Name="isRhoFixed",Description = "bool")>] 
         isRhoFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "bool")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria or empty")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "OptimizationMethod")>] 
         Method : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _forward = Helper.toHandle<Quote> forward "forward" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _hasFloatingStrikes = Helper.toCell<bool> hasFloatingStrikes "hasFloatingStrikes" 
                let _atmVolatility = Helper.toHandle<Quote> atmVolatility "atmVolatility" 
                let _volHandles = Helper.toCell<Generic.List<Handle<Quote>>> volHandles "volHandles" 
                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _beta = Helper.toCell<double> beta "beta" 
                let _nu = Helper.toCell<double> nu "nu" 
                let _rho = Helper.toCell<double> rho "rho" 
                let _isAlphaFixed = Helper.toCell<bool> isAlphaFixed "isAlphaFixed" 
                let _isBetaFixed = Helper.toCell<bool> isBetaFixed "isBetaFixed" 
                let _isNuFixed = Helper.toCell<bool> isNuFixed "isNuFixed" 
                let _isRhoFixed = Helper.toCell<bool> isRhoFixed "isRhoFixed" 
                let _vegaWeighted = Helper.toCell<bool> vegaWeighted "vegaWeighted" 
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SabrInterpolatedSmileSection
                                                            _optionDate.cell 
                                                            _forward.cell 
                                                            _strikes.cell 
                                                            _hasFloatingStrikes.cell 
                                                            _atmVolatility.cell 
                                                            _volHandles.cell 
                                                            _alpha.cell 
                                                            _beta.cell 
                                                            _nu.cell 
                                                            _rho.cell 
                                                            _isAlphaFixed.cell 
                                                            _isBetaFixed.cell 
                                                            _isNuFixed.cell 
                                                            _isRhoFixed.cell 
                                                            _vegaWeighted.cell 
                                                            _endCriteria.cell 
                                                            _Method.cell 
                                                            _dc.cell 
                                                            _shift.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SabrInterpolatedSmileSection>) l

                let source () = Helper.sourceFold "Fun.SabrInterpolatedSmileSection" 
                                               [| _optionDate.source
                                               ;  _forward.source
                                               ;  _strikes.source
                                               ;  _hasFloatingStrikes.source
                                               ;  _atmVolatility.source
                                               ;  _volHandles.source
                                               ;  _alpha.source
                                               ;  _beta.source
                                               ;  _nu.source
                                               ;  _rho.source
                                               ;  _isAlphaFixed.source
                                               ;  _isBetaFixed.source
                                               ;  _isNuFixed.source
                                               ;  _isRhoFixed.source
                                               ;  _vegaWeighted.source
                                               ;  _endCriteria.source
                                               ;  _Method.source
                                               ;  _dc.source
                                               ;  _shift.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _optionDate.cell
                                ;  _forward.cell
                                ;  _strikes.cell
                                ;  _hasFloatingStrikes.cell
                                ;  _atmVolatility.cell
                                ;  _volHandles.cell
                                ;  _alpha.cell
                                ;  _beta.cell
                                ;  _nu.cell
                                ;  _rho.cell
                                ;  _isAlphaFixed.cell
                                ;  _isBetaFixed.cell
                                ;  _isNuFixed.cell
                                ;  _isRhoFixed.cell
                                ;  _vegaWeighted.cell
                                ;  _endCriteria.cell
                                ;  _Method.cell
                                ;  _dc.cell
                                ;  _shift.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SabrInterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_update", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Update
                                                       ) :> ICell
                let format (o : SabrInterpolatedSmileSection) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_dayCounter", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SabrInterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_density", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "double")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Density") 

                                               [| _strike.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _discount.cell
                                ;  _gap.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_digitalOptionPrice", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "double")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".DigitalOptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _Type.cell
                                ;  _discount.cell
                                ;  _gap.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_exerciseDate", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".ExerciseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_exerciseTime", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".ExerciseTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_optionPrice", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".OptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _Type.cell
                                ;  _discount.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_referenceDate", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_shift", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Shift") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_variance", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Variance") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_vega", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Vega") 

                                               [| _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _discount.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_volatility", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "double or empty")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Volatility") 

                                               [| _strike.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _volatilityType.cell
                                ;  _shift.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_volatility1", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Volatility1") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_volatilityType", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_Range", Description="Create a range of SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SabrInterpolatedSmileSection> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SabrInterpolatedSmileSection> (c)) :> ICell
                let format (i : Cephei.Cell.List<SabrInterpolatedSmileSection>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SabrInterpolatedSmileSection>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
