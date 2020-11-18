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
module ImplicitEulerSchemeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ImplicitEulerScheme_factory", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEulerScheme",Description = "ImplicitEulerScheme")>] 
         impliciteulerscheme : obj)
        ([<ExcelArgument(Name="L",Description = "Object")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Object")>] 
         bcs : obj)
        ([<ExcelArgument(Name="additionalFields",Description = "Object[] or empty")>] 
         additionalFields : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEulerScheme = Helper.toCell<ImplicitEulerScheme> impliciteulerscheme "ImplicitEulerScheme"  
                let _L = Helper.toCell<Object> L "L" 
                let _bcs = Helper.toCell<Object> bcs "bcs" 
                let _additionalFields = Helper.toDefault<Object[]> additionalFields "additionalFields" null
                let builder (current : ICell) = withMnemonic mnemonic ((ImplicitEulerSchemeModel.Cast _ImplicitEulerScheme.cell).Factory
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _additionalFields.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IMixedScheme>) l

                let source () = Helper.sourceFold (_ImplicitEulerScheme.source + ".Factory") 

                                               [| _L.source
                                               ;  _bcs.source
                                               ;  _additionalFields.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImplicitEulerScheme.cell
                                ;  _L.cell
                                ;  _bcs.cell
                                ;  _additionalFields.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImplicitEulerScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImplicitEulerScheme", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="map",Description = "FdmLinearOpComposite")>] 
         map : obj)
        ([<ExcelArgument(Name="bcSet",Description = "FdmLinearOp range")>] 
         bcSet : obj)
        ([<ExcelArgument(Name="relTol",Description = "double or empty")>] 
         relTol : obj)
        ([<ExcelArgument(Name="solverType",Description = "ImplicitEulerScheme.SolverType: BiCGstab, GMRES")>] 
         solverType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _map = Helper.toCell<FdmLinearOpComposite> map "map" 
                let _bcSet = Helper.toCell<Generic.List<BoundaryCondition<FdmLinearOp>>> bcSet "bcSet" 
                let _relTol = Helper.toDefault<double> relTol "relTol" 1e-8
                let _solverType = Helper.toCell<ImplicitEulerScheme.SolverType> solverType "solverType" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ImplicitEulerScheme 
                                                            _map.cell 
                                                            _bcSet.cell 
                                                            _relTol.cell 
                                                            _solverType.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImplicitEulerScheme>) l

                let source () = Helper.sourceFold "Fun.ImplicitEulerScheme" 
                                               [| _map.source
                                               ;  _bcSet.source
                                               ;  _relTol.source
                                               ;  _solverType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _map.cell
                                ;  _bcSet.cell
                                ;  _relTol.cell
                                ;  _solverType.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImplicitEulerScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImplicitEulerScheme1", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.ImplicitEulerScheme1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImplicitEulerScheme>) l

                let source () = Helper.sourceFold "Fun.ImplicitEulerScheme1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImplicitEulerScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImplicitEulerScheme_numberOfIterations", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEulerScheme",Description = "ImplicitEulerScheme")>] 
         impliciteulerscheme : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEulerScheme = Helper.toCell<ImplicitEulerScheme> impliciteulerscheme "ImplicitEulerScheme"  
                let builder (current : ICell) = withMnemonic mnemonic ((ImplicitEulerSchemeModel.Cast _ImplicitEulerScheme.cell).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ImplicitEulerScheme.source + ".NumberOfIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ImplicitEulerScheme.cell
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
    [<ExcelFunction(Name="_ImplicitEulerScheme_setStep", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEulerScheme",Description = "ImplicitEulerScheme")>] 
         impliciteulerscheme : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEulerScheme = Helper.toCell<ImplicitEulerScheme> impliciteulerscheme "ImplicitEulerScheme"  
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((ImplicitEulerSchemeModel.Cast _ImplicitEulerScheme.cell).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : ImplicitEulerScheme) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ImplicitEulerScheme.source + ".SetStep") 

                                               [| _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImplicitEulerScheme.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_ImplicitEulerScheme_step", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEulerScheme",Description = "ImplicitEulerScheme")>] 
         impliciteulerscheme : obj)
        ([<ExcelArgument(Name="a",Description = "Object")>] 
         a : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "double or empty")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEulerScheme = Helper.toCell<ImplicitEulerScheme> impliciteulerscheme "ImplicitEulerScheme"  
                let _a = Helper.toCell<Object> a "a" 
                let _t = Helper.toCell<double> t "t" 
                let _theta = Helper.toDefault<double> theta "theta" 1.0
                let builder (current : ICell) = withMnemonic mnemonic ((ImplicitEulerSchemeModel.Cast _ImplicitEulerScheme.cell).Step
                                                            _a.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : ImplicitEulerScheme) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ImplicitEulerScheme.source + ".Step") 

                                               [| _a.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImplicitEulerScheme.cell
                                ;  _a.cell
                                ;  _t.cell
                                ;  _theta.cell
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
    [<ExcelFunction(Name="_ImplicitEulerScheme_Range", Description="Create a range of ImplicitEulerScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ImplicitEulerScheme> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<ImplicitEulerScheme> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<ImplicitEulerScheme>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ImplicitEulerScheme>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
