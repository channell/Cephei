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
  lattices
  </summary> *)
[<AutoSerializable(true)>]
module TrigeorgisFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Trigeorgis_factory", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Trigeorgis_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Reference to Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis" true 
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" true
                let _End = Helper.toCell<double> End "End" true
                let _steps = Helper.toCell<int> steps "steps" true
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_Trigeorgis.cell :?> TrigeorgisModel).Factory
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Trigeorgis>) l

                let source = Helper.sourceFold (_Trigeorgis.source + ".Factory") 
                                               [| _Trigeorgis.source
                                               ;  _Process.source
                                               ;  _End.source
                                               ;  _steps.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Trigeorgis.cell
                                ;  _Process.cell
                                ;  _End.cell
                                ;  _steps.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_Trigeorgis", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Trigeorgis_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" true
                let _End = Helper.toCell<double> End "End" true
                let _steps = Helper.toCell<int> steps "steps" true
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic (Fun.Trigeorgis 
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Trigeorgis>) l

                let source = Helper.sourceFold "Fun.Trigeorgis" 
                                               [| _Process.source
                                               ;  _End.source
                                               ;  _steps.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _End.cell
                                ;  _steps.cell
                                ;  _strike.cell
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
        parameterless constructor is requried for generics
    *)
    [<ExcelFunction(Name="_Trigeorgis1", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Trigeorgis_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Trigeorgis1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Trigeorgis>) l

                let source = Helper.sourceFold "Fun.Trigeorgis1" 
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
    [<ExcelFunction(Name="_Trigeorgis_probability", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Trigeorgis_probability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Reference to Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis" true 
                let _x = Helper.toCell<int> x "x" true
                let _y = Helper.toCell<int> y "y" true
                let _branch = Helper.toCell<int> branch "branch" true
                let builder () = withMnemonic mnemonic ((_Trigeorgis.cell :?> TrigeorgisModel).Probability
                                                            _x.cell 
                                                            _y.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Trigeorgis.source + ".Probability") 
                                               [| _Trigeorgis.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Trigeorgis.cell
                                ;  _x.cell
                                ;  _y.cell
                                ;  _branch.cell
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
    [<ExcelFunction(Name="_Trigeorgis_underlying", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Trigeorgis_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Reference to Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis" true 
                let _i = Helper.toCell<int> i "i" true
                let _index = Helper.toCell<int> index "index" true
                let builder () = withMnemonic mnemonic ((_Trigeorgis.cell :?> TrigeorgisModel).Underlying
                                                            _i.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Trigeorgis.source + ".Underlying") 
                                               [| _Trigeorgis.source
                                               ;  _i.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Trigeorgis.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_Trigeorgis_descendant", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Trigeorgis_descendant
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Reference to Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis" true 
                let _x = Helper.toCell<int> x "x" true
                let _index = Helper.toCell<int> index "index" true
                let _branch = Helper.toCell<int> branch "branch" true
                let builder () = withMnemonic mnemonic ((_Trigeorgis.cell :?> TrigeorgisModel).Descendant
                                                            _x.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Trigeorgis.source + ".Descendant") 
                                               [| _Trigeorgis.source
                                               ;  _x.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Trigeorgis.cell
                                ;  _x.cell
                                ;  _index.cell
                                ;  _branch.cell
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
    [<ExcelFunction(Name="_Trigeorgis_size", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Trigeorgis_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Reference to Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_Trigeorgis.cell :?> TrigeorgisModel).Size
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Trigeorgis.source + ".Size") 
                                               [| _Trigeorgis.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Trigeorgis.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_Trigeorgis_columns", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Trigeorgis_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Reference to Trigeorgis")>] 
         trigeorgis : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis" true 
                let builder () = withMnemonic mnemonic ((_Trigeorgis.cell :?> TrigeorgisModel).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Trigeorgis.source + ".Columns") 
                                               [| _Trigeorgis.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Trigeorgis.cell
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
    [<ExcelFunction(Name="_Trigeorgis_Range", Description="Create a range of Trigeorgis",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Trigeorgis_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Trigeorgis")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Trigeorgis> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Trigeorgis>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Trigeorgis>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Trigeorgis>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
