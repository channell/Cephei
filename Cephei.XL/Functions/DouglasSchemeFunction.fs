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

  </summary> *)
[<AutoSerializable(true)>]
module DouglasSchemeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DouglasScheme", Description="Create a DouglasScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DouglasScheme_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        ([<ExcelArgument(Name="map",Description = "Reference to map")>] 
         map : obj)
        ([<ExcelArgument(Name="bcSet",Description = "Reference to bcSet")>] 
         bcSet : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _theta = Helper.toDefault<double> theta "theta" 1.0
                let _map = Helper.toCell<FdmLinearOpComposite> map "map" 
                let _bcSet = Helper.toDefault<Generic.List<BoundaryCondition<FdmLinearOp>>> bcSet "bcSet" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DouglasScheme 
                                                            _theta.cell 
                                                            _map.cell 
                                                            _bcSet.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DouglasScheme>) l

                let source () = Helper.sourceFold "Fun.DouglasScheme" 
                                               [| _theta.source
                                               ;  _map.source
                                               ;  _bcSet.source
                                               |]
                let hash = Helper.hashFold 
                                [| _theta.cell
                                ;  _map.cell
                                ;  _bcSet.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DouglasScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DouglasScheme1", Description="Create a DouglasScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DouglasScheme_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.DouglasScheme1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DouglasScheme>) l

                let source () = Helper.sourceFold "Fun.DouglasScheme1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DouglasScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DouglasScheme_factory", Description="Create a DouglasScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DouglasScheme_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DouglasScheme",Description = "Reference to DouglasScheme")>] 
         douglasscheme : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        ([<ExcelArgument(Name="additionalInputs",Description = "Reference to additionalInputs")>] 
         additionalInputs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DouglasScheme = Helper.toCell<DouglasScheme> douglasscheme "DouglasScheme"  
                let _L = Helper.toCell<Object> L "L" 
                let _bcs = Helper.toCell<Object> bcs "bcs" 
                let _additionalInputs = Helper.toDefault<Object[]> additionalInputs "additionalInputs" null
                let builder (current : ICell) = withMnemonic mnemonic ((DouglasSchemeModel.Cast _DouglasScheme.cell).Factory
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _additionalInputs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IMixedScheme>) l

                let source () = Helper.sourceFold (_DouglasScheme.source + ".Factory") 
                                               [| _DouglasScheme.source
                                               ;  _L.source
                                               ;  _bcs.source
                                               ;  _additionalInputs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DouglasScheme.cell
                                ;  _L.cell
                                ;  _bcs.cell
                                ;  _additionalInputs.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DouglasScheme> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DouglasScheme_setStep", Description="Create a DouglasScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DouglasScheme_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DouglasScheme",Description = "Reference to DouglasScheme")>] 
         douglasscheme : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DouglasScheme = Helper.toCell<DouglasScheme> douglasscheme "DouglasScheme"  
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((DouglasSchemeModel.Cast _DouglasScheme.cell).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : DouglasScheme) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DouglasScheme.source + ".SetStep") 
                                               [| _DouglasScheme.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DouglasScheme.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_DouglasScheme_step", Description="Create a DouglasScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DouglasScheme_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DouglasScheme",Description = "Reference to DouglasScheme")>] 
         douglasscheme : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DouglasScheme = Helper.toCell<DouglasScheme> douglasscheme "DouglasScheme"  
                let _a = Helper.toCell<Object> a "a" 
                let _t = Helper.toCell<double> t "t" 
                let _theta = Helper.toDefault<double> theta "theta" 1.0
                let builder (current : ICell) = withMnemonic mnemonic ((DouglasSchemeModel.Cast _DouglasScheme.cell).Step
                                                            _a.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : DouglasScheme) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DouglasScheme.source + ".Step") 
                                               [| _DouglasScheme.source
                                               ;  _a.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DouglasScheme.cell
                                ;  _a.cell
                                ;  _t.cell
                                ;  _theta.cell
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
    [<ExcelFunction(Name="_DouglasScheme_Range", Description="Create a range of DouglasScheme",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DouglasScheme_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DouglasScheme")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DouglasScheme> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DouglasScheme>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DouglasScheme>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DouglasScheme>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
