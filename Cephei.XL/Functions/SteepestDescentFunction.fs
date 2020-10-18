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
  User has to provide line-search method and optimization end criteria  search direction = - f'(x)
  </summary> *)
[<AutoSerializable(true)>]
module SteepestDescentFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SteepestDescent", Description="Create a SteepestDescent",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SteepestDescent_create
        ([<ExcelArgument(Name="Mnemonic",Description = "SteepestDescent")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="lineSearch",Description = "SteepestDescent")>] 
         lineSearch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _lineSearch = Helper.toDefault<LineSearch> lineSearch "lineSearch" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SteepestDescent 
                                                            _lineSearch.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SteepestDescent>) l

                let source () = Helper.sourceFold "Fun.SteepestDescent" 
                                               [| _lineSearch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _lineSearch.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SteepestDescent> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SteepestDescent_minimize", Description="Create a SteepestDescent",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SteepestDescent_minimize
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SteepestDescent",Description = "SteepestDescent")>] 
         steepestdescent : obj)
        ([<ExcelArgument(Name="P",Description = "Problem")>] 
         P : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria")>] 
         endCriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SteepestDescent = Helper.toCell<SteepestDescent> steepestdescent "SteepestDescent"  
                let _P = Helper.toCell<Problem> P "P" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let builder (current : ICell) = withMnemonic mnemonic ((SteepestDescentModel.Cast _SteepestDescent.cell).Minimize
                                                            _P.cell 
                                                            _endCriteria.cell 
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SteepestDescent.source + ".Minimize") 
                                               [| _SteepestDescent.source
                                               ;  _P.source
                                               ;  _endCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SteepestDescent.cell
                                ;  _P.cell
                                ;  _endCriteria.cell
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
    [<ExcelFunction(Name="_SteepestDescent_Range", Description="Create a range of SteepestDescent",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SteepestDescent_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SteepestDescent> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SteepestDescent>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SteepestDescent>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SteepestDescent>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
