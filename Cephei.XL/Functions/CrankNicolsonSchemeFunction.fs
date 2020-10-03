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
module CrankNicolsonSchemeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CrankNicolsonScheme", Description="Create a CrankNicolsonScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolsonScheme_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        ([<ExcelArgument(Name="map",Description = "Reference to map")>] 
         map : obj)
        ([<ExcelArgument(Name="bcSet",Description = "Reference to bcSet")>] 
         bcSet : obj)
        ([<ExcelArgument(Name="relTol",Description = "Reference to relTol")>] 
         relTol : obj)
        ([<ExcelArgument(Name="solverType",Description = "Reference to solverType")>] 
         solverType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _theta = Helper.toDefault<double> theta "theta" 1.0
                let _map = Helper.toCell<FdmLinearOpComposite> map "map" 
                let _bcSet = Helper.toDefault<Generic.List<BoundaryCondition<FdmLinearOp>>> bcSet "bcSet" null
                let _relTol = Helper.toDefault<double> relTol "relTol" 1E-8
                let _solverType = Helper.toDefault<ImplicitEulerScheme.SolverType> solverType "solverType" ImplicitEulerScheme.SolverType.BiCGstab
                let builder () = withMnemonic mnemonic (Fun.CrankNicolsonScheme 
                                                            _theta.cell 
                                                            _map.cell 
                                                            _bcSet.cell 
                                                            _relTol.cell 
                                                            _solverType.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CrankNicolsonScheme>) l

                let source = Helper.sourceFold "Fun.CrankNicolsonScheme" 
                                               [| _theta.source
                                               ;  _map.source
                                               ;  _bcSet.source
                                               ;  _relTol.source
                                               ;  _solverType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _theta.cell
                                ;  _map.cell
                                ;  _bcSet.cell
                                ;  _relTol.cell
                                ;  _solverType.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CrankNicolsonScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CrankNicolsonScheme1", Description="Create a CrankNicolsonScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolsonScheme_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CrankNicolsonScheme1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CrankNicolsonScheme>) l

                let source = Helper.sourceFold "Fun.CrankNicolsonScheme1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CrankNicolsonScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CrankNicolsonScheme_factory", Description="Create a CrankNicolsonScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolsonScheme_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CrankNicolsonScheme",Description = "Reference to CrankNicolsonScheme")>] 
         cranknicolsonscheme : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        ([<ExcelArgument(Name="additionalInputs",Description = "Reference to additionalInputs")>] 
         additionalInputs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CrankNicolsonScheme = Helper.toCell<CrankNicolsonScheme> cranknicolsonscheme "CrankNicolsonScheme"  
                let _L = Helper.toCell<Object> L "L" 
                let _bcs = Helper.toCell<Object> bcs "bcs" 
                let _additionalInputs = Helper.toDefault<Object[]> additionalInputs "additionalInputs" null
                let builder () = withMnemonic mnemonic ((CrankNicolsonSchemeModel.Cast _CrankNicolsonScheme.cell).Factory
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _additionalInputs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IMixedScheme>) l

                let source = Helper.sourceFold (_CrankNicolsonScheme.source + ".Factory") 
                                               [| _CrankNicolsonScheme.source
                                               ;  _L.source
                                               ;  _bcs.source
                                               ;  _additionalInputs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CrankNicolsonScheme.cell
                                ;  _L.cell
                                ;  _bcs.cell
                                ;  _additionalInputs.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CrankNicolsonScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CrankNicolsonScheme_numberOfIterations", Description="Create a CrankNicolsonScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolsonScheme_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CrankNicolsonScheme",Description = "Reference to CrankNicolsonScheme")>] 
         cranknicolsonscheme : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CrankNicolsonScheme = Helper.toCell<CrankNicolsonScheme> cranknicolsonscheme "CrankNicolsonScheme"  
                let builder () = withMnemonic mnemonic ((CrankNicolsonSchemeModel.Cast _CrankNicolsonScheme.cell).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CrankNicolsonScheme.source + ".NumberOfIterations") 
                                               [| _CrankNicolsonScheme.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CrankNicolsonScheme.cell
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
    [<ExcelFunction(Name="_CrankNicolsonScheme_setStep", Description="Create a CrankNicolsonScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolsonScheme_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CrankNicolsonScheme",Description = "Reference to CrankNicolsonScheme")>] 
         cranknicolsonscheme : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CrankNicolsonScheme = Helper.toCell<CrankNicolsonScheme> cranknicolsonscheme "CrankNicolsonScheme"  
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((CrankNicolsonSchemeModel.Cast _CrankNicolsonScheme.cell).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : CrankNicolsonScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CrankNicolsonScheme.source + ".SetStep") 
                                               [| _CrankNicolsonScheme.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CrankNicolsonScheme.cell
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
    [<ExcelFunction(Name="_CrankNicolsonScheme_step", Description="Create a CrankNicolsonScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolsonScheme_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CrankNicolsonScheme",Description = "Reference to CrankNicolsonScheme")>] 
         cranknicolsonscheme : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CrankNicolsonScheme = Helper.toCell<CrankNicolsonScheme> cranknicolsonscheme "CrankNicolsonScheme"  
                let _a = Helper.toCell<Object> a "a" 
                let _t = Helper.toCell<double> t "t" 
                let _theta = Helper.toDefault<double> theta "theta" 1.0
                let builder () = withMnemonic mnemonic ((CrankNicolsonSchemeModel.Cast _CrankNicolsonScheme.cell).Step
                                                            _a.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : CrankNicolsonScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CrankNicolsonScheme.source + ".Step") 
                                               [| _CrankNicolsonScheme.source
                                               ;  _a.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CrankNicolsonScheme.cell
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
    [<ExcelFunction(Name="_CrankNicolsonScheme_Range", Description="Create a range of CrankNicolsonScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CrankNicolsonScheme_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CrankNicolsonScheme")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CrankNicolsonScheme> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CrankNicolsonScheme>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CrankNicolsonScheme>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CrankNicolsonScheme>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
