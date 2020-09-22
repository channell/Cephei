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
module PiecewiseZeroInflationCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_accuracy_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_accuracy_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Accuracy_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Accuracy_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_baseDate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".BaseDate") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_Clone", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Clone
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Clone") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_data", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Data") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_data_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Data_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_dates", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Dates") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_dates_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Dates_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        these are dummy methods (for the sake of ITraits and should not be called directly
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_discountImpl", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".DiscountImpl") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_forwardImpl", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ForwardImpl") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_forwards", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_forwards
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Forwards
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Forwards") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_guess", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "Reference to validData")>] 
         validData : obj)
        ([<ExcelArgument(Name="first",Description = "Reference to first")>] 
         first : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _first = Helper.toCell<int> first "first" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Guess") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _first.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _first.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_initialDate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).InitialDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".InitialDate") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_initialDate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _c = Helper.toCell<ZeroInflationTermStructure> c "c" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).InitialDate1
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".InitialDate1") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_initialValue", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).InitialValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".InitialValue") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_initialValue", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _c = Helper.toCell<ZeroInflationTermStructure> c "c" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).InitialValue1
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".InitialValue1") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_instruments_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_instruments_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Instruments_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<BootstrapHelper<ZeroInflationTermStructure>>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Instruments_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_interpolation_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Interpolation_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_interpolator_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Interpolator_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxDate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxDate") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxDate_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxDate_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxIterations", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxIterations") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxValueAfter", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "Reference to validData")>] 
         validData : obj)
        ([<ExcelArgument(Name="first",Description = "Reference to first")>] 
         first : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _first = Helper.toCell<int> first "first" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxValueAfter") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _first.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _first.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_minValueAfter", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "Reference to validData")>] 
         validData : obj)
        ([<ExcelArgument(Name="first",Description = "Reference to first")>] 
         first : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _first = Helper.toCell<int> first "first" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MinValueAfter") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _first.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _first.cell
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
        public new bool moving_
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_moving_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_moving_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Moving_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Moving_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_nodes", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Nodes") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.PiecewiseZeroInflationCurve 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseZeroInflationCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseZeroInflationCurve" 
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve1", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="baseZeroRate",Description = "Reference to baseZeroRate")>] 
         baseZeroRate : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "Reference to indexIsInterpolated")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "Reference to yTS")>] 
         yTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _baseZeroRate = Helper.toCell<double> baseZeroRate "baseZeroRate" true
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" true
                let _yTS = Helper.toHandle<Handle<YieldTermStructure>> yTS "yTS" 
                let builder () = withMnemonic mnemonic (Fun.PiecewiseZeroInflationCurve1 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _baseZeroRate.cell 
                                                            _observationLag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseZeroInflationCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseZeroInflationCurve1" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _dayCounter.source
                                               ;  _baseZeroRate.source
                                               ;  _observationLag.source
                                               ;  _frequency.source
                                               ;  _indexIsInterpolated.source
                                               ;  _yTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _dayCounter.cell
                                ;  _baseZeroRate.cell
                                ;  _observationLag.cell
                                ;  _frequency.cell
                                ;  _indexIsInterpolated.cell
                                ;  _yTS.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve2", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="baseZeroRate",Description = "Reference to baseZeroRate")>] 
         baseZeroRate : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "Reference to indexIsInterpolated")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "Reference to yTS")>] 
         yTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _baseZeroRate = Helper.toCell<double> baseZeroRate "baseZeroRate" true
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" true
                let _yTS = Helper.toHandle<Handle<YieldTermStructure>> yTS "yTS" 
                let builder () = withMnemonic mnemonic (Fun.PiecewiseZeroInflationCurve2 
                                                            _referenceDate.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _baseZeroRate.cell 
                                                            _observationLag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseZeroInflationCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseZeroInflationCurve2" 
                                               [| _referenceDate.source
                                               ;  _calendar.source
                                               ;  _dayCounter.source
                                               ;  _baseZeroRate.source
                                               ;  _observationLag.source
                                               ;  _frequency.source
                                               ;  _indexIsInterpolated.source
                                               ;  _yTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _calendar.cell
                                ;  _dayCounter.cell
                                ;  _baseZeroRate.cell
                                ;  _observationLag.cell
                                ;  _frequency.cell
                                ;  _indexIsInterpolated.cell
                                ;  _yTS.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve3", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="baseZeroRate",Description = "Reference to baseZeroRate")>] 
         baseZeroRate : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "Reference to indexIsInterpolated")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "Reference to yTS")>] 
         yTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _baseZeroRate = Helper.toCell<double> baseZeroRate "baseZeroRate" true
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" true
                let _yTS = Helper.toHandle<Handle<YieldTermStructure>> yTS "yTS" 
                let builder () = withMnemonic mnemonic (Fun.PiecewiseZeroInflationCurve3 
                                                            _dayCounter.cell 
                                                            _baseZeroRate.cell 
                                                            _observationLag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseZeroInflationCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseZeroInflationCurve3" 
                                               [| _dayCounter.source
                                               ;  _baseZeroRate.source
                                               ;  _observationLag.source
                                               ;  _frequency.source
                                               ;  _indexIsInterpolated.source
                                               ;  _yTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dayCounter.cell
                                ;  _baseZeroRate.cell
                                ;  _observationLag.cell
                                ;  _frequency.cell
                                ;  _indexIsInterpolated.cell
                                ;  _yTS.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_rates", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_rates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Rates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Rates") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_registerWith", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "Reference to helper")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _helper = Helper.toCell<BootstrapHelper<ZeroInflationTermStructure>> helper "helper" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).RegisterWith
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".RegisterWith") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _helper.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_setTermStructure", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "Reference to helper")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _helper = Helper.toCell<BootstrapHelper<ZeroInflationTermStructure>> helper "helper" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).SetTermStructure
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".SetTermStructure") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _helper.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_setupInterpolation", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).SetupInterpolation
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".SetupInterpolation") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_times", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Times") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_times_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Times_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_traits_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_traits_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Traits_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ITraits<ZeroInflationTermStructure>>) l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Traits_") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_updateGuess", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _data = Helper.toCell<Generic.List<double>> data "data" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".UpdateGuess") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _data.source
                                               ;  _discount.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _data.cell
                                ;  _discount.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroYieldImpl", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroYieldImpl") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroRate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "Reference to forceLinearInterpolation")>] 
         forceLinearInterpolation : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" true
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).ZeroRate
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroRate") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
                                ;  _forceLinearInterpolation.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroRate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "Reference to forceLinearInterpolation")>] 
         forceLinearInterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" true
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).ZeroRate1
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroRate1") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
                                ;  _forceLinearInterpolation.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroRate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).ZeroRate2
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroRate2") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
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
        ! Essentially the fair rate for a zero-coupon inflation swap (by definition), i.e. the zero term structure uses yearly compounding, which is assumed for ZCIIS instrument quotes. N.B. by default you get the same as lag and interpolation as the term structure. If you want to get predictions of RPI/CPI/etc then use an index.
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroRate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).ZeroRate3
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroRate3") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_baseRate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_baseRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).BaseRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".BaseRate") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_frequency", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Frequency") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_hasSeasonality", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_hasSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).HasSeasonality
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".HasSeasonality") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_indexIsInterpolated", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".IndexIsInterpolated") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_nominalTermStructure", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_nominalTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).NominalTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".NominalTermStructure") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        Inflation interface ! The TS observes with a lag that is usually different from the ! availability lag of the index.  An inflation rate is given, ! by default, for the maturity requested assuming this lag.
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_observationLag", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ObservationLag") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_seasonality", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_seasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Seasonality
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Seasonality>) l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Seasonality") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! Calling setSeasonality with no arguments means unsetting as the default is used to choose unsetting.
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_setSeasonality", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_setSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="seasonality",Description = "Reference to seasonality")>] 
         seasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _seasonality = Helper.toCell<Seasonality> seasonality "seasonality" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).SetSeasonality
                                                            _seasonality.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".SetSeasonality") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _seasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _seasonality.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_calendar", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Calendar") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! the day counter used for date/time conversion
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_dayCounter", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".DayCounter") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxTime", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxTime") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_referenceDate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ReferenceDate") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_settlementDays", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".SettlementDays") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_timeFromReference", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".TimeFromReference") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _date.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_update", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Update
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Update") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_allowsExtrapolation", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".AllowsExtrapolation") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_disableExtrapolation", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".DisableExtrapolation") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_enableExtrapolation", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".EnableExtrapolation") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_extrapolate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "Reference to PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseZeroInflationCurve.cell :?> PiecewiseZeroInflationCurveModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Extrapolate") 
                                               [| _PiecewiseZeroInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_Range", Description="Create a range of PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PiecewiseZeroInflationCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PiecewiseZeroInflationCurve> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PiecewiseZeroInflationCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PiecewiseZeroInflationCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PiecewiseZeroInflationCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
