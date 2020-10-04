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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Alpha
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Alpha") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_atmLevel", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".AtmLevel") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_beta", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Beta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Beta") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_endCriteria", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".EndCriteria") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_maxError", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_maxError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).MaxError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".MaxError") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_maxStrike", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".MaxStrike") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_minStrike", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".MinStrike") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_nu", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_nu
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Nu
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Nu") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_rho", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Rho") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_rmsError", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_rmsError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).RmsError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".RmsError") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection1", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="hasFloatingStrikes",Description = "Reference to hasFloatingStrikes")>] 
         hasFloatingStrikes : obj)
        ([<ExcelArgument(Name="atmVolatility",Description = "Reference to atmVolatility")>] 
         atmVolatility : obj)
        ([<ExcelArgument(Name="volHandles",Description = "Reference to volHandles")>] 
         volHandles : obj)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        ([<ExcelArgument(Name="nu",Description = "Reference to nu")>] 
         nu : obj)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        ([<ExcelArgument(Name="isAlphaFixed",Description = "Reference to isAlphaFixed")>] 
         isAlphaFixed : obj)
        ([<ExcelArgument(Name="isBetaFixed",Description = "Reference to isBetaFixed")>] 
         isBetaFixed : obj)
        ([<ExcelArgument(Name="isNuFixed",Description = "Reference to isNuFixed")>] 
         isNuFixed : obj)
        ([<ExcelArgument(Name="isRhoFixed",Description = "Reference to isRhoFixed")>] 
         isRhoFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "Reference to vegaWeighted")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
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
                let builder () = withMnemonic mnemonic (Fun.SabrInterpolatedSmileSection1 
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
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SabrInterpolatedSmileSection>) l

                let source = Helper.sourceFold "Fun.SabrInterpolatedSmileSection1" 
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
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="hasFloatingStrikes",Description = "Reference to hasFloatingStrikes")>] 
         hasFloatingStrikes : obj)
        ([<ExcelArgument(Name="atmVolatility",Description = "Reference to atmVolatility")>] 
         atmVolatility : obj)
        ([<ExcelArgument(Name="volHandles",Description = "Reference to volHandles")>] 
         volHandles : obj)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        ([<ExcelArgument(Name="nu",Description = "Reference to nu")>] 
         nu : obj)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        ([<ExcelArgument(Name="isAlphaFixed",Description = "Reference to isAlphaFixed")>] 
         isAlphaFixed : obj)
        ([<ExcelArgument(Name="isBetaFixed",Description = "Reference to isBetaFixed")>] 
         isBetaFixed : obj)
        ([<ExcelArgument(Name="isNuFixed",Description = "Reference to isNuFixed")>] 
         isNuFixed : obj)
        ([<ExcelArgument(Name="isRhoFixed",Description = "Reference to isRhoFixed")>] 
         isRhoFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "Reference to vegaWeighted")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
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
                let builder () = withMnemonic mnemonic (Fun.SabrInterpolatedSmileSection
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
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SabrInterpolatedSmileSection>) l

                let source = Helper.sourceFold "Fun.SabrInterpolatedSmileSection" 
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
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Update
                                                       ) :> ICell
                let format (o : SabrInterpolatedSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Update") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_dayCounter", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".DayCounter") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Density") 
                                               [| _SabrInterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_digitalOptionPrice", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".DigitalOptionPrice") 
                                               [| _SabrInterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_exerciseDate", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".ExerciseDate") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_exerciseTime", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".ExerciseTime") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_optionPrice", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".OptionPrice") 
                                               [| _SabrInterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_referenceDate", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".ReferenceDate") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_shift", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Shift") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_variance", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Variance") 
                                               [| _SabrInterpolatedSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_vega", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Vega") 
                                               [| _SabrInterpolatedSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
                                ;  _strike.cell
                                ;  _discount.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_volatility", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" 
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Volatility") 
                                               [| _SabrInterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_volatility1", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".Volatility1") 
                                               [| _SabrInterpolatedSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_volatilityType", Description="Create a SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SabrInterpolatedSmileSection",Description = "Reference to SabrInterpolatedSmileSection")>] 
         sabrinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SabrInterpolatedSmileSection = Helper.toCell<SabrInterpolatedSmileSection> sabrinterpolatedsmilesection "SabrInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((SabrInterpolatedSmileSectionModel.Cast _SabrInterpolatedSmileSection.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SabrInterpolatedSmileSection.source + ".VolatilityType") 
                                               [| _SabrInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SabrInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SabrInterpolatedSmileSection_Range", Description="Create a range of SabrInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SabrInterpolatedSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SabrInterpolatedSmileSection")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SabrInterpolatedSmileSection> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SabrInterpolatedSmileSection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SabrInterpolatedSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SabrInterpolatedSmileSection>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
