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
open Cephei.XL.Helper
open Cephei
open QLNet

(* <summary>
this is an abstract class to give access to all properties and methods of PiecewiseYieldCurve and avoiding generics
  </summary> *)
[<AutoSerializable(true)>]
module PiecewiseYieldCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_accuracy_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_accuracy_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Accuracy_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Accuracy_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_Clone", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_data", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Data") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_data_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Data_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_dates", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_dates_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Dates_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_discountImpl", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".DiscountImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_forwardImpl", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ForwardImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_guess", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
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

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Guess") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_initialDate1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_initialDate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).InitialDate1
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".InitialDate1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_initialDate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="c",Description = "YieldTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _c = Helper.toCell<YieldTermStructure> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".InitialDate") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_initialValue1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_initialValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="c",Description = "YieldTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _c = Helper.toCell<YieldTermStructure> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).InitialValue1
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".InitialValue1") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_initialValue", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).InitialValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".InitialValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_instruments_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_instruments_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Instruments_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<BootstrapHelper<YieldTermStructure>>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Instruments_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_interpolation_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Interpolation_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_interpolator_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Interpolator_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxDate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
        here we do not refer to the base curve as in QL because our base curve is YieldTermStructure and not Traits::base_curve
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxDate_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxDate_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxIterations", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxValueAfter", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
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

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxValueAfter") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_minValueAfter", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
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

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _first = Helper.toCell<int> first "first" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _first.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MinValueAfter") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_moving_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_moving_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Moving_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Moving_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_nodes", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Nodes
                                                       ) :> ICell
                let format (o : Generic.Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Nodes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="traits",Description = "ITraits<YieldTermStructure>")>] 
         traits : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="instruments",Description = "RateHelper range")>] 
         instruments : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="jumps",Description = "Quote")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Date")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="interpolator",Description = "IInterpolationFactory")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try
                let _traits = Helper.toCell<ITraits<YieldTermStructure>> traits "traits"
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate"
                let _instruments = Helper.toCell<Generic.List<RateHelper>> instruments "instruments"
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter"
                let _jumps = Helper.toDefaultHandleList<Quote> jumps "jumps" (new Generic.List<Handle<Quote>>())
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" (Generic.List<Date> ())
                let _accuracy = Helper.toCell<double> accuracy "accuracy"
                let _i = Helper.toCell<IInterpolationFactory> interpolator "interpolator"

                let builder (current : ICell) = withMnemonic mnemonic (Fun.PiecewiseYieldCurve
                                                            _traits.cell
                                                            _referenceDate.cell
                                                            _instruments.cell
                                                            _dayCounter.cell
                                                            _jumps.cell
                                                            _jumpDates.cell
                                                            _accuracy.cell
                                                            _i.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<QLNetHelper.PiecewiseYieldCurve>) l

                let source () = Helper.sourceFold "Fun.PiecewiseYieldCurve1" 
                                                [| _traits.source
                                                ;  _referenceDate.source
                                                ;  _instruments.source
                                                ;  _dayCounter.source
                                                ;  _jumps.source
                                                ;  _jumpDates.source
                                                ;  _accuracy.source
                                                ;  _i.source
                                                |]
                let hash = Helper.hashFold 
                                [| _traits.cell
                                ;  _referenceDate.cell
                                ;  _instruments.cell
                                ;  _dayCounter.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _accuracy.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_registerWith", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "YieldTermStructure")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _helper = Helper.toCell<BootstrapHelper<YieldTermStructure>> helper "helper" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).RegisterWith
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".RegisterWith") 

                                               [| _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_setTermStructure", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="helper",Description = "YieldTermStructure")>] 
         helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _helper = Helper.toCell<BootstrapHelper<YieldTermStructure>> helper "helper" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).SetTermStructure
                                                            _helper.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".SetTermStructure") 

                                               [| _helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_setupInterpolation", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).SetupInterpolation
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".SetupInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_times", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Times") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_times_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Times_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_traits_", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_traits_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Traits_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ITraits<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Traits_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_updateGuess", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="data",Description = "double range")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".UpdateGuess") 

                                               [| _data.source
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_zeroYieldImpl", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ZeroYieldImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
        ! The same day-counting rule used by the term structure should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_discount", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Discount
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Discount") 

                                               [| _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                ;  _t.cell
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
        These methods return the discount factor from a given date or time to the reference date.  In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_discount1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_discount1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Discount1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Discount1") 

                                               [| _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                ;  _d.cell
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
        ! The resulting interest rate has the required day-counting rule. \warning dates are not adjusted for holidays
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_forwardRate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).ForwardRate
                                                            _d.cell 
                                                            _p.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ForwardRate") 

                                               [| _d.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_forwardRate1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_forwardRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).ForwardRate1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ForwardRate1") 

                                               [| _d1.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_forwardRate2", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_forwardRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="t1",Description = "double")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).ForwardRate2
                                                            _t1.cell 
                                                            _t2.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ForwardRate2") 

                                               [| _t1.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_jumpDates", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_jumpDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).JumpDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".JumpDates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_jumpTimes", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_jumpTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).JumpTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".JumpTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_update", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Update
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
        ! The resulting interest rate has the required daycounting rule.
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_zeroRate1", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_zeroRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).ZeroRate1
                                                            _d.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ZeroRate1") 

                                               [| _d.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_zeroRate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).ZeroRate
                                                            _t.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ZeroRate") 

                                               [| _t.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_calendar", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_dayCounter", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<QLNetHelper.PiecewiseYieldCurve> format
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_maxTime", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_referenceDate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_settlementDays", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_timeFromReference", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_PiecewiseYieldCurve_allowsExtrapolation", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_disableExtrapolation", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_enableExtrapolation", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : PiecewiseYieldCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_extrapolate", Description="Create a PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseYieldCurve",Description = "PiecewiseYieldCurve")>] 
         piecewiseyieldcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseYieldCurve = Helper.toCell<QLNetHelper.PiecewiseYieldCurve> piecewiseyieldcurve "PiecewiseYieldCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseYieldCurveModel.Cast _PiecewiseYieldCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseYieldCurve.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PiecewiseYieldCurve.cell
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
    [<ExcelFunction(Name="_PiecewiseYieldCurve_Range", Description="Create a range of PiecewiseYieldCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseYieldCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<QLNetHelper.PiecewiseYieldCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<QLNetHelper.PiecewiseYieldCurve> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<QLNetHelper.PiecewiseYieldCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<QLNetHelper.PiecewiseYieldCurve>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
