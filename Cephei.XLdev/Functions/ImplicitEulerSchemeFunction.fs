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
    [<ExcelFunction(Name="_ImplicitEulerScheme_factory", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEulerScheme",Description = "Reference to ImplicitEulerScheme")>] 
         impliciteulerscheme : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        ([<ExcelArgument(Name="additionalFields",Description = "Reference to additionalFields")>] 
         additionalFields : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEulerScheme = Helper.toCell<ImplicitEulerScheme> impliciteulerscheme "ImplicitEulerScheme" true 
                let _L = Helper.toCell<Object> L "L" true
                let _bcs = Helper.toCell<Object> bcs "bcs" true
                let _additionalFields = Helper.toCell<Object[]> additionalFields "additionalFields" true
                let builder () = withMnemonic mnemonic ((_ImplicitEulerScheme.cell :?> ImplicitEulerSchemeModel).Factory
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _additionalFields.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IMixedScheme>) l

                let source = Helper.sourceFold (_ImplicitEulerScheme.source + ".Factory") 
                                               [| _ImplicitEulerScheme.source
                                               ;  _L.source
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImplicitEulerScheme", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
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

                let _map = Helper.toCell<FdmLinearOpComposite> map "map" true
                let _bcSet = Helper.toCell<Generic.List<BoundaryCondition<FdmLinearOp>>> bcSet "bcSet" true
                let _relTol = Helper.toCell<double> relTol "relTol" true
                let _solverType = Helper.toCell<SolverType> solverType "solverType" true
                let builder () = withMnemonic mnemonic (Fun.ImplicitEulerScheme 
                                                            _map.cell 
                                                            _bcSet.cell 
                                                            _relTol.cell 
                                                            _solverType.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImplicitEulerScheme>) l

                let source = Helper.sourceFold "Fun.ImplicitEulerScheme" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImplicitEulerScheme1", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ImplicitEulerScheme1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImplicitEulerScheme>) l

                let source = Helper.sourceFold "Fun.ImplicitEulerScheme1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImplicitEulerScheme_numberOfIterations", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEulerScheme",Description = "Reference to ImplicitEulerScheme")>] 
         impliciteulerscheme : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEulerScheme = Helper.toCell<ImplicitEulerScheme> impliciteulerscheme "ImplicitEulerScheme" true 
                let builder () = withMnemonic mnemonic ((_ImplicitEulerScheme.cell :?> ImplicitEulerSchemeModel).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ImplicitEulerScheme.source + ".NumberOfIterations") 
                                               [| _ImplicitEulerScheme.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImplicitEulerScheme.cell
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
    [<ExcelFunction(Name="_ImplicitEulerScheme_setStep", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEulerScheme",Description = "Reference to ImplicitEulerScheme")>] 
         impliciteulerscheme : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEulerScheme = Helper.toCell<ImplicitEulerScheme> impliciteulerscheme "ImplicitEulerScheme" true 
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_ImplicitEulerScheme.cell :?> ImplicitEulerSchemeModel).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : ImplicitEulerScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ImplicitEulerScheme.source + ".SetStep") 
                                               [| _ImplicitEulerScheme.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImplicitEulerScheme.cell
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
    [<ExcelFunction(Name="_ImplicitEulerScheme_step", Description="Create a ImplicitEulerScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEulerScheme",Description = "Reference to ImplicitEulerScheme")>] 
         impliciteulerscheme : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEulerScheme = Helper.toCell<ImplicitEulerScheme> impliciteulerscheme "ImplicitEulerScheme" true 
                let _a = Helper.toCell<Object> a "a" true
                let _t = Helper.toCell<double> t "t" true
                let _theta = Helper.toCell<double> theta "theta" true
                let builder () = withMnemonic mnemonic ((_ImplicitEulerScheme.cell :?> ImplicitEulerSchemeModel).Step
                                                            _a.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : ImplicitEulerScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ImplicitEulerScheme.source + ".Step") 
                                               [| _ImplicitEulerScheme.source
                                               ;  _a.source
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
    [<ExcelFunction(Name="_ImplicitEulerScheme_Range", Description="Create a range of ImplicitEulerScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEulerScheme_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ImplicitEulerScheme")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ImplicitEulerScheme> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ImplicitEulerScheme>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ImplicitEulerScheme>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ImplicitEulerScheme>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
