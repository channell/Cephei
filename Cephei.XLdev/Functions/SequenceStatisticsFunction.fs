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
  the correctness of the returned values is tested by checking them against numerical calculations.
  </summary> *)
[<AutoSerializable(true)>]
module SequenceStatisticsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimension",Description = "Reference to dimension")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimension = Helper.toCell<int> dimension "dimension" true
                let builder () = withMnemonic mnemonic (Fun.SequenceStatistics 
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SequenceStatistics>) l

                let source = Helper.sourceFold "Fun.SequenceStatistics" 
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
    [<ExcelFunction(Name="_SequenceStatistics_add", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "Reference to Begin")>] 
         Begin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Add
                                                            _Begin.cell 
                                                       ) :> ICell
                let format (o : SequenceStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Add") 
                                               [| _SequenceStatistics.source
                                               ;  _Begin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_add", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "Reference to Begin")>] 
         Begin : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" true
                let _weight = Helper.toCell<double> weight "weight" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Add1
                                                            _Begin.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : SequenceStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Add1") 
                                               [| _SequenceStatistics.source
                                               ;  _Begin.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_averageShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_averageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).AverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".AverageShortfall") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_correlation", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Correlation
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Correlation") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_covariance", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Covariance
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Covariance") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_downsideDeviation", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_downsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).DownsideDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".DownsideDeviation") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_downsideVariance", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_downsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).DownsideVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".DownsideVariance") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_errorEstimate", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).ErrorEstimate
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".ErrorEstimate") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_expectedShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_expectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).ExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".ExpectedShortfall") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_gaussianAverageShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianAverageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).GaussianAverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".GaussianAverageShortfall") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_gaussianExpectedShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianExpectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).GaussianExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".GaussianExpectedShortfall") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_gaussianPercentile", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).GaussianPercentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".GaussianPercentile") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_gaussianPotentialUpside", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianPotentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).GaussianPotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".GaussianPotentialUpside") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_gaussianShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).GaussianShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".GaussianShortfall") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_gaussianValueAtRisk", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianValueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).GaussianValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".GaussianValueAtRisk") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_kurtosis", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Kurtosis
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Kurtosis") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_max", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Max
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Max") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_mean", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Mean
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Mean") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_min", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Min
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Min") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_percentile", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Percentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Percentile") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_potentialUpside", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_potentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).PotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".PotentialUpside") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_regret", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_regret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Regret
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Regret") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        Modifiers
    *)
    [<ExcelFunction(Name="_SequenceStatistics_reset", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="dimension",Description = "Reference to dimension")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _dimension = Helper.toCell<int> dimension "dimension" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Reset
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (o : SequenceStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Reset") 
                                               [| _SequenceStatistics.source
                                               ;  _dimension.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        1-D inspectors lifted from underlying statistics class
    *)
    [<ExcelFunction(Name="_SequenceStatistics_samples", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Samples") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_semiDeviation", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_semiDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).SemiDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".SemiDeviation") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_semiVariance", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_semiVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).SemiVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".SemiVariance") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_shortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_shortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Shortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Shortfall") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_size", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Size") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_skewness", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Skewness
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Skewness") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_standardDeviation", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).StandardDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".StandardDeviation") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_valueAtRisk", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_valueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).ValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".ValueAtRisk") 
                                               [| _SequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_variance", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).Variance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SequenceStatistics.source + ".Variance") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_weightSum", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "Reference to SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics" true 
                let builder () = withMnemonic mnemonic ((_SequenceStatistics.cell :?> SequenceStatisticsModel).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SequenceStatistics.source + ".WeightSum") 
                                               [| _SequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_Range", Description="Create a range of SequenceStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SequenceStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SequenceStatistics")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SequenceStatistics> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SequenceStatistics>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SequenceStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SequenceStatistics>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
