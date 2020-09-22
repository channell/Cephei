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
this is an abstract class to give access to all properties and methods of PiecewiseYieldCurve and avoiding generics
  </summary> *)
[<AutoSerializable(true)>]
module PiecewiseYieldCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_accuracy_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_accuracy_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Accuracy_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Accuracy_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_Clone", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Clone") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_data", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Data") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_data_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Data_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_dates", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Dates") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_dates_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Dates_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_discountImpl", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".DiscountImpl") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_forwardImpl", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ForwardImpl") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_guess", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
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

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _first = Helper.toCell<int> first "first" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Guess") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _first.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_initialDate1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_initialDate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).InitialDate1
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".InitialDate1") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_initialDate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _c = Helper.toCell<YieldTermStructure> c "c" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".InitialDate") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_initialValue1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_initialValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _c = Helper.toCell<YieldTermStructure> c "c" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).InitialValue1
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".InitialValue1") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_initialValue", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).InitialValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".InitialValue") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_instruments_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_instruments_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Instruments_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<BootstrapHelper<YieldTermStructure>>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Instruments_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_interpolation_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Interpolation_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_interpolator_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Interpolator_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxDate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxDate") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
        here we do not refer to the base curve as in QL because our base curve is YieldTermStructure and not Traits::base_curve
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxDate_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxDate_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxIterations", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxIterations") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxValueAfter", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
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

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _first = Helper.toCell<int> first "first" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxValueAfter") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _first.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_minValueAfter", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
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

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _i = Helper.toCell<int> i "i" true
                let _c = Helper.toCell<InterpolatedCurve> c "c" true
                let _validData = Helper.toCell<bool> validData "validData" true
                let _first = Helper.toCell<int> first "first" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MinValueAfter") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _first.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_moving_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_moving_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Moving_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Moving_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_nodes", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Nodes
                                                       ) :> ICell
                let format (o : Generic.Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Nodes") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.PiecewiseYieldCurve () 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseYieldCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseYieldCurve" 
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _jumps = Helper.toCell<Generic.List<Handle<Quote>>> jumps "jumps" true
                let _jumpDates = Helper.toCell<Generic.List<Date>> jumpDates "jumpDates" true
                let builder () = withMnemonic mnemonic (Fun.PiecewiseYieldCurve1 
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _dc.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseYieldCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseYieldCurve1" 
                                               [| _settlementDays.source
                                               ;  _cal.source
                                               ;  _dc.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _cal.cell
                                ;  _dc.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
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
        two constructors to forward down the ctor chain
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve2", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" true
                let _cal = Helper.toCell<Calendar> cal "cal" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _jumps = Helper.toCell<Generic.List<Handle<Quote>>> jumps "jumps" true
                let _jumpDates = Helper.toCell<Generic.List<Date>> jumpDates "jumpDates" true
                let builder () = withMnemonic mnemonic (Fun.PiecewiseYieldCurve2 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _dc.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseYieldCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseYieldCurve2" 
                                               [| _referenceDate.source
                                               ;  _cal.source
                                               ;  _dc.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _cal.cell
                                ;  _dc.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_registerWith", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "Reference to helper")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _helper = Helper.toCell<BootstrapHelper<YieldTermStructure>> helper "helper" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).RegisterWith
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".RegisterWith") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_setTermStructure", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "Reference to helper")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _helper = Helper.toCell<BootstrapHelper<YieldTermStructure>> helper "helper" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).SetTermStructure
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".SetTermStructure") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_setupInterpolation", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).SetupInterpolation
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".SetupInterpolation") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_times", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Times") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_times_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Times_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_traits_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_traits_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Traits_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ITraits<YieldTermStructure>>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Traits_") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_updateGuess", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _data = Helper.toCell<Generic.List<double>> data "data" true
                let _discount = Helper.toCell<double> discount "discount" true
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".UpdateGuess") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _data.source
                                               ;  _discount.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_zeroYieldImpl", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _i = Helper.toCell<Interpolation> i "i" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ZeroYieldImpl") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
        ! The same day-counting rule used by the term structure should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_discount", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _t = Helper.toCell<double> t "t" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Discount
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Discount") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                ;  _t.cell
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
        These methods return the discount factor from a given date or time to the reference date.  In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_discount1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_discount1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Discount1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Discount1") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                ;  _d.cell
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
        ! The resulting interest rate has the required day-counting rule. \warning dates are not adjusted for holidays
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_forwardRate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).ForwardRate
                                                            _d.cell 
                                                            _p.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ForwardRate") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
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
        ! The resulting interest rate has the required day-counting rule.
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_forwardRate1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_forwardRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).ForwardRate1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ForwardRate1") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
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
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed times t1 and t2.
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_forwardRate2", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_forwardRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _t1 = Helper.toCell<double> t1 "t1" true
                let _t2 = Helper.toCell<double> t2 "t2" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).ForwardRate2
                                                            _t1.cell 
                                                            _t2.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ForwardRate2") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                ;  _t1.cell
                                ;  _t2.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_jumpDates", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_jumpDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).JumpDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".JumpDates") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_jumpTimes", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_jumpTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).JumpTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".JumpTimes") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_update", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Update
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Update") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
        ! The resulting interest rate has the required daycounting rule.
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_zeroRate1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_zeroRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _d = Helper.toCell<Date> d "d" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).ZeroRate1
                                                            _d.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ZeroRate1") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _d.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                ;  _d.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
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
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_zeroRate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _t = Helper.toCell<double> t "t" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).ZeroRate
                                                            _t.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ZeroRate") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _t.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                ;  _t.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_calendar", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Calendar") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_dayCounter", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".DayCounter") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxTime", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxTime") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_referenceDate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ReferenceDate") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_settlementDays", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".SettlementDays") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_timeFromReference", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".TimeFromReference") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_allowsExtrapolation", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".AllowsExtrapolation") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_disableExtrapolation", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".DisableExtrapolation") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_enableExtrapolation", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let _b = Helper.toCell<bool> b "b" true
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".EnableExtrapolation") 
                                               [| _PiecewiseYieldCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_extrapolate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "Reference to PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve" true 
                let builder () = withMnemonic mnemonic ((_PiecewiseYieldCurve.cell :?> PiecewiseYieldCurveModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Extrapolate") 
                                               [| _PiecewiseYieldCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_Range", Description="Create a range of PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PiecewiseYieldCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PiecewiseYieldCurve> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PiecewiseYieldCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PiecewiseYieldCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PiecewiseYieldCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
