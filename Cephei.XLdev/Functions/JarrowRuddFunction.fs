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
module JarrowRuddFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_JarrowRudd_factory", Description="Create a JarrowRudd",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JarrowRudd_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JarrowRudd",Description = "Reference to JarrowRudd")>] 
         jarrowrudd : obj)
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

                let _JarrowRudd = Helper.toCell<JarrowRudd> jarrowrudd "JarrowRudd" true 
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" true
                let _End = Helper.toCell<double> End "End" true
                let _steps = Helper.toCell<int> steps "steps" true
                let _strike = Helper.toCell<double> strike "strike" true
                let builder () = withMnemonic mnemonic ((_JarrowRudd.cell :?> JarrowRuddModel).Factory
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JarrowRudd>) l

                let source = Helper.sourceFold (_JarrowRudd.source + ".Factory") 
                                               [| _JarrowRudd.source
                                               ;  _Process.source
                                               ;  _End.source
                                               ;  _steps.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JarrowRudd.cell
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
    [<ExcelFunction(Name="_JarrowRudd", Description="Create a JarrowRudd",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JarrowRudd_create
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
                let builder () = withMnemonic mnemonic (Fun.JarrowRudd 
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JarrowRudd>) l

                let source = Helper.sourceFold "Fun.JarrowRudd" 
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
    [<ExcelFunction(Name="_JarrowRudd1", Description="Create a JarrowRudd",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JarrowRudd_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.JarrowRudd1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JarrowRudd>) l

                let source = Helper.sourceFold "Fun.JarrowRudd1" 
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
    [<ExcelFunction(Name="_JarrowRudd_probability", Description="Create a JarrowRudd",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JarrowRudd_probability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JarrowRudd",Description = "Reference to JarrowRudd")>] 
         jarrowrudd : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="z",Description = "Reference to z")>] 
         z : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JarrowRudd = Helper.toCell<JarrowRudd> jarrowrudd "JarrowRudd" true 
                let _x = Helper.toCell<int> x "x" true
                let _y = Helper.toCell<int> y "y" true
                let _z = Helper.toCell<int> z "z" true
                let builder () = withMnemonic mnemonic ((_JarrowRudd.cell :?> JarrowRuddModel).Probability
                                                            _x.cell 
                                                            _y.cell 
                                                            _z.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_JarrowRudd.source + ".Probability") 
                                               [| _JarrowRudd.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _z.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JarrowRudd.cell
                                ;  _x.cell
                                ;  _y.cell
                                ;  _z.cell
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
    [<ExcelFunction(Name="_JarrowRudd_underlying", Description="Create a JarrowRudd",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JarrowRudd_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JarrowRudd",Description = "Reference to JarrowRudd")>] 
         jarrowrudd : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JarrowRudd = Helper.toCell<JarrowRudd> jarrowrudd "JarrowRudd" true 
                let _i = Helper.toCell<int> i "i" true
                let _index = Helper.toCell<int> index "index" true
                let builder () = withMnemonic mnemonic ((_JarrowRudd.cell :?> JarrowRuddModel).Underlying
                                                            _i.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_JarrowRudd.source + ".Underlying") 
                                               [| _JarrowRudd.source
                                               ;  _i.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JarrowRudd.cell
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
    [<ExcelFunction(Name="_JarrowRudd_descendant", Description="Create a JarrowRudd",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JarrowRudd_descendant
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JarrowRudd",Description = "Reference to JarrowRudd")>] 
         jarrowrudd : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JarrowRudd = Helper.toCell<JarrowRudd> jarrowrudd "JarrowRudd" true 
                let _x = Helper.toCell<int> x "x" true
                let _index = Helper.toCell<int> index "index" true
                let _branch = Helper.toCell<int> branch "branch" true
                let builder () = withMnemonic mnemonic ((_JarrowRudd.cell :?> JarrowRuddModel).Descendant
                                                            _x.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_JarrowRudd.source + ".Descendant") 
                                               [| _JarrowRudd.source
                                               ;  _x.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JarrowRudd.cell
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
    [<ExcelFunction(Name="_JarrowRudd_size", Description="Create a JarrowRudd",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JarrowRudd_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JarrowRudd",Description = "Reference to JarrowRudd")>] 
         jarrowrudd : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JarrowRudd = Helper.toCell<JarrowRudd> jarrowrudd "JarrowRudd" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_JarrowRudd.cell :?> JarrowRuddModel).Size
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_JarrowRudd.source + ".Size") 
                                               [| _JarrowRudd.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JarrowRudd.cell
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
    [<ExcelFunction(Name="_JarrowRudd_columns", Description="Create a JarrowRudd",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JarrowRudd_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JarrowRudd",Description = "Reference to JarrowRudd")>] 
         jarrowrudd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JarrowRudd = Helper.toCell<JarrowRudd> jarrowrudd "JarrowRudd" true 
                let builder () = withMnemonic mnemonic ((_JarrowRudd.cell :?> JarrowRuddModel).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_JarrowRudd.source + ".Columns") 
                                               [| _JarrowRudd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JarrowRudd.cell
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
    [<ExcelFunction(Name="_JarrowRudd_Range", Description="Create a range of JarrowRudd",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let JarrowRudd_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the JarrowRudd")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<JarrowRudd> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<JarrowRudd>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<JarrowRudd>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<JarrowRudd>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
