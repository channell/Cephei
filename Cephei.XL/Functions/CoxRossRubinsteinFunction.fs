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
module CoxRossRubinsteinFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CoxRossRubinstein1", Description="Create a CoxRossRubinstein",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxRossRubinstein_create1
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

                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic (Fun.CoxRossRubinstein1 
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CoxRossRubinstein>) l

                let source = Helper.sourceFold "Fun.CoxRossRubinstein1" 
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
                    ; subscriber = Helper.subscriberModel<CoxRossRubinstein> format
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
    [<ExcelFunction(Name="_CoxRossRubinstein", Description="Create a CoxRossRubinstein",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxRossRubinstein_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CoxRossRubinstein ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CoxRossRubinstein>) l

                let source = Helper.sourceFold "Fun.CoxRossRubinstein" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CoxRossRubinstein> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CoxRossRubinstein_factory", Description="Create a CoxRossRubinstein",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxRossRubinstein_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxRossRubinstein",Description = "Reference to CoxRossRubinstein")>] 
         coxrossrubinstein : obj)
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

                let _CoxRossRubinstein = Helper.toCell<CoxRossRubinstein> coxrossrubinstein "CoxRossRubinstein"  
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _strike = Helper.toCell<double> strike "strike" 
                let builder () = withMnemonic mnemonic ((_CoxRossRubinstein.cell :?> CoxRossRubinsteinModel).Factory
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _strike.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CoxRossRubinstein>) l

                let source = Helper.sourceFold (_CoxRossRubinstein.source + ".Factory") 
                                               [| _CoxRossRubinstein.source
                                               ;  _Process.source
                                               ;  _End.source
                                               ;  _steps.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxRossRubinstein.cell
                                ;  _Process.cell
                                ;  _End.cell
                                ;  _steps.cell
                                ;  _strike.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CoxRossRubinstein> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CoxRossRubinstein_probability", Description="Create a CoxRossRubinstein",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxRossRubinstein_probability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxRossRubinstein",Description = "Reference to CoxRossRubinstein")>] 
         coxrossrubinstein : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxRossRubinstein = Helper.toCell<CoxRossRubinstein> coxrossrubinstein "CoxRossRubinstein"  
                let _x = Helper.toCell<int> x "x" 
                let _y = Helper.toCell<int> y "y" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder () = withMnemonic mnemonic ((_CoxRossRubinstein.cell :?> CoxRossRubinsteinModel).Probability
                                                            _x.cell 
                                                            _y.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxRossRubinstein.source + ".Probability") 
                                               [| _CoxRossRubinstein.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxRossRubinstein.cell
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
    [<ExcelFunction(Name="_CoxRossRubinstein_underlying", Description="Create a CoxRossRubinstein",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxRossRubinstein_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxRossRubinstein",Description = "Reference to CoxRossRubinstein")>] 
         coxrossrubinstein : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxRossRubinstein = Helper.toCell<CoxRossRubinstein> coxrossrubinstein "CoxRossRubinstein"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((_CoxRossRubinstein.cell :?> CoxRossRubinsteinModel).Underlying
                                                            _i.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxRossRubinstein.source + ".Underlying") 
                                               [| _CoxRossRubinstein.source
                                               ;  _i.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxRossRubinstein.cell
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
    [<ExcelFunction(Name="_CoxRossRubinstein_descendant", Description="Create a CoxRossRubinstein",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxRossRubinstein_descendant
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxRossRubinstein",Description = "Reference to CoxRossRubinstein")>] 
         coxrossrubinstein : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxRossRubinstein = Helper.toCell<CoxRossRubinstein> coxrossrubinstein "CoxRossRubinstein"  
                let _x = Helper.toCell<int> x "x" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder () = withMnemonic mnemonic ((_CoxRossRubinstein.cell :?> CoxRossRubinsteinModel).Descendant
                                                            _x.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxRossRubinstein.source + ".Descendant") 
                                               [| _CoxRossRubinstein.source
                                               ;  _x.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxRossRubinstein.cell
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
    [<ExcelFunction(Name="_CoxRossRubinstein_size", Description="Create a CoxRossRubinstein",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxRossRubinstein_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxRossRubinstein",Description = "Reference to CoxRossRubinstein")>] 
         coxrossrubinstein : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxRossRubinstein = Helper.toCell<CoxRossRubinstein> coxrossrubinstein "CoxRossRubinstein"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_CoxRossRubinstein.cell :?> CoxRossRubinsteinModel).Size
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxRossRubinstein.source + ".Size") 
                                               [| _CoxRossRubinstein.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxRossRubinstein.cell
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
    [<ExcelFunction(Name="_CoxRossRubinstein_columns", Description="Create a CoxRossRubinstein",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxRossRubinstein_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxRossRubinstein",Description = "Reference to CoxRossRubinstein")>] 
         coxrossrubinstein : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxRossRubinstein = Helper.toCell<CoxRossRubinstein> coxrossrubinstein "CoxRossRubinstein"  
                let builder () = withMnemonic mnemonic ((_CoxRossRubinstein.cell :?> CoxRossRubinsteinModel).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxRossRubinstein.source + ".Columns") 
                                               [| _CoxRossRubinstein.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxRossRubinstein.cell
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
    [<ExcelFunction(Name="_CoxRossRubinstein_Range", Description="Create a range of CoxRossRubinstein",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxRossRubinstein_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CoxRossRubinstein")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CoxRossRubinstein> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CoxRossRubinstein>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CoxRossRubinstein>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CoxRossRubinstein>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
