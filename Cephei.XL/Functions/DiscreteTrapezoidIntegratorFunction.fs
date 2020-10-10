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
module DiscreteTrapezoidIntegratorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator", Description="Create a DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluations",Description = "Reference to evaluations")>] 
         evaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluations = Helper.toCell<int> evaluations "evaluations" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DiscreteTrapezoidIntegrator 
                                                            _evaluations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscreteTrapezoidIntegrator>) l

                let source () = Helper.sourceFold "Fun.DiscreteTrapezoidIntegrator" 
                                               [| _evaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _evaluations.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscreteTrapezoidIntegrator> format
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator_absoluteAccuracy", Description="Create a DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteTrapezoidIntegrator",Description = "Reference to DiscreteTrapezoidIntegrator")>] 
         discretetrapezoidintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteTrapezoidIntegrator = Helper.toCell<DiscreteTrapezoidIntegrator> discretetrapezoidintegrator "DiscreteTrapezoidIntegrator"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscreteTrapezoidIntegratorModel.Cast _DiscreteTrapezoidIntegrator.cell).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscreteTrapezoidIntegrator.source + ".AbsoluteAccuracy") 
                                               [| _DiscreteTrapezoidIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteTrapezoidIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator_absoluteError", Description="Create a DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteTrapezoidIntegrator",Description = "Reference to DiscreteTrapezoidIntegrator")>] 
         discretetrapezoidintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteTrapezoidIntegrator = Helper.toCell<DiscreteTrapezoidIntegrator> discretetrapezoidintegrator "DiscreteTrapezoidIntegrator"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscreteTrapezoidIntegratorModel.Cast _DiscreteTrapezoidIntegrator.cell).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscreteTrapezoidIntegrator.source + ".AbsoluteError") 
                                               [| _DiscreteTrapezoidIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteTrapezoidIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator_integrationSuccess", Description="Create a DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteTrapezoidIntegrator",Description = "Reference to DiscreteTrapezoidIntegrator")>] 
         discretetrapezoidintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteTrapezoidIntegrator = Helper.toCell<DiscreteTrapezoidIntegrator> discretetrapezoidintegrator "DiscreteTrapezoidIntegrator"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscreteTrapezoidIntegratorModel.Cast _DiscreteTrapezoidIntegrator.cell).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscreteTrapezoidIntegrator.source + ".IntegrationSuccess") 
                                               [| _DiscreteTrapezoidIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteTrapezoidIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator_maxEvaluations", Description="Create a DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteTrapezoidIntegrator",Description = "Reference to DiscreteTrapezoidIntegrator")>] 
         discretetrapezoidintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteTrapezoidIntegrator = Helper.toCell<DiscreteTrapezoidIntegrator> discretetrapezoidintegrator "DiscreteTrapezoidIntegrator"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscreteTrapezoidIntegratorModel.Cast _DiscreteTrapezoidIntegrator.cell).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscreteTrapezoidIntegrator.source + ".MaxEvaluations") 
                                               [| _DiscreteTrapezoidIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteTrapezoidIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator_numberOfEvaluations", Description="Create a DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteTrapezoidIntegrator",Description = "Reference to DiscreteTrapezoidIntegrator")>] 
         discretetrapezoidintegrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteTrapezoidIntegrator = Helper.toCell<DiscreteTrapezoidIntegrator> discretetrapezoidintegrator "DiscreteTrapezoidIntegrator"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscreteTrapezoidIntegratorModel.Cast _DiscreteTrapezoidIntegrator.cell).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscreteTrapezoidIntegrator.source + ".NumberOfEvaluations") 
                                               [| _DiscreteTrapezoidIntegrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteTrapezoidIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator_setAbsoluteAccuracy", Description="Create a DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteTrapezoidIntegrator",Description = "Reference to DiscreteTrapezoidIntegrator")>] 
         discretetrapezoidintegrator : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteTrapezoidIntegrator = Helper.toCell<DiscreteTrapezoidIntegrator> discretetrapezoidintegrator "DiscreteTrapezoidIntegrator"  
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscreteTrapezoidIntegratorModel.Cast _DiscreteTrapezoidIntegrator.cell).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : DiscreteTrapezoidIntegrator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscreteTrapezoidIntegrator.source + ".SetAbsoluteAccuracy") 
                                               [| _DiscreteTrapezoidIntegrator.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteTrapezoidIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator_setMaxEvaluations", Description="Create a DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteTrapezoidIntegrator",Description = "Reference to DiscreteTrapezoidIntegrator")>] 
         discretetrapezoidintegrator : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteTrapezoidIntegrator = Helper.toCell<DiscreteTrapezoidIntegrator> discretetrapezoidintegrator "DiscreteTrapezoidIntegrator"  
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscreteTrapezoidIntegratorModel.Cast _DiscreteTrapezoidIntegrator.cell).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : DiscreteTrapezoidIntegrator) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscreteTrapezoidIntegrator.source + ".SetMaxEvaluations") 
                                               [| _DiscreteTrapezoidIntegrator.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteTrapezoidIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator_value", Description="Create a DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscreteTrapezoidIntegrator",Description = "Reference to DiscreteTrapezoidIntegrator")>] 
         discretetrapezoidintegrator : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscreteTrapezoidIntegrator = Helper.toCell<DiscreteTrapezoidIntegrator> discretetrapezoidintegrator "DiscreteTrapezoidIntegrator"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscreteTrapezoidIntegratorModel.Cast _DiscreteTrapezoidIntegrator.cell).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscreteTrapezoidIntegrator.source + ".Value") 
                                               [| _DiscreteTrapezoidIntegrator.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscreteTrapezoidIntegrator.cell
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
    [<ExcelFunction(Name="_DiscreteTrapezoidIntegrator_Range", Description="Create a range of DiscreteTrapezoidIntegrator",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscreteTrapezoidIntegrator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscreteTrapezoidIntegrator")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscreteTrapezoidIntegrator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscreteTrapezoidIntegrator>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscreteTrapezoidIntegrator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DiscreteTrapezoidIntegrator>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
