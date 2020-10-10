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
  Integral of a 1-dimensional function using the Gauss-Kronrod methods   This class provide a non-adaptive integration procedure which uses fixed Gauss-Kronrod abscissae to sample the integrand at a maximum of 87 points.  It is provided for fast integration of smooth functions.  This function applies the Gauss-Kronrod 10-point, 21-point, 43-point and 87-point integration rules in succession until an estimate of the integral of f over (a, b) is achieved within the desired absolute and relative error limits, epsabs and epsrel. The function returns the final approximation, result, an estimate of the absolute error, abserr and the number of function evaluations used, neval. The Gauss-Kronrod rules are designed in such a way that each rule uses all the results of its predecessors, in order to minimize the total number of function evaluations.
  </summary> *)
[<AutoSerializable(true)>]
module GaussKronrodNonAdaptiveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="absoluteAccuracy",Description = "Reference to absoluteAccuracy")>] 
         absoluteAccuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="relativeAccuracy",Description = "Reference to relativeAccuracy")>] 
         relativeAccuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _absoluteAccuracy = Helper.toCell<double> absoluteAccuracy "absoluteAccuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _relativeAccuracy = Helper.toCell<double> relativeAccuracy "relativeAccuracy" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GaussKronrodNonAdaptive 
                                                            _absoluteAccuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _relativeAccuracy.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussKronrodNonAdaptive>) l

                let source () = Helper.sourceFold "Fun.GaussKronrodNonAdaptive" 
                                               [| _absoluteAccuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _relativeAccuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _absoluteAccuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _relativeAccuracy.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussKronrodNonAdaptive> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_relativeAccuracy", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_relativeAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodNonAdaptive",Description = "Reference to GaussKronrodNonAdaptive")>] 
         gausskronrodnonadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodNonAdaptive = Helper.toCell<GaussKronrodNonAdaptive> gausskronrodnonadaptive "GaussKronrodNonAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodNonAdaptiveModel.Cast _GaussKronrodNonAdaptive.cell).RelativeAccuracy
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussKronrodNonAdaptive.source + ".RelativeAccuracy") 
                                               [| _GaussKronrodNonAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodNonAdaptive.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_absoluteAccuracy", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodNonAdaptive",Description = "Reference to GaussKronrodNonAdaptive")>] 
         gausskronrodnonadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodNonAdaptive = Helper.toCell<GaussKronrodNonAdaptive> gausskronrodnonadaptive "GaussKronrodNonAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodNonAdaptiveModel.Cast _GaussKronrodNonAdaptive.cell).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GaussKronrodNonAdaptive.source + ".AbsoluteAccuracy") 
                                               [| _GaussKronrodNonAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodNonAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_absoluteError", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodNonAdaptive",Description = "Reference to GaussKronrodNonAdaptive")>] 
         gausskronrodnonadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodNonAdaptive = Helper.toCell<GaussKronrodNonAdaptive> gausskronrodnonadaptive "GaussKronrodNonAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodNonAdaptiveModel.Cast _GaussKronrodNonAdaptive.cell).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussKronrodNonAdaptive.source + ".AbsoluteError") 
                                               [| _GaussKronrodNonAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodNonAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_integrationSuccess", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodNonAdaptive",Description = "Reference to GaussKronrodNonAdaptive")>] 
         gausskronrodnonadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodNonAdaptive = Helper.toCell<GaussKronrodNonAdaptive> gausskronrodnonadaptive "GaussKronrodNonAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodNonAdaptiveModel.Cast _GaussKronrodNonAdaptive.cell).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GaussKronrodNonAdaptive.source + ".IntegrationSuccess") 
                                               [| _GaussKronrodNonAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodNonAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_maxEvaluations", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodNonAdaptive",Description = "Reference to GaussKronrodNonAdaptive")>] 
         gausskronrodnonadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodNonAdaptive = Helper.toCell<GaussKronrodNonAdaptive> gausskronrodnonadaptive "GaussKronrodNonAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodNonAdaptiveModel.Cast _GaussKronrodNonAdaptive.cell).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussKronrodNonAdaptive.source + ".MaxEvaluations") 
                                               [| _GaussKronrodNonAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodNonAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_numberOfEvaluations", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodNonAdaptive",Description = "Reference to GaussKronrodNonAdaptive")>] 
         gausskronrodnonadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodNonAdaptive = Helper.toCell<GaussKronrodNonAdaptive> gausskronrodnonadaptive "GaussKronrodNonAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodNonAdaptiveModel.Cast _GaussKronrodNonAdaptive.cell).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussKronrodNonAdaptive.source + ".NumberOfEvaluations") 
                                               [| _GaussKronrodNonAdaptive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodNonAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_setAbsoluteAccuracy", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodNonAdaptive",Description = "Reference to GaussKronrodNonAdaptive")>] 
         gausskronrodnonadaptive : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodNonAdaptive = Helper.toCell<GaussKronrodNonAdaptive> gausskronrodnonadaptive "GaussKronrodNonAdaptive"  
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodNonAdaptiveModel.Cast _GaussKronrodNonAdaptive.cell).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : GaussKronrodNonAdaptive) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GaussKronrodNonAdaptive.source + ".SetAbsoluteAccuracy") 
                                               [| _GaussKronrodNonAdaptive.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodNonAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_setMaxEvaluations", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodNonAdaptive",Description = "Reference to GaussKronrodNonAdaptive")>] 
         gausskronrodnonadaptive : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodNonAdaptive = Helper.toCell<GaussKronrodNonAdaptive> gausskronrodnonadaptive "GaussKronrodNonAdaptive"  
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodNonAdaptiveModel.Cast _GaussKronrodNonAdaptive.cell).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : GaussKronrodNonAdaptive) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GaussKronrodNonAdaptive.source + ".SetMaxEvaluations") 
                                               [| _GaussKronrodNonAdaptive.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodNonAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_value", Description="Create a GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodNonAdaptive",Description = "Reference to GaussKronrodNonAdaptive")>] 
         gausskronrodnonadaptive : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodNonAdaptive = Helper.toCell<GaussKronrodNonAdaptive> gausskronrodnonadaptive "GaussKronrodNonAdaptive"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodNonAdaptiveModel.Cast _GaussKronrodNonAdaptive.cell).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussKronrodNonAdaptive.source + ".Value") 
                                               [| _GaussKronrodNonAdaptive.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodNonAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodNonAdaptive_Range", Description="Create a range of GaussKronrodNonAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodNonAdaptive_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussKronrodNonAdaptive")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussKronrodNonAdaptive> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussKronrodNonAdaptive>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussKronrodNonAdaptive>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GaussKronrodNonAdaptive>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
