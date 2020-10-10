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
module RiskStatisticsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RiskStatistics_gaussianAverageShortfall", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_gaussianAverageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).GaussianAverageShortfall
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".GaussianAverageShortfall") 
                                               [| _RiskStatistics.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_RiskStatistics_gaussianDownsideVariance", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_gaussianDownsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).GaussianDownsideVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".GaussianDownsideVariance") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_gaussianExpectedShortfall", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_gaussianExpectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).GaussianExpectedShortfall
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".GaussianExpectedShortfall") 
                                               [| _RiskStatistics.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_RiskStatistics_gaussianPercentile", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_gaussianPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).GaussianPercentile
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".GaussianPercentile") 
                                               [| _RiskStatistics.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_RiskStatistics_gaussianPotentialUpside", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_gaussianPotentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).GaussianPotentialUpside
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".GaussianPotentialUpside") 
                                               [| _RiskStatistics.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_RiskStatistics_gaussianRegret", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_gaussianRegret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).GaussianRegret
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".GaussianRegret") 
                                               [| _RiskStatistics.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_RiskStatistics_gaussianShortfall", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_gaussianShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).GaussianShortfall
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".GaussianShortfall") 
                                               [| _RiskStatistics.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_RiskStatistics_gaussianValueAtRisk", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_gaussianValueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).GaussianValueAtRisk
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".GaussianValueAtRisk") 
                                               [| _RiskStatistics.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        
    *)
    (*!! duplicate Add function 
    [<ExcelFunction(Name="_RiskStatistics_add", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let _weight = Helper.toCell<double> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Add
                                                            _value.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : RiskStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Add") 
                                               [| _RiskStatistics.source
                                               ;  _value.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_addSequence", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_addSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="weight",Description = "Reference to weight")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _weight = Helper.toCell<Generic.List<double>> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).AddSequence
                                                            _data.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : RiskStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".AddSequence") 
                                               [| _RiskStatistics.source
                                               ;  _data.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        averaged shortfallness
    *)
    [<ExcelFunction(Name="_RiskStatistics_averageShortfall", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_averageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _target = Helper.toCell<double> target "target" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).AverageShortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".AverageShortfall") 
                                               [| _RiskStatistics.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_downsideDeviation", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_downsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).DownsideDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".DownsideDeviation") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        returns the variance of observations below 0.0,
    *)
    [<ExcelFunction(Name="_RiskStatistics_downsideVariance", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_downsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).DownsideVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".DownsideVariance") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_errorEstimate", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".ErrorEstimate") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_expectationValue", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_expectationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="inRange",Description = "Reference to inRange")>] 
         inRange : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _f = Helper.toCell<Func<Generic.KeyValuePair<double,double>,double>> f "f" 
                let _inRange = Helper.toCell<Func<Generic.KeyValuePair<double,double>,bool>> inRange "inRange" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).ExpectationValue
                                                            _f.cell 
                                                            _inRange.cell 
                                                       ) :> ICell
                let format (o : Generic.KeyValuePair<double,int>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".ExpectationValue") 
                                               [| _RiskStatistics.source
                                               ;  _f.source
                                               ;  _inRange.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        ! returns the expected loss in case that the loss exceeded a VaR threshold,  that is the average of observations below the given percentile \f$ p \f$. Also know as conditional value-at-risk.  See Artzner, Delbaen, Eber and Heath, "Coherent measures of risk", Mathematical Finance 9 (1999)
    *)
    [<ExcelFunction(Name="_RiskStatistics_expectedShortfall", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_expectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="centile",Description = "Reference to centile")>] 
         centile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _centile = Helper.toCell<double> centile "centile" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).ExpectedShortfall
                                                            _centile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".ExpectedShortfall") 
                                               [| _RiskStatistics.source
                                               ;  _centile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
                                ;  _centile.cell
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
    [<ExcelFunction(Name="_RiskStatistics_kurtosis", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Kurtosis
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Kurtosis") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_max", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Max
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Max") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_mean", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Mean
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Mean") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_min", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Min
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Min") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_percentile", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="percent",Description = "Reference to percent")>] 
         percent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _percent = Helper.toCell<double> percent "percent" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Percentile
                                                            _percent.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Percentile") 
                                               [| _RiskStatistics.source
                                               ;  _percent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        ! potential upside (the reciprocal of VAR) at a given percentile
    *)
    [<ExcelFunction(Name="_RiskStatistics_potentialUpside", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_potentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="centile",Description = "Reference to centile")>] 
         centile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _centile = Helper.toCell<double> centile "centile" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).PotentialUpside
                                                            _centile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".PotentialUpside") 
                                               [| _RiskStatistics.source
                                               ;  _centile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
                                ;  _centile.cell
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
        ! returns the variance of observations below target, See Dembo and Freeman, "The Rules Of Risk", Wiley (2001).
    *)
    [<ExcelFunction(Name="_RiskStatistics_regret", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_regret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _target = Helper.toCell<double> target "target" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Regret
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Regret") 
                                               [| _RiskStatistics.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_reset", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Reset
                                                       ) :> ICell
                let format (o : RiskStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Reset") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_samples", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Samples") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        ! returns the semi deviation, defined as the square root of the semi variance.
    *)
    [<ExcelFunction(Name="_RiskStatistics_semiDeviation", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_semiDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).SemiDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".SemiDeviation") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        ! returns the variance of observations below the mean, See Markowitz (1959).
    *)
    [<ExcelFunction(Name="_RiskStatistics_semiVariance", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_semiVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).SemiVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".SemiVariance") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        probability of missing the given target
    *)
    [<ExcelFunction(Name="_RiskStatistics_shortfall", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_shortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "Reference to target")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _target = Helper.toCell<double> target "target" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Shortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Shortfall") 
                                               [| _RiskStatistics.source
                                               ;  _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_skewness", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Skewness
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Skewness") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_standardDeviation", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).StandardDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".StandardDeviation") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
        ! value-at-risk at a given percentile
    *)
    [<ExcelFunction(Name="_RiskStatistics_valueAtRisk", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_valueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        ([<ExcelArgument(Name="centile",Description = "Reference to centile")>] 
         centile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let _centile = Helper.toCell<double> centile "centile" 
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).ValueAtRisk
                                                            _centile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".ValueAtRisk") 
                                               [| _RiskStatistics.source
                                               ;  _centile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
                                ;  _centile.cell
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
    [<ExcelFunction(Name="_RiskStatistics_variance", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).Variance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".Variance") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_weightSum", Description="Create a RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RiskStatistics",Description = "Reference to RiskStatistics")>] 
         riskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RiskStatistics = Helper.toCell<RiskStatistics> riskstatistics "RiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((RiskStatisticsModel.Cast _RiskStatistics.cell).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RiskStatistics.source + ".WeightSum") 
                                               [| _RiskStatistics.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RiskStatistics.cell
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
    [<ExcelFunction(Name="_RiskStatistics_Range", Description="Create a range of RiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RiskStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the RiskStatistics")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RiskStatistics> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<RiskStatistics>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<RiskStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<RiskStatistics>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
