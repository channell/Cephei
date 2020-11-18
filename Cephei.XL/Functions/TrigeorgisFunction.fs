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
    [<ExcelFunction(Name="_Trigeorgis_factory", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Trigeorgis_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess1D")>] 
         Process : obj)
        ([<ExcelArgument(Name="End",Description = "double")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "int")>] 
         steps : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis"  
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrigeorgisModel.Cast _Trigeorgis.cell).Factory
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Trigeorgis>) l

                let source () = Helper.sourceFold (_Trigeorgis.source + ".Factory") 

                                               [| _Process.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Trigeorgis> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Trigeorgis1", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Trigeorgis_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess1D")>] 
         Process : obj)
        ([<ExcelArgument(Name="End",Description = "double")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "int")>] 
         steps : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Trigeorgis1 
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Trigeorgis>) l

                let source () = Helper.sourceFold "Fun.Trigeorgis1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Trigeorgis> format
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
    [<ExcelFunction(Name="_Trigeorgis", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Trigeorgis_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Trigeorgis ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Trigeorgis>) l

                let source () = Helper.sourceFold "Fun.Trigeorgis" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Trigeorgis> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Trigeorgis_probability", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Trigeorgis_probability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="x",Description = "int")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "int")>] 
         y : obj)
        ([<ExcelArgument(Name="branch",Description = "int")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis"  
                let _x = Helper.toCell<int> x "x" 
                let _y = Helper.toCell<int> y "y" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrigeorgisModel.Cast _Trigeorgis.cell).Probability
                                                            _x.cell 
                                                            _y.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Trigeorgis.source + ".Probability") 

                                               [| _x.source
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
    [<ExcelFunction(Name="_Trigeorgis_underlying", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Trigeorgis_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrigeorgisModel.Cast _Trigeorgis.cell).Underlying
                                                            _i.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Trigeorgis.source + ".Underlying") 

                                               [| _i.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Trigeorgis.cell
                                ;  _i.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_Trigeorgis_descendant", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Trigeorgis_descendant
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="x",Description = "int")>] 
         x : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "int")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis"  
                let _x = Helper.toCell<int> x "x" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrigeorgisModel.Cast _Trigeorgis.cell).Descendant
                                                            _x.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Trigeorgis.source + ".Descendant") 

                                               [| _x.source
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
    [<ExcelFunction(Name="_Trigeorgis_size", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Trigeorgis_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Trigeorgis")>] 
         trigeorgis : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrigeorgisModel.Cast _Trigeorgis.cell).Size
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Trigeorgis.source + ".Size") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Trigeorgis.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_Trigeorgis_columns", Description="Create a Trigeorgis",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Trigeorgis_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Trigeorgis",Description = "Trigeorgis")>] 
         trigeorgis : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Trigeorgis = Helper.toCell<Trigeorgis> trigeorgis "Trigeorgis"  
                let builder (current : ICell) = withMnemonic mnemonic ((TrigeorgisModel.Cast _Trigeorgis.cell).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Trigeorgis.source + ".Columns") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Trigeorgis.cell
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
    [<ExcelFunction(Name="_Trigeorgis_Range", Description="Create a range of Trigeorgis",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Trigeorgis_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Trigeorgis> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<Trigeorgis> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<Trigeorgis>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Trigeorgis>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
