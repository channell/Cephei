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
module DiscretizedCapFloorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedCapFloor", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="args",Description = "CapFloor.Arguments")>] 
         args : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _args = Helper.toCell<CapFloor.Arguments> args "args" 
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.DiscretizedCapFloor 
                                                            _args.cell 
                                                            _referenceDate.cell 
                                                            _dayCounter.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedCapFloor>) l

                let source () = Helper.sourceFold "Fun.DiscretizedCapFloor" 
                                               [| _args.source
                                               ;  _referenceDate.source
                                               ;  _dayCounter.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _args.cell
                                ;  _referenceDate.cell
                                ;  _dayCounter.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedCapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedCapFloor_mandatoryTimes", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".MandatoryTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
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
    [<ExcelFunction(Name="_DiscretizedCapFloor_reset", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".Reset") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
                                ;  _size.cell
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
        ! This method performs both pre- and post-adjustment
    *)
    [<ExcelFunction(Name="_DiscretizedCapFloor_adjustValues", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".AdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
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
        High-level interface  Users of discretized assets should use these methods in order to initialize, evolve and take the present value of the assets.  They call the corresponding methods in the Lattice interface, to which we refer for documentation.
    *)
    [<ExcelFunction(Name="_DiscretizedCapFloor_initialize", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        ([<ExcelArgument(Name="Method",Description = "Lattice")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".Initialize") 

                                               [| _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
                                ;  _Method.cell
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
    [<ExcelFunction(Name="_DiscretizedCapFloor_method", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".METHOD") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedCapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedCapFloor_partialRollback", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".PartialRollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
                                ;  _To.cell
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
        ! This method will be invoked after rollback and after any other asset had their chance to look at the values. For instance, payments happening at the present time (and therefore not included in an option to be exercised at this time) will be added here.  This method is not virtual; derived classes must override the protected postAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedCapFloor_postAdjustValues", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".PostAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
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
        ! This method will be invoked after rollback and before any other asset (i.e., an option on this one) has any chance to look at the values. For instance, payments happening at times already spanned by the rollback will be added here.  This method is not virtual; derived classes must override the protected preAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedCapFloor_preAdjustValues", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".PreAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
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
    [<ExcelFunction(Name="_DiscretizedCapFloor_presentValue", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".PresentValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
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
    [<ExcelFunction(Name="_DiscretizedCapFloor_rollback", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".Rollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
                                ;  _To.cell
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
        safe version of QL double* time()
    *)
    [<ExcelFunction(Name="_DiscretizedCapFloor_setTime", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
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
        safe version of QL Vector* values()
    *)
    [<ExcelFunction(Name="_DiscretizedCapFloor_setValues", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCapFloor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".SetValues") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_DiscretizedCapFloor_time", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".Time") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
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
    [<ExcelFunction(Name="_DiscretizedCapFloor_values", Description="Create a DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCapFloor",Description = "DiscretizedCapFloor")>] 
         discretizedcapfloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCapFloor = Helper.toModelReference<DiscretizedCapFloor> discretizedcapfloor "DiscretizedCapFloor"  
                let builder (current : ICell) = ((DiscretizedCapFloorModel.Cast _DiscretizedCapFloor.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedCapFloor.source + ".Values") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCapFloor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedCapFloor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedCapFloor_Range", Description="Create a range of DiscretizedCapFloor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCapFloor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedCapFloor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DiscretizedCapFloor> (c)) :> ICell
                let format (i : Cephei.Cell.List<DiscretizedCapFloor>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DiscretizedCapFloor>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
