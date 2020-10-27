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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_accuracy_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_accuracy_
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Accuracy_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Accuracy_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_baseDate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".BaseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_Clone", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_data", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Data") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_data_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Data_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_dates", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_dates_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Dates_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_discountImpl", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".DiscountImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_forwardImpl", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ForwardImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_forwards", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_forwards
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Forwards
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Forwards") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_guess", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "InterpolatedCurve")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "bool")>] 
         validData : obj)
        ([<ExcelArgument(Name="first",Description = "int")>] 
         first : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Guess") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_initialDate1", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_initialDate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).InitialDate1
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".InitialDate1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_initialDate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="c",Description = "ZeroInflationTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _c = Helper.toCell<ZeroInflationTermStructure> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".InitialDate") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_initialValue", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).InitialValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".InitialValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_initialValue1", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_initialValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="c",Description = "ZeroInflationTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _c = Helper.toCell<ZeroInflationTermStructure> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).InitialValue1
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".InitialValue1") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_instruments_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_instruments_
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Instruments_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<BootstrapHelper<ZeroInflationTermStructure>>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Instruments_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_interpolation_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Interpolation")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Interpolation_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_interpolator_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "IInterpolationFactory")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Interpolator_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxDate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxDate_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxDate_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxIterations", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxValueAfter", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "InterpolatedCurve")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "bool")>] 
         validData : obj)
        ([<ExcelArgument(Name="first",Description = "int")>] 
         first : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxValueAfter") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_minValueAfter", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "InterpolatedCurve")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "bool")>] 
         validData : obj)
        ([<ExcelArgument(Name="first",Description = "int")>] 
         first : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MinValueAfter") 

                                               [| _i.source
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
        public new bool moving_
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_moving_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_moving_
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Moving_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Moving_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_nodes", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Nodes
                                                       ) :> ICell
                let format (o : Generic.Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Nodes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve3", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.PiecewiseZeroInflationCurve3 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseZeroInflationCurve>) l

                let source () = Helper.sourceFold "Fun.PiecewiseZeroInflationCurve3" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve1", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="baseZeroRate",Description = "double")>] 
         baseZeroRate : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "bool")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "YieldTermStructure")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PiecewiseZeroInflationCurve1 
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

                let source () = Helper.sourceFold "Fun.PiecewiseZeroInflationCurve1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="baseZeroRate",Description = "double")>] 
         baseZeroRate : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "bool")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "YieldTermStructure")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PiecewiseZeroInflationCurve
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

                let source () = Helper.sourceFold "Fun.PiecewiseZeroInflationCurve1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve2", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "PiecewiseZeroInflationCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="baseZeroRate",Description = "double")>] 
         baseZeroRate : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="indexIsInterpolated",Description = "bool")>] 
         indexIsInterpolated : obj)
        ([<ExcelArgument(Name="yTS",Description = "YieldTermStructure")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PiecewiseZeroInflationCurve2
                                                            _dayCounter.cell 
                                                            _baseZeroRate.cell 
                                                            _observationLag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseZeroInflationCurve>) l

                let source () = Helper.sourceFold "Fun.PiecewiseZeroInflationCurve2" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_rates", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_rates
        ([<ExcelArgument(Name="Mnemonic",Description = "ZeroInflationTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Rates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Rates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_registerWith", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "ZeroInflationTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "ZeroInflationTermStructure")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _helper = Helper.toCell<BootstrapHelper<ZeroInflationTermStructure>> helper "helper" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).RegisterWith
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".RegisterWith") 

                                               [| _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _helper.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_setTermStructure", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "ZeroInflationTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "ZeroInflationTermStructure")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _helper = Helper.toCell<BootstrapHelper<ZeroInflationTermStructure>> helper "helper" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).SetTermStructure
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".SetTermStructure") 

                                               [| _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _helper.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_setupInterpolation", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "ZeroInflationTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).SetupInterpolation
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".SetupInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_times", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "ZeroInflationTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Times") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_times_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "ZeroInflationTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Times_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_traits_", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_traits_
        ([<ExcelArgument(Name="Mnemonic",Description = "ZeroInflationTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Traits_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ITraits<ZeroInflationTermStructure>>) l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Traits_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_updateGuess", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="data",Description = "double")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".UpdateGuess") 

                                               [| _data.source
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroYieldImpl", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroYieldImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroRate3", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroRate3
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "bool")>] 
         forceLinearInterpolation : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).ZeroRate3
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroRate3") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroRate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "bool")>] 
         forceLinearInterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).ZeroRate
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroRate") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroRate1", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).ZeroRate1
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroRate1") 

                                               [| _d.source
                                               ;  _instObsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _d.cell
                                ;  _instObsLag.cell
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
        ! Essentially the fair rate for a zero-coupon inflation swap (by definition), i.e. the zero term structure uses yearly compounding, which is assumed for ZCIIS instrument quotes. N.B. by default you get the same as lag and interpolation as the term structure. If you want to get predictions of RPI/CPI/etc then use an index.
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_zeroRate2", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_zeroRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).ZeroRate2
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ZeroRate2") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_baseRate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_baseRate
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).BaseRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".BaseRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_frequency", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_hasSeasonality", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_hasSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).HasSeasonality
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".HasSeasonality") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_indexIsInterpolated", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".IndexIsInterpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_nominalTermStructure", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_nominalTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).NominalTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".NominalTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_observationLag", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ObservationLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_seasonality", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_seasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Seasonality")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Seasonality
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Seasonality>) l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Seasonality") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_setSeasonality", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_setSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="seasonality",Description = "Seasonality")>] 
         seasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _seasonality = Helper.toCell<Seasonality> seasonality "seasonality" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).SetSeasonality
                                                            _seasonality.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".SetSeasonality") 

                                               [| _seasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _seasonality.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_calendar", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_dayCounter", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseZeroInflationCurve> format
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_maxTime", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_referenceDate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_settlementDays", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_timeFromReference", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _date.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_update", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Update
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_allowsExtrapolation", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_disableExtrapolation", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_enableExtrapolation", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseZeroInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_extrapolate", Description="Create a PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseZeroInflationCurve",Description = "PiecewiseZeroInflationCurve")>] 
         piecewisezeroinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseZeroInflationCurve = Helper.toCell<PiecewiseZeroInflationCurve> piecewisezeroinflationcurve "PiecewiseZeroInflationCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseZeroInflationCurveModel.Cast _PiecewiseZeroInflationCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseZeroInflationCurve.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseZeroInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseZeroInflationCurve_Range", Description="Create a range of PiecewiseZeroInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseZeroInflationCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PiecewiseZeroInflationCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PiecewiseZeroInflationCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<PiecewiseZeroInflationCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PiecewiseZeroInflationCurve>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
