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
  the correctness of the result is tested by checking it against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module SimpsonIntegralFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SimpsonIntegral", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
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
                let builder (current : ICell) = (Fun.SimpsonIntegral 
                                                            _accuracy.cell 
                                                            _maxIterations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SimpsonIntegral>) l

                let source () = Helper.sourceFold "Fun.SimpsonIntegral" 
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
                    ; subscriber = Helper.subscriberModel<SimpsonIntegral> format
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
    [<ExcelFunction(Name="_SimpsonIntegral_absoluteAccuracy", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toModelReference<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder (current : ICell) = ((SimpsonIntegralModel.Cast _SimpsonIntegral.cell).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimpsonIntegral.source + ".AbsoluteAccuracy") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_absoluteError", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toModelReference<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder (current : ICell) = ((SimpsonIntegralModel.Cast _SimpsonIntegral.cell).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimpsonIntegral.source + ".AbsoluteError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_integrationSuccess", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toModelReference<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder (current : ICell) = ((SimpsonIntegralModel.Cast _SimpsonIntegral.cell).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimpsonIntegral.source + ".IntegrationSuccess") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_maxEvaluations", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toModelReference<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder (current : ICell) = ((SimpsonIntegralModel.Cast _SimpsonIntegral.cell).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimpsonIntegral.source + ".MaxEvaluations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_numberOfEvaluations", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toModelReference<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder (current : ICell) = ((SimpsonIntegralModel.Cast _SimpsonIntegral.cell).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimpsonIntegral.source + ".NumberOfEvaluations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_setAbsoluteAccuracy", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "SimpsonIntegral")>] 
         simpsonintegral : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toModelReference<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder (current : ICell) = ((SimpsonIntegralModel.Cast _SimpsonIntegral.cell).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : SimpsonIntegral) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimpsonIntegral.source + ".SetAbsoluteAccuracy") 

                                               [| _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_setMaxEvaluations", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "SimpsonIntegral")>] 
         simpsonintegral : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toModelReference<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = ((SimpsonIntegralModel.Cast _SimpsonIntegral.cell).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : SimpsonIntegral) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimpsonIntegral.source + ".SetMaxEvaluations") 

                                               [| _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_value", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "SimpsonIntegral")>] 
         simpsonintegral : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toModelReference<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder (current : ICell) = ((SimpsonIntegralModel.Cast _SimpsonIntegral.cell).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimpsonIntegral.source + ".Value") 

                                               [| _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_Range", Description="Create a range of SimpsonIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpsonIntegral_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SimpsonIntegral> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SimpsonIntegral> (c)) :> ICell
                let format (i : Cephei.Cell.List<SimpsonIntegral>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SimpsonIntegral>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
