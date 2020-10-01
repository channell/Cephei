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
Armijo line search.  (see Polak, Algorithms and consistent approximations, Optimization, volume 124 of Applied Mathematical Sciences, Springer-Verlag, NY, 1997)
  </summary> *)
[<AutoSerializable(true)>]
module ArmijoLineSearchFunction =

    (*
        ! Default constructor
    *)
    [<ExcelFunction(Name="_ArmijoLineSearch1", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="eps",Description = "Reference to eps")>] 
         eps : obj)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _eps = Helper.toCell<double> eps "eps" 
                let _alpha = Helper.toCell<double> alpha "alpha" 
                let builder () = withMnemonic mnemonic (Fun.ArmijoLineSearch1 
                                                            _eps.cell 
                                                            _alpha.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ArmijoLineSearch>) l

                let source = Helper.sourceFold "Fun.ArmijoLineSearch" 
                                               [| _eps.source
                                               ;  _alpha.source
                                               |]
                let hash = Helper.hashFold 
                                [| _eps.cell
                                ;  _alpha.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArmijoLineSearch> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ArmijoLineSearch", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="eps",Description = "Reference to eps")>] 
         eps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _eps = Helper.toCell<double> eps "eps" 
                let builder () = withMnemonic mnemonic (Fun.ArmijoLineSearch    
                                                            _eps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ArmijoLineSearch>) l

                let source = Helper.sourceFold "Fun.ArmijoLineSearch1" 
                                               [| _eps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _eps.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArmijoLineSearch> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ArmijoLineSearch3", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ArmijoLineSearch3 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ArmijoLineSearch>) l

                let source = Helper.sourceFold "Fun.ArmijoLineSearch3" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArmijoLineSearch> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ArmijoLineSearch2", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="eps",Description = "Reference to eps")>] 
         eps : obj)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _eps = Helper.toCell<double> eps "eps" 
                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder () = withMnemonic mnemonic (Fun.ArmijoLineSearch2
                                                            _eps.cell 
                                                            _alpha.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ArmijoLineSearch>) l

                let source = Helper.sourceFold "Fun.ArmijoLineSearch3" 
                                               [| _eps.source
                                               ;  _alpha.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _eps.cell
                                ;  _alpha.cell
                                ;  _beta.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArmijoLineSearch> format
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
    [<ExcelFunction(Name="_ArmijoLineSearch_value", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArmijoLineSearch",Description = "Reference to ArmijoLineSearch")>] 
         armijolinesearch : obj)
        ([<ExcelArgument(Name="P",Description = "Reference to P")>] 
         P : obj)
        ([<ExcelArgument(Name="ecType",Description = "Reference to ecType")>] 
         ecType : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="t_ini",Description = "Reference to t_ini")>] 
         t_ini : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArmijoLineSearch = Helper.toCell<ArmijoLineSearch> armijolinesearch "ArmijoLineSearch"  
                let _P = Helper.toCell<Problem> P "P" 
                let _ecType = Helper.toCell<EndCriteria.Type> ecType "ecType" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _t_ini = Helper.toCell<double> t_ini "t_ini" 
                let builder () = withMnemonic mnemonic ((_ArmijoLineSearch.cell :?> ArmijoLineSearchModel3).Value
                                                            _P.cell 
                                                            _ecType.cell 
                                                            _endCriteria.cell 
                                                            _t_ini.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ArmijoLineSearch.source + ".Value") 
                                               [| _ArmijoLineSearch.source
                                               ;  _P.source
                                               ;  _ecType.source
                                               ;  _endCriteria.source
                                               ;  _t_ini.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArmijoLineSearch.cell
                                ;  _P.cell
                                ;  _ecType.cell
                                ;  _endCriteria.cell
                                ;  _t_ini.cell
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
        ! return last cost function value
    *)
    [<ExcelFunction(Name="_ArmijoLineSearch_lastFunctionValue", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_lastFunctionValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArmijoLineSearch",Description = "Reference to ArmijoLineSearch")>] 
         armijolinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArmijoLineSearch = Helper.toCell<ArmijoLineSearch> armijolinesearch "ArmijoLineSearch"  
                let builder () = withMnemonic mnemonic ((_ArmijoLineSearch.cell :?> ArmijoLineSearchModel).LastFunctionValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ArmijoLineSearch.source + ".LastFunctionValue") 
                                               [| _ArmijoLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArmijoLineSearch.cell
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
        ! return last gradient
    *)
    [<ExcelFunction(Name="_ArmijoLineSearch_lastGradient", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_lastGradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArmijoLineSearch",Description = "Reference to ArmijoLineSearch")>] 
         armijolinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArmijoLineSearch = Helper.toCell<ArmijoLineSearch> armijolinesearch "ArmijoLineSearch"  
                let builder () = withMnemonic mnemonic ((_ArmijoLineSearch.cell :?> ArmijoLineSearchModel).LastGradient
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_ArmijoLineSearch.source + ".LastGradient") 
                                               [| _ArmijoLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArmijoLineSearch.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArmijoLineSearch> format
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
    [<ExcelFunction(Name="_ArmijoLineSearch_lastGradientNorm2", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_lastGradientNorm2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArmijoLineSearch",Description = "Reference to ArmijoLineSearch")>] 
         armijolinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArmijoLineSearch = Helper.toCell<ArmijoLineSearch> armijolinesearch "ArmijoLineSearch"  
                let builder () = withMnemonic mnemonic ((_ArmijoLineSearch.cell :?> ArmijoLineSearchModel).LastGradientNorm2
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ArmijoLineSearch.source + ".LastGradientNorm2") 
                                               [| _ArmijoLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArmijoLineSearch.cell
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
        ! return last x value
    *)
    [<ExcelFunction(Name="_ArmijoLineSearch_lastX", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_lastX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArmijoLineSearch",Description = "Reference to ArmijoLineSearch")>] 
         armijolinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArmijoLineSearch = Helper.toCell<ArmijoLineSearch> armijolinesearch "ArmijoLineSearch"  
                let builder () = withMnemonic mnemonic ((_ArmijoLineSearch.cell :?> ArmijoLineSearchModel).LastX
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_ArmijoLineSearch.source + ".LastX") 
                                               [| _ArmijoLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArmijoLineSearch.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArmijoLineSearch> format
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
    [<ExcelFunction(Name="_ArmijoLineSearch_searchDirection", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_searchDirection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArmijoLineSearch",Description = "Reference to ArmijoLineSearch")>] 
         armijolinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArmijoLineSearch = Helper.toCell<ArmijoLineSearch> armijolinesearch "ArmijoLineSearch"  
                let builder () = withMnemonic mnemonic ((_ArmijoLineSearch.cell :?> ArmijoLineSearchModel).SearchDirection
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_ArmijoLineSearch.source + ".SearchDirection") 
                                               [| _ArmijoLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArmijoLineSearch.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ArmijoLineSearch> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ArmijoLineSearch_succeed", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_succeed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArmijoLineSearch",Description = "Reference to ArmijoLineSearch")>] 
         armijolinesearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArmijoLineSearch = Helper.toCell<ArmijoLineSearch> armijolinesearch "ArmijoLineSearch"  
                let builder () = withMnemonic mnemonic ((_ArmijoLineSearch.cell :?> ArmijoLineSearchModel).Succeed
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ArmijoLineSearch.source + ".Succeed") 
                                               [| _ArmijoLineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArmijoLineSearch.cell
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
        initial value of line-search step
    *)
    [<ExcelFunction(Name="_ArmijoLineSearch_update", Description="Create a ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ArmijoLineSearch",Description = "Reference to ArmijoLineSearch")>] 
         armijolinesearch : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        ([<ExcelArgument(Name="Constraint",Description = "Reference to Constraint")>] 
         Constraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ArmijoLineSearch = Helper.toCell<ArmijoLineSearch> armijolinesearch "ArmijoLineSearch"  
                let _data = Helper.toCell<Vector> data "data" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toCell<double> beta "beta" 
                let _Constraint = Helper.toCell<Constraint> Constraint "Constraint" 
                let builder () = withMnemonic mnemonic ((_ArmijoLineSearch.cell :?> ArmijoLineSearchModel).Update
                                                            _data.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                            _Constraint.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ArmijoLineSearch.source + ".Update") 
                                               [| _ArmijoLineSearch.source
                                               ;  _data.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               ;  _Constraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ArmijoLineSearch.cell
                                ;  _data.cell
                                ;  _direction.cell
                                ;  _beta.cell
                                ;  _Constraint.cell
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
    [<ExcelFunction(Name="_ArmijoLineSearch_Range", Description="Create a range of ArmijoLineSearch",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ArmijoLineSearch_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ArmijoLineSearch")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ArmijoLineSearch> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ArmijoLineSearch>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ArmijoLineSearch>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ArmijoLineSearch>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
