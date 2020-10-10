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
module BlackDeltaPremiumAdjustedSolverClassFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackDeltaPremiumAdjustedSolverClass", Description="Create a BlackDeltaPremiumAdjustedSolverClass",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackDeltaPremiumAdjustedSolverClass_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ot",Description = "Reference to ot")>] 
         ot : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        ([<ExcelArgument(Name="dDiscount",Description = "Reference to dDiscount")>] 
         dDiscount : obj)
        ([<ExcelArgument(Name="fDiscount",Description = "Reference to fDiscount")>] 
         fDiscount : obj)
        ([<ExcelArgument(Name="stdDev",Description = "Reference to stdDev")>] 
         stdDev : obj)
        ([<ExcelArgument(Name="delta",Description = "Reference to delta")>] 
         delta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ot = Helper.toCell<Option.Type> ot "ot" 
                let _dt = Helper.toCell<DeltaVolQuote.DeltaType> dt "dt" 
                let _spot = Helper.toCell<double> spot "spot" 
                let _dDiscount = Helper.toCell<double> dDiscount "dDiscount" 
                let _fDiscount = Helper.toCell<double> fDiscount "fDiscount" 
                let _stdDev = Helper.toCell<double> stdDev "stdDev" 
                let _delta = Helper.toCell<double> delta "delta" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackDeltaPremiumAdjustedSolverClass 
                                                            _ot.cell 
                                                            _dt.cell 
                                                            _spot.cell 
                                                            _dDiscount.cell 
                                                            _fDiscount.cell 
                                                            _stdDev.cell 
                                                            _delta.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackDeltaPremiumAdjustedSolverClass>) l

                let source () = Helper.sourceFold "Fun.BlackDeltaPremiumAdjustedSolverClass" 
                                               [| _ot.source
                                               ;  _dt.source
                                               ;  _spot.source
                                               ;  _dDiscount.source
                                               ;  _fDiscount.source
                                               ;  _stdDev.source
                                               ;  _delta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ot.cell
                                ;  _dt.cell
                                ;  _spot.cell
                                ;  _dDiscount.cell
                                ;  _fDiscount.cell
                                ;  _stdDev.cell
                                ;  _delta.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackDeltaPremiumAdjustedSolverClass> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackDeltaPremiumAdjustedSolverClass_value", Description="Create a BlackDeltaPremiumAdjustedSolverClass",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackDeltaPremiumAdjustedSolverClass_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaPremiumAdjustedSolverClass",Description = "Reference to BlackDeltaPremiumAdjustedSolverClass")>] 
         blackdeltapremiumadjustedsolverclass : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaPremiumAdjustedSolverClass = Helper.toCell<BlackDeltaPremiumAdjustedSolverClass> blackdeltapremiumadjustedsolverclass "BlackDeltaPremiumAdjustedSolverClass"  
                let _strike = Helper.toCell<double> strike "strike" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackDeltaPremiumAdjustedSolverClassModel.Cast _BlackDeltaPremiumAdjustedSolverClass.cell).Value
                                                            _strike.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackDeltaPremiumAdjustedSolverClass.source + ".Value") 
                                               [| _BlackDeltaPremiumAdjustedSolverClass.source
                                               ;  _strike.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaPremiumAdjustedSolverClass.cell
                                ;  _strike.cell
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
    [<ExcelFunction(Name="_BlackDeltaPremiumAdjustedSolverClass_derivative", Description="Create a BlackDeltaPremiumAdjustedSolverClass",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackDeltaPremiumAdjustedSolverClass_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackDeltaPremiumAdjustedSolverClass",Description = "Reference to BlackDeltaPremiumAdjustedSolverClass")>] 
         blackdeltapremiumadjustedsolverclass : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackDeltaPremiumAdjustedSolverClass = Helper.toCell<BlackDeltaPremiumAdjustedSolverClass> blackdeltapremiumadjustedsolverclass "BlackDeltaPremiumAdjustedSolverClass"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackDeltaPremiumAdjustedSolverClassModel.Cast _BlackDeltaPremiumAdjustedSolverClass.cell).Derivative
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackDeltaPremiumAdjustedSolverClass.source + ".Derivative") 
                                               [| _BlackDeltaPremiumAdjustedSolverClass.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackDeltaPremiumAdjustedSolverClass.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_BlackDeltaPremiumAdjustedSolverClass_Range", Description="Create a range of BlackDeltaPremiumAdjustedSolverClass",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackDeltaPremiumAdjustedSolverClass_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackDeltaPremiumAdjustedSolverClass")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackDeltaPremiumAdjustedSolverClass> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackDeltaPremiumAdjustedSolverClass>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackDeltaPremiumAdjustedSolverClass>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BlackDeltaPremiumAdjustedSolverClass>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
