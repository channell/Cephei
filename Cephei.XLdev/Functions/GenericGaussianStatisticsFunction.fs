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
  This class wraps a somewhat generic statistic tool and adds a number of gaussian risk measures (e.g.: value-at-risk, expected shortfall, etc.) based on the mean and variance provided by the underlying statistic tool.
  </summary> *)
[<AutoSerializable(true)>]
module GenericGaussianStatisticsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_add", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _value = Helper.toCell<double> value "value" true
                let _weight = Helper.toCell<double> weight "weight" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Add
                                                            _value.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GenericGaussianStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Add") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _value.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_addSequence", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_addSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _data = Helper.toCell<Generic.List<double>> data "data" true
                let _weight = Helper.toCell<Generic.List<double>> weight "weight" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).AddSequence
                                                            _data.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GenericGaussianStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".AddSequence") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _data.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_errorEstimate", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".ErrorEstimate") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_expectationValue", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_expectationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="inRange",Description = "Reference to inRange")>] 
         inRange : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _f = Helper.toCell<Func<KeyValuePair<double,double>,double>> f "f" true
                let _inRange = Helper.toCell<Func<KeyValuePair<double,double>,bool>> inRange "inRange" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).ExpectationValue
                                                            _f.cell 
                                                            _inRange.cell 
                                                       ) :> ICell
                let format (o : KeyValuePair<double,int>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".ExpectationValue") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _f.source
                                               ;  _inRange.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        ! gaussian-assumption Average Shortfall (averaged shortfallness)
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianAverageShortfall", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianAverageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _target = Helper.toCell<double> target "target" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianAverageShortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianAverageShortfall") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianDownsideDeviation", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianDownsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianDownsideDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianDownsideDeviation") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        ! returns the downside variance
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianDownsideVariance", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianDownsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianDownsideVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianDownsideVariance") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        ! Assuming a gaussian distribution it returns the expected loss in case that the loss exceeded a VaR threshold,  that is the average of observations below the given percentile \f$ p \f$. Also know as conditional value-at-risk.  See Artzner, Delbaen, Eber and Heath, "Coherent measures of risk", Mathematical Finance 9 (1999)
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianExpectedShortfall", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianExpectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "Reference to percentile")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _percentile = Helper.toCell<double> percentile "percentile" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianExpectedShortfall
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianExpectedShortfall") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
        ! \pre percentile must be in range (0%-100%) extremes excluded
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianPercentile", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "Reference to percentile")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _percentile = Helper.toCell<double> percentile "percentile" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianPercentile
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianPercentile") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
        ! gaussian-assumption Potential-Upside at a given percentile
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianPotentialUpside", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianPotentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "Reference to percentile")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _percentile = Helper.toCell<double> percentile "percentile" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianPotentialUpside
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianPotentialUpside") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
        ! returns the variance of observations below target See Dembo, Freeman "The Rules Of Risk", Wiley (2001)
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianRegret", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianRegret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _target = Helper.toCell<double> target "target" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianRegret
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianRegret") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        ! gaussian-assumption Shortfall (observations below target)
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianShortfall", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _target = Helper.toCell<double> target "target" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianShortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianShortfall") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianTopPercentile", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianTopPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "Reference to percentile")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _percentile = Helper.toCell<double> percentile "percentile" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianTopPercentile
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianTopPercentile") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
        ! gaussian-assumption Value-At-Risk at a given percentile
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianValueAtRisk", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianValueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "Reference to percentile")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _percentile = Helper.toCell<double> percentile "percentile" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).GaussianValueAtRisk
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianValueAtRisk") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _s = Helper.toCell<'Stat> s "s" true
                let builder () = withMnemonic mnemonic (Fun.GenericGaussianStatistics 
                                                            _s.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GenericGaussianStatistics>) l

                let source = Helper.sourceFold "Fun.GenericGaussianStatistics" 
                                               [| _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _s.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics1", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.GenericGaussianStatistics1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GenericGaussianStatistics>) l

                let source = Helper.sourceFold "Fun.GenericGaussianStatistics1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_kurtosis", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Kurtosis
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Kurtosis") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_max", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Max
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Max") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_mean", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Mean
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Mean") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_min", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Min
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Min") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_percentile", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percent",Description = "Reference to percent")>] 
         percent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let _percent = Helper.toCell<double> percent "percent" true
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Percentile
                                                            _percent.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Percentile") 
                                               [| _GenericGaussianStatistics.source
                                               ;  _percent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_reset", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Reset
                                                       ) :> ICell
                let format (o : GenericGaussianStatistics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Reset") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_samples", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Samples") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_skewness", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Skewness
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Skewness") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_standardDeviation", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).StandardDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".StandardDeviation") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_variance", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).Variance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".Variance") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_weightSum", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "Reference to GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics" true 
                let builder () = withMnemonic mnemonic ((_GenericGaussianStatistics.cell :?> GenericGaussianStatisticsModel).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GenericGaussianStatistics.source + ".WeightSum") 
                                               [| _GenericGaussianStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_Range", Description="Create a range of GenericGaussianStatistics",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GenericGaussianStatistics")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GenericGaussianStatistics> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GenericGaussianStatistics>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GenericGaussianStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GenericGaussianStatistics>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
