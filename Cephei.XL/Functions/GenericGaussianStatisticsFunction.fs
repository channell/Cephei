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
(*!! generic
(* <summary>
  This class wraps a somewhat generic statistic tool and adds a number of gaussian risk measures (e.g.: value-at-risk, expected shortfall, etc.) based on the mean and variance provided by the underlying statistic tool.
  </summary> *)
[<AutoSerializable(true)>]
module GenericGaussianStatisticsFunction =

    (*
        
    *)
    (*!! duplicat add function
    [<ExcelFunction(Name="_GenericGaussianStatistics_add", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        ([<ExcelArgument(Name="weight",Description = "double")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let _weight = Helper.toCell<double> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Add
                                                            _value.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GenericGaussianStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Add") 

                                               [| _value.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_addSequence", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_addSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="data",Description = "double range")>] 
         data : obj)
        ([<ExcelArgument(Name="weight",Description = "double range")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _weight = Helper.toCell<Generic.List<double>> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).AddSequence
                                                            _data.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GenericGaussianStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".AddSequence") 

                                               [| _data.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_errorEstimate", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_expectationValue", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_expectationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="f",Description = ",double")>] 
         f : obj)
        ([<ExcelArgument(Name="inRange",Description = ",bool")>] 
         inRange : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _f = Helper.toCell<Func<Generic.KeyValuePair<double,double>,double>> f "f" 
                let _inRange = Helper.toCell<Func<Generic.KeyValuePair<double,double>,bool>> inRange "inRange" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).ExpectationValue
                                                            _f.cell 
                                                            _inRange.cell 
                                                       ) :> ICell
                let format (o : KeyValuePair<double,int>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".ExpectationValue") 

                                               [| _f.source
                                               ;  _inRange.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        ! gaussian-assumption Average Shortfall (averaged shortfallness)
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianAverageShortfall", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianAverageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "double")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _target = Helper.toCell<double> target "target" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianAverageShortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianAverageShortfall") 

                                               [| _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _target.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianDownsideDeviation", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianDownsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianDownsideDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianDownsideDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianDownsideVariance", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianDownsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianDownsideVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianDownsideVariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        ! Assuming a gaussian distribution it returns the expected loss in case that the loss exceeded a VaR threshold,  that is the average of observations below the given percentile \f$ p \f$. Also know as conditional value-at-risk.  See Artzner, Delbaen, Eber and Heath, "Coherent measures of risk", Mathematical Finance 9 (1999)
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianExpectedShortfall", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianExpectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "double")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _percentile = Helper.toCell<double> percentile "percentile" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianExpectedShortfall
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianExpectedShortfall") 

                                               [| _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
        ! \pre percentile must be in range (0%-100%) extremes excluded
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianPercentile", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "double")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _percentile = Helper.toCell<double> percentile "percentile" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianPercentile
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianPercentile") 

                                               [| _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
        ! gaussian-assumption Potential-Upside at a given percentile
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianPotentialUpside", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianPotentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "double")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _percentile = Helper.toCell<double> percentile "percentile" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianPotentialUpside
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianPotentialUpside") 

                                               [| _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
        ! returns the variance of observations below target See Dembo, Freeman "The Rules Of Risk", Wiley (2001)
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianRegret", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianRegret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "double")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _target = Helper.toCell<double> target "target" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianRegret
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianRegret") 

                                               [| _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _target.cell
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
        ! gaussian-assumption Shortfall (observations below target)
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianShortfall", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "double")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _target = Helper.toCell<double> target "target" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianShortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianShortfall") 

                                               [| _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _target.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianTopPercentile", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianTopPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "double")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _percentile = Helper.toCell<double> percentile "percentile" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianTopPercentile
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianTopPercentile") 

                                               [| _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
        ! gaussian-assumption Value-At-Risk at a given percentile
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_gaussianValueAtRisk", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_gaussianValueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percentile",Description = "double")>] 
         percentile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _percentile = Helper.toCell<double> percentile "percentile" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).GaussianValueAtRisk
                                                            _percentile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".GaussianValueAtRisk") 

                                               [| _percentile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
                                ;  _percentile.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="s",Description = "'Stat")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _s = Helper.toCell<'Stat> s "s" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GenericGaussianStatistics 
                                                            _s.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GenericGaussianStatistics>) l

                let source () = Helper.sourceFold "Fun.GenericGaussianStatistics" 
                                               [| _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _s.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericGaussianStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics1", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.GenericGaussianStatistics1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GenericGaussianStatistics>) l

                let source () = Helper.sourceFold "Fun.GenericGaussianStatistics1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericGaussianStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_kurtosis", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Kurtosis
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Kurtosis") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_max", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Max
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Max") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_mean", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Mean
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Mean") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_min", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Min
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Min") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_percentile", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        ([<ExcelArgument(Name="percent",Description = "double")>] 
         percent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let _percent = Helper.toCell<double> percent "percent" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Percentile
                                                            _percent.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Percentile") 

                                               [| _percent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_GenericGaussianStatistics_reset", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Reset
                                                       ) :> ICell
                let format (o : GenericGaussianStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_samples", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Samples") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_skewness", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Skewness
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Skewness") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_standardDeviation", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).StandardDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".StandardDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_variance", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).Variance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".Variance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_weightSum", Description="Create a GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericGaussianStatistics",Description = "GenericGaussianStatistics")>] 
         genericgaussianstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericGaussianStatistics = Helper.toCell<GenericGaussianStatistics> genericgaussianstatistics "GenericGaussianStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericGaussianStatisticsModel.Cast _GenericGaussianStatistics.cell).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericGaussianStatistics.source + ".WeightSum") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericGaussianStatistics.cell
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
    [<ExcelFunction(Name="_GenericGaussianStatistics_Range", Description="Create a range of GenericGaussianStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericGaussianStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GenericGaussianStatistics> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<GenericGaussianStatistics> (c)) :> ICell
                let format (i : Generic.List<ICell<GenericGaussianStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<GenericGaussianStatistics>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
