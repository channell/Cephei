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
module SVIFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SVI_interpolate", Description="Create a SVI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVI_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVI",Description = "Reference to SVI")>] 
         svi : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "Reference to xEnd")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVI = Helper.toCell<SVI> svi "SVI"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xEnd = Helper.toCell<int> xEnd "xEnd" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder () = withMnemonic mnemonic ((_SVI.cell :?> SVIModel).Interpolate
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_SVI.source + ".Interpolate") 
                                               [| _SVI.source
                                               ;  _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVI.cell
                                ;  _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVI", Description="Create a SVI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVI_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
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
        ([<ExcelArgument(Name="aIsFixed",Description = "Reference to aIsFixed")>] 
         aIsFixed : obj)
        ([<ExcelArgument(Name="bIsFixed",Description = "Reference to bIsFixed")>] 
         bIsFixed : obj)
        ([<ExcelArgument(Name="sigmaIsFixed",Description = "Reference to sigmaIsFixed")>] 
         sigmaIsFixed : obj)
        ([<ExcelArgument(Name="rhoIsFixed",Description = "Reference to rhoIsFixed")>] 
         rhoIsFixed : obj)
        ([<ExcelArgument(Name="mIsFixed",Description = "Reference to mIsFixed")>] 
         mIsFixed : obj)
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
        ([<ExcelArgument(Name="addParams",Description = "Reference to addParams")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _t = Helper.toCell<double> t "t" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _rho = Helper.toCell<double> rho "rho" 
                let _m = Helper.toCell<double> m "m" 
                let _aIsFixed = Helper.toCell<bool> aIsFixed "aIsFixed" 
                let _bIsFixed = Helper.toCell<bool> bIsFixed "bIsFixed" 
                let _sigmaIsFixed = Helper.toCell<bool> sigmaIsFixed "sigmaIsFixed" 
                let _rhoIsFixed = Helper.toCell<bool> rhoIsFixed "rhoIsFixed" 
                let _mIsFixed = Helper.toCell<bool> mIsFixed "mIsFixed" 
                let _vegaWeighted = Helper.toCell<bool> vegaWeighted "vegaWeighted" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _optMethod = Helper.toCell<OptimizationMethod> optMethod "optMethod" 
                let _errorAccept = Helper.toCell<double> errorAccept "errorAccept" 
                let _useMaxError = Helper.toCell<bool> useMaxError "useMaxError" 
                let _maxGuesses = Helper.toCell<int> maxGuesses "maxGuesses" 
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" 
                let builder () = withMnemonic mnemonic (Fun.SVI 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SVI>) l

                let source = Helper.sourceFold "Fun.SVI" 
                                               [| _t.source
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
                                [| _t.cell
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SVI_Range", Description="Create a range of SVI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SVI")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SVI> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SVI>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SVI>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SVI>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
