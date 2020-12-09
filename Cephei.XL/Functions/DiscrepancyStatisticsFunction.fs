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
  It inherit from SequenceStatistics<Statistics> and adds L^2 discrepancy calculation
  </summary> *)
[<AutoSerializable(true)>]
module DiscrepancyStatisticsFunction =

    (*!! duplicate add function
    (*
        
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_add", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "double range")>] 
         Begin : obj)
        ([<ExcelArgument(Name="weight",Description = "double")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" 
                let _weight = Helper.toCell<double> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Add
                                                            _Begin.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : DiscrepancyStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Add") 

                                               [| _Begin.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _Begin.cell
                                ;  _weight.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_add", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "double range")>] 
         Begin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Add1
                                                            _Begin.cell 
                                                       ) :> ICell
                let format (o : DiscrepancyStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Add") 

                                               [| _Begin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _Begin.cell
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
        !  1-dimensional inspectors
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_discrepancy", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_discrepancy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Discrepancy
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Discrepancy") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
        constructor
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimension",Description = "int")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimension = Helper.toCell<int> dimension "dimension" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DiscrepancyStatistics 
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscrepancyStatistics>) l

                let source () = Helper.sourceFold "Fun.DiscrepancyStatistics" 
                                               [| _dimension.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimension.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscrepancyStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_reset", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="dimension",Description = "int")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _dimension = Helper.toCell<int> dimension "dimension" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Reset
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (o : DiscrepancyStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Reset") 

                                               [| _dimension.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _dimension.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_averageShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_averageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).AverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".AverageShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
        ! returns the correlation Matrix
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_correlation", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Correlation
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Correlation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscrepancyStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the covariance Matrix
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_covariance", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Covariance
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Covariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscrepancyStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_downsideDeviation", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_downsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).DownsideDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".DownsideDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_downsideVariance", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_downsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).DownsideVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".DownsideVariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_errorEstimate", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).ErrorEstimate
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_expectedShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_expectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).ExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".ExpectedShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianAverageShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianAverageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).GaussianAverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianAverageShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianExpectedShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianExpectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).GaussianExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianExpectedShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
        single argument list
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianPercentile", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).GaussianPercentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianPercentile") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianPotentialUpside", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianPotentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).GaussianPotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianPotentialUpside") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).GaussianShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianValueAtRisk", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianValueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).GaussianValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianValueAtRisk") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_kurtosis", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Kurtosis
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Kurtosis") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_max", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Max
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Max") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
        void argument list
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_mean", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Mean
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Mean") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_min", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Min
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Min") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_percentile", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Percentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Percentile") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_potentialUpside", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_potentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).PotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".PotentialUpside") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_regret", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_regret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Regret
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Regret") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
        1-D inspectors lifted from underlying statistics class
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_samples", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Samples") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_semiDeviation", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_semiDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).SemiDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".SemiDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_semiVariance", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_semiVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).SemiVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".SemiVariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_shortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_shortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Shortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Shortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_size", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_skewness", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Skewness
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Skewness") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_standardDeviation", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).StandardDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".StandardDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_valueAtRisk", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_valueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).ValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".ValueAtRisk") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_variance", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).Variance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".Variance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_weightSum", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscrepancyStatisticsModel.Cast _DiscrepancyStatistics.cell).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscrepancyStatistics.source + ".WeightSum") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_Range", Description="Create a range of DiscrepancyStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscrepancyStatistics> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DiscrepancyStatistics> (c)) :> ICell
                let format (i : Generic.List<ICell<DiscrepancyStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DiscrepancyStatistics>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
