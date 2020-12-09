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
module NegativePowerDefaultIntensityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NegativePowerDefaultIntensity_defaultRecovery", Description="Create a NegativePowerDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NegativePowerDefaultIntensity_defaultRecovery
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NegativePowerDefaultIntensity",Description = "NegativePowerDefaultIntensity")>] 
         negativepowerdefaultintensity : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NegativePowerDefaultIntensity = Helper.toCell<NegativePowerDefaultIntensity> negativepowerdefaultintensity "NegativePowerDefaultIntensity"  
                let _t = Helper.toCell<double> t "t" 
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = withMnemonic mnemonic ((NegativePowerDefaultIntensityModel.Cast _NegativePowerDefaultIntensity.cell).DefaultRecovery
                                                            _t.cell 
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NegativePowerDefaultIntensity.source + ".DefaultRecovery") 

                                               [| _t.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NegativePowerDefaultIntensity.cell
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
    [<ExcelFunction(Name="_NegativePowerDefaultIntensity_hazardRate", Description="Create a NegativePowerDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NegativePowerDefaultIntensity_hazardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NegativePowerDefaultIntensity",Description = "NegativePowerDefaultIntensity")>] 
         negativepowerdefaultintensity : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NegativePowerDefaultIntensity = Helper.toCell<NegativePowerDefaultIntensity> negativepowerdefaultintensity "NegativePowerDefaultIntensity"  
                let _t = Helper.toCell<double> t "t" 
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = withMnemonic mnemonic ((NegativePowerDefaultIntensityModel.Cast _NegativePowerDefaultIntensity.cell).HazardRate
                                                            _t.cell 
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NegativePowerDefaultIntensity.source + ".HazardRate") 

                                               [| _t.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NegativePowerDefaultIntensity.cell
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
    [<ExcelFunction(Name="_NegativePowerDefaultIntensity1", Description="Create a NegativePowerDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NegativePowerDefaultIntensity_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="alpha",Description = "double")>] 
         alpha : obj)
        ([<ExcelArgument(Name="p",Description = "double")>] 
         p : obj)
        ([<ExcelArgument(Name="recovery",Description = "double")>] 
         recovery : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _p = Helper.toCell<double> p "p" 
                let _recovery = Helper.toCell<double> recovery "recovery" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.NegativePowerDefaultIntensity1 
                                                            _alpha.cell 
                                                            _p.cell 
                                                            _recovery.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NegativePowerDefaultIntensity>) l

                let source () = Helper.sourceFold "Fun.NegativePowerDefaultIntensity1" 
                                               [| _alpha.source
                                               ;  _p.source
                                               ;  _recovery.source
                                               |]
                let hash = Helper.hashFold 
                                [| _alpha.cell
                                ;  _p.cell
                                ;  _recovery.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NegativePowerDefaultIntensity> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NegativePowerDefaultIntensity", Description="Create a NegativePowerDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NegativePowerDefaultIntensity_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="alpha",Description = "double")>] 
         alpha : obj)
        ([<ExcelArgument(Name="p",Description = "double")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _p = Helper.toCell<double> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.NegativePowerDefaultIntensity
                                                            _alpha.cell 
                                                            _p.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NegativePowerDefaultIntensity>) l

                let source () = Helper.sourceFold "Fun.NegativePowerDefaultIntensity" 
                                               [| _alpha.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _alpha.cell
                                ;  _p.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NegativePowerDefaultIntensity> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NegativePowerDefaultIntensity_Range", Description="Create a range of NegativePowerDefaultIntensity",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NegativePowerDefaultIntensity_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NegativePowerDefaultIntensity> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<NegativePowerDefaultIntensity> (c)) :> ICell
                let format (i : Generic.List<ICell<NegativePowerDefaultIntensity>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<NegativePowerDefaultIntensity>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
