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
  References: K. J. in ’t Hout and S. Foulon, ADI finite difference schemes for option pricing in the Heston model with correlation, http://arxiv.org/pdf/0811.3427
  </summary> *)
[<AutoSerializable(true)>]
module ModifiedCraigSneydSchemeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ModifiedCraigSneydScheme_factory", Description="Create a ModifiedCraigSneydScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ModifiedCraigSneydScheme_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ModifiedCraigSneydScheme",Description = "Reference to ModifiedCraigSneydScheme")>] 
         modifiedcraigsneydscheme : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        ([<ExcelArgument(Name="additionalInputs",Description = "Reference to additionalInputs")>] 
         additionalInputs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ModifiedCraigSneydScheme = Helper.toCell<ModifiedCraigSneydScheme> modifiedcraigsneydscheme "ModifiedCraigSneydScheme" true 
                let _L = Helper.toCell<Object> L "L" true
                let _bcs = Helper.toCell<Object> bcs "bcs" true
                let _additionalInputs = Helper.toCell<Object[]> additionalInputs "additionalInputs" true
                let builder () = withMnemonic mnemonic ((_ModifiedCraigSneydScheme.cell :?> ModifiedCraigSneydSchemeModel).Factory
                                                            _L.cell 
                                                            _bcs.cell 
                                                            _additionalInputs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IMixedScheme>) l

                let source = Helper.sourceFold (_ModifiedCraigSneydScheme.source + ".Factory") 
                                               [| _ModifiedCraigSneydScheme.source
                                               ;  _L.source
                                               ;  _bcs.source
                                               ;  _additionalInputs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ModifiedCraigSneydScheme.cell
                                ;  _L.cell
                                ;  _bcs.cell
                                ;  _additionalInputs.cell
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
    [<ExcelFunction(Name="_ModifiedCraigSneydScheme1", Description="Create a ModifiedCraigSneydScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ModifiedCraigSneydScheme_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        ([<ExcelArgument(Name="mu",Description = "Reference to mu")>] 
         mu : obj)
        ([<ExcelArgument(Name="map",Description = "Reference to map")>] 
         map : obj)
        ([<ExcelArgument(Name="bcSet",Description = "Reference to bcSet")>] 
         bcSet : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _theta = Helper.toCell<double> theta "theta" true
                let _mu = Helper.toCell<double> mu "mu" true
                let _map = Helper.toCell<FdmLinearOpComposite> map "map" true
                let _bcSet = Helper.toCell<Generic.List<BoundaryCondition<FdmLinearOp>>> bcSet "bcSet" true
                let builder () = withMnemonic mnemonic (Fun.ModifiedCraigSneydScheme1
                                                            _theta.cell 
                                                            _mu.cell 
                                                            _map.cell 
                                                            _bcSet.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ModifiedCraigSneydScheme>) l

                let source = Helper.sourceFold "Fun.ModifiedCraigSneydScheme1" 
                                               [| _theta.source
                                               ;  _mu.source
                                               ;  _map.source
                                               ;  _bcSet.source
                                               |]
                let hash = Helper.hashFold 
                                [| _theta.cell
                                ;  _mu.cell
                                ;  _map.cell
                                ;  _bcSet.cell
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
    [<ExcelFunction(Name="_ModifiedCraigSneydScheme", Description="Create a ModifiedCraigSneydScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ModifiedCraigSneydScheme_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ModifiedCraigSneydScheme ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ModifiedCraigSneydScheme>) l

                let source = Helper.sourceFold "Fun.ModifiedCraigSneydScheme ()" 
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
    [<ExcelFunction(Name="_ModifiedCraigSneydScheme_setStep", Description="Create a ModifiedCraigSneydScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ModifiedCraigSneydScheme_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ModifiedCraigSneydScheme",Description = "Reference to ModifiedCraigSneydScheme")>] 
         modifiedcraigsneydscheme : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ModifiedCraigSneydScheme = Helper.toCell<ModifiedCraigSneydScheme> modifiedcraigsneydscheme "ModifiedCraigSneydScheme" true 
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_ModifiedCraigSneydScheme.cell :?> ModifiedCraigSneydSchemeModel).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : ModifiedCraigSneydScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ModifiedCraigSneydScheme.source + ".SetStep") 
                                               [| _ModifiedCraigSneydScheme.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ModifiedCraigSneydScheme.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_ModifiedCraigSneydScheme_step", Description="Create a ModifiedCraigSneydScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ModifiedCraigSneydScheme_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ModifiedCraigSneydScheme",Description = "Reference to ModifiedCraigSneydScheme")>] 
         modifiedcraigsneydscheme : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ModifiedCraigSneydScheme = Helper.toCell<ModifiedCraigSneydScheme> modifiedcraigsneydscheme "ModifiedCraigSneydScheme" true 
                let _a = Helper.toCell<Object> a "a" true
                let _t = Helper.toCell<double> t "t" true
                let _theta = Helper.toCell<double> theta "theta" true
                let builder () = withMnemonic mnemonic ((_ModifiedCraigSneydScheme.cell :?> ModifiedCraigSneydSchemeModel).Step
                                                            _a.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : ModifiedCraigSneydScheme) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ModifiedCraigSneydScheme.source + ".Step") 
                                               [| _ModifiedCraigSneydScheme.source
                                               ;  _a.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ModifiedCraigSneydScheme.cell
                                ;  _a.cell
                                ;  _t.cell
                                ;  _theta.cell
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
    [<ExcelFunction(Name="_ModifiedCraigSneydScheme_Range", Description="Create a range of ModifiedCraigSneydScheme",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ModifiedCraigSneydScheme_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ModifiedCraigSneydScheme")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ModifiedCraigSneydScheme> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ModifiedCraigSneydScheme>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ModifiedCraigSneydScheme>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ModifiedCraigSneydScheme>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
