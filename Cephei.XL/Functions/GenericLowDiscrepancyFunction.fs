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

  </summary> *)
[<AutoSerializable(true)>]
module GenericLowDiscrepancyFunction =

    (*
        more traits
    *)
    [<ExcelFunction(Name="_GenericLowDiscrepancy_allowsErrorEstimate", Description="Create a GenericLowDiscrepancy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericLowDiscrepancy_allowsErrorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericLowDiscrepancy",Description = "Reference to GenericLowDiscrepancy")>] 
         genericlowdiscrepancy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericLowDiscrepancy = Helper.toCell<GenericLowDiscrepancy> genericlowdiscrepancy "GenericLowDiscrepancy"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericLowDiscrepancyModel.Cast _GenericLowDiscrepancy.cell).AllowsErrorEstimate
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericLowDiscrepancy.source + ".AllowsErrorEstimate") 
                                               [| _GenericLowDiscrepancy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericLowDiscrepancy.cell
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
        factory
    *)
    [<ExcelFunction(Name="_GenericLowDiscrepancy_make_sequence_generator", Description="Create a GenericLowDiscrepancy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericLowDiscrepancy_make_sequence_generator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericLowDiscrepancy",Description = "Reference to GenericLowDiscrepancy")>] 
         genericlowdiscrepancy : obj)
        ([<ExcelArgument(Name="dimension",Description = "Reference to dimension")>] 
         dimension : obj)
        ([<ExcelArgument(Name="seed",Description = "Reference to seed")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericLowDiscrepancy = Helper.toCell<GenericLowDiscrepancy> genericlowdiscrepancy "GenericLowDiscrepancy"  
                let _dimension = Helper.toCell<int> dimension "dimension" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericLowDiscrepancyModel.Cast _GenericLowDiscrepancy.cell).Make_sequence_generator
                                                            _dimension.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IRNG>) l

                let source () = Helper.sourceFold (_GenericLowDiscrepancy.source + ".Make_sequence_generator") 
                                               [| _GenericLowDiscrepancy.source
                                               ;  _dimension.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericLowDiscrepancy.cell
                                ;  _dimension.cell
                                ;  _seed.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericLowDiscrepancy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GenericLowDiscrepancy_Range", Description="Create a range of GenericLowDiscrepancy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericLowDiscrepancy_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GenericLowDiscrepancy")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GenericLowDiscrepancy> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GenericLowDiscrepancy>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GenericLowDiscrepancy>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GenericLowDiscrepancy>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
