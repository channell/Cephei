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
(*!!generic
(* <summary>
  It provides 1-dimensional statistics as discrepancy plus N-dimensional (sequence) statistics (e.g. mean, variance, skewness, kurtosis, etc.) with one component for each dimension of the sample space.  For most of the statistics this class relies on the StatisticsType underlying class to provide 1-D methods that will be iterated for all the components of the N-D data. These lifted methods are the union of all the methods that might be requested to the 1-D underlying StatisticsType class, with the usual compile-time checks provided by the template approach.  the correctness of the returned values is tested by checking them against numerical calculations.
  </summary> *)
[<AutoSerializable(true)>]
module GenericSequenceStatisticsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GenericSequenceStatistics_add", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "Reference to Begin")>] 
         Begin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Add
                                                            _Begin.cell 
                                                       ) :> ICell
                let format (o : GenericSequenceStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Add") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _Begin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_add", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "Reference to Begin")>] 
         Begin : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" 
                let _weight = Helper.toCell<double> weight "weight" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Add1
                                                            _Begin.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GenericSequenceStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Add") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _Begin.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_averageShortfall", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_averageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).AverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".AverageShortfall") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_correlation", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Correlation
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Correlation") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericSequenceStatistics> format
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_covariance", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Covariance
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Covariance") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericSequenceStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GenericSequenceStatistics_downsideDeviation", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_downsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).DownsideDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".DownsideDeviation") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_downsideVariance", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_downsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).DownsideVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".DownsideVariance") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_errorEstimate", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).ErrorEstimate
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".ErrorEstimate") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_expectedShortfall", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_expectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).ExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".ExpectedShortfall") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_gaussianAverageShortfall", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_gaussianAverageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).GaussianAverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".GaussianAverageShortfall") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_gaussianExpectedShortfall", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_gaussianExpectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).GaussianExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".GaussianExpectedShortfall") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_gaussianPercentile", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_gaussianPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).GaussianPercentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".GaussianPercentile") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_gaussianPotentialUpside", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_gaussianPotentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).GaussianPotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".GaussianPotentialUpside") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_gaussianShortfall", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_gaussianShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).GaussianShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".GaussianShortfall") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_gaussianValueAtRisk", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_gaussianValueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).GaussianValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".GaussianValueAtRisk") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimension",Description = "Reference to dimension")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimension = Helper.toCell<int> dimension "dimension" 
                let builder () = withMnemonic mnemonic (Fun.GenericSequenceStatistics 
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GenericSequenceStatistics>) l

                let source = Helper.sourceFold "Fun.GenericSequenceStatistics" 
                                               [| _dimension.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimension.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericSequenceStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GenericSequenceStatistics_kurtosis", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Kurtosis
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Kurtosis") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_max", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Max
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Max") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_mean", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Mean
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Mean") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_min", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Min
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Min") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_percentile", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Percentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Percentile") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_potentialUpside", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_potentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).PotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".PotentialUpside") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_regret", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_regret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Regret
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Regret") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_reset", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="dimension",Description = "Reference to dimension")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _dimension = Helper.toCell<int> dimension "dimension" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Reset
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (o : GenericSequenceStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Reset") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _dimension.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_samples", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Samples") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_semiDeviation", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_semiDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).SemiDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".SemiDeviation") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_semiVariance", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_semiVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).SemiVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".SemiVariance") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_shortfall", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_shortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Shortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Shortfall") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_size", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Size") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_skewness", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Skewness
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Skewness") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_standardDeviation", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).StandardDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".StandardDeviation") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_valueAtRisk", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_valueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).ValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".ValueAtRisk") 
                                               [| _GenericSequenceStatistics.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_variance", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).Variance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".Variance") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_weightSum", Description="Create a GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericSequenceStatistics",Description = "Reference to GenericSequenceStatistics")>] 
         genericsequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericSequenceStatistics = Helper.toCell<GenericSequenceStatistics> genericsequencestatistics "GenericSequenceStatistics"  
                let builder () = withMnemonic mnemonic ((GenericSequenceStatisticsModel.Cast _GenericSequenceStatistics.cell).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericSequenceStatistics.source + ".WeightSum") 
                                               [| _GenericSequenceStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericSequenceStatistics.cell
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
    [<ExcelFunction(Name="_GenericSequenceStatistics_Range", Description="Create a range of GenericSequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericSequenceStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GenericSequenceStatistics")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GenericSequenceStatistics> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GenericSequenceStatistics>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GenericSequenceStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GenericSequenceStatistics>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
