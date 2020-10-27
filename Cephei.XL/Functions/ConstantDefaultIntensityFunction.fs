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
module ConstantDefaultIntensityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConstantDefaultIntensity", Description="Create a ConstantDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantDefaultIntensity_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="constant",Description = "double")>] 
         constant : obj)
        ([<ExcelArgument(Name="recovery",Description = "double")>] 
         recovery : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _constant = Helper.toCell<double> constant "constant" 
                let _recovery = Helper.toCell<double> recovery "recovery" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantDefaultIntensity 
                                                            _constant.cell 
                                                            _recovery.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantDefaultIntensity>) l

                let source () = Helper.sourceFold "Fun.ConstantDefaultIntensity" 
                                               [| _constant.source
                                               ;  _recovery.source
                                               |]
                let hash = Helper.hashFold 
                                [| _constant.cell
                                ;  _recovery.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantDefaultIntensity> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantDefaultIntensity1", Description="Create a ConstantDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantDefaultIntensity_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="constant",Description = "double")>] 
         constant : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _constant = Helper.toCell<double> constant "constant" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ConstantDefaultIntensity1 
                                                            _constant.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantDefaultIntensity>) l

                let source () = Helper.sourceFold "Fun.ConstantDefaultIntensity1" 
                                               [| _constant.source
                                               |]
                let hash = Helper.hashFold 
                                [| _constant.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantDefaultIntensity> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantDefaultIntensity_defaultRecovery", Description="Create a ConstantDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantDefaultIntensity_defaultRecovery
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantDefaultIntensity",Description = "ConstantDefaultIntensity")>] 
         constantdefaultintensity : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantDefaultIntensity = Helper.toCell<ConstantDefaultIntensity> constantdefaultintensity "ConstantDefaultIntensity"  
                let _t = Helper.toCell<double> t "t" 
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantDefaultIntensityModel.Cast _ConstantDefaultIntensity.cell).DefaultRecovery
                                                            _t.cell 
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantDefaultIntensity.source + ".DefaultRecovery") 

                                               [| _t.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantDefaultIntensity.cell
                                ;  _t.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_ConstantDefaultIntensity_hazardRate", Description="Create a ConstantDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantDefaultIntensity_hazardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantDefaultIntensity",Description = "ConstantDefaultIntensity")>] 
         constantdefaultintensity : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantDefaultIntensity = Helper.toCell<ConstantDefaultIntensity> constantdefaultintensity "ConstantDefaultIntensity"  
                let _t = Helper.toCell<double> t "t" 
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConstantDefaultIntensityModel.Cast _ConstantDefaultIntensity.cell).HazardRate
                                                            _t.cell 
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConstantDefaultIntensity.source + ".HazardRate") 

                                               [| _t.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantDefaultIntensity.cell
                                ;  _t.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_ConstantDefaultIntensity_Range", Description="Create a range of ConstantDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantDefaultIntensity_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConstantDefaultIntensity> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConstantDefaultIntensity>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConstantDefaultIntensity>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ConstantDefaultIntensity>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
