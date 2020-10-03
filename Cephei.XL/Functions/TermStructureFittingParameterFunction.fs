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
  Deterministic time-dependent parameter used for yield-curve fitting
  </summary> *)
[<AutoSerializable(true)>]
module TermStructureFittingParameterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TermStructureFittingParameter", Description="Create a TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="impl",Description = "Reference to impl")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _impl = Helper.toCell<Parameter.Impl> impl "impl" 
                let builder () = withMnemonic mnemonic (Fun.TermStructureFittingParameter 
                                                            _impl.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TermStructureFittingParameter>) l

                let source = Helper.sourceFold "Fun.TermStructureFittingParameter" 
                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _impl.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TermStructureFittingParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TermStructureFittingParameter1", Description="Create a TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="term",Description = "Reference to term")>] 
         term : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _term = Helper.toHandle<YieldTermStructure> term "term" 
                let builder () = withMnemonic mnemonic (Fun.TermStructureFittingParameter1 
                                                            _term.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TermStructureFittingParameter>) l

                let source = Helper.sourceFold "Fun.TermStructureFittingParameter1" 
                                               [| _term.source
                                               |]
                let hash = Helper.hashFold 
                                [| _term.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TermStructureFittingParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TermStructureFittingParameter_constraint", Description="Create a TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureFittingParameter",Description = "Reference to TermStructureFittingParameter")>] 
         termstructurefittingparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureFittingParameter = Helper.toCell<TermStructureFittingParameter> termstructurefittingparameter "TermStructureFittingParameter"  
                let builder () = withMnemonic mnemonic ((TermStructureFittingParameterModel.Cast _TermStructureFittingParameter.cell).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_TermStructureFittingParameter.source + ".CONSTRAINT") 
                                               [| _TermStructureFittingParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TermStructureFittingParameter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TermStructureFittingParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TermStructureFittingParameter_implementation", Description="Create a TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_implementation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureFittingParameter",Description = "Reference to TermStructureFittingParameter")>] 
         termstructurefittingparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureFittingParameter = Helper.toCell<TermStructureFittingParameter> termstructurefittingparameter "TermStructureFittingParameter"  
                let builder () = withMnemonic mnemonic ((TermStructureFittingParameterModel.Cast _TermStructureFittingParameter.cell).Implementation
                                                       ) :> ICell
                let format (o : Parameter.Impl) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TermStructureFittingParameter.source + ".Implementation") 
                                               [| _TermStructureFittingParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TermStructureFittingParameter.cell
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
    [<ExcelFunction(Name="_TermStructureFittingParameter_parameters", Description="Create a TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureFittingParameter",Description = "Reference to TermStructureFittingParameter")>] 
         termstructurefittingparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureFittingParameter = Helper.toCell<TermStructureFittingParameter> termstructurefittingparameter "TermStructureFittingParameter"  
                let builder () = withMnemonic mnemonic ((TermStructureFittingParameterModel.Cast _TermStructureFittingParameter.cell).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_TermStructureFittingParameter.source + ".Parameters") 
                                               [| _TermStructureFittingParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TermStructureFittingParameter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TermStructureFittingParameter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TermStructureFittingParameter_setParam", Description="Create a TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_setParam
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureFittingParameter",Description = "Reference to TermStructureFittingParameter")>] 
         termstructurefittingparameter : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureFittingParameter = Helper.toCell<TermStructureFittingParameter> termstructurefittingparameter "TermStructureFittingParameter"  
                let _i = Helper.toCell<int> i "i" 
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((TermStructureFittingParameterModel.Cast _TermStructureFittingParameter.cell).SetParam
                                                            _i.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : TermStructureFittingParameter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TermStructureFittingParameter.source + ".SetParam") 
                                               [| _TermStructureFittingParameter.source
                                               ;  _i.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TermStructureFittingParameter.cell
                                ;  _i.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_TermStructureFittingParameter_size", Description="Create a TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureFittingParameter",Description = "Reference to TermStructureFittingParameter")>] 
         termstructurefittingparameter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureFittingParameter = Helper.toCell<TermStructureFittingParameter> termstructurefittingparameter "TermStructureFittingParameter"  
                let builder () = withMnemonic mnemonic ((TermStructureFittingParameterModel.Cast _TermStructureFittingParameter.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TermStructureFittingParameter.source + ".Size") 
                                               [| _TermStructureFittingParameter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TermStructureFittingParameter.cell
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
    [<ExcelFunction(Name="_TermStructureFittingParameter_testParams", Description="Create a TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_testParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureFittingParameter",Description = "Reference to TermStructureFittingParameter")>] 
         termstructurefittingparameter : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureFittingParameter = Helper.toCell<TermStructureFittingParameter> termstructurefittingparameter "TermStructureFittingParameter"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder () = withMnemonic mnemonic ((TermStructureFittingParameterModel.Cast _TermStructureFittingParameter.cell).TestParams
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TermStructureFittingParameter.source + ".TestParams") 
                                               [| _TermStructureFittingParameter.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TermStructureFittingParameter.cell
                                ;  _p.cell
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
    [<ExcelFunction(Name="_TermStructureFittingParameter_value", Description="Create a TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TermStructureFittingParameter",Description = "Reference to TermStructureFittingParameter")>] 
         termstructurefittingparameter : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TermStructureFittingParameter = Helper.toCell<TermStructureFittingParameter> termstructurefittingparameter "TermStructureFittingParameter"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((TermStructureFittingParameterModel.Cast _TermStructureFittingParameter.cell).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_TermStructureFittingParameter.source + ".Value") 
                                               [| _TermStructureFittingParameter.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TermStructureFittingParameter.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_TermStructureFittingParameter_Range", Description="Create a range of TermStructureFittingParameter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TermStructureFittingParameter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TermStructureFittingParameter")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TermStructureFittingParameter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TermStructureFittingParameter>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TermStructureFittingParameter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TermStructureFittingParameter>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
