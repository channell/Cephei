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
(*!! excluded from exscel interface
(* <summary>
helper class to temporarily and safely change the settings
  </summary> *)
[<AutoSerializable(true)>]
module SavedSettingsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SavedSettings_Dispose", Description="Create a SavedSettings",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SavedSettings_Dispose
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SavedSettings",Description = "Reference to SavedSettings")>] 
         savedsettings : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SavedSettings = Helper.toCell<SavedSettings> savedsettings "SavedSettings"  
                let builder (current : ICell) = withMnemonic mnemonic ((SavedSettingsModel.Cast _SavedSettings.cell).Dispose
                                                       ) :> ICell
                let format (o : SavedSettings) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SavedSettings.source + ".Dispose") 
                                               [| _SavedSettings.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SavedSettings.cell
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
    [<ExcelFunction(Name="_SavedSettings", Description="Create a SavedSettings",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SavedSettings_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.SavedSettings 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SavedSettings>) l

                let source () = Helper.sourceFold "Fun.SavedSettings" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SavedSettings> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SavedSettings_Range", Description="Create a range of SavedSettings",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SavedSettings_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SavedSettings")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SavedSettings> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SavedSettings>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SavedSettings>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SavedSettings>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
