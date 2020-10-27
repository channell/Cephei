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
  It can accumulate a set of data and return statistics (e.g: mean, variance, skewness, kurtosis, error estimation, etc.)  high moments are numerically unstable for high average/standardDeviation ratios.
  </summary> *)
[<AutoSerializable(true)>]
module IncrementalStatisticsFunction =

    (*
        
    *)
    (*! duplicate add function 
    [<ExcelFunction(Name="_IncrementalStatistics_add", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        ([<ExcelArgument(Name="weight",Description = "double")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let _weight = Helper.toCell<double> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Add
                                                            _value.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : IncrementalStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Add") 

                                               [| _value.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
                                ;  _value.cell
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
        ! \pre weight must be positive or null
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_add", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Add1
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : IncrementalStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Add") 

                                               [| _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
                                ;  _value.cell
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
        ! adds a sequence of data to the set, with default weight
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_addSequence", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_addSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        ([<ExcelArgument(Name="list",Description = "double range")>] 
         list : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let _list = Helper.toCell<Generic.List<double>> list "list" 
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).AddSequence
                                                            _list.cell 
                                                       ) :> ICell
                let format (o : IncrementalStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".AddSequence") 

                                               [| _list.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
                                ;  _list.cell
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
        ! \pre weights must be positive or null
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_addSequence1", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_addSequence1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        ([<ExcelArgument(Name="data",Description = "double range")>] 
         data : obj)
        ([<ExcelArgument(Name="weight",Description = "double range")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _weight = Helper.toCell<Generic.List<double>> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).AddSequence1
                                                            _data.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : IncrementalStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".AddSequence1") 

                                               [| _data.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
                                ;  _data.cell
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
    (*
        ! returns the downside deviation, defined as the square root of the downside variance.
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_downsideDeviation", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_downsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).DownsideDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".DownsideDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! returns the downside variance
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_downsideVariance", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_downsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).DownsideVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".DownsideVariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! returns the error estimate \f$ \epsilon \f$, defined as the square root of the ratio of the variance to the number of samples.
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_errorEstimate", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
    [<ExcelFunction(Name="_IncrementalStatistics_expectationValue", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_expectationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        ([<ExcelArgument(Name="f",Description = ",double")>] 
         f : obj)
        ([<ExcelArgument(Name="inRange",Description = ",bool")>] 
         inRange : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let _f = Helper.toCell<Func<Generic.KeyValuePair<double,double>,double>> f "f" 
                let _inRange = Helper.toCell<Func<Generic.KeyValuePair<double,double>,bool>> inRange "inRange" 
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).ExpectationValue
                                                            _f.cell 
                                                            _inRange.cell 
                                                       ) :> ICell
                let format (o : Generic.KeyValuePair<double,int>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".ExpectationValue") 

                                               [| _f.source
                                               ;  _inRange.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
                                ;  _f.cell
                                ;  _inRange.cell
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
    [<ExcelFunction(Name="_IncrementalStatistics", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.IncrementalStatistics ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IncrementalStatistics>) l

                let source () = Helper.sourceFold "Fun.IncrementalStatistics" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<IncrementalStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the excess kurtosis The above evaluates to 0 for a Gaussian distribution.
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_kurtosis", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Kurtosis
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Kurtosis") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! returns the maximum sample value
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_max", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Max
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Max") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! returns the mean, defined as \f[ \langle x \rangle = \frac{\sum w_i x_i}{\sum w_i}. \f]
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_mean", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Mean
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Mean") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! returns the minimum sample value
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_min", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Min
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Min") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
    [<ExcelFunction(Name="_IncrementalStatistics_percentile", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        ([<ExcelArgument(Name="percent",Description = "double")>] 
         percent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let _percent = Helper.toCell<double> percent "percent" 
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Percentile
                                                            _percent.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Percentile") 

                                               [| _percent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
                                ;  _percent.cell
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
        ! resets the data to a null set
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_reset", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Reset
                                                       ) :> ICell
                let format (o : IncrementalStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! number of samples collected
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_samples", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Samples") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! returns the skewness, defined as \f[ \frac{N^2}{(N-1)(N-2)} \frac{\left\langle \left( x-\langle x \rangle \right)^3 \right\rangle}{\sigma^3}. \f] The above evaluates to 0 for a Gaussian distribution.
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_skewness", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Skewness
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Skewness") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! returns the standard deviation \f$ \sigma \f$, defined as the square root of the variance.
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_standardDeviation", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).StandardDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".StandardDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! returns the variance, defined as \f[ \frac{N}{N-1} \left\langle \left( x-\langle x \rangle \right)^2 \right\rangle. \f]
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_variance", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).Variance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".Variance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
        ! sum of data weights
    *)
    [<ExcelFunction(Name="_IncrementalStatistics_weightSum", Description="Create a IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IncrementalStatistics",Description = "IncrementalStatistics")>] 
         incrementalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IncrementalStatistics = Helper.toCell<IncrementalStatistics> incrementalstatistics "IncrementalStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((IncrementalStatisticsModel.Cast _IncrementalStatistics.cell).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_IncrementalStatistics.source + ".WeightSum") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _IncrementalStatistics.cell
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
    [<ExcelFunction(Name="_IncrementalStatistics_Range", Description="Create a range of IncrementalStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let IncrementalStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IncrementalStatistics> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IncrementalStatistics>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<IncrementalStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<IncrementalStatistics>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
