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
module DiscretizedCallableFixedRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="args",Description = "CallableBond.Arguments")>] 
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

                let _args = Helper.toCell<CallableBond.Arguments> args "args" 
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DiscretizedCallableFixedRateBond 
                                                            _args.cell 
                                                            _referenceDate.cell 
                                                            _dayCounter.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedCallableFixedRateBond>) l

                let source () = Helper.sourceFold "Fun.DiscretizedCallableFixedRateBond" 
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
                    ; subscriber = Helper.subscriberModel<DiscretizedCallableFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_mandatoryTimes", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".MandatoryTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_reset", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".Reset") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_adjustValues", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedCallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".AdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_initialize", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        ([<ExcelArgument(Name="Method",Description = "Lattice")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".Initialize") 

                                               [| _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_method", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".METHOD") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedCallableFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_partialRollback", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".PartialRollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_postAdjustValues", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedCallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".PostAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_preAdjustValues", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedCallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".PreAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_presentValue", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".PresentValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_rollback", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".Rollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_setTime", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_setValues", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedCallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".SetValues") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_time", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".Time") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_values", Description="Create a DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedCallableFixedRateBond",Description = "DiscretizedCallableFixedRateBond")>] 
         discretizedcallablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedCallableFixedRateBond = Helper.toCell<DiscretizedCallableFixedRateBond> discretizedcallablefixedratebond "DiscretizedCallableFixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedCallableFixedRateBondModel.Cast _DiscretizedCallableFixedRateBond.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedCallableFixedRateBond.source + ".Values") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedCallableFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedCallableFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedCallableFixedRateBond_Range", Description="Create a range of DiscretizedCallableFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedCallableFixedRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedCallableFixedRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DiscretizedCallableFixedRateBond> (c)) :> ICell
                let format (i : Generic.List<ICell<DiscretizedCallableFixedRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DiscretizedCallableFixedRateBond>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
