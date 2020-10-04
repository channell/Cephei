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
  In one dimension the Crank-Nicolson scheme is equivalent to the Douglas scheme and in higher dimensions it is usually inferior to operator splitting methods like Craig-Sneyd or Hundsdorfer-Verwer.
  </summary> *)
[<AutoSerializable(true)>]
module MethodOfLinesSchemeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MethodOfLinesScheme_factory", Description="Create a MethodOfLinesScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MethodOfLinesScheme_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MethodOfLinesScheme",Description = "Reference to MethodOfLinesScheme")>] 
         methodoflinesscheme : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        ([<ExcelArgument(Name="additionalInputs",Description = "Reference to additionalInputs")>] 
         additionalInputs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MethodOfLinesScheme = Helper.toCell<MethodOfLinesScheme> methodoflinesscheme "MethodOfLinesScheme"  
                let _L = Helper.toCell<Object> L "L" 
                let _bcs = Helper.toCell<Object> bcs "bcs" 
                let _additionalInputs = Helper.toDefault<Object[]> additionalInputs "additionalInputs" null
                let builder () = withMnemonic mnemonic ((MethodOfLinesSchemeModel.Cast _MethodOfLinesScheme.cell).Factory
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _additionalInputs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IMixedScheme>) l

                let source = Helper.sourceFold (_MethodOfLinesScheme.source + ".Factory") 
                                               [| _MethodOfLinesScheme.source
                                               ;  _L.source
                                               ;  _bcs.source
                                               ;  _additionalInputs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MethodOfLinesScheme.cell
                                ;  _L.cell
                                ;  _bcs.cell
                                ;  _additionalInputs.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MethodOfLinesScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MethodOfLinesScheme", Description="Create a MethodOfLinesScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MethodOfLinesScheme_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="eps",Description = "Reference to eps")>] 
         eps : obj)
        ([<ExcelArgument(Name="relInitStepSize",Description = "Reference to relInitStepSize")>] 
         relInitStepSize : obj)
        ([<ExcelArgument(Name="map",Description = "Reference to map")>] 
         map : obj)
        ([<ExcelArgument(Name="bcSet",Description = "Reference to bcSet")>] 
         bcSet : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _eps = Helper.toCell<double> eps "eps" 
                let _relInitStepSize = Helper.toCell<double> relInitStepSize "relInitStepSize" 
                let _map = Helper.toCell<FdmLinearOpComposite> map "map" 
                let _bcSet = Helper.toDefault<Generic.List<BoundaryCondition<FdmLinearOp>>> bcSet "bcSet" null
                let builder () = withMnemonic mnemonic (Fun.MethodOfLinesScheme 
                                                            _eps.cell 
                                                            _relInitStepSize.cell 
                                                            _map.cell 
                                                            _bcSet.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MethodOfLinesScheme>) l

                let source = Helper.sourceFold "Fun.MethodOfLinesScheme" 
                                               [| _eps.source
                                               ;  _relInitStepSize.source
                                               ;  _map.source
                                               ;  _bcSet.source
                                               |]
                let hash = Helper.hashFold 
                                [| _eps.cell
                                ;  _relInitStepSize.cell
                                ;  _map.cell
                                ;  _bcSet.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MethodOfLinesScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MethodOfLinesScheme1", Description="Create a MethodOfLinesScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MethodOfLinesScheme_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.MethodOfLinesScheme1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MethodOfLinesScheme>) l

                let source = Helper.sourceFold "Fun.MethodOfLinesScheme1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MethodOfLinesScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MethodOfLinesScheme_setStep", Description="Create a MethodOfLinesScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MethodOfLinesScheme_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MethodOfLinesScheme",Description = "Reference to MethodOfLinesScheme")>] 
         methodoflinesscheme : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MethodOfLinesScheme = Helper.toCell<MethodOfLinesScheme> methodoflinesscheme "MethodOfLinesScheme"  
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((MethodOfLinesSchemeModel.Cast _MethodOfLinesScheme.cell).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : MethodOfLinesScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MethodOfLinesScheme.source + ".SetStep") 
                                               [| _MethodOfLinesScheme.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MethodOfLinesScheme.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_MethodOfLinesScheme_step", Description="Create a MethodOfLinesScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MethodOfLinesScheme_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MethodOfLinesScheme",Description = "Reference to MethodOfLinesScheme")>] 
         methodoflinesscheme : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MethodOfLinesScheme = Helper.toCell<MethodOfLinesScheme> methodoflinesscheme "MethodOfLinesScheme"  
                let _a = Helper.toCell<Object> a "a" 
                let _t = Helper.toCell<double> t "t" 
                let _theta = Helper.toDefault<double> theta "theta" 1.0
                let builder () = withMnemonic mnemonic ((MethodOfLinesSchemeModel.Cast _MethodOfLinesScheme.cell).Step
                                                            _a.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : MethodOfLinesScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MethodOfLinesScheme.source + ".Step") 
                                               [| _MethodOfLinesScheme.source
                                               ;  _a.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MethodOfLinesScheme.cell
                                ;  _a.cell
                                ;  _t.cell
                                ;  _theta.cell
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
    [<ExcelFunction(Name="_MethodOfLinesScheme_Range", Description="Create a range of MethodOfLinesScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MethodOfLinesScheme_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MethodOfLinesScheme")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MethodOfLinesScheme> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MethodOfLinesScheme>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MethodOfLinesScheme>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MethodOfLinesScheme>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
