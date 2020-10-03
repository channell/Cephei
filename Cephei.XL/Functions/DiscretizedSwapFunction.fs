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
module DiscretizedSwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedSwap", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="args",Description = "Reference to args")>] 
         args : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _args = Helper.toCell<VanillaSwap.Arguments> args "args" 
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder () = withMnemonic mnemonic (Fun.DiscretizedSwap 
                                                            _args.cell 
                                                            _referenceDate.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedSwap>) l

                let source = Helper.sourceFold "Fun.DiscretizedSwap" 
                                               [| _args.source
                                               ;  _referenceDate.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _args.cell
                                ;  _referenceDate.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedSwap_mandatoryTimes", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".MandatoryTimes") 
                                               [| _DiscretizedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
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
    [<ExcelFunction(Name="_DiscretizedSwap_reset", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let _size = Helper.toCell<int> size "size" 
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".Reset") 
                                               [| _DiscretizedSwap.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
                                ;  _size.cell
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
        ! This method performs both pre- and post-adjustment
    *)
    [<ExcelFunction(Name="_DiscretizedSwap_adjustValues", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".AdjustValues") 
                                               [| _DiscretizedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
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
        High-level interface  Users of discretized assets should use these methods in order to initialize, evolve and take the present value of the assets.  They call the corresponding methods in the Lattice interface, to which we refer for documentation.
    *)
    [<ExcelFunction(Name="_DiscretizedSwap_initialize", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".Initialize") 
                                               [| _DiscretizedSwap.source
                                               ;  _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
                                ;  _Method.cell
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
    [<ExcelFunction(Name="_DiscretizedSwap_method", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".METHOD") 
                                               [| _DiscretizedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedSwap_partialRollback", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".PartialRollback") 
                                               [| _DiscretizedSwap.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
                                ;  _To.cell
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
        ! This method will be invoked after rollback and after any other asset had their chance to look at the values. For instance, payments happening at the present time (and therefore not included in an option to be exercised at this time) will be added here.  This method is not virtual; derived classes must override the protected postAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedSwap_postAdjustValues", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".PostAdjustValues") 
                                               [| _DiscretizedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
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
        ! This method will be invoked after rollback and before any other asset (i.e., an option on this one) has any chance to look at the values. For instance, payments happening at times already spanned by the rollback will be added here.  This method is not virtual; derived classes must override the protected preAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedSwap_preAdjustValues", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".PreAdjustValues") 
                                               [| _DiscretizedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
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
    [<ExcelFunction(Name="_DiscretizedSwap_presentValue", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".PresentValue") 
                                               [| _DiscretizedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
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
    [<ExcelFunction(Name="_DiscretizedSwap_rollback", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".Rollback") 
                                               [| _DiscretizedSwap.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
                                ;  _To.cell
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
        safe version of QL double* time()
    *)
    [<ExcelFunction(Name="_DiscretizedSwap_setTime", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".SetTime") 
                                               [| _DiscretizedSwap.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
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
        safe version of QL Vector* values()
    *)
    [<ExcelFunction(Name="_DiscretizedSwap_setValues", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".SetValues") 
                                               [| _DiscretizedSwap.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_DiscretizedSwap_time", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".Time") 
                                               [| _DiscretizedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
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
    [<ExcelFunction(Name="_DiscretizedSwap_values", Description="Create a DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedSwap",Description = "Reference to DiscretizedSwap")>] 
         discretizedswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedSwap = Helper.toCell<DiscretizedSwap> discretizedswap "DiscretizedSwap"  
                let builder () = withMnemonic mnemonic ((DiscretizedSwapModel.Cast _DiscretizedSwap.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedSwap.source + ".Values") 
                                               [| _DiscretizedSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedSwap.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedSwap_Range", Description="Create a range of DiscretizedSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscretizedSwap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedSwap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscretizedSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscretizedSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DiscretizedSwap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
