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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_accuracy_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_accuracy_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Accuracy_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Accuracy_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_baseDate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".BaseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_Clone", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_data", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Data") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_data_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Data_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_dates", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_dates_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Dates_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
        these are dummy methods (for the sake of ITraits and should not be called directly
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_discountImpl", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".DiscountImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_forwardImpl", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".ForwardImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_forwards", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_forwards
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Forwards
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Forwards") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_guess", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
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

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Guess") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_initialDate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="c",Description = "YoYInflationTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _c = Helper.toCell<YoYInflationTermStructure> c "c" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".InitialDate") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_initialDate1", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_initialDate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).InitialDate1
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".InitialDate1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_initialValue1", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_initialValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).InitialValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".InitialValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_initialValue", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="c",Description = "YoYInflationTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _c = Helper.toCell<YoYInflationTermStructure> c "c" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).InitialValue
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".InitialValue") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_instruments_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_instruments_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Instruments_
                                                       ) :> ICell
                let format (i : Generic.List<BootstrapHelper<YoYInflationTermStructure>>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Instruments_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_interpolation_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Interpolation_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_interpolator_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Interpolator_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxDate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxDate_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxDate_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxIterations", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxValueAfter", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
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

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxValueAfter") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_minValueAfter", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
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

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MinValueAfter") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_moving_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_moving_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Moving_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Moving_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_nodes", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Nodes
                                                       ) :> ICell
                let format (o : Generic.Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Nodes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve3", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.PiecewiseYoYInflationCurve3 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseYoYInflationCurve>) l

                let source () = Helper.sourceFold "Fun.PiecewiseYoYInflationCurve3" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
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
                let builder (current : ICell) = (Fun.PiecewiseYoYInflationCurve
                                                            _dayCounter.cell 
                                                            _baseZeroRate.cell 
                                                            _observationLag.cell 
                                                            _frequency.cell 
                                                            _indexIsInterpolated.cell 
                                                            _yTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseYoYInflationCurve>) l

                let source () = Helper.sourceFold "Fun.PiecewiseYoYInflationCurve" 
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve1", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
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
                let builder (current : ICell) = (Fun.PiecewiseYoYInflationCurve1
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

                let source () = Helper.sourceFold "Fun.PiecewiseYoYInflationCurve1" 
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve2", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
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
                let builder (current : ICell) = (Fun.PiecewiseYoYInflationCurve2
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

                let source () = Helper.sourceFold "Fun.PiecewiseYoYInflationCurve2" 
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_rates", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_rates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Rates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Rates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_registerWith", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "YoYInflationTermStructure")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _helper = Helper.toCell<BootstrapHelper<YoYInflationTermStructure>> helper "helper" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).RegisterWith
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".RegisterWith") 

                                               [| _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_setTermStructure", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "YoYInflationTermStructure")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _helper = Helper.toCell<BootstrapHelper<YoYInflationTermStructure>> helper "helper" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).SetTermStructure
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".SetTermStructure") 

                                               [| _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_setupInterpolation", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).SetupInterpolation
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".SetupInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_times", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Times") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_times_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Times_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_traits_", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_traits_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Traits_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ITraits<YoYInflationTermStructure>>) l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Traits_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_updateGuess", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="data",Description = "double range")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".UpdateGuess") 

                                               [| _data.source
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_zeroYieldImpl", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".ZeroYieldImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_yoyRate1", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_yoyRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
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

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).YoyRate1
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".YoyRate1") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_yoyRate3", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_yoyRate3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        ([<ExcelArgument(Name="forceLinearInterpolation",Description = "bool")>] 
         forceLinearInterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let _forceLinearInterpolation = Helper.toCell<bool> forceLinearInterpolation "forceLinearInterpolation" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).YoyRate3
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                            _forceLinearInterpolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".YoyRate3") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_yoyRate2", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_yoyRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="instObsLag",Description = "Period")>] 
         instObsLag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _instObsLag = Helper.toCell<Period> instObsLag "instObsLag" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).YoyRate2
                                                            _d.cell 
                                                            _instObsLag.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".YoyRate2") 

                                               [| _d.source
                                               ;  _instObsLag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
        ! \note this is not the year-on-year swap (YYIIS) rate.
    *)
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_yoyRate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_yoyRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).YoyRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".YoyRate") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_baseRate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_baseRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).BaseRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".BaseRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_frequency", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_hasSeasonality", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_hasSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).HasSeasonality
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".HasSeasonality") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_indexIsInterpolated", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".IndexIsInterpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_nominalTermStructure", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_nominalTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).NominalTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".NominalTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_observationLag", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".ObservationLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_seasonality", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_seasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Seasonality
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Seasonality>) l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Seasonality") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_setSeasonality", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_setSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="seasonality",Description = "Seasonality")>] 
         seasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _seasonality = Helper.toCell<Seasonality> seasonality "seasonality" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).SetSeasonality
                                                            _seasonality.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".SetSeasonality") 

                                               [| _seasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_calendar", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_dayCounter", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_maxTime", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_referenceDate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_settlementDays", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_timeFromReference", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_update", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Update
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_allowsExtrapolation", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_disableExtrapolation", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_enableExtrapolation", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYoYInflationCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_extrapolate", Description="Create a PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYoYInflationCurve",Description = "PiecewiseYoYInflationCurve")>] 
         piecewiseyoyinflationcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYoYInflationCurve = Helper.toCell<PiecewiseYoYInflationCurve> piecewiseyoyinflationcurve "PiecewiseYoYInflationCurve"  
                let builder (current : ICell) = ((PiecewiseYoYInflationCurveModel.Cast _PiecewiseYoYInflationCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYoYInflationCurve.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYoYInflationCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYoYInflationCurve_Range", Description="Create a range of PiecewiseYoYInflationCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYoYInflationCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PiecewiseYoYInflationCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<PiecewiseYoYInflationCurve> (c)) :> ICell
                let format (i : Cephei.Cell.List<PiecewiseYoYInflationCurve>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<PiecewiseYoYInflationCurve>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
