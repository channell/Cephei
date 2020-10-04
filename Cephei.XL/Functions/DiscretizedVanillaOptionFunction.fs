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
module DiscretizedVanillaOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedVanillaOption", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="args",Description = "Reference to args")>] 
         args : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _args = Helper.toCell<Option.Arguments> args "args" 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _grid = Helper.toCell<TimeGrid> grid "grid" 
                let builder () = withMnemonic mnemonic (Fun.DiscretizedVanillaOption 
                                                            _args.cell 
                                                            _Process.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedVanillaOption>) l

                let source = Helper.sourceFold "Fun.DiscretizedVanillaOption" 
                                               [| _args.source
                                               ;  _Process.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _args.cell
                                ;  _Process.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedVanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedVanillaOption_mandatoryTimes", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".MandatoryTimes") 
                                               [| _DiscretizedVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_reset", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let _size = Helper.toCell<int> size "size" 
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".Reset") 
                                               [| _DiscretizedVanillaOption.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_adjustValues", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".AdjustValues") 
                                               [| _DiscretizedVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_initialize", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".Initialize") 
                                               [| _DiscretizedVanillaOption.source
                                               ;  _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_method", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".METHOD") 
                                               [| _DiscretizedVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedVanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedVanillaOption_partialRollback", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".PartialRollback") 
                                               [| _DiscretizedVanillaOption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_postAdjustValues", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".PostAdjustValues") 
                                               [| _DiscretizedVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_preAdjustValues", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".PreAdjustValues") 
                                               [| _DiscretizedVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_presentValue", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".PresentValue") 
                                               [| _DiscretizedVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_rollback", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".Rollback") 
                                               [| _DiscretizedVanillaOption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_setTime", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".SetTime") 
                                               [| _DiscretizedVanillaOption.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_setValues", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".SetValues") 
                                               [| _DiscretizedVanillaOption.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_time", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".Time") 
                                               [| _DiscretizedVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
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
    [<ExcelFunction(Name="_DiscretizedVanillaOption_values", Description="Create a DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedVanillaOption",Description = "Reference to DiscretizedVanillaOption")>] 
         discretizedvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedVanillaOption = Helper.toCell<DiscretizedVanillaOption> discretizedvanillaoption "DiscretizedVanillaOption"  
                let builder () = withMnemonic mnemonic ((DiscretizedVanillaOptionModel.Cast _DiscretizedVanillaOption.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedVanillaOption.source + ".Values") 
                                               [| _DiscretizedVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedVanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedVanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedVanillaOption_Range", Description="Create a range of DiscretizedVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedVanillaOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscretizedVanillaOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedVanillaOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscretizedVanillaOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscretizedVanillaOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DiscretizedVanillaOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
