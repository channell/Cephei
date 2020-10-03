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

  </summary> *)
[<AutoSerializable(true)>]
module FdmSimpleProcess1DMesherFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmSimpleProcess1DMesher", Description="Create a FdmSimpleProcess1DMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSimpleProcess1DMesher_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="tAvgSteps",Description = "Reference to tAvgSteps")>] 
         tAvgSteps : obj)
        ([<ExcelArgument(Name="epsilon",Description = "Reference to epsilon")>] 
         epsilon : obj)
        ([<ExcelArgument(Name="mandatoryPoint",Description = "Reference to mandatoryPoint")>] 
         mandatoryPoint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _tAvgSteps = Helper.toDefault<int> tAvgSteps "tAvgSteps" 10
                let _epsilon = Helper.toDefault<double> epsilon "epsilon" 0.0001
                let _mandatoryPoint = Helper.toNullable<double> mandatoryPoint "mandatoryPoint"
                let builder () = withMnemonic mnemonic (Fun.FdmSimpleProcess1DMesher 
                                                            _size.cell 
                                                            _Process.cell 
                                                            _maturity.cell 
                                                            _tAvgSteps.cell 
                                                            _epsilon.cell 
                                                            _mandatoryPoint.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSimpleProcess1DMesher>) l

                let source = Helper.sourceFold "Fun.FdmSimpleProcess1DMesher" 
                                               [| _size.source
                                               ;  _Process.source
                                               ;  _maturity.source
                                               ;  _tAvgSteps.source
                                               ;  _epsilon.source
                                               ;  _mandatoryPoint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                ;  _Process.cell
                                ;  _maturity.cell
                                ;  _tAvgSteps.cell
                                ;  _epsilon.cell
                                ;  _mandatoryPoint.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSimpleProcess1DMesher> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSimpleProcess1DMesher_dminus", Description="Create a FdmSimpleProcess1DMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSimpleProcess1DMesher_dminus
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSimpleProcess1DMesher",Description = "Reference to FdmSimpleProcess1DMesher")>] 
         fdmsimpleprocess1dmesher : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSimpleProcess1DMesher = Helper.toCell<FdmSimpleProcess1DMesher> fdmsimpleprocess1dmesher "FdmSimpleProcess1DMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((_FdmSimpleProcess1DMesher.cell :?> FdmSimpleProcess1DMesherModel).Dminus
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmSimpleProcess1DMesher.source + ".Dminus") 
                                               [| _FdmSimpleProcess1DMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSimpleProcess1DMesher.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_FdmSimpleProcess1DMesher_dplus", Description="Create a FdmSimpleProcess1DMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSimpleProcess1DMesher_dplus
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSimpleProcess1DMesher",Description = "Reference to FdmSimpleProcess1DMesher")>] 
         fdmsimpleprocess1dmesher : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSimpleProcess1DMesher = Helper.toCell<FdmSimpleProcess1DMesher> fdmsimpleprocess1dmesher "FdmSimpleProcess1DMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((_FdmSimpleProcess1DMesher.cell :?> FdmSimpleProcess1DMesherModel).Dplus
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmSimpleProcess1DMesher.source + ".Dplus") 
                                               [| _FdmSimpleProcess1DMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSimpleProcess1DMesher.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_FdmSimpleProcess1DMesher_location", Description="Create a FdmSimpleProcess1DMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSimpleProcess1DMesher_location
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSimpleProcess1DMesher",Description = "Reference to FdmSimpleProcess1DMesher")>] 
         fdmsimpleprocess1dmesher : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSimpleProcess1DMesher = Helper.toCell<FdmSimpleProcess1DMesher> fdmsimpleprocess1dmesher "FdmSimpleProcess1DMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((_FdmSimpleProcess1DMesher.cell :?> FdmSimpleProcess1DMesherModel).Location
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmSimpleProcess1DMesher.source + ".Location") 
                                               [| _FdmSimpleProcess1DMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSimpleProcess1DMesher.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_FdmSimpleProcess1DMesher_locations", Description="Create a FdmSimpleProcess1DMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSimpleProcess1DMesher_locations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSimpleProcess1DMesher",Description = "Reference to FdmSimpleProcess1DMesher")>] 
         fdmsimpleprocess1dmesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSimpleProcess1DMesher = Helper.toCell<FdmSimpleProcess1DMesher> fdmsimpleprocess1dmesher "FdmSimpleProcess1DMesher"  
                let builder () = withMnemonic mnemonic ((_FdmSimpleProcess1DMesher.cell :?> FdmSimpleProcess1DMesherModel).Locations
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FdmSimpleProcess1DMesher.source + ".Locations") 
                                               [| _FdmSimpleProcess1DMesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSimpleProcess1DMesher.cell
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
        
    *)
    [<ExcelFunction(Name="_FdmSimpleProcess1DMesher_size", Description="Create a FdmSimpleProcess1DMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSimpleProcess1DMesher_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSimpleProcess1DMesher",Description = "Reference to FdmSimpleProcess1DMesher")>] 
         fdmsimpleprocess1dmesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSimpleProcess1DMesher = Helper.toCell<FdmSimpleProcess1DMesher> fdmsimpleprocess1dmesher "FdmSimpleProcess1DMesher"  
                let builder () = withMnemonic mnemonic ((_FdmSimpleProcess1DMesher.cell :?> FdmSimpleProcess1DMesherModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmSimpleProcess1DMesher.source + ".Size") 
                                               [| _FdmSimpleProcess1DMesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSimpleProcess1DMesher.cell
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
    [<ExcelFunction(Name="_FdmSimpleProcess1DMesher_Range", Description="Create a range of FdmSimpleProcess1DMesher",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSimpleProcess1DMesher_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmSimpleProcess1DMesher")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmSimpleProcess1DMesher> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmSimpleProcess1DMesher>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmSimpleProcess1DMesher>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmSimpleProcess1DMesher>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"