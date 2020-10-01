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
module FdmDividendHandlerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmDividendHandler_applyTo", Description="Create a FdmDividendHandler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDividendHandler_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDividendHandler",Description = "Reference to FdmDividendHandler")>] 
         fdmdividendhandler : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDividendHandler = Helper.toCell<FdmDividendHandler> fdmdividendhandler "FdmDividendHandler"  
                let _o = Helper.toCell<Object> o "o" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_FdmDividendHandler.cell :?> FdmDividendHandlerModel).ApplyTo
                                                            _o.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FdmDividendHandler) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmDividendHandler.source + ".ApplyTo") 
                                               [| _FdmDividendHandler.source
                                               ;  _o.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDividendHandler.cell
                                ;  _o.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_FdmDividendHandler_dividendDates", Description="Create a FdmDividendHandler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDividendHandler_dividendDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDividendHandler",Description = "Reference to FdmDividendHandler")>] 
         fdmdividendhandler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDividendHandler = Helper.toCell<FdmDividendHandler> fdmdividendhandler "FdmDividendHandler"  
                let builder () = withMnemonic mnemonic ((_FdmDividendHandler.cell :?> FdmDividendHandlerModel).DividendDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FdmDividendHandler.source + ".DividendDates") 
                                               [| _FdmDividendHandler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDividendHandler.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmDividendHandler_dividends", Description="Create a FdmDividendHandler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDividendHandler_dividends
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDividendHandler",Description = "Reference to FdmDividendHandler")>] 
         fdmdividendhandler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDividendHandler = Helper.toCell<FdmDividendHandler> fdmdividendhandler "FdmDividendHandler"  
                let builder () = withMnemonic mnemonic ((_FdmDividendHandler.cell :?> FdmDividendHandlerModel).Dividends
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FdmDividendHandler.source + ".Dividends") 
                                               [| _FdmDividendHandler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDividendHandler.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmDividendHandler_dividendTimes", Description="Create a FdmDividendHandler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDividendHandler_dividendTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmDividendHandler",Description = "Reference to FdmDividendHandler")>] 
         fdmdividendhandler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmDividendHandler = Helper.toCell<FdmDividendHandler> fdmdividendhandler "FdmDividendHandler"  
                let builder () = withMnemonic mnemonic ((_FdmDividendHandler.cell :?> FdmDividendHandlerModel).DividendTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FdmDividendHandler.source + ".DividendTimes") 
                                               [| _FdmDividendHandler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmDividendHandler.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmDividendHandler", Description="Create a FdmDividendHandler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDividendHandler_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="mesher",Description = "Reference to mesher")>] 
         mesher : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="equityDirection",Description = "Reference to equityDirection")>] 
         equityDirection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _schedule = Helper.toCell<DividendSchedule> schedule "schedule" 
                let _mesher = Helper.toCell<FdmMesher> mesher "mesher" 
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _equityDirection = Helper.toCell<int> equityDirection "equityDirection" 
                let builder () = withMnemonic mnemonic (Fun.FdmDividendHandler 
                                                            _schedule.cell 
                                                            _mesher.cell 
                                                            _referenceDate.cell 
                                                            _dayCounter.cell 
                                                            _equityDirection.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmDividendHandler>) l

                let source = Helper.sourceFold "Fun.FdmDividendHandler" 
                                               [| _schedule.source
                                               ;  _mesher.source
                                               ;  _referenceDate.source
                                               ;  _dayCounter.source
                                               ;  _equityDirection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _schedule.cell
                                ;  _mesher.cell
                                ;  _referenceDate.cell
                                ;  _dayCounter.cell
                                ;  _equityDirection.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmDividendHandler> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdmDividendHandler_Range", Description="Create a range of FdmDividendHandler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmDividendHandler_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmDividendHandler")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmDividendHandler> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmDividendHandler>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmDividendHandler>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmDividendHandler>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
