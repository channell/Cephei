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
module VarProxy_HelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_VarProxy_Helper_corrModel_", Description="Create a VarProxy_Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VarProxy_Helper_corrModel_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VarProxy_Helper",Description = "VarProxy_Helper")>] 
         varproxy_helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VarProxy_Helper = Helper.toCell<VarProxy_Helper> varproxy_helper "VarProxy_Helper"  
                let builder (current : ICell) = ((VarProxy_HelperModel.Cast _VarProxy_Helper.cell).CorrModel_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmCorrelationModel>) l

                let source () = Helper.sourceFold (_VarProxy_Helper.source + ".CorrModel_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VarProxy_Helper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VarProxy_Helper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VarProxy_Helper_value", Description="Create a VarProxy_Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VarProxy_Helper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VarProxy_Helper",Description = "VarProxy_Helper")>] 
         varproxy_helper : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VarProxy_Helper = Helper.toCell<VarProxy_Helper> varproxy_helper "VarProxy_Helper"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((VarProxy_HelperModel.Cast _VarProxy_Helper.cell).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_VarProxy_Helper.source + ".Value") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VarProxy_Helper.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_VarProxy_Helper", Description="Create a VarProxy_Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VarProxy_Helper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="proxy",Description = "LfmCovarianceProxy")>] 
         proxy : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _proxy = Helper.toCell<LfmCovarianceProxy> proxy "proxy" 
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = (Fun.VarProxy_Helper 
                                                            _proxy.cell 
                                                            _i.cell 
                                                            _j.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VarProxy_Helper>) l

                let source () = Helper.sourceFold "Fun.VarProxy_Helper" 
                                               [| _proxy.source
                                               ;  _i.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _proxy.cell
                                ;  _i.cell
                                ;  _j.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VarProxy_Helper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VarProxy_Helper_volaModel_", Description="Create a VarProxy_Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VarProxy_Helper_volaModel_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VarProxy_Helper",Description = "VarProxy_Helper")>] 
         varproxy_helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VarProxy_Helper = Helper.toCell<VarProxy_Helper> varproxy_helper "VarProxy_Helper"  
                let builder (current : ICell) = ((VarProxy_HelperModel.Cast _VarProxy_Helper.cell).VolaModel_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmVolatilityModel>) l

                let source () = Helper.sourceFold (_VarProxy_Helper.source + ".VolaModel_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VarProxy_Helper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VarProxy_Helper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_VarProxy_Helper_Range", Description="Create a range of VarProxy_Helper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VarProxy_Helper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VarProxy_Helper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<VarProxy_Helper> (c)) :> ICell
                let format (i : Cephei.Cell.List<VarProxy_Helper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<VarProxy_Helper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
