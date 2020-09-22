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
    [<ExcelFunction(Name="_FdmQuantoHelper_equityFxCorrelation", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_equityFxCorrelation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).EquityFxCorrelation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".EquityFxCorrelation") 
                                               [| _FdmQuantoHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_exchRateATMlevel", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_exchRateATMlevel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).ExchRateATMlevel
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".ExchRateATMlevel") 
                                               [| _FdmQuantoHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rTS",Description = "Reference to rTS")>] 
         rTS : obj)
        ([<ExcelArgument(Name="fTS",Description = "Reference to fTS")>] 
         fTS : obj)
        ([<ExcelArgument(Name="fxVolTS",Description = "Reference to fxVolTS")>] 
         fxVolTS : obj)
        ([<ExcelArgument(Name="equityFxCorrelation",Description = "Reference to equityFxCorrelation")>] 
         equityFxCorrelation : obj)
        ([<ExcelArgument(Name="exchRateATMlevel",Description = "Reference to exchRateATMlevel")>] 
         exchRateATMlevel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rTS = Helper.toCell<YieldTermStructure> rTS "rTS" true
                let _fTS = Helper.toCell<YieldTermStructure> fTS "fTS" true
                let _fxVolTS = Helper.toCell<BlackVolTermStructure> fxVolTS "fxVolTS" true
                let _equityFxCorrelation = Helper.toCell<double> equityFxCorrelation "equityFxCorrelation" true
                let _exchRateATMlevel = Helper.toCell<double> exchRateATMlevel "exchRateATMlevel" true
                let builder () = withMnemonic mnemonic (Fun.FdmQuantoHelper 
                                                            _rTS.cell 
                                                            _fTS.cell 
                                                            _fxVolTS.cell 
                                                            _equityFxCorrelation.cell 
                                                            _exchRateATMlevel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmQuantoHelper>) l

                let source = Helper.sourceFold "Fun.FdmQuantoHelper" 
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
    [<ExcelFunction(Name="_FdmQuantoHelper_foreignTermStructure", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_foreignTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).ForeignTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YieldTermStructure>) l

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".ForeignTermStructure") 
                                               [| _FdmQuantoHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_fxVolatilityTermStructure", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_fxVolatilityTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).FxVolatilityTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackVolTermStructure>) l

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".FxVolatilityTermStructure") 
                                               [| _FdmQuantoHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_quantoAdjustment1", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_quantoAdjustment1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        ([<ExcelArgument(Name="equityVol",Description = "Reference to equityVol")>] 
         equityVol : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let _equityVol = Helper.toCell<Vector> equityVol "equityVol" true
                let _t1 = Helper.toCell<double> t1 "t1" true
                let _t2 = Helper.toCell<double> t2 "t2" true
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).QuantoAdjustment1
                                                            _equityVol.cell 
                                                            _t1.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".QuantoAdjustment1") 
                                               [| _FdmQuantoHelper.source
                                               ;  _equityVol.source
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
    [<ExcelFunction(Name="_FdmQuantoHelper_quantoAdjustment", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_quantoAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        ([<ExcelArgument(Name="equityVol",Description = "Reference to equityVol")>] 
         equityVol : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let _equityVol = Helper.toCell<double> equityVol "equityVol" true
                let _t1 = Helper.toCell<double> t1 "t1" true
                let _t2 = Helper.toCell<double> t2 "t2" true
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).QuantoAdjustment
                                                            _equityVol.cell 
                                                            _t1.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".QuantoAdjustment") 
                                               [| _FdmQuantoHelper.source
                                               ;  _equityVol.source
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
    [<ExcelFunction(Name="_FdmQuantoHelper_registerWith", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FdmQuantoHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".RegisterWith") 
                                               [| _FdmQuantoHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_riskFreeTermStructure", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_riskFreeTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).RiskFreeTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YieldTermStructure>) l

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".RiskFreeTermStructure") 
                                               [| _FdmQuantoHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_unregisterWith", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FdmQuantoHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".UnregisterWith") 
                                               [| _FdmQuantoHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_update", Description="Create a FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmQuantoHelper",Description = "Reference to FdmQuantoHelper")>] 
         fdmquantohelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmQuantoHelper = Helper.toCell<FdmQuantoHelper> fdmquantohelper "FdmQuantoHelper" true 
                let builder () = withMnemonic mnemonic ((_FdmQuantoHelper.cell :?> FdmQuantoHelperModel).Update
                                                       ) :> ICell
                let format (o : FdmQuantoHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmQuantoHelper.source + ".Update") 
                                               [| _FdmQuantoHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmQuantoHelper.cell
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
    [<ExcelFunction(Name="_FdmQuantoHelper_Range", Description="Create a range of FdmQuantoHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmQuantoHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmQuantoHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmQuantoHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmQuantoHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmQuantoHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmQuantoHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
