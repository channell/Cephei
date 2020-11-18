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
  Integral of a 1-dimensional function using the Gauss-Kronrod methods   This class provide an adaptive integration procedure using 15 points Gauss-Kronrod integration rule.  This is more robust in that it allows to integrate less smooth functions (though singular functions should be integrated using dedicated algorithms) but less efficient beacuse it does not reuse precedently computed points during computation steps.  References:  Gauss-Kronrod Integration
<http://mathcssun1.emporia.edu/~oneilcat/ExperimentApplet3/ExperimentApplet3.html>  NMS - Numerical Analysis Library
<http://www.math.iastate.edu/burkardt/f_src/nms/nms.html>  the correctness of the result is tested by checking it against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module GaussKronrodAdaptiveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussKronrodAdaptive", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="absoluteAccuracy",Description = "double")>] 
         absoluteAccuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _absoluteAccuracy = Helper.toCell<double> absoluteAccuracy "absoluteAccuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GaussKronrodAdaptive 
                                                            _absoluteAccuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussKronrodAdaptive>) l

                let source () = Helper.sourceFold "Fun.GaussKronrodAdaptive" 
                                               [| _absoluteAccuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _absoluteAccuracy.cell
                                ;  _maxEvaluations.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussKronrodAdaptive> format
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_absoluteAccuracy", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodAdaptiveModel.Cast _GaussKronrodAdaptive.cell).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GaussKronrodAdaptive.source + ".AbsoluteAccuracy") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_absoluteError", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodAdaptiveModel.Cast _GaussKronrodAdaptive.cell).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussKronrodAdaptive.source + ".AbsoluteError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_integrationSuccess", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodAdaptiveModel.Cast _GaussKronrodAdaptive.cell).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GaussKronrodAdaptive.source + ".IntegrationSuccess") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_maxEvaluations", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodAdaptiveModel.Cast _GaussKronrodAdaptive.cell).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussKronrodAdaptive.source + ".MaxEvaluations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_numberOfEvaluations", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive"  
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodAdaptiveModel.Cast _GaussKronrodAdaptive.cell).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussKronrodAdaptive.source + ".NumberOfEvaluations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_setAbsoluteAccuracy", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive"  
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodAdaptiveModel.Cast _GaussKronrodAdaptive.cell).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : GaussKronrodAdaptive) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GaussKronrodAdaptive.source + ".SetAbsoluteAccuracy") 

                                               [| _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_setMaxEvaluations", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive"  
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodAdaptiveModel.Cast _GaussKronrodAdaptive.cell).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : GaussKronrodAdaptive) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GaussKronrodAdaptive.source + ".SetMaxEvaluations") 

                                               [| _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_value", Description="Create a GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussKronrodAdaptive",Description = "GaussKronrodAdaptive")>] 
         gausskronrodadaptive : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussKronrodAdaptive = Helper.toCell<GaussKronrodAdaptive> gausskronrodadaptive "GaussKronrodAdaptive"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((GaussKronrodAdaptiveModel.Cast _GaussKronrodAdaptive.cell).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussKronrodAdaptive.source + ".Value") 

                                               [| _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussKronrodAdaptive.cell
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
    [<ExcelFunction(Name="_GaussKronrodAdaptive_Range", Description="Create a range of GaussKronrodAdaptive",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussKronrodAdaptive_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussKronrodAdaptive> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<GaussKronrodAdaptive> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<GaussKronrodAdaptive>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GaussKronrodAdaptive>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
