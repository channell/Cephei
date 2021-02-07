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
module FdmQuantoHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmQuantoHelper_equityFxCorrelation", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_equityFxCorrelation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).EquityFxCorrelation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".EquityFxCorrelation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_exchRateATMlevel", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_exchRateATMlevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).ExchRateATMlevel
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".ExchRateATMlevel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rTS",Description = "YieldTermStructure")>] 
         rTS : obj)
        ([<ExcelArgument(Name="fTS",Description = "YieldTermStructure")>] 
         fTS : obj)
        ([<ExcelArgument(Name="fxVolTS",Description = "BlackVolTermStructure")>] 
         fxVolTS : obj)
        ([<ExcelArgument(Name="equityFxCorrelation",Description = "double")>] 
         equityFxCorrelation : obj)
        ([<ExcelArgument(Name="exchRateATMlevel",Description = "double")>] 
         exchRateATMlevel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rTS = Helper.toCell<YieldTermStructure> rTS "rTS" 
                let _fTS = Helper.toCell<YieldTermStructure> fTS "fTS" 
                let _fxVolTS = Helper.toCell<BlackVolTermStructure> fxVolTS "fxVolTS" 
                let _equityFxCorrelation = Helper.toCell<double> equityFxCorrelation "equityFxCorrelation" 
                let _exchRateATMlevel = Helper.toCell<double> exchRateATMlevel "exchRateATMlevel" 
                let builder (current : ICell) = (Fun.FdmQuantoHelper 
                                                            _rTS.cell 
                                                            _fTS.cell 
                                                            _fxVolTS.cell 
                                                            _equityFxCorrelation.cell 
                                                            _exchRateATMlevel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmQuantoHelper>) l

                let source () = Helper.sourceFold "Fun.FdmQuantoHelper" 
                                               [| _rTS.source
                                               ;  _fTS.source
                                               ;  _fxVolTS.source
                                               ;  _equityFxCorrelation.source
                                               ;  _exchRateATMlevel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rTS.cell
                                ;  _fTS.cell
                                ;  _fxVolTS.cell
                                ;  _equityFxCorrelation.cell
                                ;  _exchRateATMlevel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmQuantoHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmQuantoHelper_foreignTermStructure", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_foreignTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).ForeignTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YieldTermStructure>) l

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".ForeignTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmQuantoHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmQuantoHelper_fxVolatilityTermStructure", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_fxVolatilityTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).FxVolatilityTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackVolTermStructure>) l

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".FxVolatilityTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmQuantoHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmQuantoHelper_quantoAdjustment1", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_quantoAdjustment1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        ([<ExcelArgument(Name="equityVol",Description = "Vector")>] 
         equityVol : obj)
        ([<ExcelArgument(Name="t1",Description = "double")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let _equityVol = Helper.toCell<Vector> equityVol "equityVol" 
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).QuantoAdjustment1
                                                            _equityVol.cell 
                                                            _t1.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".QuantoAdjustment1") 

                                               [| _equityVol.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
                                ;  _equityVol.cell
                                ;  _t1.cell
                                ;  _t2.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmQuantoHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmQuantoHelper_quantoAdjustment", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_quantoAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        ([<ExcelArgument(Name="equityVol",Description = "double")>] 
         equityVol : obj)
        ([<ExcelArgument(Name="t1",Description = "double")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let _equityVol = Helper.toCell<double> equityVol "equityVol" 
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).QuantoAdjustment
                                                            _equityVol.cell 
                                                            _t1.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".QuantoAdjustment") 

                                               [| _equityVol.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
                                ;  _equityVol.cell
                                ;  _t1.cell
                                ;  _t2.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_registerWith", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FdmQuantoHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_riskFreeTermStructure", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_riskFreeTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).RiskFreeTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YieldTermStructure>) l

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".RiskFreeTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmQuantoHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmQuantoHelper_unregisterWith", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FdmQuantoHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_update", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper"  
                let builder (current : ICell) = ((FdmQuantoHelperModel.Cast _FdmQuantoHelper.cell).Update
                                                       ) :> ICell
                let format (o : FdmQuantoHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmQuantoHelper.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_Range", Description="Create a range of FdmQuantoHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmQuantoHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmQuantoHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmQuantoHelper> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmQuantoHelper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmQuantoHelper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
