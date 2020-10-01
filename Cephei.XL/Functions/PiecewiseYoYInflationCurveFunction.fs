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
module PiecewiseYoYInflationCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_accuracy_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_accuracy_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Accuracy_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Accuracy_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_baseDate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".BaseDate") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_Clone", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Clone") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_data", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Data") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_data_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Data_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_dates", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Dates") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_dates_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Dates_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_discountImpl", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".DiscountImpl") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_forwardImpl", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".ForwardImpl") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_forwards", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_forwards
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Forwards
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Forwards") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_guess", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
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

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Guess") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _first.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_initialDate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _c = Helper.toCell<YoYInflationTermStructure> c "c" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".InitialDate") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_initialDate1", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_initialDate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).InitialDate1
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".InitialDate1") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_initialValue1", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_initialValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).InitialValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".InitialValue1") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_initialValue", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _c = Helper.toCell<YoYInflationTermStructure> c "c" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).InitialValue
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".InitialValue") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_instruments_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_instruments_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Instruments_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<BootstrapHelper<YoYInflationTermStructure>>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Instruments_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_interpolation_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Interpolation_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_interpolator_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Interpolator_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxDate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxDate") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxDate_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxDate_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxIterations", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxIterations") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxValueAfter", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
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

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxValueAfter") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _first.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_minValueAfter", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
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

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MinValueAfter") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _first.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_moving_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_moving_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Moving_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Moving_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_nodes", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Nodes
                                                       ) :> ICell
                let format (o : Generic.Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Nodes") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve3", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.PiecewiseYoYInflationCurve3 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseYoYInflationCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseYoYInflationCurve3" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_create
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

                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _baseZeroRate = Helper.toCell<double> baseZeroRate "baseZeroRate" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" 
                let _yTS = Helper.toHandle<YieldTermStructure> yTS "yTS" 
                let builder () = withMnemonic mnemonic (Fun.PiecewiseYoYInflationCurve
                                                            _dayCounter.cell 
                                                            _baseZeroRate.cell 
                                                            _observationLag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseYoYInflationCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseYoYInflationCurve" 
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
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve1", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_create1
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

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _baseZeroRate = Helper.toCell<double> baseZeroRate "baseZeroRate" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" 
                let _yTS = Helper.toHandle<YieldTermStructure> yTS "yTS" 
                let builder () = withMnemonic mnemonic (Fun.PiecewiseYoYInflationCurve1
                                                            _referenceDate.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _baseZeroRate.cell 
                                                            _observationLag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseYoYInflationCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseYoYInflationCurve1" 
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
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve2", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_create2
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

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _baseZeroRate = Helper.toCell<double> baseZeroRate "baseZeroRate" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _indexIsInterpolated = Helper.toCell<bool> indexIsInterpolated "indexIsInterpolated" 
                let _yTS = Helper.toHandle<YieldTermStructure> yTS "yTS" 
                let builder () = withMnemonic mnemonic (Fun.PiecewiseYoYInflationCurve2
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _baseZeroRate.cell 
                                                            _observationLag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseYoYInflationCurve>) l

                let source = Helper.sourceFold "Fun.PiecewiseYoYInflationCurve2" 
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
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_rates", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_rates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Rates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Rates") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_registerWith", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "Reference to helper")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _helper = Helper.toCell<BootstrapHelper<YoYInflationTermStructure>> helper "helper" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).RegisterWith
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".RegisterWith") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_setTermStructure", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "Reference to helper")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _helper = Helper.toCell<BootstrapHelper<YoYInflationTermStructure>> helper "helper" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).SetTermStructure
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".SetTermStructure") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_setupInterpolation", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).SetupInterpolation
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".SetupInterpolation") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_times", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Times") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_times_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Times_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_traits_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_traits_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Traits_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ITraits<YoYInflationTermStructure>>) l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Traits_") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_updateGuess", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".UpdateGuess") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _data.source
                                               ;  _discount.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_zeroYieldImpl", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".ZeroYieldImpl") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_yoyRate1", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_yoyRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
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

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).YoyRate1
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".YoyRate1") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_yoyRate3", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_yoyRate3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "Reference to forceLinearInterpolation")>] 
         forceLinearInterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).YoyRate3
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".YoyRate3") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               ;  _forceLinearInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_yoyRate2", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_yoyRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Reference to instObsLag")>] 
         instObsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).YoyRate2
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".YoyRate2") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _d.source
                                               ;  _instObsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
        ! \note this is not the year-on-year swap (YYIIS) rate.
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_yoyRate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).YoyRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".YoyRate") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_baseRate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_baseRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).BaseRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".BaseRate") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_frequency", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Frequency") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_hasSeasonality", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_hasSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).HasSeasonality
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".HasSeasonality") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_indexIsInterpolated", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".IndexIsInterpolated") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_nominalTermStructure", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_nominalTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).NominalTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".NominalTermStructure") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_observationLag", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".ObservationLag") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_seasonality", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_seasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Seasonality
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Seasonality>) l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Seasonality") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_setSeasonality", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_setSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="seasonality",Description = "Reference to seasonality")>] 
         seasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _seasonality = Helper.toCell<Seasonality> seasonality "seasonality" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).SetSeasonality
                                                            _seasonality.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".SetSeasonality") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _seasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_calendar", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Calendar") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_dayCounter", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".DayCounter") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseYoYInflationCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxTime", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxTime") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_referenceDate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".ReferenceDate") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_settlementDays", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".SettlementDays") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_timeFromReference", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".TimeFromReference") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_update", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Update
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Update") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_allowsExtrapolation", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".AllowsExtrapolation") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_disableExtrapolation", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".DisableExtrapolation") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_enableExtrapolation", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".EnableExtrapolation") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_extrapolate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "Reference to PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder () = withMnemonic mnemonic ((_PiecewiseYoYInflationCurve.cell :?> PiecewiseYoYInflationCurveModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Extrapolate") 
                                               [| _PiecewiseYoYInflationCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_Range", Description="Create a range of PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PiecewiseYoYInflationCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PiecewiseYoYInflationCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PiecewiseYoYInflationCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PiecewiseYoYInflationCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PiecewiseYoYInflationCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
