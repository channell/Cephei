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
  This is an abstract class and contains the functions correctXXXRate which returns rates with the seasonality correction.  Currently only the price multiplicative version is implemented, but this covers stationary (1-year) and non-stationary (multi-year) seasonality depending on how many years of factors are given.  Seasonality is piecewise constant, hence it will work with un-interpolated inflation indices.  A seasonality assumption can be used to fill in inflation swap curves between maturities that are usually given in integer numbers of years, e.g. 8,9,10,15,20, etc.  Historical seasonality may be observed in reported CPI values, alternatively it may be affected by known future events, e.g. announced changes in VAT rates.  Thus seasonality may be stationary or non-stationary.  If seasonality is additive then both swap rates will show affects.  Additive seasonality is not implemented.
  </summary> *)
[<AutoSerializable(true)>]
module SeasonalityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Seasonality_correctYoYRate", Description="Create a Seasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Seasonality_correctYoYRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Seasonality",Description = "Seasonality")>] 
         seasonality : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="r",Description = "double")>] 
         r : obj)
        ([<ExcelArgument(Name="iTS",Description = "InflationTermStructure")>] 
         iTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Seasonality = Helper.toCell<Seasonality> seasonality "Seasonality"  
                let _d = Helper.toCell<Date> d "d" 
                let _r = Helper.toCell<double> r "r" 
                let _iTS = Helper.toCell<InflationTermStructure> iTS "iTS" 
                let builder (current : ICell) = ((SeasonalityModel.Cast _Seasonality.cell).CorrectYoYRate
                                                            _d.cell 
                                                            _r.cell 
                                                            _iTS.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Seasonality.source + ".CorrectYoYRate") 

                                               [| _d.source
                                               ;  _r.source
                                               ;  _iTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Seasonality.cell
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
    [<ExcelFunction(Name="_Seasonality_correctZeroRate", Description="Create a Seasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Seasonality_correctZeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Seasonality",Description = "Seasonality")>] 
         seasonality : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="r",Description = "double")>] 
         r : obj)
        ([<ExcelArgument(Name="iTS",Description = "InflationTermStructure")>] 
         iTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Seasonality = Helper.toCell<Seasonality> seasonality "Seasonality"  
                let _d = Helper.toCell<Date> d "d" 
                let _r = Helper.toCell<double> r "r" 
                let _iTS = Helper.toCell<InflationTermStructure> iTS "iTS" 
                let builder (current : ICell) = ((SeasonalityModel.Cast _Seasonality.cell).CorrectZeroRate
                                                            _d.cell 
                                                            _r.cell 
                                                            _iTS.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Seasonality.source + ".CorrectZeroRate") 

                                               [| _d.source
                                               ;  _r.source
                                               ;  _iTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Seasonality.cell
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
        ! It is possible for multi-year seasonalities to be inconsistent with the inflation term structure they are given to.  This method enables testing - but programmers are not required to implement it.  E.g. for price seasonality the corrections at whole years after the inflation curve base date should be the same or else there can be an inconsistency with quoted instruments. Alternatively, the seasonality can be set _before_ the inflation curve is bootstrapped.
    *)
    [<ExcelFunction(Name="_Seasonality_isConsistent", Description="Create a Seasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Seasonality_isConsistent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Seasonality",Description = "Seasonality")>] 
         seasonality : obj)
        ([<ExcelArgument(Name="iTS",Description = "InflationTermStructure")>] 
         iTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Seasonality = Helper.toCell<Seasonality> seasonality "Seasonality"  
                let _iTS = Helper.toCell<InflationTermStructure> iTS "iTS" 
                let builder (current : ICell) = ((SeasonalityModel.Cast _Seasonality.cell).IsConsistent
                                                            _iTS.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Seasonality.source + ".IsConsistent") 

                                               [| _iTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Seasonality.cell
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
    [<ExcelFunction(Name="_Seasonality_Range", Description="Create a range of Seasonality",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Seasonality_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Seasonality> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Seasonality> (c)) :> ICell
                let format (i : Cephei.Cell.List<Seasonality>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Seasonality>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
