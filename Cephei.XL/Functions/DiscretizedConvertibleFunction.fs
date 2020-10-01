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
    [<ExcelFunction(Name="_DiscretizedConvertible_addCoupon", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_addCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).AddCoupon
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".AddCoupon") 
                                               [| _DiscretizedConvertible.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_adjustedGrid", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_adjustedGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).AdjustedGrid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".AdjustedGrid") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_DiscretizedConvertible_applyCallability", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_applyCallability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="convertible",Description = "Reference to convertible")>] 
         convertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _i = Helper.toCell<int> i "i" 
                let _convertible = Helper.toCell<bool> convertible "convertible" 
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).ApplyCallability
                                                            _i.cell 
                                                            _convertible.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".ApplyCallability") 
                                               [| _DiscretizedConvertible.source
                                               ;  _i.source
                                               ;  _convertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                ;  _i.cell
                                ;  _convertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_applyConvertibility", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_applyConvertibility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).ApplyConvertibility
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".ApplyConvertibility") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_conversionProbability", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_conversionProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).ConversionProbability
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".ConversionProbability") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_DiscretizedConvertible", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_create
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

                let _args = Helper.toCell<ConvertibleBond.option.Arguments> args "args" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _grid = Helper.toCell<TimeGrid> grid "grid" 
                let builder () = withMnemonic mnemonic (Fun.DiscretizedConvertible 
                                                            _args.cell 
                                                            _Process.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedConvertible>) l

                let source = Helper.sourceFold "Fun.DiscretizedConvertible" 
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
    [<ExcelFunction(Name="_DiscretizedConvertible_dividendValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_dividendValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).DividendValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".DividendValues") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_DiscretizedConvertible_mandatoryTimes", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".MandatoryTimes") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_process", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_process
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).Process
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GeneralizedBlackScholesProcess>) l

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".PROCESS") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_DiscretizedConvertible_reset", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _size = Helper.toCell<int> size "size" 
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".Reset") 
                                               [| _DiscretizedConvertible.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
        
    *)
    [<ExcelFunction(Name="_DiscretizedConvertible_spreadAdjustedRate", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_spreadAdjustedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).SpreadAdjustedRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".SpreadAdjustedRate") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_DiscretizedConvertible_adjustValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".AdjustValues") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_initialize", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".Initialize") 
                                               [| _DiscretizedConvertible.source
                                               ;  _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_method", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".METHOD") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_DiscretizedConvertible_partialRollback", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".PartialRollback") 
                                               [| _DiscretizedConvertible.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_postAdjustValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".PostAdjustValues") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_preAdjustValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".PreAdjustValues") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_presentValue", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".PresentValue") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_rollback", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".Rollback") 
                                               [| _DiscretizedConvertible.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_setTime", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".SetTime") 
                                               [| _DiscretizedConvertible.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_setValues", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedConvertible) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".SetValues") 
                                               [| _DiscretizedConvertible.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_time", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".Time") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
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
    [<ExcelFunction(Name="_DiscretizedConvertible_values", Description="Create a DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedConvertible",Description = "Reference to DiscretizedConvertible")>] 
         discretizedconvertible : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedConvertible = Helper.toCell<DiscretizedConvertible> discretizedconvertible "DiscretizedConvertible"  
                let builder () = withMnemonic mnemonic ((_DiscretizedConvertible.cell :?> DiscretizedConvertibleModel).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedConvertible.source + ".Values") 
                                               [| _DiscretizedConvertible.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedConvertible.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedConvertible> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedConvertible_Range", Description="Create a range of DiscretizedConvertible",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedConvertible_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscretizedConvertible")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedConvertible> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscretizedConvertible>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscretizedConvertible>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DiscretizedConvertible>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
