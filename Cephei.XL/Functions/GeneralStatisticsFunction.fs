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
  This class accumulates a set of data and returns their statistics (e.g: mean, variance, skewness, kurtosis, error estimation, percentile, etc.) based on the empirical distribution (no gaussian assumption)  It doesn't suffer the numerical instability problem of IncrementalStatistics. The downside is that it stores all samples, thus increasing the memory requirements.
  </summary> *)
[<AutoSerializable(true)>]
module GeneralStatisticsFunction =

    (*
        
    *)
    (*!! duplicate add function
    [<ExcelFunction(Name="_GeneralStatistics_add", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let _weight = Helper.toCell<double> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Add
                                                            _value.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GeneralStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Add") 
                                               [| _GeneralStatistics.source
                                               ;  _value.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
        ! adds a datum to the set, possibly with a weight
    *)
    (*!! duplicate add function
    [<ExcelFunction(Name="_GeneralStatistics_add", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Add1
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : GeneralStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Add") 
                                               [| _GeneralStatistics.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
            *)
    (*
        ! adds a sequence of data to the set, with default weight
    *)
    [<ExcelFunction(Name="_GeneralStatistics_addSequence", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_addSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        ([<ExcelArgument(Name="list",Description = "Reference to list")>] 
         list : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let _list = Helper.toCell<Generic.List<double>> list "list" 
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).AddSequence
                                                            _list.cell 
                                                       ) :> ICell
                let format (o : GeneralStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".AddSequence") 
                                               [| _GeneralStatistics.source
                                               ;  _list.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
        ! adds a sequence of data to the set, each with its weight
    *)
    [<ExcelFunction(Name="_GeneralStatistics_addSequence1", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_addSequence1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _weight = Helper.toCell<Generic.List<double>> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).AddSequence1
                                                            _data.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GeneralStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".AddSequence1") 
                                               [| _GeneralStatistics.source
                                               ;  _data.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
        ! collected data
    *)
    [<ExcelFunction(Name="_GeneralStatistics_data", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Data
                                                       ) :> ICell
                let format (i : Generic.List<Generic.KeyValuePair<double,double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Data") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
        ! returns the error estimate on the mean value, defined as \f$ \epsilon = \sigma/\sqrt{N}. \f$
    *)
    [<ExcelFunction(Name="_GeneralStatistics_errorEstimate", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".ErrorEstimate") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
        ! Expectation value of a function \f$ f \f$ on a given range \f$ \mathcal{R} \f$, i.e.,  The range is passed as a boolean function returning
<tt>true</tt> if the argument belongs to the range or <tt>false</tt> otherwise.  The function returns a pair made of the result and the number of observations in the given range.
    *)
    [<ExcelFunction(Name="_GeneralStatistics_expectationValue", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_expectationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="inRange",Description = "Reference to inRange")>] 
         inRange : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let _f = Helper.toCell<Func<Generic.KeyValuePair<double,double>,double>> f "f" 
                let _inRange = Helper.toCell<Func<Generic.KeyValuePair<double,double>,bool>> inRange "inRange" 
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).ExpectationValue
                                                            _f.cell 
                                                            _inRange.cell 
                                                       ) :> ICell
                let format (o : Generic.KeyValuePair<double,int>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".ExpectationValue") 
                                               [| _GeneralStatistics.source
                                               ;  _f.source
                                               ;  _inRange.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.GeneralStatistics ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GeneralStatistics>) l

                let source () = Helper.sourceFold "Fun.GeneralStatistics" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GeneralStatistics> format
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
    [<ExcelFunction(Name="_GeneralStatistics_kurtosis", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Kurtosis
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Kurtosis") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics_max", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Max
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Max") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics_mean", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Mean
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Mean") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics_min", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Min
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Min") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
        ! \f$ y \f$-th percentile, defined as the value \f$ \bar{x} \f$ \pre \f$ y \f$ must be in the range \f$ (0-1]. \f$
    *)
    [<ExcelFunction(Name="_GeneralStatistics_percentile", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        ([<ExcelArgument(Name="percent",Description = "Reference to percent")>] 
         percent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let _percent = Helper.toCell<double> percent "percent" 
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Percentile
                                                            _percent.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Percentile") 
                                               [| _GeneralStatistics.source
                                               ;  _percent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics_reset", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Reset
                                                       ) :> ICell
                let format (o : GeneralStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Reset") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics_samples", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Samples") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics_skewness", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Skewness
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Skewness") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
        ! sort the data set in increasing order
    *)
    [<ExcelFunction(Name="_GeneralStatistics_sort", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_sort
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Sort
                                                       ) :> ICell
                let format (o : GeneralStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Sort") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics_standardDeviation", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).StandardDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".StandardDeviation") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
        ! \f$ y \f$-th top percentile, defined as the value \pre \f$ y \f$ must be in the range \f$ (0-1]. \f$
    *)
    [<ExcelFunction(Name="_GeneralStatistics_topPercentile", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_topPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        ([<ExcelArgument(Name="percent",Description = "Reference to percent")>] 
         percent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let _percent = Helper.toCell<double> percent "percent" 
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).TopPercentile
                                                            _percent.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".TopPercentile") 
                                               [| _GeneralStatistics.source
                                               ;  _percent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
        ! returns the variance, defined as \f[ \sigma^2 = \frac{N}{N-1} \left\langle \left( x-\langle x \rangle \right)^2 \right\rangle. \f]
    *)
    [<ExcelFunction(Name="_GeneralStatistics_variance", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).Variance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".Variance") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics_weightSum", Description="Create a GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralStatistics",Description = "Reference to GeneralStatistics")>] 
         generalstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralStatistics = Helper.toCell<GeneralStatistics> generalstatistics "GeneralStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GeneralStatisticsModel.Cast _GeneralStatistics.cell).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GeneralStatistics.source + ".WeightSum") 
                                               [| _GeneralStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralStatistics.cell
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
    [<ExcelFunction(Name="_GeneralStatistics_Range", Description="Create a range of GeneralStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GeneralStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GeneralStatistics")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GeneralStatistics> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GeneralStatistics>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GeneralStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GeneralStatistics>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
