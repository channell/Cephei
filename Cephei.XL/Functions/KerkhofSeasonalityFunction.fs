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

  </summary> *)
[<AutoSerializable(true)>]
module KerkhofSeasonalityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_KerkhofSeasonality", Description="Create a KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_create
        ([<ExcelArgument(Name="Mnemonic",Description = "KerkhofSeasonality")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="seasonalityBaseDate",Description = "Date")>] 
         seasonalityBaseDate : obj)
        ([<ExcelArgument(Name="seasonalityFactors",Description = "double")>] 
         seasonalityFactors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _seasonalityBaseDate = Helper.toCell<Date> seasonalityBaseDate "seasonalityBaseDate" 
                let _seasonalityFactors = Helper.toCell<Generic.List<double>> seasonalityFactors "seasonalityFactors" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.KerkhofSeasonality 
                                                            _seasonalityBaseDate.cell 
                                                            _seasonalityFactors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<KerkhofSeasonality>) l

                let source () = Helper.sourceFold "Fun.KerkhofSeasonality" 
                                               [| _seasonalityBaseDate.source
                                               ;  _seasonalityFactors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _seasonalityBaseDate.cell
                                ;  _seasonalityFactors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<KerkhofSeasonality> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_KerkhofSeasonality_seasonalityFactor", Description="Create a KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_seasonalityFactor
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KerkhofSeasonality",Description = "KerkhofSeasonality")>] 
         kerkhofseasonality : obj)
        ([<ExcelArgument(Name="To",Description = "Date")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KerkhofSeasonality = Helper.toCell<KerkhofSeasonality> kerkhofseasonality "KerkhofSeasonality"  
                let _To = Helper.toCell<Date> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((KerkhofSeasonalityModel.Cast _KerkhofSeasonality.cell).SeasonalityFactor
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KerkhofSeasonality.source + ".SeasonalityFactor") 
                                               [| _KerkhofSeasonality.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KerkhofSeasonality.cell
                                ;  _To.cell
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
    [<ExcelFunction(Name="_KerkhofSeasonality_correctYoYRate", Description="Create a KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_correctYoYRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KerkhofSeasonality",Description = "KerkhofSeasonality")>] 
         kerkhofseasonality : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="r",Description = "double")>] 
         r : obj)
        ([<ExcelArgument(Name="iTS",Description = "InflationTermStructure")>] 
         iTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KerkhofSeasonality = Helper.toCell<KerkhofSeasonality> kerkhofseasonality "KerkhofSeasonality"  
                let _d = Helper.toCell<Date> d "d" 
                let _r = Helper.toCell<double> r "r" 
                let _iTS = Helper.toCell<InflationTermStructure> iTS "iTS" 
                let builder (current : ICell) = withMnemonic mnemonic ((KerkhofSeasonalityModel.Cast _KerkhofSeasonality.cell).CorrectYoYRate
                                                            _d.cell 
                                                            _r.cell 
                                                            _iTS.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KerkhofSeasonality.source + ".CorrectYoYRate") 
                                               [| _KerkhofSeasonality.source
                                               ;  _d.source
                                               ;  _r.source
                                               ;  _iTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KerkhofSeasonality.cell
                                ;  _d.cell
                                ;  _r.cell
                                ;  _iTS.cell
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
        Seasonality interface
    *)
    [<ExcelFunction(Name="_KerkhofSeasonality_correctZeroRate", Description="Create a KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_correctZeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KerkhofSeasonality",Description = "KerkhofSeasonality")>] 
         kerkhofseasonality : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="r",Description = "double")>] 
         r : obj)
        ([<ExcelArgument(Name="iTS",Description = "InflationTermStructure")>] 
         iTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KerkhofSeasonality = Helper.toCell<KerkhofSeasonality> kerkhofseasonality "KerkhofSeasonality"  
                let _d = Helper.toCell<Date> d "d" 
                let _r = Helper.toCell<double> r "r" 
                let _iTS = Helper.toCell<InflationTermStructure> iTS "iTS" 
                let builder (current : ICell) = withMnemonic mnemonic ((KerkhofSeasonalityModel.Cast _KerkhofSeasonality.cell).CorrectZeroRate
                                                            _d.cell 
                                                            _r.cell 
                                                            _iTS.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_KerkhofSeasonality.source + ".CorrectZeroRate") 
                                               [| _KerkhofSeasonality.source
                                               ;  _d.source
                                               ;  _r.source
                                               ;  _iTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KerkhofSeasonality.cell
                                ;  _d.cell
                                ;  _r.cell
                                ;  _iTS.cell
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
    [<ExcelFunction(Name="_KerkhofSeasonality_frequency", Description="Create a KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KerkhofSeasonality",Description = "KerkhofSeasonality")>] 
         kerkhofseasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KerkhofSeasonality = Helper.toCell<KerkhofSeasonality> kerkhofseasonality "KerkhofSeasonality"  
                let builder (current : ICell) = withMnemonic mnemonic ((KerkhofSeasonalityModel.Cast _KerkhofSeasonality.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KerkhofSeasonality.source + ".Frequency") 
                                               [| _KerkhofSeasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KerkhofSeasonality.cell
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
    [<ExcelFunction(Name="_KerkhofSeasonality_isConsistent", Description="Create a KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_isConsistent
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KerkhofSeasonality",Description = "KerkhofSeasonality")>] 
         kerkhofseasonality : obj)
        ([<ExcelArgument(Name="iTS",Description = "InflationTermStructure")>] 
         iTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KerkhofSeasonality = Helper.toCell<KerkhofSeasonality> kerkhofseasonality "KerkhofSeasonality"  
                let _iTS = Helper.toCell<InflationTermStructure> iTS "iTS" 
                let builder (current : ICell) = withMnemonic mnemonic ((KerkhofSeasonalityModel.Cast _KerkhofSeasonality.cell).IsConsistent
                                                            _iTS.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KerkhofSeasonality.source + ".IsConsistent") 
                                               [| _KerkhofSeasonality.source
                                               ;  _iTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KerkhofSeasonality.cell
                                ;  _iTS.cell
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
        ! inspectors
    *)
    [<ExcelFunction(Name="_KerkhofSeasonality_seasonalityBaseDate", Description="Create a KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_seasonalityBaseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KerkhofSeasonality",Description = "KerkhofSeasonality")>] 
         kerkhofseasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KerkhofSeasonality = Helper.toCell<KerkhofSeasonality> kerkhofseasonality "KerkhofSeasonality"  
                let builder (current : ICell) = withMnemonic mnemonic ((KerkhofSeasonalityModel.Cast _KerkhofSeasonality.cell).SeasonalityBaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_KerkhofSeasonality.source + ".SeasonalityBaseDate") 
                                               [| _KerkhofSeasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KerkhofSeasonality.cell
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
    [<ExcelFunction(Name="_KerkhofSeasonality_seasonalityFactors", Description="Create a KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_seasonalityFactors
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KerkhofSeasonality",Description = "KerkhofSeasonality")>] 
         kerkhofseasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KerkhofSeasonality = Helper.toCell<KerkhofSeasonality> kerkhofseasonality "KerkhofSeasonality"  
                let builder (current : ICell) = withMnemonic mnemonic ((KerkhofSeasonalityModel.Cast _KerkhofSeasonality.cell).SeasonalityFactors
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_KerkhofSeasonality.source + ".SeasonalityFactors") 
                                               [| _KerkhofSeasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KerkhofSeasonality.cell
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
    [<ExcelFunction(Name="_KerkhofSeasonality_set", Description="Create a KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_set
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="KerkhofSeasonality",Description = "KerkhofSeasonality")>] 
         kerkhofseasonality : obj)
        ([<ExcelArgument(Name="seasonalityBaseDate",Description = "Date")>] 
         seasonalityBaseDate : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="seasonalityFactors",Description = "double")>] 
         seasonalityFactors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _KerkhofSeasonality = Helper.toCell<KerkhofSeasonality> kerkhofseasonality "KerkhofSeasonality"  
                let _seasonalityBaseDate = Helper.toCell<Date> seasonalityBaseDate "seasonalityBaseDate" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _seasonalityFactors = Helper.toCell<Generic.List<double>> seasonalityFactors "seasonalityFactors" 
                let builder (current : ICell) = withMnemonic mnemonic ((KerkhofSeasonalityModel.Cast _KerkhofSeasonality.cell).Set
                                                            _seasonalityBaseDate.cell 
                                                            _frequency.cell 
                                                            _seasonalityFactors.cell 
                                                       ) :> ICell
                let format (o : KerkhofSeasonality) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_KerkhofSeasonality.source + ".Set") 
                                               [| _KerkhofSeasonality.source
                                               ;  _seasonalityBaseDate.source
                                               ;  _frequency.source
                                               ;  _seasonalityFactors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _KerkhofSeasonality.cell
                                ;  _seasonalityBaseDate.cell
                                ;  _frequency.cell
                                ;  _seasonalityFactors.cell
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
    [<ExcelFunction(Name="_KerkhofSeasonality_Range", Description="Create a range of KerkhofSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let KerkhofSeasonality_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<KerkhofSeasonality> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<KerkhofSeasonality>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<KerkhofSeasonality>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<KerkhofSeasonality>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
