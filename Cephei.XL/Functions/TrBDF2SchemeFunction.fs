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
  In one dimension the Crank-Nicolson scheme is equivalent to the Douglas scheme and in higher dimensions it is usually inferior to operator splitting methods like Craig-Sneyd or Hundsdorfer-Verwer.
  </summary> *)
[<AutoSerializable(true)>]
module TrBDF2SchemeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TrBDF2Scheme_apply", Description="Create a TrBDF2Scheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrBDF2Scheme_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrBDF2Scheme",Description = "Reference to TrBDF2Scheme")>] 
         trbdf2scheme : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrBDF2Scheme = Helper.toCell<TrBDF2Scheme> trbdf2scheme "TrBDF2Scheme"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrBDF2SchemeModel.Cast _TrBDF2Scheme.cell).Apply
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TrBDF2Scheme.source + ".Apply") 
                                               [| _TrBDF2Scheme.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrBDF2Scheme.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TrBDF2Scheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TrBDF2Scheme_factory", Description="Create a TrBDF2Scheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrBDF2Scheme_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrBDF2Scheme",Description = "Reference to TrBDF2Scheme")>] 
         trbdf2scheme : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        ([<ExcelArgument(Name="additionalInputs",Description = "Reference to additionalInputs")>] 
         additionalInputs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrBDF2Scheme = Helper.toCell<TrBDF2Scheme> trbdf2scheme "TrBDF2Scheme"  
                let _L = Helper.toCell<Object> L "L" 
                let _bcs = Helper.toCell<Object> bcs "bcs" 
                let _additionalInputs = Helper.toDefault<Object[]> additionalInputs "additionalInputs" null
                let builder (current : ICell) = withMnemonic mnemonic ((TrBDF2SchemeModel.Cast _TrBDF2Scheme.cell).Factory
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _additionalInputs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IMixedScheme>) l

                let source () = Helper.sourceFold (_TrBDF2Scheme.source + ".Factory") 
                                               [| _TrBDF2Scheme.source
                                               ;  _L.source
                                               ;  _bcs.source
                                               ;  _additionalInputs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrBDF2Scheme.cell
                                ;  _L.cell
                                ;  _bcs.cell
                                ;  _additionalInputs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TrBDF2Scheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TrBDF2Scheme_numberOfIterations", Description="Create a TrBDF2Scheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrBDF2Scheme_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrBDF2Scheme",Description = "Reference to TrBDF2Scheme")>] 
         trbdf2scheme : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrBDF2Scheme = Helper.toCell<TrBDF2Scheme> trbdf2scheme "TrBDF2Scheme"  
                let builder (current : ICell) = withMnemonic mnemonic ((TrBDF2SchemeModel.Cast _TrBDF2Scheme.cell).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrBDF2Scheme.source + ".NumberOfIterations") 
                                               [| _TrBDF2Scheme.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrBDF2Scheme.cell
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
    [<ExcelFunction(Name="_TrBDF2Scheme_setStep", Description="Create a TrBDF2Scheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrBDF2Scheme_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrBDF2Scheme",Description = "Reference to TrBDF2Scheme")>] 
         trbdf2scheme : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrBDF2Scheme = Helper.toCell<TrBDF2Scheme> trbdf2scheme "TrBDF2Scheme"  
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrBDF2SchemeModel.Cast _TrBDF2Scheme.cell).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : TrBDF2Scheme) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TrBDF2Scheme.source + ".SetStep") 
                                               [| _TrBDF2Scheme.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrBDF2Scheme.cell
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
    [<ExcelFunction(Name="_TrBDF2Scheme_step", Description="Create a TrBDF2Scheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrBDF2Scheme_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrBDF2Scheme",Description = "Reference to TrBDF2Scheme")>] 
         trbdf2scheme : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrBDF2Scheme = Helper.toCell<TrBDF2Scheme> trbdf2scheme "TrBDF2Scheme"  
                let _a = Helper.toCell<Object> a "a" 
                let _t = Helper.toCell<double> t "t" 
                let _theta = Helper.toDefault<double> theta "theta" 1.0
                let builder (current : ICell) = withMnemonic mnemonic ((TrBDF2SchemeModel.Cast _TrBDF2Scheme.cell).Step
                                                            _a.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : TrBDF2Scheme) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TrBDF2Scheme.source + ".Step") 
                                               [| _TrBDF2Scheme.source
                                               ;  _a.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrBDF2Scheme.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_TrBDF2Scheme", Description="Create a TrBDF2Scheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrBDF2Scheme_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        ([<ExcelArgument(Name="map",Description = "Reference to map")>] 
         map : obj)
        ([<ExcelArgument(Name="trapezoidalScheme",Description = "Reference to trapezoidalScheme")>] 
         trapezoidalScheme : obj)
        ([<ExcelArgument(Name="bcSet",Description = "Reference to bcSet")>] 
         bcSet : obj)
        ([<ExcelArgument(Name="relTol",Description = "Reference to relTol")>] 
         relTol : obj)
        ([<ExcelArgument(Name="solverType",Description = "Reference to solverType")>] 
         solverType : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _map = Helper.toCell<FdmLinearOpComposite> map "map" 
                let _trapezoidalScheme = Helper.toCell<'TrapezoidalScheme> trapezoidalScheme "trapezoidalScheme" 
                let _bcSet = Helper.toDefault<Generic.List<BoundaryCondition<FdmLinearOp>>> bcSet "bcSet" null
                let _relTol = Helper.toDefault<double> relTol "relTol" 1E-8
                let _solverType = Helper.toDefault<TrBDF2Scheme<'TrapezoidalScheme>.SolverType> solverType "solverType" TrBDF2Scheme<TrapezoidalScheme>.SolverType.BiCGstab
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TrBDF2Scheme 
                                                            _alpha.cell 
                                                            _map.cell 
                                                            _trapezoidalScheme.cell 
                                                            _bcSet.cell 
                                                            _relTol.cell 
                                                            _solverType.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TrBDF2Scheme>) l

                let source () = Helper.sourceFold "Fun.TrBDF2Scheme" 
                                               [| _alpha.source
                                               ;  _map.source
                                               ;  _trapezoidalScheme.source
                                               ;  _bcSet.source
                                               ;  _relTol.source
                                               ;  _solverType.source
                                               |]
                let hash = Helper.hashFold 
                                [| _alpha.cell
                                ;  _map.cell
                                ;  _trapezoidalScheme.cell
                                ;  _bcSet.cell
                                ;  _relTol.cell
                                ;  _solverType.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TrBDF2Scheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TrBDF2Scheme1", Description="Create a TrBDF2Scheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrBDF2Scheme_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.TrBDF2Scheme1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TrBDF2Scheme>) l

                let source () = Helper.sourceFold "Fun.TrBDF2Scheme1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TrBDF2Scheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TrBDF2Scheme_Range", Description="Create a range of TrBDF2Scheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrBDF2Scheme_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TrBDF2Scheme")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TrBDF2Scheme> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TrBDF2Scheme>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TrBDF2Scheme>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TrBDF2Scheme>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
