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
    [<ExcelFunction(Name="_DiscrepancyStatistics_add", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "Reference to Begin")>] 
         Begin : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" true
                let _weight = Helper.toCell<double> weight "weight" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Add
                                                            _Begin.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : DiscrepancyStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Add") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _Begin.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _Begin.cell
                                ;  _weight.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_add", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "Reference to Begin")>] 
         Begin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Add1
                                                            _Begin.cell 
                                                       ) :> ICell
                let format (o : DiscrepancyStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Add") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _Begin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _Begin.cell
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
        !  1-dimensional inspectors
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_discrepancy", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_discrepancy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Discrepancy
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Discrepancy") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
        constructor
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimension",Description = "Reference to dimension")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimension = Helper.toCell<int> dimension "dimension" true
                let builder () = withMnemonic mnemonic (Fun.DiscrepancyStatistics 
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscrepancyStatistics>) l

                let source = Helper.sourceFold "Fun.DiscrepancyStatistics" 
                                               [| _dimension.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimension.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_reset", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="dimension",Description = "Reference to dimension")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _dimension = Helper.toCell<int> dimension "dimension" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Reset
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (o : DiscrepancyStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Reset") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _dimension.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _dimension.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_averageShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_averageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).AverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".AverageShortfall") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
        ! returns the correlation Matrix
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_correlation", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Correlation
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Correlation") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_covariance", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Covariance
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Covariance") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_downsideDeviation", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_downsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).DownsideDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".DownsideDeviation") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_downsideVariance", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_downsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).DownsideVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".DownsideVariance") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_errorEstimate", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).ErrorEstimate
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".ErrorEstimate") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_expectedShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_expectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).ExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".ExpectedShortfall") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianAverageShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianAverageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).GaussianAverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianAverageShortfall") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianExpectedShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianExpectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).GaussianExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianExpectedShortfall") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
        single argument list
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianPercentile", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).GaussianPercentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianPercentile") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianPotentialUpside", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianPotentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).GaussianPotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianPotentialUpside") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianShortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).GaussianShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianShortfall") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_gaussianValueAtRisk", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_gaussianValueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).GaussianValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".GaussianValueAtRisk") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_kurtosis", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Kurtosis
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Kurtosis") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_max", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Max
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Max") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
        void argument list
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_mean", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Mean
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Mean") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_min", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Min
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Min") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_percentile", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Percentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Percentile") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_potentialUpside", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_potentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).PotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".PotentialUpside") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_regret", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_regret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Regret
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Regret") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
        1-D inspectors lifted from underlying statistics class
    *)
    [<ExcelFunction(Name="_DiscrepancyStatistics_samples", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Samples") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_semiDeviation", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_semiDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).SemiDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".SemiDeviation") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_semiVariance", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_semiVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).SemiVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".SemiVariance") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_shortfall", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_shortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Shortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Shortfall") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_size", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Size") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_skewness", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Skewness
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Skewness") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_standardDeviation", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).StandardDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".StandardDeviation") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_valueAtRisk", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_valueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).ValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".ValueAtRisk") 
                                               [| _DiscrepancyStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_variance", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).Variance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".Variance") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_weightSum", Description="Create a DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscrepancyStatistics",Description = "Reference to DiscrepancyStatistics")>] 
         discrepancystatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscrepancyStatistics = Helper.toCell<DiscrepancyStatistics> discrepancystatistics "DiscrepancyStatistics" true 
                let builder () = withMnemonic mnemonic ((_DiscrepancyStatistics.cell :?> DiscrepancyStatisticsModel).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscrepancyStatistics.source + ".WeightSum") 
                                               [| _DiscrepancyStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscrepancyStatistics.cell
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
    [<ExcelFunction(Name="_DiscrepancyStatistics_Range", Description="Create a range of DiscrepancyStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscrepancyStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscrepancyStatistics")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscrepancyStatistics> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscrepancyStatistics>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscrepancyStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DiscrepancyStatistics>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
