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
  This class is used with the BinomialDoubleBarrierEngine to implement the enhanced binomial algorithm of E.Derman, I.Kani, D.Ergener, I.Bardhan ("Enhanced Numerical Methods for Options with Barriers", 1995)  This algorithm is only suitable if the payoff can be approximated linearly, e.g. is not usable for cash-or-nothing payoffs.
  </summary> *)
[<AutoSerializable(true)>]
module DiscretizedDermanKaniDoubleBarrierOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="args",Description = "DoubleBarrierOption.Arguments")>] 
         args : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="grid",Description = "TimeGrid or empty")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _args = Helper.toCell<DoubleBarrierOption.Arguments> args "args" 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _grid = Helper.toDefault<TimeGrid> grid "grid" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DiscretizedDermanKaniDoubleBarrierOption 
                                                            _args.cell 
                                                            _Process.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedDermanKaniDoubleBarrierOption>) l

                let source () = Helper.sourceFold "Fun.DiscretizedDermanKaniDoubleBarrierOption" 
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
                    ; subscriber = Helper.subscriberModel<DiscretizedDermanKaniDoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_mandatoryTimes", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".MandatoryTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_reset", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".Reset") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_adjustValues", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".AdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_initialize", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        ([<ExcelArgument(Name="Method",Description = "Lattice")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".Initialize") 

                                               [| _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_method", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".METHOD") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDermanKaniDoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_partialRollback", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".PartialRollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_postAdjustValues", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".PostAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_preAdjustValues", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".PreAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_presentValue", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".PresentValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_rollback", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".Rollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_setTime", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_setValues", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDermanKaniDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".SetValues") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_time", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".Time") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_values", Description="Create a DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDermanKaniDoubleBarrierOption",Description = "DiscretizedDermanKaniDoubleBarrierOption")>] 
         discretizeddermankanidoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDermanKaniDoubleBarrierOption = Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> discretizeddermankanidoublebarrieroption "DiscretizedDermanKaniDoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDermanKaniDoubleBarrierOptionModel.Cast _DiscretizedDermanKaniDoubleBarrierOption.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedDermanKaniDoubleBarrierOption.source + ".Values") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDermanKaniDoubleBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDermanKaniDoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedDermanKaniDoubleBarrierOption_Range", Description="Create a range of DiscretizedDermanKaniDoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDermanKaniDoubleBarrierOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedDermanKaniDoubleBarrierOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DiscretizedDermanKaniDoubleBarrierOption> (c)) :> ICell
                let format (i : Cephei.Cell.List<DiscretizedDermanKaniDoubleBarrierOption>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DiscretizedDermanKaniDoubleBarrierOption>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
