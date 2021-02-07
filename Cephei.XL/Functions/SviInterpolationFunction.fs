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
  %SABR smile interpolation between discrete volatility points.
  </summary> *)
[<AutoSerializable(true)>]
module SviInterpolationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SviInterpolation_a", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".A") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_b", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".B") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_endCriteria", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".EndCriteria") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_expiry", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_expiry
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Expiry
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Expiry") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_forward", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_forward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Forward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Forward") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_interpolationWeights", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_interpolationWeights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).InterpolationWeights
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SviInterpolation.source + ".InterpolationWeights") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_m", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_m
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).M
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".M") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_maxError", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_maxError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).MaxError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".MaxError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_rho", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_rmsError", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_rmsError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).RmsError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".RmsError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_sigma", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Sigma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "double range")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double range")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
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
        ([<ExcelArgument(Name="aIsFixed",Description = "bool")>] 
         aIsFixed : obj)
        ([<ExcelArgument(Name="bIsFixed",Description = "bool")>] 
         bIsFixed : obj)
        ([<ExcelArgument(Name="sigmaIsFixed",Description = "bool")>] 
         sigmaIsFixed : obj)
        ([<ExcelArgument(Name="rhoIsFixed",Description = "bool")>] 
         rhoIsFixed : obj)
        ([<ExcelArgument(Name="mIsFixed",Description = "bool")>] 
         mIsFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "bool or empty")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria or empty")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="optMethod",Description = "OptimizationMethod or empty")>] 
         optMethod : obj)
        ([<ExcelArgument(Name="errorAccept",Description = "double or empty")>] 
         errorAccept : obj)
        ([<ExcelArgument(Name="useMaxError",Description = "bool or empty")>] 
         useMaxError : obj)
        ([<ExcelArgument(Name="maxGuesses",Description = "int or empty")>] 
         maxGuesses : obj)
        ([<ExcelArgument(Name="addParams",Description = "double or empty")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _t = Helper.toCell<double> t "t" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _a = Helper.toNullable<double> a "a"
                let _b = Helper.toNullable<double> b "b"
                let _sigma = Helper.toNullable<double> sigma "sigma"
                let _rho = Helper.toNullable<double> rho "rho"
                let _m = Helper.toNullable<double> m "m"
                let _aIsFixed = Helper.toCell<bool> aIsFixed "aIsFixed" 
                let _bIsFixed = Helper.toCell<bool> bIsFixed "bIsFixed" 
                let _sigmaIsFixed = Helper.toCell<bool> sigmaIsFixed "sigmaIsFixed" 
                let _rhoIsFixed = Helper.toCell<bool> rhoIsFixed "rhoIsFixed" 
                let _mIsFixed = Helper.toCell<bool> mIsFixed "mIsFixed" 
                let _vegaWeighted = Helper.toDefault<bool> vegaWeighted "vegaWeighted" true
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _optMethod = Helper.toDefault<OptimizationMethod> optMethod "optMethod" null
                let _errorAccept = Helper.toDefault<double> errorAccept "errorAccept" 0.0020
                let _useMaxError = Helper.toDefault<bool> useMaxError "useMaxError" false
                let _maxGuesses = Helper.toDefault<int> maxGuesses "maxGuesses" 50
                let _addParams = Helper.toDefault<Generic.List<Nullable<double>>> addParams "addParams" null
                let builder (current : ICell) = (Fun.SviInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _t.cell 
                                                            _forward.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _sigma.cell 
                                                            _rho.cell 
                                                            _m.cell 
                                                            _aIsFixed.cell 
                                                            _bIsFixed.cell 
                                                            _sigmaIsFixed.cell 
                                                            _rhoIsFixed.cell 
                                                            _mIsFixed.cell 
                                                            _vegaWeighted.cell 
                                                            _endCriteria.cell 
                                                            _optMethod.cell 
                                                            _errorAccept.cell 
                                                            _useMaxError.cell 
                                                            _maxGuesses.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SviInterpolation>) l

                let source () = Helper.sourceFold "Fun.SviInterpolation" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _t.source
                                               ;  _forward.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _sigma.source
                                               ;  _rho.source
                                               ;  _m.source
                                               ;  _aIsFixed.source
                                               ;  _bIsFixed.source
                                               ;  _sigmaIsFixed.source
                                               ;  _rhoIsFixed.source
                                               ;  _mIsFixed.source
                                               ;  _vegaWeighted.source
                                               ;  _endCriteria.source
                                               ;  _optMethod.source
                                               ;  _errorAccept.source
                                               ;  _useMaxError.source
                                               ;  _maxGuesses.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _t.cell
                                ;  _forward.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _sigma.cell
                                ;  _rho.cell
                                ;  _m.cell
                                ;  _aIsFixed.cell
                                ;  _bIsFixed.cell
                                ;  _sigmaIsFixed.cell
                                ;  _rhoIsFixed.cell
                                ;  _mIsFixed.cell
                                ;  _vegaWeighted.cell
                                ;  _endCriteria.cell
                                ;  _optMethod.cell
                                ;  _errorAccept.cell
                                ;  _useMaxError.cell
                                ;  _maxGuesses.cell
                                ;  _addParams.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SviInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SviInterpolation_derivative", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Derivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_empty", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_primitive", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Primitive") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_secondDerivative", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".SecondDerivative") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_update", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Update
                                                       ) :> ICell
                let format (o : SviInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_value1", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "bool")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Value1") 

                                               [| _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
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
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_SviInterpolation_value", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Value") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_SviInterpolation_xMax", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".XMax") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_xMin", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".XMin") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_SviInterpolation_allowsExtrapolation", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_SviInterpolation_disableExtrapolation", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SviInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_SviInterpolation_enableExtrapolation", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SviInterpolation) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_SviInterpolation_extrapolate", Description="Create a SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SviInterpolation",Description = "SviInterpolation")>] 
         sviinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SviInterpolation = Helper.toCell<SviInterpolation> sviinterpolation "SviInterpolation"  
                let builder (current : ICell) = ((SviInterpolationModel.Cast _SviInterpolation.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SviInterpolation.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SviInterpolation.cell
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
    [<ExcelFunction(Name="_SviInterpolation_Range", Description="Create a range of SviInterpolation",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SviInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SviInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SviInterpolation> (c)) :> ICell
                let format (i : Cephei.Cell.List<SviInterpolation>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SviInterpolation>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
