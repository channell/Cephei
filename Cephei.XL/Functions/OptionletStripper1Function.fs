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
  Helper class to strip optionlet (i.e. caplet/floorlet) volatilities (a.k.a. forward-forward volatilities) from the (cap/floor) term volatilities of a CapFloorTermVolSurface.
  </summary> *)
[<AutoSerializable(true)>]
module OptionletStripper1Function =

    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper1_capFloorPrices", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_capFloorPrices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).CapFloorPrices
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".CapFloorPrices") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper1> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper1_capFloorVolatilities", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_capFloorVolatilities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).CapFloorVolatilities
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".CapFloorVolatilities") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper1> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper1_optionletPrices", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_optionletPrices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).OptionletPrices
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".OptionletPrices") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper1> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper1", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termVolSurface",Description = "CapFloorTermVolSurface")>] 
         termVolSurface : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="switchStrike",Description = "double")>] 
         switchStrike : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double or empty")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxIter",Description = "int or empty")>] 
         maxIter : obj)
        ([<ExcelArgument(Name="discount",Description = "YieldTermStructure")>] 
         discount : obj)
        ([<ExcelArgument(Name="Type",Description = "VolatilityType: ShiftedLognormal, Normal")>] 
         Type : obj)
        ([<ExcelArgument(Name="displacement",Description = "double or empty")>] 
         displacement : obj)
        ([<ExcelArgument(Name="dontThrow",Description = "bool or empty")>] 
         dontThrow : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termVolSurface = Helper.toCell<CapFloorTermVolSurface> termVolSurface "termVolSurface" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _switchStrike = Helper.toNullable<double> switchStrike "switchStrike"
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-6
                let _maxIter = Helper.toDefault<int> maxIter "maxIter" 100
                let _discount = Helper.toHandle<YieldTermStructure> discount "discount" 
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _displacement = Helper.toDefault<double> displacement "displacement" 0.0
                let _dontThrow = Helper.toDefault<bool> dontThrow "dontThrow" false
                let builder (current : ICell) = withMnemonic mnemonic (Fun.OptionletStripper1 
                                                            _termVolSurface.cell 
                                                            _index.cell 
                                                            _switchStrike.cell 
                                                            _accuracy.cell 
                                                            _maxIter.cell 
                                                            _discount.cell 
                                                            _Type.cell 
                                                            _displacement.cell 
                                                            _dontThrow.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OptionletStripper1>) l

                let source () = Helper.sourceFold "Fun.OptionletStripper1" 
                                               [| _termVolSurface.source
                                               ;  _index.source
                                               ;  _switchStrike.source
                                               ;  _accuracy.source
                                               ;  _maxIter.source
                                               ;  _discount.source
                                               ;  _Type.source
                                               ;  _displacement.source
                                               ;  _dontThrow.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termVolSurface.cell
                                ;  _index.cell
                                ;  _switchStrike.cell
                                ;  _accuracy.cell
                                ;  _maxIter.cell
                                ;  _discount.cell
                                ;  _Type.cell
                                ;  _displacement.cell
                                ;  _dontThrow.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper1> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper1_switchStrike", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_switchStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).SwitchStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".SwitchStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_atmOptionletRates", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_atmOptionletRates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).AtmOptionletRates
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".AtmOptionletRates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_businessDayConvention", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_calendar", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper1> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper1_dayCounter", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper1> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper1_displacement", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_displacement
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).Displacement
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".Displacement") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_iborIndex", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_iborIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).IborIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".IborIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper1> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper1_optionletAccrualPeriods", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_optionletAccrualPeriods
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).OptionletAccrualPeriods
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".OptionletAccrualPeriods") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_optionletFixingDates", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_optionletFixingDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).OptionletFixingDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".OptionletFixingDates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_optionletFixingTenors", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_optionletFixingTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).OptionletFixingTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".OptionletFixingTenors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_optionletFixingTimes", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_optionletFixingTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).OptionletFixingTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".OptionletFixingTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_optionletMaturities", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_optionletMaturities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).OptionletMaturities
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".OptionletMaturities") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_optionletPaymentDates", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_optionletPaymentDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).OptionletPaymentDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".OptionletPaymentDates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
        StrippedOptionletBase interface
    *)
    [<ExcelFunction(Name="_OptionletStripper1_optionletStrikes", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_optionletStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).OptionletStrikes
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".OptionletStrikes") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_optionletVolatilities", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_optionletVolatilities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).OptionletVolatilities
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".OptionletVolatilities") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_settlementDays", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_termVolSurface", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_termVolSurface
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).TermVolSurface
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapFloorTermVolSurface>) l

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".TermVolSurface") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OptionletStripper1> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OptionletStripper1_volatilityType", Description="Create a OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OptionletStripper1",Description = "OptionletStripper1")>] 
         optionletstripper1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OptionletStripper1 = Helper.toCell<OptionletStripper1> optionletstripper1 "OptionletStripper1"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionletStripper1Model.Cast _OptionletStripper1.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OptionletStripper1.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OptionletStripper1.cell
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
    [<ExcelFunction(Name="_OptionletStripper1_Range", Description="Create a range of OptionletStripper1",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OptionletStripper1_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OptionletStripper1> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<OptionletStripper1> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<OptionletStripper1>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<OptionletStripper1>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
