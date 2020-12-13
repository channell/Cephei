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
    [<ExcelFunction(Name="_SequenceStatistics", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimension",Description = "int")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimension = Helper.toCell<int> dimension "dimension" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SequenceStatistics 
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SequenceStatistics>) l

                let source () = Helper.sourceFold "Fun.SequenceStatistics" 
                                               [| _dimension.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimension.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SequenceStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! duplicate add
    [<ExcelFunction(Name="_SequenceStatistics_add", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "double range")>] 
         Begin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Add
                                                            _Begin.cell 
                                                       ) :> ICell
                let format (o : SequenceStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Add") 

                                               [| _Begin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _Begin.cell
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
    (*!! duplicate Add functions
    [<ExcelFunction(Name="_SequenceStatistics_add", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="Begin",Description = "double range")>] 
         Begin : obj)
        ([<ExcelArgument(Name="weight",Description = "double")>] 
         weight : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" 
                let _weight = Helper.toCell<double> weight "weight" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Add1
                                                            _Begin.cell 
                                                            _weight.cell 
                                                       ) :> ICell
                let format (o : SequenceStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Add") 

                                               [| _Begin.source
                                               ;  _weight.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _Begin.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_averageShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_averageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).AverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".AverageShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        ! returns the correlation Matrix
    *)
    [<ExcelFunction(Name="_SequenceStatistics_correlation", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Correlation
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Correlation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SequenceStatistics> format
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
    [<ExcelFunction(Name="_SequenceStatistics_covariance", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Covariance
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Covariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SequenceStatistics> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_downsideDeviation", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_downsideDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).DownsideDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".DownsideDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_downsideVariance", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_downsideVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).DownsideVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".DownsideVariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_errorEstimate", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).ErrorEstimate
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_expectedShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_expectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).ExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".ExpectedShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_gaussianAverageShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianAverageShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).GaussianAverageShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".GaussianAverageShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_gaussianExpectedShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianExpectedShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).GaussianExpectedShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".GaussianExpectedShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        single argument list
    *)
    [<ExcelFunction(Name="_SequenceStatistics_gaussianPercentile", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianPercentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).GaussianPercentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".GaussianPercentile") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_gaussianPotentialUpside", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianPotentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).GaussianPotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".GaussianPotentialUpside") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_gaussianShortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianShortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).GaussianShortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".GaussianShortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_gaussianValueAtRisk", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_gaussianValueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).GaussianValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".GaussianValueAtRisk") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_kurtosis", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_kurtosis
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Kurtosis
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Kurtosis") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_max", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_max
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Max
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Max") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        void argument list
    *)
    [<ExcelFunction(Name="_SequenceStatistics_mean", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_mean
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Mean
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Mean") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_min", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_min
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Min
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Min") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_percentile", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_percentile
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Percentile
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Percentile") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_potentialUpside", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_potentialUpside
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).PotentialUpside
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".PotentialUpside") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_regret", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_regret
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Regret
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Regret") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        Modifiers
    *)
    [<ExcelFunction(Name="_SequenceStatistics_reset", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="dimension",Description = "int")>] 
         dimension : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _dimension = Helper.toCell<int> dimension "dimension" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Reset
                                                            _dimension.cell 
                                                       ) :> ICell
                let format (o : SequenceStatistics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Reset") 

                                               [| _dimension.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _dimension.cell
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
        1-D inspectors lifted from underlying statistics class
    *)
    [<ExcelFunction(Name="_SequenceStatistics_samples", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_samples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Samples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Samples") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_semiDeviation", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_semiDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).SemiDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".SemiDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_semiVariance", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_semiVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).SemiVariance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".SemiVariance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_shortfall", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_shortfall
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Shortfall
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Shortfall") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_size", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_skewness", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_skewness
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Skewness
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Skewness") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_standardDeviation", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_standardDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).StandardDeviation
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".StandardDeviation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_valueAtRisk", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_valueAtRisk
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).ValueAtRisk
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".ValueAtRisk") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_variance", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).Variance
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".Variance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
        
    *)
    [<ExcelFunction(Name="_SequenceStatistics_weightSum", Description="Create a SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_weightSum
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SequenceStatistics",Description = "SequenceStatistics")>] 
         sequencestatistics : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SequenceStatistics = Helper.toCell<SequenceStatistics> sequencestatistics "SequenceStatistics"  
                let builder (current : ICell) = withMnemonic mnemonic ((SequenceStatisticsModel.Cast _SequenceStatistics.cell).WeightSum
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SequenceStatistics.source + ".WeightSum") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SequenceStatistics.cell
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
    [<ExcelFunction(Name="_SequenceStatistics_Range", Description="Create a range of SequenceStatistics",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SequenceStatistics_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SequenceStatistics> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SequenceStatistics> (c)) :> ICell
                let format (i : Cephei.Cell.List<SequenceStatistics>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SequenceStatistics>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
