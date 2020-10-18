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
  %SABR interpolation factory and traits
  </summary> *)
[<AutoSerializable(true)>]
module SABRFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SABR_interpolate", Description="Create a SABR",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABR_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Interpolation")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABR",Description = "SABR")>] 
         sabr : obj)
        ([<ExcelArgument(Name="xBegin",Description = "double")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "int")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABR = Helper.toCell<SABR> sabr "SABR"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xEnd = Helper.toCell<int> xEnd "xEnd" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = withMnemonic mnemonic ((SABRModel.Cast _SABR.cell).Interpolate
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_SABR.source + ".Interpolate") 
                                               [| _SABR.source
                                               ;  _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABR.cell
                                ;  _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SABR> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SABR", Description="Create a SABR",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABR_create
        ([<ExcelArgument(Name="Mnemonic",Description = "SABR")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        ([<ExcelArgument(Name="alpha",Description = "double")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "double")>] 
         beta : obj)
        ([<ExcelArgument(Name="nu",Description = "double")>] 
         nu : obj)
        ([<ExcelArgument(Name="rho",Description = "double")>] 
         rho : obj)
        ([<ExcelArgument(Name="alphaIsFixed",Description = "bool")>] 
         alphaIsFixed : obj)
        ([<ExcelArgument(Name="betaIsFixed",Description = "bool")>] 
         betaIsFixed : obj)
        ([<ExcelArgument(Name="nuIsFixed",Description = "bool")>] 
         nuIsFixed : obj)
        ([<ExcelArgument(Name="rhoIsFixed",Description = "bool")>] 
         rhoIsFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "SABR")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "SABR")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="optMethod",Description = "SABR")>] 
         optMethod : obj)
        ([<ExcelArgument(Name="errorAccept",Description = "SABR")>] 
         errorAccept : obj)
        ([<ExcelArgument(Name="useMaxError",Description = "SABR")>] 
         useMaxError : obj)
        ([<ExcelArgument(Name="maxGuesses",Description = "SABR")>] 
         maxGuesses : obj)
        ([<ExcelArgument(Name="shift",Description = "SABR")>] 
         shift : obj)
        ([<ExcelArgument(Name="volatilityType",Description = "SABR")>] 
         volatilityType : obj)
        ([<ExcelArgument(Name="approximationModel",Description = "SABR")>] 
         approximationModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _t = Helper.toCell<double> t "t" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _beta = Helper.toCell<double> beta "beta" 
                let _nu = Helper.toCell<double> nu "nu" 
                let _rho = Helper.toCell<double> rho "rho" 
                let _alphaIsFixed = Helper.toCell<bool> alphaIsFixed "alphaIsFixed" 
                let _betaIsFixed = Helper.toCell<bool> betaIsFixed "betaIsFixed" 
                let _nuIsFixed = Helper.toCell<bool> nuIsFixed "nuIsFixed" 
                let _rhoIsFixed = Helper.toCell<bool> rhoIsFixed "rhoIsFixed" 
                let _vegaWeighted = Helper.toDefault<bool> vegaWeighted "vegaWeighted" false
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _optMethod = Helper.toDefault<OptimizationMethod> optMethod "optMethod" null
                let _errorAccept = Helper.toDefault<double> errorAccept "errorAccept" 0.0020
                let _useMaxError = Helper.toDefault<bool> useMaxError "useMaxError" false
                let _maxGuesses = Helper.toDefault<int> maxGuesses "maxGuesses" 50
                let _shift = Helper.toDefault<double> shift "shift" 0.0
                let _volatilityType = Helper.toDefault<VolatilityType> volatilityType "volatilityType" VolatilityType.ShiftedLognormal
                let _approximationModel = Helper.toDefault<SabrApproximationModel> approximationModel "approximationModel" SabrApproximationModel.Hagan2002
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SABR 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SABR>) l

                let source () = Helper.sourceFold "Fun.SABR" 
                                               [| _t.source
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
                                [| _t.cell
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SABR> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SABR_Range", Description="Create a range of SABR",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABR_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SABR> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SABR>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SABR>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SABR>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
