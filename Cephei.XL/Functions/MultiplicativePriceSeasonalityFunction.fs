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
  Stationary multiplicative seasonality in CPI/RPI/HICP (i.e. in price) implies that zero inflation swap rates are affected, but that year-on-year inflation swap rates show no effect.  Of course, if the seasonality in CPI/RPI/HICP is non-stationary then both swap rates will be affected.  Factors must be in multiples of the minimum required for one year, e.g. 12 for monthly, and these factors are reused for as long as is required, i.e. they wrap around.  So, for example, if 24 factors are given this repeats every two years.  True stationary seasonality can be obtained by giving the same number of factors as the frequency dictates e.g. 12 for monthly seasonality.  Multi-year seasonality (i.e. non-stationary) is fragile: the user <b>must</b> ensure that corrections at whole years before and after the inflation term structure base date are the same.  Otherwise there can be an inconsistency with quoted rates.  This is enforced if the frequency is lower than daily.  This is not enforced for daily seasonality because this will always be inconsistent due to weekends, holidays, leap years, etc.  If you use multi-year daily seasonality it is up to you to check.  Factors are normalized relative to their appropriate reference dates.  For zero inflation this is the inflation curve true base date: since you have a fixing for that date the seasonality factor must be one.  For YoY inflation the reference is always one year earlier.  Seasonality is treated as piecewise constant, hence it works correctly with uninterpolated indices if the seasonality correction factor frequency is the same as the index frequency (or less).
  </summary> *)
[<AutoSerializable(true)>]
module MultiplicativePriceSeasonalityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality_correctYoYRate", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_correctYoYRate
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiplicativePriceSeasonality")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiplicativePriceSeasonality",Description = "MultiplicativePriceSeasonality")>] 
         multiplicativepriceseasonality : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="r",Description = "double")>] 
         r : obj)
        ([<ExcelArgument(Name="iTS",Description = "InflationTermStructure")>] 
         iTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiplicativePriceSeasonality = Helper.toCell<MultiplicativePriceSeasonality> multiplicativepriceseasonality "MultiplicativePriceSeasonality"  
                let _d = Helper.toCell<Date> d "d" 
                let _r = Helper.toCell<double> r "r" 
                let _iTS = Helper.toCell<InflationTermStructure> iTS "iTS" 
                let builder (current : ICell) = withMnemonic mnemonic ((MultiplicativePriceSeasonalityModel.Cast _MultiplicativePriceSeasonality.cell).CorrectYoYRate
                                                            _d.cell 
                                                            _r.cell 
                                                            _iTS.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiplicativePriceSeasonality.source + ".CorrectYoYRate") 

                                               [| _d.source
                                               ;  _r.source
                                               ;  _iTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiplicativePriceSeasonality.cell
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
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality_correctZeroRate", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_correctZeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiplicativePriceSeasonality")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiplicativePriceSeasonality",Description = "MultiplicativePriceSeasonality")>] 
         multiplicativepriceseasonality : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="r",Description = "double")>] 
         r : obj)
        ([<ExcelArgument(Name="iTS",Description = "InflationTermStructure")>] 
         iTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiplicativePriceSeasonality = Helper.toCell<MultiplicativePriceSeasonality> multiplicativepriceseasonality "MultiplicativePriceSeasonality"  
                let _d = Helper.toCell<Date> d "d" 
                let _r = Helper.toCell<double> r "r" 
                let _iTS = Helper.toCell<InflationTermStructure> iTS "iTS" 
                let builder (current : ICell) = withMnemonic mnemonic ((MultiplicativePriceSeasonalityModel.Cast _MultiplicativePriceSeasonality.cell).CorrectZeroRate
                                                            _d.cell 
                                                            _r.cell 
                                                            _iTS.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiplicativePriceSeasonality.source + ".CorrectZeroRate") 

                                               [| _d.source
                                               ;  _r.source
                                               ;  _iTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiplicativePriceSeasonality.cell
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
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality_frequency", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiplicativePriceSeasonality")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiplicativePriceSeasonality",Description = "MultiplicativePriceSeasonality")>] 
         multiplicativepriceseasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiplicativePriceSeasonality = Helper.toCell<MultiplicativePriceSeasonality> multiplicativepriceseasonality "MultiplicativePriceSeasonality"  
                let builder (current : ICell) = withMnemonic mnemonic ((MultiplicativePriceSeasonalityModel.Cast _MultiplicativePriceSeasonality.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MultiplicativePriceSeasonality.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiplicativePriceSeasonality.cell
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
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality_isConsistent", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_isConsistent
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiplicativePriceSeasonality")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiplicativePriceSeasonality",Description = "MultiplicativePriceSeasonality")>] 
         multiplicativepriceseasonality : obj)
        ([<ExcelArgument(Name="iTS",Description = "InflationTermStructure")>] 
         iTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiplicativePriceSeasonality = Helper.toCell<MultiplicativePriceSeasonality> multiplicativepriceseasonality "MultiplicativePriceSeasonality"  
                let _iTS = Helper.toCell<InflationTermStructure> iTS "iTS" 
                let builder (current : ICell) = withMnemonic mnemonic ((MultiplicativePriceSeasonalityModel.Cast _MultiplicativePriceSeasonality.cell).IsConsistent
                                                            _iTS.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MultiplicativePriceSeasonality.source + ".IsConsistent") 

                                               [| _iTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiplicativePriceSeasonality.cell
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
        Constructors
    *)
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality1", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiplicativePriceSeasonality")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.MultiplicativePriceSeasonality1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiplicativePriceSeasonality>) l

                let source () = Helper.sourceFold "Fun.MultiplicativePriceSeasonality1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiplicativePriceSeasonality> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_create
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiplicativePriceSeasonality")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="seasonalityBaseDate",Description = "Date")>] 
         seasonalityBaseDate : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="seasonalityFactors",Description = "double")>] 
         seasonalityFactors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _seasonalityBaseDate = Helper.toCell<Date> seasonalityBaseDate "seasonalityBaseDate" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _seasonalityFactors = Helper.toCell<Generic.List<double>> seasonalityFactors "seasonalityFactors" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MultiplicativePriceSeasonality
                                                            _seasonalityBaseDate.cell 
                                                            _frequency.cell 
                                                            _seasonalityFactors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiplicativePriceSeasonality>) l

                let source () = Helper.sourceFold "Fun.MultiplicativePriceSeasonality" 
                                               [| _seasonalityBaseDate.source
                                               ;  _frequency.source
                                               ;  _seasonalityFactors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _seasonalityBaseDate.cell
                                ;  _frequency.cell
                                ;  _seasonalityFactors.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiplicativePriceSeasonality> format
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
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality_seasonalityBaseDate", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_seasonalityBaseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiplicativePriceSeasonality",Description = "MultiplicativePriceSeasonality")>] 
         multiplicativepriceseasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiplicativePriceSeasonality = Helper.toCell<MultiplicativePriceSeasonality> multiplicativepriceseasonality "MultiplicativePriceSeasonality"  
                let builder (current : ICell) = withMnemonic mnemonic ((MultiplicativePriceSeasonalityModel.Cast _MultiplicativePriceSeasonality.cell).SeasonalityBaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_MultiplicativePriceSeasonality.source + ".SeasonalityBaseDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiplicativePriceSeasonality.cell
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
        ! The factor returned is NOT normalized relative to ANYTHING.
    *)
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality_seasonalityFactor", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_seasonalityFactor
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiplicativePriceSeasonality",Description = "MultiplicativePriceSeasonality")>] 
         multiplicativepriceseasonality : obj)
        ([<ExcelArgument(Name="To",Description = "Date")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiplicativePriceSeasonality = Helper.toCell<MultiplicativePriceSeasonality> multiplicativepriceseasonality "MultiplicativePriceSeasonality"  
                let _To = Helper.toCell<Date> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((MultiplicativePriceSeasonalityModel.Cast _MultiplicativePriceSeasonality.cell).SeasonalityFactor
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiplicativePriceSeasonality.source + ".SeasonalityFactor") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiplicativePriceSeasonality.cell
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
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality_seasonalityFactors", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_seasonalityFactors
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiplicativePriceSeasonality",Description = "MultiplicativePriceSeasonality")>] 
         multiplicativepriceseasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiplicativePriceSeasonality = Helper.toCell<MultiplicativePriceSeasonality> multiplicativepriceseasonality "MultiplicativePriceSeasonality"  
                let builder (current : ICell) = withMnemonic mnemonic ((MultiplicativePriceSeasonalityModel.Cast _MultiplicativePriceSeasonality.cell).SeasonalityFactors
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_MultiplicativePriceSeasonality.source + ".SeasonalityFactors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiplicativePriceSeasonality.cell
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
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality_set", Description="Create a MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_set
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiplicativePriceSeasonality",Description = "MultiplicativePriceSeasonality")>] 
         multiplicativepriceseasonality : obj)
        ([<ExcelArgument(Name="seasonalityBaseDate",Description = "Date")>] 
         seasonalityBaseDate : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="seasonalityFactors",Description = "double")>] 
         seasonalityFactors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiplicativePriceSeasonality = Helper.toCell<MultiplicativePriceSeasonality> multiplicativepriceseasonality "MultiplicativePriceSeasonality"  
                let _seasonalityBaseDate = Helper.toCell<Date> seasonalityBaseDate "seasonalityBaseDate" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _seasonalityFactors = Helper.toCell<Generic.List<double>> seasonalityFactors "seasonalityFactors" 
                let builder (current : ICell) = withMnemonic mnemonic ((MultiplicativePriceSeasonalityModel.Cast _MultiplicativePriceSeasonality.cell).Set
                                                            _seasonalityBaseDate.cell 
                                                            _frequency.cell 
                                                            _seasonalityFactors.cell 
                                                       ) :> ICell
                let format (o : MultiplicativePriceSeasonality) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MultiplicativePriceSeasonality.source + ".Set") 

                                               [| _seasonalityBaseDate.source
                                               ;  _frequency.source
                                               ;  _seasonalityFactors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiplicativePriceSeasonality.cell
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
    [<ExcelFunction(Name="_MultiplicativePriceSeasonality_Range", Description="Create a range of MultiplicativePriceSeasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiplicativePriceSeasonality_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MultiplicativePriceSeasonality> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MultiplicativePriceSeasonality>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<MultiplicativePriceSeasonality>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<MultiplicativePriceSeasonality>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
