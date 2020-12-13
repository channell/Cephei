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
module DiscretizedConvertibleFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedConvertible_addCoupon", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_addCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).AddCoupon
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".AddCoupon") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_adjustedGrid", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_adjustedGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).AdjustedGrid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".AdjustedGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedConvertible> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedConvertible_applyCallability", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_applyCallability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="convertible",Description = "bool")>] 
         convertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _i = Helper.toCell<int> i "i" 
                let _convertible = Helper.toCell<bool> convertible "convertible" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).ApplyCallability
                                                            _i.cell 
                                                            _convertible.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".ApplyCallability") 

                                               [| _i.source
                                               ;  _convertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                ;  _i.cell
                                ;  _convertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_applyConvertibility", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_applyConvertibility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).ApplyConvertibility
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".ApplyConvertibility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_conversionProbability", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_conversionProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).ConversionProbability
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".ConversionProbability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedConvertible> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedConvertible", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="args",Description = "ConvertibleBond.option.Arguments")>] 
         args : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="grid",Description = "TimeGrid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _args = Helper.toCell<ConvertibleBond.option.Arguments> args "args" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _grid = Helper.toCell<TimeGrid> grid "grid" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DiscretizedConvertible 
                                                            _args.cell 
                                                            _Process.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedConvertible>) l

                let source () = Helper.sourceFold "Fun.DiscretizedConvertible" 
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
                    ; subscriber = Helper.subscriberModel<DiscretizedConvertible> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedConvertible_dividendValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_dividendValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).DividendValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".DividendValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedConvertible> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedConvertible_mandatoryTimes", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".MandatoryTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_process", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_process
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).Process
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GeneralizedBlackScholesProcess>) l

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".PROCESS") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedConvertible> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedConvertible_reset", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".Reset") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_spreadAdjustedRate", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_spreadAdjustedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).SpreadAdjustedRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".SpreadAdjustedRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedConvertible> format
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
    [<ExcelFunction(Name="_DiscretizedConvertible_adjustValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".AdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_initialize", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="Method",Description = "Lattice")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".Initialize") 

                                               [| _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_method", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".METHOD") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedConvertible> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedConvertible_partialRollback", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".PartialRollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_postAdjustValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".PostAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_preAdjustValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".PreAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_presentValue", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".PresentValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_rollback", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".Rollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_setTime", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_setValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".SetValues") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_time", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".Time") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_values", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedConvertibleModel.Cast _DiscretizedConvertible.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedConvertible.source + ".Values") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedConvertible> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedConvertible_Range", Description="Create a range of DiscretizedConvertible",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedConvertible_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedConvertible> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DiscretizedConvertible> (c)) :> ICell
                let format (i : Cephei.Cell.List<DiscretizedConvertible>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DiscretizedConvertible>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
