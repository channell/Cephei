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
  Integral of a one-dimensional function   Given a number N of intervals, the integral of a function f between a and b is calculated by means of the trapezoid formula f = f(x_{0}) + f(x_{1}) + f(x_{2}) + + f(x_{N-1}) + f(x_{N}) where x_0 = a x_N = b and x_i = a+i x with x = (b-a)/N  the correctness of the result is tested by checking it against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module SegmentIntegralFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SegmentIntegral", Description="Create a SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="intervals",Description = "Reference to intervals")>] 
         intervals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _intervals = Helper.toCell<int> intervals "intervals" 
                let builder () = withMnemonic mnemonic (Fun.SegmentIntegral 
                                                            _intervals.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SegmentIntegral>) l

                let source = Helper.sourceFold "Fun.SegmentIntegral" 
                                               [| _intervals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _intervals.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SegmentIntegral> format
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
    [<ExcelFunction(Name="_SegmentIntegral_absoluteAccuracy", Description="Create a SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SegmentIntegral",Description = "Reference to SegmentIntegral")>] 
         segmentintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SegmentIntegral = Helper.toCell<SegmentIntegral> segmentintegral "SegmentIntegral"  
                let builder () = withMnemonic mnemonic ((_SegmentIntegral.cell :?> SegmentIntegralModel).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SegmentIntegral.source + ".AbsoluteAccuracy") 
                                               [| _SegmentIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SegmentIntegral.cell
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
    [<ExcelFunction(Name="_SegmentIntegral_absoluteError", Description="Create a SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SegmentIntegral",Description = "Reference to SegmentIntegral")>] 
         segmentintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SegmentIntegral = Helper.toCell<SegmentIntegral> segmentintegral "SegmentIntegral"  
                let builder () = withMnemonic mnemonic ((_SegmentIntegral.cell :?> SegmentIntegralModel).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SegmentIntegral.source + ".AbsoluteError") 
                                               [| _SegmentIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SegmentIntegral.cell
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
    [<ExcelFunction(Name="_SegmentIntegral_integrationSuccess", Description="Create a SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SegmentIntegral",Description = "Reference to SegmentIntegral")>] 
         segmentintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SegmentIntegral = Helper.toCell<SegmentIntegral> segmentintegral "SegmentIntegral"  
                let builder () = withMnemonic mnemonic ((_SegmentIntegral.cell :?> SegmentIntegralModel).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SegmentIntegral.source + ".IntegrationSuccess") 
                                               [| _SegmentIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SegmentIntegral.cell
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
    [<ExcelFunction(Name="_SegmentIntegral_maxEvaluations", Description="Create a SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SegmentIntegral",Description = "Reference to SegmentIntegral")>] 
         segmentintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SegmentIntegral = Helper.toCell<SegmentIntegral> segmentintegral "SegmentIntegral"  
                let builder () = withMnemonic mnemonic ((_SegmentIntegral.cell :?> SegmentIntegralModel).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SegmentIntegral.source + ".MaxEvaluations") 
                                               [| _SegmentIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SegmentIntegral.cell
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
    [<ExcelFunction(Name="_SegmentIntegral_numberOfEvaluations", Description="Create a SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SegmentIntegral",Description = "Reference to SegmentIntegral")>] 
         segmentintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SegmentIntegral = Helper.toCell<SegmentIntegral> segmentintegral "SegmentIntegral"  
                let builder () = withMnemonic mnemonic ((_SegmentIntegral.cell :?> SegmentIntegralModel).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SegmentIntegral.source + ".NumberOfEvaluations") 
                                               [| _SegmentIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SegmentIntegral.cell
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
    [<ExcelFunction(Name="_SegmentIntegral_setAbsoluteAccuracy", Description="Create a SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SegmentIntegral",Description = "Reference to SegmentIntegral")>] 
         segmentintegral : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SegmentIntegral = Helper.toCell<SegmentIntegral> segmentintegral "SegmentIntegral"  
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder () = withMnemonic mnemonic ((_SegmentIntegral.cell :?> SegmentIntegralModel).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : SegmentIntegral) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SegmentIntegral.source + ".SetAbsoluteAccuracy") 
                                               [| _SegmentIntegral.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SegmentIntegral.cell
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
    [<ExcelFunction(Name="_SegmentIntegral_setMaxEvaluations", Description="Create a SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SegmentIntegral",Description = "Reference to SegmentIntegral")>] 
         segmentintegral : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SegmentIntegral = Helper.toCell<SegmentIntegral> segmentintegral "SegmentIntegral"  
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_SegmentIntegral.cell :?> SegmentIntegralModel).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : SegmentIntegral) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SegmentIntegral.source + ".SetMaxEvaluations") 
                                               [| _SegmentIntegral.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SegmentIntegral.cell
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
    [<ExcelFunction(Name="_SegmentIntegral_value", Description="Create a SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SegmentIntegral",Description = "Reference to SegmentIntegral")>] 
         segmentintegral : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SegmentIntegral = Helper.toCell<SegmentIntegral> segmentintegral "SegmentIntegral"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder () = withMnemonic mnemonic ((_SegmentIntegral.cell :?> SegmentIntegralModel).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SegmentIntegral.source + ".Value") 
                                               [| _SegmentIntegral.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SegmentIntegral.cell
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
    [<ExcelFunction(Name="_SegmentIntegral_Range", Description="Create a range of SegmentIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SegmentIntegral_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SegmentIntegral")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SegmentIntegral> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SegmentIntegral>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SegmentIntegral>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SegmentIntegral>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
