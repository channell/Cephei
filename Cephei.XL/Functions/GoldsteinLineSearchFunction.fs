﻿(*
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
Goldstein and Price line-search class
  </summary> *)
[<AutoSerializable(true)>]
module GoldsteinLineSearchFunction =

    (*
        ! Default constructor
    *)
    [<ExcelFunction(Name="_GoldsteinLineSearch", Description="Create a GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_create
        ([<ExcelArgument(Name="Mnemonic",Description = "GoldsteinLineSearch")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="eps",Description = "GoldsteinLineSearch")>] 
         eps : obj)
        ([<ExcelArgument(Name="alpha",Description = "GoldsteinLineSearch")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "GoldsteinLineSearch")>] 
         beta : obj)
        ([<ExcelArgument(Name="extrapolation",Description = "GoldsteinLineSearch")>] 
         extrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _eps = Helper.toDefault<double> eps "eps" 1e-8
                let _alpha = Helper.toDefault<double> alpha "alpha" 0.05
                let _beta = Helper.toDefault<double> beta "beta" 0.65
                let _extrapolation = Helper.toDefault<double> extrapolation "extrapolation" 1.5
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GoldsteinLineSearch 
                                                            _eps.cell 
                                                            _alpha.cell 
                                                            _beta.cell 
                                                            _extrapolation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GoldsteinLineSearch>) l

                let source () = Helper.sourceFold "Fun.GoldsteinLineSearch" 
                                               [| _eps.source
                                               ;  _alpha.source
                                               ;  _beta.source
                                               ;  _extrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _eps.cell
                                ;  _alpha.cell
                                ;  _beta.cell
                                ;  _extrapolation.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GoldsteinLineSearch> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Perform line search
    *)
    [<ExcelFunction(Name="_GoldsteinLineSearch_value", Description="Create a GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GoldsteinLineSearch",Description = "GoldsteinLineSearch")>] 
         goldsteinlinesearch : obj)
        ([<ExcelArgument(Name="P",Description = "Problem")>] 
         P : obj)
        ([<ExcelArgument(Name="ecType",Description = "EndCriteria.Type: None, MaxIterations, StationaryPoint, StationaryFunctionValue, StationaryFunctionAccuracy, ZeroGradientNorm, Unknown")>] 
         ecType : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="t_ini",Description = "double")>] 
         t_ini : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GoldsteinLineSearch = Helper.toCell<GoldsteinLineSearch> goldsteinlinesearch "GoldsteinLineSearch"  
                let _P = Helper.toCell<Problem> P "P" 
                let _ecType = Helper.toCell<EndCriteria.Type> ecType "ecType" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _t_ini = Helper.toCell<double> t_ini "t_ini" 
                let builder (current : ICell) = withMnemonic mnemonic ((GoldsteinLineSearchModel.Cast _GoldsteinLineSearch.cell).Value
                                                            _P.cell 
                                                            _ecType.cell 
                                                            _endCriteria.cell 
                                                            _t_ini.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GoldsteinLineSearch.source + ".Value") 
                                               [| _GoldsteinLineSearch.source
                                               ;  _P.source
                                               ;  _ecType.source
                                               ;  _endCriteria.source
                                               ;  _t_ini.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GoldsteinLineSearch.cell
                                ;  _P.cell
                                ;  _ecType.cell
                                ;  _endCriteria.cell
                                ;  _t_ini.cell
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
        ! return last cost function value
    *)
    [<ExcelFunction(Name="_GoldsteinLineSearch_lastFunctionValue", Description="Create a GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_lastFunctionValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GoldsteinLineSearch",Description = "GoldsteinLineSearch")>] 
         goldsteinlinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GoldsteinLineSearch = Helper.toCell<GoldsteinLineSearch> goldsteinlinesearch "GoldsteinLineSearch"  
                let builder (current : ICell) = withMnemonic mnemonic ((GoldsteinLineSearchModel.Cast _GoldsteinLineSearch.cell).LastFunctionValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GoldsteinLineSearch.source + ".LastFunctionValue") 
                                               [| _GoldsteinLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GoldsteinLineSearch.cell
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
        ! return last gradient
    *)
    [<ExcelFunction(Name="_GoldsteinLineSearch_lastGradient", Description="Create a GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_lastGradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GoldsteinLineSearch",Description = "GoldsteinLineSearch")>] 
         goldsteinlinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GoldsteinLineSearch = Helper.toCell<GoldsteinLineSearch> goldsteinlinesearch "GoldsteinLineSearch"  
                let builder (current : ICell) = withMnemonic mnemonic ((GoldsteinLineSearchModel.Cast _GoldsteinLineSearch.cell).LastGradient
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GoldsteinLineSearch.source + ".LastGradient") 
                                               [| _GoldsteinLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GoldsteinLineSearch.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GoldsteinLineSearch> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! return square norm of last gradient
    *)
    [<ExcelFunction(Name="_GoldsteinLineSearch_lastGradientNorm2", Description="Create a GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_lastGradientNorm2
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GoldsteinLineSearch",Description = "GoldsteinLineSearch")>] 
         goldsteinlinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GoldsteinLineSearch = Helper.toCell<GoldsteinLineSearch> goldsteinlinesearch "GoldsteinLineSearch"  
                let builder (current : ICell) = withMnemonic mnemonic ((GoldsteinLineSearchModel.Cast _GoldsteinLineSearch.cell).LastGradientNorm2
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GoldsteinLineSearch.source + ".LastGradientNorm2") 
                                               [| _GoldsteinLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GoldsteinLineSearch.cell
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
        ! return last x value
    *)
    [<ExcelFunction(Name="_GoldsteinLineSearch_lastX", Description="Create a GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_lastX
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GoldsteinLineSearch",Description = "GoldsteinLineSearch")>] 
         goldsteinlinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GoldsteinLineSearch = Helper.toCell<GoldsteinLineSearch> goldsteinlinesearch "GoldsteinLineSearch"  
                let builder (current : ICell) = withMnemonic mnemonic ((GoldsteinLineSearchModel.Cast _GoldsteinLineSearch.cell).LastX
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GoldsteinLineSearch.source + ".LastX") 
                                               [| _GoldsteinLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GoldsteinLineSearch.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GoldsteinLineSearch> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! current value of the search direction
    *)
    [<ExcelFunction(Name="_GoldsteinLineSearch_searchDirection", Description="Create a GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_searchDirection
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GoldsteinLineSearch",Description = "GoldsteinLineSearch")>] 
         goldsteinlinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GoldsteinLineSearch = Helper.toCell<GoldsteinLineSearch> goldsteinlinesearch "GoldsteinLineSearch"  
                let builder (current : ICell) = withMnemonic mnemonic ((GoldsteinLineSearchModel.Cast _GoldsteinLineSearch.cell).SearchDirection
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GoldsteinLineSearch.source + ".SearchDirection") 
                                               [| _GoldsteinLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GoldsteinLineSearch.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GoldsteinLineSearch> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GoldsteinLineSearch_succeed", Description="Create a GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_succeed
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GoldsteinLineSearch",Description = "GoldsteinLineSearch")>] 
         goldsteinlinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GoldsteinLineSearch = Helper.toCell<GoldsteinLineSearch> goldsteinlinesearch "GoldsteinLineSearch"  
                let builder (current : ICell) = withMnemonic mnemonic ((GoldsteinLineSearchModel.Cast _GoldsteinLineSearch.cell).Succeed
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GoldsteinLineSearch.source + ".Succeed") 
                                               [| _GoldsteinLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GoldsteinLineSearch.cell
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
        initial value of line-search step
    *)
    [<ExcelFunction(Name="_GoldsteinLineSearch_update", Description="Create a GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GoldsteinLineSearch",Description = "GoldsteinLineSearch")>] 
         goldsteinlinesearch : obj)
        ([<ExcelArgument(Name="data",Description = "Vector")>] 
         data : obj)
        ([<ExcelArgument(Name="direction",Description = "Vector")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "Helper.Range.fromModelList")>] 
         beta : obj)
        ([<ExcelArgument(Name="Constraint",Description = "Constraint")>] 
         Constraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GoldsteinLineSearch = Helper.toCell<GoldsteinLineSearch> goldsteinlinesearch "GoldsteinLineSearch"  
                let _data = Helper.toCell<Vector> data "data" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toDefault<double> beta "beta" 0.65
                let _Constraint = Helper.toCell<Constraint> Constraint "Constraint" 
                let builder (current : ICell) = withMnemonic mnemonic ((GoldsteinLineSearchModel.Cast _GoldsteinLineSearch.cell).Update
                                                            _data.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                            _Constraint.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GoldsteinLineSearch.source + ".Update") 
                                               [| _GoldsteinLineSearch.source
                                               ;  _data.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               ;  _Constraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GoldsteinLineSearch.cell
                                ;  _data.cell
                                ;  _direction.cell
                                ;  _beta.cell
                                ;  _Constraint.cell
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
    [<ExcelFunction(Name="_GoldsteinLineSearch_Range", Description="Create a range of GoldsteinLineSearch",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GoldsteinLineSearch_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GoldsteinLineSearch> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GoldsteinLineSearch>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GoldsteinLineSearch>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GoldsteinLineSearch>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
