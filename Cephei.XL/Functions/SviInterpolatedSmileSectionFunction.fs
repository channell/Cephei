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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_a", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".A") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_atmLevel", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_atmLevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).AtmLevel
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".AtmLevel") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_b", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".B") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_endCriteria", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".EndCriteria") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_m", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_m
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).M
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".M") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_maxError", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_maxError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).MaxError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".MaxError") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_maxStrike", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".MaxStrike") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_minStrike", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".MinStrike") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_rho", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Rho") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_rmsError", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_rmsError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).RmsError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".RmsError") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_sigma", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Sigma") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_create
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
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        ([<ExcelArgument(Name="isAFixed",Description = "Reference to isAFixed")>] 
         isAFixed : obj)
        ([<ExcelArgument(Name="isBFixed",Description = "Reference to isBFixed")>] 
         isBFixed : obj)
        ([<ExcelArgument(Name="isSigmaFixed",Description = "Reference to isSigmaFixed")>] 
         isSigmaFixed : obj)
        ([<ExcelArgument(Name="isRhoFixed",Description = "Reference to isRhoFixed")>] 
         isRhoFixed : obj)
        ([<ExcelArgument(Name="isMFixed",Description = "Reference to isMFixed")>] 
         isMFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "Reference to vegaWeighted")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
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
                let builder () = withMnemonic mnemonic (Fun.SviInterpolatedSmileSection 
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
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SviInterpolatedSmileSection>) l

                let source = Helper.sourceFold "Fun.SviInterpolatedSmileSection" 
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
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection1", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_create1
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
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        ([<ExcelArgument(Name="isAFixed",Description = "Reference to isAFixed")>] 
         isAFixed : obj)
        ([<ExcelArgument(Name="isBFixed",Description = "Reference to isBFixed")>] 
         isBFixed : obj)
        ([<ExcelArgument(Name="isSigmaFixed",Description = "Reference to isSigmaFixed")>] 
         isSigmaFixed : obj)
        ([<ExcelArgument(Name="isRhoFixed",Description = "Reference to isRhoFixed")>] 
         isRhoFixed : obj)
        ([<ExcelArgument(Name="isMFixed",Description = "Reference to isMFixed")>] 
         isMFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "Reference to vegaWeighted")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
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
                let builder () = withMnemonic mnemonic (Fun.SviInterpolatedSmileSection1 
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
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SviInterpolatedSmileSection>) l

                let source = Helper.sourceFold "Fun.SviInterpolatedSmileSection1" 
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
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_update", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).Update
                                                       ) :> ICell
                let format (o : SviInterpolatedSmileSection) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Update") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_dayCounter", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".DayCounter") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_density", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_density
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="gap",Description = "Reference to gap")>] 
         gap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).Density
                                                            _strike.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Density") 
                                               [| _SviInterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_digitalOptionPrice", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_digitalOptionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
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

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _gap = Helper.toCell<double> gap "gap" 
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).DigitalOptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                            _gap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".DigitalOptionPrice") 
                                               [| _SviInterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_exerciseDate", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_exerciseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).ExerciseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".ExerciseDate") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_exerciseTime", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_exerciseTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).ExerciseTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".ExerciseTime") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_optionPrice", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_optionPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).OptionPrice
                                                            _strike.cell 
                                                            _Type.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".OptionPrice") 
                                               [| _SviInterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_referenceDate", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".ReferenceDate") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_shift", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).Shift
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Shift") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_variance", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).Variance
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Variance") 
                                               [| _SviInterpolatedSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_vega", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).Vega
                                                            _strike.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Vega") 
                                               [| _SviInterpolatedSmileSection.source
                                               ;  _strike.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_volatility", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _volatilityType = Helper.toCell<VolatilityType> volatilityType "volatilityType" 
                let _shift = Helper.toCell<double> shift "shift" 
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).Volatility
                                                            _strike.cell 
                                                            _volatilityType.cell 
                                                            _shift.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Volatility") 
                                               [| _SviInterpolatedSmileSection.source
                                               ;  _strike.source
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_volatility1", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).Volatility1
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".Volatility1") 
                                               [| _SviInterpolatedSmileSection.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_volatilityType", Description="Create a SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolatedSmileSection",Description = "Reference to SviInterpolatedSmileSection")>] 
         sviinterpolatedsmilesection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolatedSmileSection = Helper.toCell<SviInterpolatedSmileSection> sviinterpolatedsmilesection "SviInterpolatedSmileSection"  
                let builder () = withMnemonic mnemonic ((_SviInterpolatedSmileSection.cell :?> SviInterpolatedSmileSectionModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SviInterpolatedSmileSection.source + ".VolatilityType") 
                                               [| _SviInterpolatedSmileSection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolatedSmileSection.cell
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
    [<ExcelFunction(Name="_SviInterpolatedSmileSection_Range", Description="Create a range of SviInterpolatedSmileSection",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SviInterpolatedSmileSection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SviInterpolatedSmileSection")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SviInterpolatedSmileSection> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SviInterpolatedSmileSection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SviInterpolatedSmileSection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SviInterpolatedSmileSection>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
