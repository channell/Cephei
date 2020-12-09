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
module SviInterpolatedSmileSectionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_a", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".A") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_atmLevel", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".AtmLevel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_b", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".B") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_endCriteria", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".EndCriteria") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_m", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_m
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).M
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".M") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_maxError", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_maxError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).MaxError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".MaxError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_maxStrike", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_minStrike", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_rho", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_rmsError", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_rmsError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).RmsError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".RmsError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_sigma", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Sigma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_create
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
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        ([<ExcelArgument(Name="sigma",Description = "double")>] 
         sigma : obj)
        ([<ExcelArgument(Name="rho",Description = "double")>] 
         rho : obj)
        ([<ExcelArgument(Name="m",Description = "double")>] 
         m : obj)
        ([<ExcelArgument(Name="isAFixed",Description = "bool")>] 
         isAFixed : obj)
        ([<ExcelArgument(Name="isBFixed",Description = "bool")>] 
         isBFixed : obj)
        ([<ExcelArgument(Name="isSigmaFixed",Description = "bool")>] 
         isSigmaFixed : obj)
        ([<ExcelArgument(Name="isRhoFixed",Description = "bool")>] 
         isRhoFixed : obj)
        ([<ExcelArgument(Name="isMFixed",Description = "bool")>] 
         isMFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "bool")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria or empty")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "OptimizationMethod")>] 
         Method : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
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
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _rho = Helper.toCell<double> rho "rho" 
                let _m = Helper.toCell<double> m "m" 
                let _isAFixed = Helper.toCell<bool> isAFixed "isAFixed" 
                let _isBFixed = Helper.toCell<bool> isBFixed "isBFixed" 
                let _isSigmaFixed = Helper.toCell<bool> isSigmaFixed "isSigmaFixed" 
                let _isRhoFixed = Helper.toCell<bool> isRhoFixed "isRhoFixed" 
                let _isMFixed = Helper.toCell<bool> isMFixed "isMFixed" 
                let _vegaWeighted = Helper.toCell<bool> vegaWeighted "vegaWeighted" 
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SviInterpolatedSmileSection 
                                                            _optionDate.cell 
                                                            _forward.cell 
                                                            _strikes.cell 
                                                            _hasFloatingStrikes.cell 
                                                            _atmVolatility.cell 
                                                            _volHandles.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _sigma.cell 
                                                            _rho.cell 
                                                            _m.cell 
                                                            _isAFixed.cell 
                                                            _isBFixed.cell 
                                                            _isSigmaFixed.cell 
                                                            _isRhoFixed.cell 
                                                            _isMFixed.cell 
                                                            _vegaWeighted.cell 
                                                            _endCriteria.cell 
                                                            _Method.cell 
                                                            _dc.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SviInterpolatedSmileSection>) l

                let source () = Helper.sourceFold "Fun.SviInterpolatedSmileSection" 
                                               [| _optionDate.source
                                               ;  _forward.source
                                               ;  _strikes.source
                                               ;  _hasFloatingStrikes.source
                                               ;  _atmVolatility.source
                                               ;  _volHandles.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _sigma.source
                                               ;  _rho.source
                                               ;  _m.source
                                               ;  _isAFixed.source
                                               ;  _isBFixed.source
                                               ;  _isSigmaFixed.source
                                               ;  _isRhoFixed.source
                                               ;  _isMFixed.source
                                               ;  _vegaWeighted.source
                                               ;  _endCriteria.source
                                               ;  _Method.source
                                               ;  _dc.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _optionDate.cell
                                ;  _forward.cell
                                ;  _strikes.cell
                                ;  _hasFloatingStrikes.cell
                                ;  _atmVolatility.cell
                                ;  _volHandles.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _sigma.cell
                                ;  _rho.cell
                                ;  _m.cell
                                ;  _isAFixed.cell
                                ;  _isBFixed.cell
                                ;  _isSigmaFixed.cell
                                ;  _isRhoFixed.cell
                                ;  _isMFixed.cell
                                ;  _vegaWeighted.cell
                                ;  _endCriteria.cell
                                ;  _Method.cell
                                ;  _dc.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SviInterpolatedSmileSection> format
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection1", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_create1
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
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        ([<ExcelArgument(Name="sigma",Description = "double")>] 
         sigma : obj)
        ([<ExcelArgument(Name="rho",Description = "double")>] 
         rho : obj)
        ([<ExcelArgument(Name="m",Description = "double")>] 
         m : obj)
        ([<ExcelArgument(Name="isAFixed",Description = "bool")>] 
         isAFixed : obj)
        ([<ExcelArgument(Name="isBFixed",Description = "bool")>] 
         isBFixed : obj)
        ([<ExcelArgument(Name="isSigmaFixed",Description = "bool")>] 
         isSigmaFixed : obj)
        ([<ExcelArgument(Name="isRhoFixed",Description = "bool")>] 
         isRhoFixed : obj)
        ([<ExcelArgument(Name="isMFixed",Description = "bool")>] 
         isMFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "bool")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria or empty")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "OptimizationMethod")>] 
         Method : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
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
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _rho = Helper.toCell<double> rho "rho" 
                let _m = Helper.toCell<double> m "m" 
                let _isAFixed = Helper.toCell<bool> isAFixed "isAFixed" 
                let _isBFixed = Helper.toCell<bool> isBFixed "isBFixed" 
                let _isSigmaFixed = Helper.toCell<bool> isSigmaFixed "isSigmaFixed" 
                let _isRhoFixed = Helper.toCell<bool> isRhoFixed "isRhoFixed" 
                let _isMFixed = Helper.toCell<bool> isMFixed "isMFixed" 
                let _vegaWeighted = Helper.toCell<bool> vegaWeighted "vegaWeighted" 
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SviInterpolatedSmileSection1 
                                                            _optionDate.cell 
                                                            _forward.cell 
                                                            _strikes.cell 
                                                            _hasFloatingStrikes.cell 
                                                            _atmVolatility.cell 
                                                            _volHandles.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _sigma.cell 
                                                            _rho.cell 
                                                            _m.cell 
                                                            _isAFixed.cell 
                                                            _isBFixed.cell 
                                                            _isSigmaFixed.cell 
                                                            _isRhoFixed.cell 
                                                            _isMFixed.cell 
                                                            _vegaWeighted.cell 
                                                            _endCriteria.cell 
                                                            _Method.cell 
                                                            _dc.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SviInterpolatedSmileSection>) l

                let source () = Helper.sourceFold "Fun.SviInterpolatedSmileSection1" 
                                               [| _optionDate.source
                                               ;  _forward.source
                                               ;  _strikes.source
                                               ;  _hasFloatingStrikes.source
                                               ;  _atmVolatility.source
                                               ;  _volHandles.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _sigma.source
                                               ;  _rho.source
                                               ;  _m.source
                                               ;  _isAFixed.source
                                               ;  _isBFixed.source
                                               ;  _isSigmaFixed.source
                                               ;  _isRhoFixed.source
                                               ;  _isMFixed.source
                                               ;  _vegaWeighted.source
                                               ;  _endCriteria.source
                                               ;  _Method.source
                                               ;  _dc.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _optionDate.cell
                                ;  _forward.cell
                                ;  _strikes.cell
                                ;  _hasFloatingStrikes.cell
                                ;  _atmVolatility.cell
                                ;  _volHandles.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _sigma.cell
                                ;  _rho.cell
                                ;  _m.cell
                                ;  _isAFixed.cell
                                ;  _isBFixed.cell
                                ;  _isSigmaFixed.cell
                                ;  _isRhoFixed.cell
                                ;  _isMFixed.cell
                                ;  _vegaWeighted.cell
                                ;  _endCriteria.cell
                                ;  _Method.cell
                                ;  _dc.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SviInterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_update", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).Update
                                                       ) :> ICell
                let format (o : SviInterpolatedSmileSection) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_dayCounter", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SviInterpolatedSmileSection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_density", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "double")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Density") 

                                               [| _strike.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_digitalOptionPrice", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
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

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".DigitalOptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               ;  _gap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_exerciseDate", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".ExerciseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_exerciseTime", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".ExerciseTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_optionPrice", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".OptionPrice") 

                                               [| _strike.source
                                               ;  _Type.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_referenceDate", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_shift", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Shift") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_variance", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Variance") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_vega", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Vega") 

                                               [| _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_volatility", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "double")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" 
                let _shift = Helper.toCell<double> shift "shift" 
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Volatility") 

                                               [| _strike.source
                                               ;  _volatilityType.source
                                               ;  _shift.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_volatility1", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Volatility1") 

                                               [| _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_volatilityType", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder (current : ICell) = withMnemonic mnemonic ((SviInterpolatedSmileSectionModel.Cast _SviInterpolatedSmileSection.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_Range", Description="Create a range of SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SviInterpolatedSmileSection> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SviInterpolatedSmileSection> (c)) :> ICell
                let format (i : Generic.List<ICell<SviInterpolatedSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SviInterpolatedSmileSection>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
