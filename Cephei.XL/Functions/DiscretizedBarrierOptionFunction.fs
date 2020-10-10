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
module DiscretizedBarrierOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedBarrierOption_checkBarrier", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_checkBarrier
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        ([<ExcelArgument(Name="optvalues",Description = "Reference to optvalues")>] 
         optvalues : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let _optvalues = Helper.toCell<Vector> optvalues "optvalues" 
                let _grid = Helper.toDefault<Vector> grid "grid" null
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).CheckBarrier
                                                            _optvalues.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".CheckBarrier") 
                                               [| _DiscretizedBarrierOption.source
                                               ;  _optvalues.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
                                ;  _optvalues.cell
                                ;  _grid.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_create
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

                let _args = Helper.toCell<BarrierOption.Arguments> args "args" 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _grid = Helper.toDefault<TimeGrid> grid "grid" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DiscretizedBarrierOption 
                                                            _args.cell 
                                                            _Process.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedBarrierOption>) l

                let source () = Helper.sourceFold "Fun.DiscretizedBarrierOption" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedBarrierOption_mandatoryTimes", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".MandatoryTimes") 
                                               [| _DiscretizedBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_reset", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".Reset") 
                                               [| _DiscretizedBarrierOption.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
        
    *)
    [<ExcelFunction(Name="_DiscretizedBarrierOption_vanilla", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_vanilla
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).Vanilla
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".Vanilla") 
                                               [| _DiscretizedBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedBarrierOption> format
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_adjustValues", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".AdjustValues") 
                                               [| _DiscretizedBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_initialize", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".Initialize") 
                                               [| _DiscretizedBarrierOption.source
                                               ;  _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_method", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".METHOD") 
                                               [| _DiscretizedBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedBarrierOption_partialRollback", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".PartialRollback") 
                                               [| _DiscretizedBarrierOption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_postAdjustValues", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".PostAdjustValues") 
                                               [| _DiscretizedBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_preAdjustValues", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".PreAdjustValues") 
                                               [| _DiscretizedBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_presentValue", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".PresentValue") 
                                               [| _DiscretizedBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_rollback", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".Rollback") 
                                               [| _DiscretizedBarrierOption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_setTime", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".SetTime") 
                                               [| _DiscretizedBarrierOption.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_setValues", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".SetValues") 
                                               [| _DiscretizedBarrierOption.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_time", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".Time") 
                                               [| _DiscretizedBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedBarrierOption_values", Description="Create a DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedBarrierOption",Description = "Reference to DiscretizedBarrierOption")>] 
         discretizedbarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedBarrierOption = Helper.toCell<DiscretizedBarrierOption> discretizedbarrieroption "DiscretizedBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedBarrierOptionModel.Cast _DiscretizedBarrierOption.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedBarrierOption.source + ".Values") 
                                               [| _DiscretizedBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedBarrierOption_Range", Description="Create a range of DiscretizedBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedBarrierOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscretizedBarrierOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedBarrierOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscretizedBarrierOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscretizedBarrierOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DiscretizedBarrierOption>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
