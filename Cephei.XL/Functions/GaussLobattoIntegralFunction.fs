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
  References: This algorithm is a C++ implementation of the algorithm outlined in  W. Gander and W. Gautschi, Adaptive Quadrature - Revisited. BIT, 40(1):84-101, March 2000. CS technical report: ftp.inf.ethz.ch/pub/publications/tech-reports/3xx/306.ps.gz  The original MATLAB version can be downloaded here http://www.inf.ethz.ch/personal/gander/adaptlob.m
  </summary> *)
[<AutoSerializable(true)>]
module GaussLobattoIntegralFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussLobattoIntegral", Description="Create a GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="maxIterations",Description = "Reference to maxIterations")>] 
         maxIterations : obj)
        ([<ExcelArgument(Name="absAccuracy",Description = "Reference to absAccuracy")>] 
         absAccuracy : obj)
        ([<ExcelArgument(Name="relAccuracy",Description = "Reference to relAccuracy")>] 
         relAccuracy : obj)
        ([<ExcelArgument(Name="useConvergenceEstimate",Description = "Reference to useConvergenceEstimate")>] 
         useConvergenceEstimate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _maxIterations = Helper.toCell<int> maxIterations "maxIterations" 
                let _absAccuracy = Helper.toNullable<double> absAccuracy "absAccuracy"
                let _relAccuracy = Helper.toNullable<double> relAccuracy "relAccuracy"
                let _useConvergenceEstimate = Helper.toCell<bool> useConvergenceEstimate "useConvergenceEstimate" 
                let builder () = withMnemonic mnemonic (Fun.GaussLobattoIntegral 
                                                            _maxIterations.cell 
                                                            _absAccuracy.cell 
                                                            _relAccuracy.cell 
                                                            _useConvergenceEstimate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussLobattoIntegral>) l

                let source = Helper.sourceFold "Fun.GaussLobattoIntegral" 
                                               [| _maxIterations.source
                                               ;  _absAccuracy.source
                                               ;  _relAccuracy.source
                                               ;  _useConvergenceEstimate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _maxIterations.cell
                                ;  _absAccuracy.cell
                                ;  _relAccuracy.cell
                                ;  _useConvergenceEstimate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussLobattoIntegral> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_GaussLobattoIntegral_absoluteAccuracy", Description="Create a GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLobattoIntegral",Description = "Reference to GaussLobattoIntegral")>] 
         gausslobattointegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLobattoIntegral = Helper.toCell<GaussLobattoIntegral> gausslobattointegral "GaussLobattoIntegral"  
                let builder () = withMnemonic mnemonic ((_GaussLobattoIntegral.cell :?> GaussLobattoIntegralModel).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GaussLobattoIntegral.source + ".AbsoluteAccuracy") 
                                               [| _GaussLobattoIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLobattoIntegral.cell
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
    [<ExcelFunction(Name="_GaussLobattoIntegral_absoluteError", Description="Create a GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLobattoIntegral",Description = "Reference to GaussLobattoIntegral")>] 
         gausslobattointegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLobattoIntegral = Helper.toCell<GaussLobattoIntegral> gausslobattointegral "GaussLobattoIntegral"  
                let builder () = withMnemonic mnemonic ((_GaussLobattoIntegral.cell :?> GaussLobattoIntegralModel).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussLobattoIntegral.source + ".AbsoluteError") 
                                               [| _GaussLobattoIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLobattoIntegral.cell
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
    [<ExcelFunction(Name="_GaussLobattoIntegral_integrationSuccess", Description="Create a GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLobattoIntegral",Description = "Reference to GaussLobattoIntegral")>] 
         gausslobattointegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLobattoIntegral = Helper.toCell<GaussLobattoIntegral> gausslobattointegral "GaussLobattoIntegral"  
                let builder () = withMnemonic mnemonic ((_GaussLobattoIntegral.cell :?> GaussLobattoIntegralModel).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GaussLobattoIntegral.source + ".IntegrationSuccess") 
                                               [| _GaussLobattoIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLobattoIntegral.cell
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
    [<ExcelFunction(Name="_GaussLobattoIntegral_maxEvaluations", Description="Create a GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLobattoIntegral",Description = "Reference to GaussLobattoIntegral")>] 
         gausslobattointegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLobattoIntegral = Helper.toCell<GaussLobattoIntegral> gausslobattointegral "GaussLobattoIntegral"  
                let builder () = withMnemonic mnemonic ((_GaussLobattoIntegral.cell :?> GaussLobattoIntegralModel).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussLobattoIntegral.source + ".MaxEvaluations") 
                                               [| _GaussLobattoIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLobattoIntegral.cell
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
    [<ExcelFunction(Name="_GaussLobattoIntegral_numberOfEvaluations", Description="Create a GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLobattoIntegral",Description = "Reference to GaussLobattoIntegral")>] 
         gausslobattointegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLobattoIntegral = Helper.toCell<GaussLobattoIntegral> gausslobattointegral "GaussLobattoIntegral"  
                let builder () = withMnemonic mnemonic ((_GaussLobattoIntegral.cell :?> GaussLobattoIntegralModel).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussLobattoIntegral.source + ".NumberOfEvaluations") 
                                               [| _GaussLobattoIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLobattoIntegral.cell
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
        Modifiers
    *)
    [<ExcelFunction(Name="_GaussLobattoIntegral_setAbsoluteAccuracy", Description="Create a GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLobattoIntegral",Description = "Reference to GaussLobattoIntegral")>] 
         gausslobattointegral : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLobattoIntegral = Helper.toCell<GaussLobattoIntegral> gausslobattointegral "GaussLobattoIntegral"  
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder () = withMnemonic mnemonic ((_GaussLobattoIntegral.cell :?> GaussLobattoIntegralModel).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : GaussLobattoIntegral) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GaussLobattoIntegral.source + ".SetAbsoluteAccuracy") 
                                               [| _GaussLobattoIntegral.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLobattoIntegral.cell
                                ;  _accuracy.cell
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
    [<ExcelFunction(Name="_GaussLobattoIntegral_setMaxEvaluations", Description="Create a GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLobattoIntegral",Description = "Reference to GaussLobattoIntegral")>] 
         gausslobattointegral : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLobattoIntegral = Helper.toCell<GaussLobattoIntegral> gausslobattointegral "GaussLobattoIntegral"  
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_GaussLobattoIntegral.cell :?> GaussLobattoIntegralModel).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : GaussLobattoIntegral) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GaussLobattoIntegral.source + ".SetMaxEvaluations") 
                                               [| _GaussLobattoIntegral.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLobattoIntegral.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_GaussLobattoIntegral_value", Description="Create a GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussLobattoIntegral",Description = "Reference to GaussLobattoIntegral")>] 
         gausslobattointegral : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussLobattoIntegral = Helper.toCell<GaussLobattoIntegral> gausslobattointegral "GaussLobattoIntegral"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder () = withMnemonic mnemonic ((_GaussLobattoIntegral.cell :?> GaussLobattoIntegralModel).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussLobattoIntegral.source + ".Value") 
                                               [| _GaussLobattoIntegral.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussLobattoIntegral.cell
                                ;  _f.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_GaussLobattoIntegral_Range", Description="Create a range of GaussLobattoIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussLobattoIntegral_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussLobattoIntegral")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussLobattoIntegral> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussLobattoIntegral>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussLobattoIntegral>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussLobattoIntegral>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
