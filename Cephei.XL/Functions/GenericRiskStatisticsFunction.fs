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
  This class wraps a somewhat generic statistic tool and adds a number of risk measures (e.g.: value-at-risk, expected shortfall, etc.) based on the data distribution as reported by the underlying statistic tool.  add historical annualized volatility
  </summary> *)
[<AutoSerializable(true)>]
module GenericRiskStatisticsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_add", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        ([<ExcelArgument(Name="weight",Description = "double")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _value = Helper.toCell<double> value "value" 
                let _weight = Helper.toCell<double> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Add
                                                            _value.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GenericRiskStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Add") 

                                               [| _value.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_GenericRiskStatistics_addSequence", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_addSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="data",Description = "double range")>] 
         data : obj)
        ([<ExcelArgument(Name="weight",Description = "double range")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _weight = Helper.toCell<Generic.List<double>> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).AddSequence
                                                            _data.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : GenericRiskStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".AddSequence") 

                                               [| _data.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_averageShortfall", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_averageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "double")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _target = Helper.toCell<double> target "target" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).AverageShortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".AverageShortfall") 

                                               [| _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_downsideDeviation", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_downsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).DownsideDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".DownsideDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_downsideVariance", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_downsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).DownsideVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".DownsideVariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_errorEstimate", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_expectationValue", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_expectationValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="f",Description = ",double")>] 
         f : obj)
        ([<ExcelArgument(Name="inRange",Description = ",bool")>] 
         inRange : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _f = Helper.toCell<Func<Generic.KeyValuePair<double,double>,double>> f "f" 
                let _inRange = Helper.toCell<Func<Generic.KeyValuePair<double,double>,bool>> inRange "inRange" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).ExpectationValue
                                                            _f.cell 
                                                            _inRange.cell 
                                                       ) :> ICell
                let format (o : KeyValuePair<double,int>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".ExpectationValue") 

                                               [| _f.source
                                               ;  _inRange.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_expectedShortfall", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_expectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="centile",Description = "double")>] 
         centile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _centile = Helper.toCell<double> centile "centile" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).ExpectedShortfall
                                                            _centile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".ExpectedShortfall") 

                                               [| _centile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_kurtosis", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Kurtosis
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Kurtosis") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_max", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Max
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Max") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_mean", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Mean
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Mean") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_min", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Min
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Min") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_percentile", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="percent",Description = "double")>] 
         percent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _percent = Helper.toCell<double> percent "percent" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Percentile
                                                            _percent.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Percentile") 

                                               [| _percent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_potentialUpside", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_potentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="centile",Description = "double")>] 
         centile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _centile = Helper.toCell<double> centile "centile" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).PotentialUpside
                                                            _centile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".PotentialUpside") 

                                               [| _centile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_regret", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_regret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "double")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _target = Helper.toCell<double> target "target" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Regret
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Regret") 

                                               [| _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_reset", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Reset
                                                       ) :> ICell
                let format (o : GenericRiskStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_samples", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Samples") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_semiDeviation", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_semiDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).SemiDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".SemiDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_semiVariance", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_semiVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).SemiVariance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".SemiVariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_shortfall", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_shortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="target",Description = "double")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _target = Helper.toCell<double> target "target" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Shortfall
                                                            _target.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Shortfall") 

                                               [| _target.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_skewness", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Skewness
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Skewness") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_standardDeviation", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).StandardDeviation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".StandardDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_valueAtRisk", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_valueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        ([<ExcelArgument(Name="centile",Description = "double")>] 
         centile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let _centile = Helper.toCell<double> centile "centile" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).ValueAtRisk
                                                            _centile.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".ValueAtRisk") 

                                               [| _centile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_variance", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).Variance
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".Variance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_weightSum", Description="Create a GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericRiskStatistics",Description = "GenericRiskStatistics")>] 
         genericriskstatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericRiskStatistics = Helper.toCell<GenericRiskStatistics> genericriskstatistics "GenericRiskStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((GenericRiskStatisticsModel.Cast _GenericRiskStatistics.cell).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GenericRiskStatistics.source + ".WeightSum") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GenericRiskStatistics.cell
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
    [<ExcelFunction(Name="_GenericRiskStatistics_Range", Description="Create a range of GenericRiskStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericRiskStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GenericRiskStatistics> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GenericRiskStatistics>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GenericRiskStatistics>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GenericRiskStatistics>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
