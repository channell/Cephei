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
  This class wraps a somewhat generic statistic tool and adds a number of risk measures (e.g.: value-at-risk, expected shortfall, etc.) based on the data distribution as reported by the underlying statistic tool.  add historical annualized volatility
  </summary> *)
[<AutoSerializable(true)>]
module GenericRiskStatisticsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_add", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _value = Helper.toCell<double> value "value" true
                let _weight = Helper.toCell<double> weight "weight" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Add
                                                            _value.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GenericRiskStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Add") 
                                               [| _GenericRiskStatistics.source
                                               ;  _value.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_addSequence", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_addSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _data = Helper.toCell<Generic.List<double>> data "data" true
                let _weight = Helper.toCell<Generic.List<double>> weight "weight" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).AddSequence
                                                            _data.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GenericRiskStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".AddSequence") 
                                               [| _GenericRiskStatistics.source
                                               ;  _data.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _data.cell
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
        averaged shortfallness
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_averageShortfall", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_averageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _target = Helper.toCell<double> target "target" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).AverageShortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".AverageShortfall") 
                                               [| _GenericRiskStatistics.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _target.cell
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
        ! returns the downside deviation, defined as the square root of the downside variance.
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_downsideDeviation", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_downsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).DownsideDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".DownsideDeviation") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
        returns the variance of observations below 0.0,
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_downsideVariance", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_downsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).DownsideVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".DownsideVariance") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_errorEstimate", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".ErrorEstimate") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_expectationValue", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_expectationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="inRange",Description = "Reference to inRange")>] 
         inRange : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _f = Helper.toCell<Func<KeyValuePair<double,double>,double>> f "f" true
                let _inRange = Helper.toCell<Func<KeyValuePair<double,double>,bool>> inRange "inRange" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).ExpectationValue
                                                            _f.cell 
                                                            _inRange.cell 
                                                       ) :> ICell
                let format (o : KeyValuePair<double,int>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".ExpectationValue") 
                                               [| _GenericRiskStatistics.source
                                               ;  _f.source
                                               ;  _inRange.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _f.cell
                                ;  _inRange.cell
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
        ! returns the expected loss in case that the loss exceeded a VaR threshold,  that is the average of observations below the given percentile \f$ p \f$. Also know as conditional value-at-risk.  See Artzner, Delbaen, Eber and Heath, "Coherent measures of risk", Mathematical Finance 9 (1999)
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_expectedShortfall", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_expectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="centile",Description = "Reference to centile")>] 
         centile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _centile = Helper.toCell<double> centile "centile" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).ExpectedShortfall
                                                            _centile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".ExpectedShortfall") 
                                               [| _GenericRiskStatistics.source
                                               ;  _centile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _centile.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_kurtosis", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Kurtosis
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Kurtosis") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_max", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Max
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Max") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_mean", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Mean
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Mean") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_min", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Min
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Min") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_percentile", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="percent",Description = "Reference to percent")>] 
         percent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _percent = Helper.toCell<double> percent "percent" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Percentile
                                                            _percent.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Percentile") 
                                               [| _GenericRiskStatistics.source
                                               ;  _percent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _percent.cell
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
        ! potential upside (the reciprocal of VAR) at a given percentile
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_potentialUpside", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_potentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="centile",Description = "Reference to centile")>] 
         centile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _centile = Helper.toCell<double> centile "centile" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).PotentialUpside
                                                            _centile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".PotentialUpside") 
                                               [| _GenericRiskStatistics.source
                                               ;  _centile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _centile.cell
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
        ! returns the variance of observations below target, See Dembo and Freeman, "The Rules Of Risk", Wiley (2001).
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_regret", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_regret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _target = Helper.toCell<double> target "target" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Regret
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Regret") 
                                               [| _GenericRiskStatistics.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _target.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_reset", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Reset
                                                       ) :> ICell
                let format (o : GenericRiskStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Reset") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_samples", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Samples") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
        ! returns the semi deviation, defined as the square root of the semi variance.
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_semiDeviation", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_semiDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).SemiDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".SemiDeviation") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
        ! returns the variance of observations below the mean, See Markowitz (1959).
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_semiVariance", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_semiVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).SemiVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".SemiVariance") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
        probability of missing the given target
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_shortfall", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_shortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _target = Helper.toCell<double> target "target" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Shortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Shortfall") 
                                               [| _GenericRiskStatistics.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _target.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_skewness", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Skewness
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Skewness") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_standardDeviation", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).StandardDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".StandardDeviation") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
        ! value-at-risk at a given percentile
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_valueAtRisk", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_valueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="centile",Description = "Reference to centile")>] 
         centile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let _centile = Helper.toCell<double> centile "centile" true
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).ValueAtRisk
                                                            _centile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".ValueAtRisk") 
                                               [| _GenericRiskStatistics.source
                                               ;  _centile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
                                ;  _centile.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_variance", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).Variance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".Variance") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_weightSum", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "Reference to GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericRiskStatistics.cell :?> GenericRiskStatisticsModel).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericRiskStatistics.source + ".WeightSum") 
                                               [| _GenericRiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_Range", Description="Create a range of GenericRiskStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericRiskStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GenericRiskStatistics")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GenericRiskStatistics> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GenericRiskStatistics>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GenericRiskStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GenericRiskStatistics>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
