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
  %SABR smile interpolation between discrete volatility points. For volatility type Normal and when the forward < 0, it is suggested to fix beta = 0.0
  </summary> *)
[<AutoSerializable(true)>]
module SABRInterpolationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SABRInterpolation_alpha", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Alpha
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Alpha") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_beta", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Beta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Beta") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_endCriteria", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".EndCriteria") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_expiry", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_expiry
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Expiry
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Expiry") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_forward", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_forward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Forward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Forward") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_interpolationWeights", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_interpolationWeights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).InterpolationWeights
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SABRInterpolation.source + ".InterpolationWeights") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_SABRInterpolation_maxError", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_maxError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).MaxError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".MaxError") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_nu", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_nu
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Nu
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Nu") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_rho", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Rho") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_rmsError", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_rmsError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).RmsError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".RmsError") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "Reference to xEnd")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        ([<ExcelArgument(Name="nu",Description = "Reference to nu")>] 
         nu : obj)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        ([<ExcelArgument(Name="alphaIsFixed",Description = "Reference to alphaIsFixed")>] 
         alphaIsFixed : obj)
        ([<ExcelArgument(Name="betaIsFixed",Description = "Reference to betaIsFixed")>] 
         betaIsFixed : obj)
        ([<ExcelArgument(Name="nuIsFixed",Description = "Reference to nuIsFixed")>] 
         nuIsFixed : obj)
        ([<ExcelArgument(Name="rhoIsFixed",Description = "Reference to rhoIsFixed")>] 
         rhoIsFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "Reference to vegaWeighted")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="optMethod",Description = "Reference to optMethod")>] 
         optMethod : obj)
        ([<ExcelArgument(Name="errorAccept",Description = "Reference to errorAccept")>] 
         errorAccept : obj)
        ([<ExcelArgument(Name="useMaxError",Description = "Reference to useMaxError")>] 
         useMaxError : obj)
        ([<ExcelArgument(Name="maxGuesses",Description = "Reference to maxGuesses")>] 
         maxGuesses : obj)
        ([<ExcelArgument(Name="shift",Description = "Reference to shift")>] 
         shift : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "Reference to volatilityType")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="approximationModel",Description = "Reference to approximationModel")>] 
         approximationModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xEnd = Helper.toCell<int> xEnd "xEnd" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _t = Helper.toCell<double> t "t" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _alpha = Helper.toNullable<double> alpha "alpha"
                let _beta = Helper.toNullable<double> beta "beta"
                let _nu = Helper.toNullable<double> nu "nu"
                let _rho = Helper.toNullable<double> rho "rho"
                let _alphaIsFixed = Helper.toCell<bool> alphaIsFixed "alphaIsFixed" 
                let _betaIsFixed = Helper.toCell<bool> betaIsFixed "betaIsFixed" 
                let _nuIsFixed = Helper.toCell<bool> nuIsFixed "nuIsFixed" 
                let _rhoIsFixed = Helper.toCell<bool> rhoIsFixed "rhoIsFixed" 
                let _vegaWeighted = Helper.toDefault<bool> vegaWeighted "vegaWeighted" true
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _optMethod = Helper.toDefault<OptimizationMethod> optMethod "optMethod" null
                let _errorAccept = Helper.toDefault<double> errorAccept "errorAccept" 0.0020
                let _useMaxError = Helper.toDefault<bool> useMaxError "useMaxError" false
                let _maxGuesses = Helper.toDefault<int> maxGuesses "maxGuesses" 50
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _volatilityType = Helper.toDefault<VolatilityType> volatilityType "volatilityType" VolatilityType.ShiftedLognormal
                let _approximationModel = Helper.toDefault<SabrApproximationModel> approximationModel "approximationModel" SabrApproximationModel.Hagan2002
                let builder () = withMnemonic mnemonic (Fun.SABRInterpolation 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _t.cell 
                                                            _forward.cell 
                                                            _alpha.cell 
                                                            _beta.cell 
                                                            _nu.cell 
                                                            _rho.cell 
                                                            _alphaIsFixed.cell 
                                                            _betaIsFixed.cell 
                                                            _nuIsFixed.cell 
                                                            _rhoIsFixed.cell 
                                                            _vegaWeighted.cell 
                                                            _endCriteria.cell 
                                                            _optMethod.cell 
                                                            _errorAccept.cell 
                                                            _useMaxError.cell 
                                                            _maxGuesses.cell 
                                                            _shift.cell 
                                                            _volatilityType.cell 
                                                            _approximationModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SABRInterpolation>) l

                let source = Helper.sourceFold "Fun.SABRInterpolation" 
                                               [| _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               ;  _t.source
                                               ;  _forward.source
                                               ;  _alpha.source
                                               ;  _beta.source
                                               ;  _nu.source
                                               ;  _rho.source
                                               ;  _alphaIsFixed.source
                                               ;  _betaIsFixed.source
                                               ;  _nuIsFixed.source
                                               ;  _rhoIsFixed.source
                                               ;  _vegaWeighted.source
                                               ;  _endCriteria.source
                                               ;  _optMethod.source
                                               ;  _errorAccept.source
                                               ;  _useMaxError.source
                                               ;  _maxGuesses.source
                                               ;  _shift.source
                                               ;  _volatilityType.source
                                               ;  _approximationModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                ;  _t.cell
                                ;  _forward.cell
                                ;  _alpha.cell
                                ;  _beta.cell
                                ;  _nu.cell
                                ;  _rho.cell
                                ;  _alphaIsFixed.cell
                                ;  _betaIsFixed.cell
                                ;  _nuIsFixed.cell
                                ;  _rhoIsFixed.cell
                                ;  _vegaWeighted.cell
                                ;  _endCriteria.cell
                                ;  _optMethod.cell
                                ;  _errorAccept.cell
                                ;  _useMaxError.cell
                                ;  _maxGuesses.cell
                                ;  _shift.cell
                                ;  _volatilityType.cell
                                ;  _approximationModel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SABRInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SABRInterpolation_derivative", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Derivative") 
                                               [| _SABRInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_empty", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Empty") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_primitive", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Primitive") 
                                               [| _SABRInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_secondDerivative", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".SecondDerivative") 
                                               [| _SABRInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_update", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Update
                                                       ) :> ICell
                let format (o : SABRInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Update") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_value1", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Value1") 
                                               [| _SABRInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_SABRInterpolation_value", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Value") 
                                               [| _SABRInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_xMax", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".XMax") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_xMin", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".XMin") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_SABRInterpolation_allowsExtrapolation", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".AllowsExtrapolation") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_SABRInterpolation_disableExtrapolation", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SABRInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".DisableExtrapolation") 
                                               [| _SABRInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_SABRInterpolation_enableExtrapolation", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SABRInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".EnableExtrapolation") 
                                               [| _SABRInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_extrapolate", Description="Create a SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRInterpolation",Description = "Reference to SABRInterpolation")>] 
         sabrinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRInterpolation = Helper.toCell<SABRInterpolation> sabrinterpolation "SABRInterpolation"  
                let builder () = withMnemonic mnemonic ((_SABRInterpolation.cell :?> SABRInterpolationModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SABRInterpolation.source + ".Extrapolate") 
                                               [| _SABRInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRInterpolation.cell
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
    [<ExcelFunction(Name="_SABRInterpolation_Range", Description="Create a range of SABRInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SABRInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SABRInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SABRInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SABRInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SABRInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SABRInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
