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
Interface class to map the functionality of SobolBrownianGenerator to the "conventional" sequence generator interface
  </summary> *)
[<AutoSerializable(true)>]
module SobolBrownianBridgeRsgFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SobolBrownianBridgeRsg_dimension", Description="Create a SobolBrownianBridgeRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianBridgeRsg_dimension
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianBridgeRsg",Description = "Reference to SobolBrownianBridgeRsg")>] 
         sobolbrownianbridgersg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianBridgeRsg = Helper.toCell<SobolBrownianBridgeRsg> sobolbrownianbridgersg "SobolBrownianBridgeRsg"  
                let builder () = withMnemonic mnemonic ((SobolBrownianBridgeRsgModel.Cast _SobolBrownianBridgeRsg.cell).Dimension
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SobolBrownianBridgeRsg.source + ".Dimension") 
                                               [| _SobolBrownianBridgeRsg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianBridgeRsg.cell
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
    [<ExcelFunction(Name="_SobolBrownianBridgeRsg_factory", Description="Create a SobolBrownianBridgeRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianBridgeRsg_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianBridgeRsg",Description = "Reference to SobolBrownianBridgeRsg")>] 
         sobolbrownianbridgersg : obj)
        ([<ExcelArgument(Name="dimensionality",Description = "Reference to dimensionality")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="seed",Description = "Reference to seed")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianBridgeRsg = Helper.toCell<SobolBrownianBridgeRsg> sobolbrownianbridgersg "SobolBrownianBridgeRsg"  
                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let _seed = Helper.toDefault<uint64> seed "seed" 0UL
                let builder () = withMnemonic mnemonic ((SobolBrownianBridgeRsgModel.Cast _SobolBrownianBridgeRsg.cell).Factory
                                                            _dimensionality.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IRNG>) l

                let source = Helper.sourceFold (_SobolBrownianBridgeRsg.source + ".Factory") 
                                               [| _SobolBrownianBridgeRsg.source
                                               ;  _dimensionality.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianBridgeRsg.cell
                                ;  _dimensionality.cell
                                ;  _seed.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolBrownianBridgeRsg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! sample not suppoorted bh helper
    [<ExcelFunction(Name="_SobolBrownianBridgeRsg_lastSequence", Description="Create a SobolBrownianBridgeRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianBridgeRsg_lastSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianBridgeRsg",Description = "Reference to SobolBrownianBridgeRsg")>] 
         sobolbrownianbridgersg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianBridgeRsg = Helper.toCell<SobolBrownianBridgeRsg> sobolbrownianbridgersg "SobolBrownianBridgeRsg"  
                let builder () = withMnemonic mnemonic ((SobolBrownianBridgeRsgModel.Cast _SobolBrownianBridgeRsg.cell).LastSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SobolBrownianBridgeRsg.source + ".LastSequence") 
                                               [| _SobolBrownianBridgeRsg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianBridgeRsg.cell
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
            *)
    (*
        
    *)
    (*!! Sample not supported by Helper
    [<ExcelFunction(Name="_SobolBrownianBridgeRsg_nextSequence", Description="Create a SobolBrownianBridgeRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianBridgeRsg_nextSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolBrownianBridgeRsg",Description = "Reference to SobolBrownianBridgeRsg")>] 
         sobolbrownianbridgersg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolBrownianBridgeRsg = Helper.toCell<SobolBrownianBridgeRsg> sobolbrownianbridgersg "SobolBrownianBridgeRsg"  
                let builder () = withMnemonic mnemonic ((SobolBrownianBridgeRsgModel.Cast _SobolBrownianBridgeRsg.cell).NextSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SobolBrownianBridgeRsg.source + ".NextSequence") 
                                               [| _SobolBrownianBridgeRsg.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolBrownianBridgeRsg.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_SobolBrownianBridgeRsg", Description="Create a SobolBrownianBridgeRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianBridgeRsg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="factors",Description = "Reference to factors")>] 
         factors : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        ([<ExcelArgument(Name="ordering",Description = "Reference to ordering")>] 
         ordering : obj)
        ([<ExcelArgument(Name="seed",Description = "Reference to seed")>] 
         seed : obj)
        ([<ExcelArgument(Name="directionIntegers",Description = "Reference to directionIntegers")>] 
         directionIntegers : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _factors = Helper.toCell<int> factors "factors" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _ordering = Helper.toDefault<SobolBrownianGenerator.Ordering> ordering "ordering" SobolBrownianGenerator.Ordering.Diagonal
                let _seed = Helper.toDefault<uint64> seed "seed" 0UL
                let _directionIntegers = Helper.toDefault<SobolRsg.DirectionIntegers> directionIntegers "directionIntegers" SobolRsg.DirectionIntegers.JoeKuoD7
                let builder () = withMnemonic mnemonic (Fun.SobolBrownianBridgeRsg 
                                                            _factors.cell 
                                                            _steps.cell 
                                                            _ordering.cell 
                                                            _seed.cell 
                                                            _directionIntegers.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SobolBrownianBridgeRsg>) l

                let source = Helper.sourceFold "Fun.SobolBrownianBridgeRsg" 
                                               [| _factors.source
                                               ;  _steps.source
                                               ;  _ordering.source
                                               ;  _seed.source
                                               ;  _directionIntegers.source
                                               |]
                let hash = Helper.hashFold 
                                [| _factors.cell
                                ;  _steps.cell
                                ;  _ordering.cell
                                ;  _seed.cell
                                ;  _directionIntegers.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolBrownianBridgeRsg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SobolBrownianBridgeRsg_Range", Description="Create a range of SobolBrownianBridgeRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolBrownianBridgeRsg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SobolBrownianBridgeRsg")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SobolBrownianBridgeRsg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SobolBrownianBridgeRsg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SobolBrownianBridgeRsg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SobolBrownianBridgeRsg>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
