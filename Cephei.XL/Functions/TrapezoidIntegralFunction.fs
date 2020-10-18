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
(*!! generic
(* <summary>
  Given a target accuracy the integral of a function f between a and b is calculated by means of the trapezoid formula f = f(x_{0}) + f(x_{1}) + f(x_{2}) + + f(x_{N-1}) + f(x_{N}) where x_0 = a x_N = b and x_i = a+i x with x = (b-a)/N The number N of intervals is repeatedly increased until the target accuracy is reached.  the correctness of the result is tested by checking it against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module TrapezoidIntegralFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TrapezoidIntegral", Description="Create a TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_create
        ([<ExcelArgument(Name="Mnemonic",Description = "TrapezoidIntegral")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxIterations",Description = "int")>] 
         maxIterations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxIterations = Helper.toCell<int> maxIterations "maxIterations" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TrapezoidIntegral 
                                                            _accuracy.cell 
                                                            _maxIterations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TrapezoidIntegral>) l

                let source () = Helper.sourceFold "Fun.TrapezoidIntegral" 
                                               [| _accuracy.source
                                               ;  _maxIterations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _accuracy.cell
                                ;  _maxIterations.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TrapezoidIntegral> format
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
    [<ExcelFunction(Name="_TrapezoidIntegral_absoluteAccuracy", Description="Create a TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrapezoidIntegral",Description = "TrapezoidIntegral")>] 
         trapezoidintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrapezoidIntegral = Helper.toCell<TrapezoidIntegral> trapezoidintegral "TrapezoidIntegral"  
                let builder (current : ICell) = withMnemonic mnemonic ((TrapezoidIntegralModel.Cast _TrapezoidIntegral.cell).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TrapezoidIntegral.source + ".AbsoluteAccuracy") 
                                               [| _TrapezoidIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrapezoidIntegral.cell
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
    [<ExcelFunction(Name="_TrapezoidIntegral_absoluteError", Description="Create a TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrapezoidIntegral",Description = "TrapezoidIntegral")>] 
         trapezoidintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrapezoidIntegral = Helper.toCell<TrapezoidIntegral> trapezoidintegral "TrapezoidIntegral"  
                let builder (current : ICell) = withMnemonic mnemonic ((TrapezoidIntegralModel.Cast _TrapezoidIntegral.cell).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrapezoidIntegral.source + ".AbsoluteError") 
                                               [| _TrapezoidIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrapezoidIntegral.cell
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
    [<ExcelFunction(Name="_TrapezoidIntegral_integrationSuccess", Description="Create a TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrapezoidIntegral",Description = "TrapezoidIntegral")>] 
         trapezoidintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrapezoidIntegral = Helper.toCell<TrapezoidIntegral> trapezoidintegral "TrapezoidIntegral"  
                let builder (current : ICell) = withMnemonic mnemonic ((TrapezoidIntegralModel.Cast _TrapezoidIntegral.cell).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TrapezoidIntegral.source + ".IntegrationSuccess") 
                                               [| _TrapezoidIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrapezoidIntegral.cell
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
    [<ExcelFunction(Name="_TrapezoidIntegral_maxEvaluations", Description="Create a TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrapezoidIntegral",Description = "TrapezoidIntegral")>] 
         trapezoidintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrapezoidIntegral = Helper.toCell<TrapezoidIntegral> trapezoidintegral "TrapezoidIntegral"  
                let builder (current : ICell) = withMnemonic mnemonic ((TrapezoidIntegralModel.Cast _TrapezoidIntegral.cell).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrapezoidIntegral.source + ".MaxEvaluations") 
                                               [| _TrapezoidIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrapezoidIntegral.cell
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
    [<ExcelFunction(Name="_TrapezoidIntegral_numberOfEvaluations", Description="Create a TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrapezoidIntegral",Description = "TrapezoidIntegral")>] 
         trapezoidintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrapezoidIntegral = Helper.toCell<TrapezoidIntegral> trapezoidintegral "TrapezoidIntegral"  
                let builder (current : ICell) = withMnemonic mnemonic ((TrapezoidIntegralModel.Cast _TrapezoidIntegral.cell).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrapezoidIntegral.source + ".NumberOfEvaluations") 
                                               [| _TrapezoidIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrapezoidIntegral.cell
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
        Modifiers
    *)
    [<ExcelFunction(Name="_TrapezoidIntegral_setAbsoluteAccuracy", Description="Create a TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrapezoidIntegral",Description = "TrapezoidIntegral")>] 
         trapezoidintegral : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrapezoidIntegral = Helper.toCell<TrapezoidIntegral> trapezoidintegral "TrapezoidIntegral"  
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrapezoidIntegralModel.Cast _TrapezoidIntegral.cell).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : TrapezoidIntegral) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TrapezoidIntegral.source + ".SetAbsoluteAccuracy") 
                                               [| _TrapezoidIntegral.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrapezoidIntegral.cell
                                ;  _accuracy.cell
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
    [<ExcelFunction(Name="_TrapezoidIntegral_setMaxEvaluations", Description="Create a TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrapezoidIntegral",Description = "TrapezoidIntegral")>] 
         trapezoidintegral : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrapezoidIntegral = Helper.toCell<TrapezoidIntegral> trapezoidintegral "TrapezoidIntegral"  
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrapezoidIntegralModel.Cast _TrapezoidIntegral.cell).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : TrapezoidIntegral) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TrapezoidIntegral.source + ".SetMaxEvaluations") 
                                               [| _TrapezoidIntegral.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrapezoidIntegral.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_TrapezoidIntegral_value", Description="Create a TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrapezoidIntegral",Description = "TrapezoidIntegral")>] 
         trapezoidintegral : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrapezoidIntegral = Helper.toCell<TrapezoidIntegral> trapezoidintegral "TrapezoidIntegral"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrapezoidIntegralModel.Cast _TrapezoidIntegral.cell).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrapezoidIntegral.source + ".Value") 
                                               [| _TrapezoidIntegral.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrapezoidIntegral.cell
                                ;  _f.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_TrapezoidIntegral_Range", Description="Create a range of TrapezoidIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrapezoidIntegral_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TrapezoidIntegral> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TrapezoidIntegral>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TrapezoidIntegral>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TrapezoidIntegral>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
