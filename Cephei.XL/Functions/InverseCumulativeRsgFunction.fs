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
  It uses a sequence of uniform deviate in (0, 1) as the source of cumulative distribution values. Then an inverse cumulative distribution is used to calculate the distribution deviate.  The uniform deviate sequence is supplied by USG. The inverse cumulative distribution is supplied by IC.
  </summary> *)
[<AutoSerializable(true)>]
module InverseCumulativeRsgFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InverseCumulativeRsg_dimension", Description="Create a InverseCumulativeRsg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeRsg_dimension
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InverseCumulativeRsg",Description = "Reference to InverseCumulativeRsg")>] 
         inversecumulativersg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InverseCumulativeRsg = Helper.toCell<InverseCumulativeRsg> inversecumulativersg "InverseCumulativeRsg" true 
                let builder () = withMnemonic mnemonic ((_InverseCumulativeRsg.cell :?> InverseCumulativeRsgModel).Dimension
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_InverseCumulativeRsg.source + ".Dimension") 
                                               [| _InverseCumulativeRsg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InverseCumulativeRsg.cell
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
    [<ExcelFunction(Name="_InverseCumulativeRsg_factory", Description="Create a InverseCumulativeRsg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeRsg_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InverseCumulativeRsg",Description = "Reference to InverseCumulativeRsg")>] 
         inversecumulativersg : obj)
        ([<ExcelArgument(Name="dimensionality",Description = "Reference to dimensionality")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="seed",Description = "Reference to seed")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InverseCumulativeRsg = Helper.toCell<InverseCumulativeRsg> inversecumulativersg "InverseCumulativeRsg" true 
                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" true
                let _seed = Helper.toCell<uint64> seed "seed" true
                let builder () = withMnemonic mnemonic ((_InverseCumulativeRsg.cell :?> InverseCumulativeRsgModel).Factory
                                                            _dimensionality.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IRNG>) l

                let source = Helper.sourceFold (_InverseCumulativeRsg.source + ".Factory") 
                                               [| _InverseCumulativeRsg.source
                                               ;  _dimensionality.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InverseCumulativeRsg.cell
                                ;  _dimensionality.cell
                                ;  _seed.cell
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
    [<ExcelFunction(Name="_InverseCumulativeRsg", Description="Create a InverseCumulativeRsg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeRsg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="uniformSequenceGenerator",Description = "Reference to uniformSequenceGenerator")>] 
         uniformSequenceGenerator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _uniformSequenceGenerator = Helper.toCell<'USG> uniformSequenceGenerator "uniformSequenceGenerator" true
                let builder () = withMnemonic mnemonic (Fun.InverseCumulativeRsg 
                                                            _uniformSequenceGenerator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseCumulativeRsg>) l

                let source = Helper.sourceFold "Fun.InverseCumulativeRsg" 
                                               [| _uniformSequenceGenerator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _uniformSequenceGenerator.cell
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
    [<ExcelFunction(Name="_InverseCumulativeRsg1", Description="Create a InverseCumulativeRsg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeRsg_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="uniformSequenceGenerator",Description = "Reference to uniformSequenceGenerator")>] 
         uniformSequenceGenerator : obj)
        ([<ExcelArgument(Name="inverseCumulative",Description = "Reference to inverseCumulative")>] 
         inverseCumulative : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _uniformSequenceGenerator = Helper.toCell<'USG> uniformSequenceGenerator "uniformSequenceGenerator" true
                let _inverseCumulative = Helper.toCell<'IC> inverseCumulative "inverseCumulative" true
                let builder () = withMnemonic mnemonic (Fun.InverseCumulativeRsg1 
                                                            _uniformSequenceGenerator.cell 
                                                            _inverseCumulative.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InverseCumulativeRsg>) l

                let source = Helper.sourceFold "Fun.InverseCumulativeRsg1" 
                                               [| _uniformSequenceGenerator.source
                                               ;  _inverseCumulative.source
                                               |]
                let hash = Helper.hashFold 
                                [| _uniformSequenceGenerator.cell
                                ;  _inverseCumulative.cell
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
    [<ExcelFunction(Name="_InverseCumulativeRsg_lastSequence", Description="Create a InverseCumulativeRsg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeRsg_lastSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InverseCumulativeRsg",Description = "Reference to InverseCumulativeRsg")>] 
         inversecumulativersg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InverseCumulativeRsg = Helper.toCell<InverseCumulativeRsg> inversecumulativersg "InverseCumulativeRsg" true 
                let builder () = withMnemonic mnemonic ((_InverseCumulativeRsg.cell :?> InverseCumulativeRsgModel).LastSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InverseCumulativeRsg.source + ".LastSequence") 
                                               [| _InverseCumulativeRsg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InverseCumulativeRsg.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns next sample from the Gaussian distribution
    *)
    [<ExcelFunction(Name="_InverseCumulativeRsg_nextSequence", Description="Create a InverseCumulativeRsg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeRsg_nextSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InverseCumulativeRsg",Description = "Reference to InverseCumulativeRsg")>] 
         inversecumulativersg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InverseCumulativeRsg = Helper.toCell<InverseCumulativeRsg> inversecumulativersg "InverseCumulativeRsg" true 
                let builder () = withMnemonic mnemonic ((_InverseCumulativeRsg.cell :?> InverseCumulativeRsgModel).NextSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InverseCumulativeRsg.source + ".NextSequence") 
                                               [| _InverseCumulativeRsg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InverseCumulativeRsg.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_InverseCumulativeRsg_Range", Description="Create a range of InverseCumulativeRsg",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InverseCumulativeRsg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InverseCumulativeRsg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InverseCumulativeRsg> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InverseCumulativeRsg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InverseCumulativeRsg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InverseCumulativeRsg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)