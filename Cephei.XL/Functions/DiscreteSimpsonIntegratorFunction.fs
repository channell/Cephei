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
module DiscreteSimpsonIntegratorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator", Description="Create a DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluations",Description = "Reference to evaluations")>] 
         evaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluations = Helper.toCell<int> evaluations "evaluations" 
                let builder () = withMnemonic mnemonic (Fun.DiscreteSimpsonIntegrator 
                                                            _evaluations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscreteSimpsonIntegrator>) l

                let source = Helper.sourceFold "Fun.DiscreteSimpsonIntegrator" 
                                               [| _evaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _evaluations.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscreteSimpsonIntegrator> format
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator_absoluteAccuracy", Description="Create a DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteSimpsonIntegrator",Description = "Reference to DiscreteSimpsonIntegrator")>] 
         discretesimpsonintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteSimpsonIntegrator = Helper.toCell<DiscreteSimpsonIntegrator> discretesimpsonintegrator "DiscreteSimpsonIntegrator"  
                let builder () = withMnemonic mnemonic ((_DiscreteSimpsonIntegrator.cell :?> DiscreteSimpsonIntegratorModel).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscreteSimpsonIntegrator.source + ".AbsoluteAccuracy") 
                                               [| _DiscreteSimpsonIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteSimpsonIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator_absoluteError", Description="Create a DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteSimpsonIntegrator",Description = "Reference to DiscreteSimpsonIntegrator")>] 
         discretesimpsonintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteSimpsonIntegrator = Helper.toCell<DiscreteSimpsonIntegrator> discretesimpsonintegrator "DiscreteSimpsonIntegrator"  
                let builder () = withMnemonic mnemonic ((_DiscreteSimpsonIntegrator.cell :?> DiscreteSimpsonIntegratorModel).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteSimpsonIntegrator.source + ".AbsoluteError") 
                                               [| _DiscreteSimpsonIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteSimpsonIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator_integrationSuccess", Description="Create a DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteSimpsonIntegrator",Description = "Reference to DiscreteSimpsonIntegrator")>] 
         discretesimpsonintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteSimpsonIntegrator = Helper.toCell<DiscreteSimpsonIntegrator> discretesimpsonintegrator "DiscreteSimpsonIntegrator"  
                let builder () = withMnemonic mnemonic ((_DiscreteSimpsonIntegrator.cell :?> DiscreteSimpsonIntegratorModel).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscreteSimpsonIntegrator.source + ".IntegrationSuccess") 
                                               [| _DiscreteSimpsonIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteSimpsonIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator_maxEvaluations", Description="Create a DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteSimpsonIntegrator",Description = "Reference to DiscreteSimpsonIntegrator")>] 
         discretesimpsonintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteSimpsonIntegrator = Helper.toCell<DiscreteSimpsonIntegrator> discretesimpsonintegrator "DiscreteSimpsonIntegrator"  
                let builder () = withMnemonic mnemonic ((_DiscreteSimpsonIntegrator.cell :?> DiscreteSimpsonIntegratorModel).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteSimpsonIntegrator.source + ".MaxEvaluations") 
                                               [| _DiscreteSimpsonIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteSimpsonIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator_numberOfEvaluations", Description="Create a DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteSimpsonIntegrator",Description = "Reference to DiscreteSimpsonIntegrator")>] 
         discretesimpsonintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteSimpsonIntegrator = Helper.toCell<DiscreteSimpsonIntegrator> discretesimpsonintegrator "DiscreteSimpsonIntegrator"  
                let builder () = withMnemonic mnemonic ((_DiscreteSimpsonIntegrator.cell :?> DiscreteSimpsonIntegratorModel).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteSimpsonIntegrator.source + ".NumberOfEvaluations") 
                                               [| _DiscreteSimpsonIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteSimpsonIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator_setAbsoluteAccuracy", Description="Create a DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteSimpsonIntegrator",Description = "Reference to DiscreteSimpsonIntegrator")>] 
         discretesimpsonintegrator : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteSimpsonIntegrator = Helper.toCell<DiscreteSimpsonIntegrator> discretesimpsonintegrator "DiscreteSimpsonIntegrator"  
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder () = withMnemonic mnemonic ((_DiscreteSimpsonIntegrator.cell :?> DiscreteSimpsonIntegratorModel).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : DiscreteSimpsonIntegrator) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscreteSimpsonIntegrator.source + ".SetAbsoluteAccuracy") 
                                               [| _DiscreteSimpsonIntegrator.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteSimpsonIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator_setMaxEvaluations", Description="Create a DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteSimpsonIntegrator",Description = "Reference to DiscreteSimpsonIntegrator")>] 
         discretesimpsonintegrator : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteSimpsonIntegrator = Helper.toCell<DiscreteSimpsonIntegrator> discretesimpsonintegrator "DiscreteSimpsonIntegrator"  
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_DiscreteSimpsonIntegrator.cell :?> DiscreteSimpsonIntegratorModel).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : DiscreteSimpsonIntegrator) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscreteSimpsonIntegrator.source + ".SetMaxEvaluations") 
                                               [| _DiscreteSimpsonIntegrator.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteSimpsonIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator_value", Description="Create a DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteSimpsonIntegrator",Description = "Reference to DiscreteSimpsonIntegrator")>] 
         discretesimpsonintegrator : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteSimpsonIntegrator = Helper.toCell<DiscreteSimpsonIntegrator> discretesimpsonintegrator "DiscreteSimpsonIntegrator"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder () = withMnemonic mnemonic ((_DiscreteSimpsonIntegrator.cell :?> DiscreteSimpsonIntegratorModel).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscreteSimpsonIntegrator.source + ".Value") 
                                               [| _DiscreteSimpsonIntegrator.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteSimpsonIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteSimpsonIntegrator_Range", Description="Create a range of DiscreteSimpsonIntegrator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscreteSimpsonIntegrator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscreteSimpsonIntegrator")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscreteSimpsonIntegrator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscreteSimpsonIntegrator>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscreteSimpsonIntegrator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DiscreteSimpsonIntegrator>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
