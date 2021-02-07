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
  This class calculates time-dependent Black volatilities using as input a vector of (ATM) Black volatilities observed in the market.  The calculation is performed interpolating on the variance curve. Linear interpolation is used as default; this can be changed by the setInterpolation() method.  For strike dependence, see BlackVarianceSurface.  check time extrapolation
  </summary> *)
[<AutoSerializable(true)>]
module BlackVarianceCurveFunction =

    (*
        required for Handle
    *)
    [<ExcelFunction(Name="_BlackVarianceCurve", Description="Create a BlackVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVarianceCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dates",Description = "Date range")>] 
         dates : obj)
        ([<ExcelArgument(Name="blackVolCurve",Description = "double range")>] 
         blackVolCurve : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="forceMonotoneVariance",Description = "bool")>] 
         forceMonotoneVariance : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _blackVolCurve = Helper.toCell<Generic.List<double>> blackVolCurve "blackVolCurve" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _forceMonotoneVariance = Helper.toCell<bool> forceMonotoneVariance "forceMonotoneVariance" 
                let builder (current : ICell) = (Fun.BlackVarianceCurve 
                                                            _referenceDate.cell 
                                                            _dates.cell 
                                                            _blackVolCurve.cell 
                                                            _dayCounter.cell 
                                                            _forceMonotoneVariance.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackVarianceCurve>) l

                let source () = Helper.sourceFold "Fun.BlackVarianceCurve" 
                                               [| _referenceDate.source
                                               ;  _dates.source
                                               ;  _blackVolCurve.source
                                               ;  _dayCounter.source
                                               ;  _forceMonotoneVariance.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _dates.cell
                                ;  _blackVolCurve.cell
                                ;  _dayCounter.cell
                                ;  _forceMonotoneVariance.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackVarianceCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackVarianceCurve_dayCounter", Description="Create a BlackVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVarianceCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceCurve",Description = "BlackVarianceCurve")>] 
         blackvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceCurve = Helper.toCell<BlackVarianceCurve> blackvariancecurve "BlackVarianceCurve"  
                let builder (current : ICell) = ((BlackVarianceCurveModel.Cast _BlackVarianceCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_BlackVarianceCurve.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackVarianceCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackVarianceCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackVarianceCurve_maxDate", Description="Create a BlackVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVarianceCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceCurve",Description = "BlackVarianceCurve")>] 
         blackvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceCurve = Helper.toCell<BlackVarianceCurve> blackvariancecurve "BlackVarianceCurve"  
                let builder (current : ICell) = ((BlackVarianceCurveModel.Cast _BlackVarianceCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BlackVarianceCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackVarianceCurve.cell
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
    [<ExcelFunction(Name="_BlackVarianceCurve_maxStrike", Description="Create a BlackVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVarianceCurve_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceCurve",Description = "BlackVarianceCurve")>] 
         blackvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceCurve = Helper.toCell<BlackVarianceCurve> blackvariancecurve "BlackVarianceCurve"  
                let builder (current : ICell) = ((BlackVarianceCurveModel.Cast _BlackVarianceCurve.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackVarianceCurve.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackVarianceCurve.cell
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
    [<ExcelFunction(Name="_BlackVarianceCurve_minStrike", Description="Create a BlackVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVarianceCurve_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceCurve",Description = "BlackVarianceCurve")>] 
         blackvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceCurve = Helper.toCell<BlackVarianceCurve> blackvariancecurve "BlackVarianceCurve"  
                let builder (current : ICell) = ((BlackVarianceCurveModel.Cast _BlackVarianceCurve.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackVarianceCurve.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackVarianceCurve.cell
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
    (*!!
    [<ExcelFunction(Name="_BlackVarianceCurve_setInterpolation", Description="Create a BlackVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVarianceCurve_setInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceCurve",Description = "BlackVarianceCurve")>] 
         blackvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceCurve = Helper.toCell<BlackVarianceCurve> blackvariancecurve "BlackVarianceCurve"  
                let builder (current : ICell) = ((BlackVarianceCurveModel.Cast _BlackVarianceCurve.cell).SetInterpolation
                                                       ) :> ICell
                let format (o : BlackVarianceCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackVarianceCurve.source + ".SetInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackVarianceCurve.cell
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
            *)
    (*
        
    *)
    (*!!
    [<ExcelFunction(Name="_BlackVarianceCurve_setInterpolation", Description="Create a BlackVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVarianceCurve_setInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceCurve",Description = "BlackVarianceCurve")>] 
         blackvariancecurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolator")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceCurve = Helper.toCell<BlackVarianceCurve> blackvariancecurve "BlackVarianceCurve"  
                let _i = Helper.toCell<Interpolator> i "i" 
                let builder (current : ICell) = ((BlackVarianceCurveModel.Cast _BlackVarianceCurve.cell).SetInterpolation1
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : BlackVarianceCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackVarianceCurve.source + ".SetInterpolation") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceCurve.cell
                                ;  _i.cell
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
            *)
    [<ExcelFunction(Name="_BlackVarianceCurve_Range", Description="Create a range of BlackVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVarianceCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackVarianceCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BlackVarianceCurve> (c)) :> ICell
                let format (i : Cephei.Cell.List<BlackVarianceCurve>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BlackVarianceCurve>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
