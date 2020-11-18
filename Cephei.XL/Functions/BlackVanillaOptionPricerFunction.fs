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
===========================================================================// BlackVanillaOptionPricer                         // ===========================================================================
  </summary> *)
[<AutoSerializable(true)>]
module BlackVanillaOptionPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackVanillaOptionPricer", Description="Create a BlackVanillaOptionPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVanillaOptionPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="forwardValue",Description = "double")>] 
         forwardValue : obj)
        ([<ExcelArgument(Name="expiryDate",Description = "Date")>] 
         expiryDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Period")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="volatilityStructure",Description = "SwaptionVolatilityStructure")>] 
         volatilityStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _forwardValue = Helper.toCell<double> forwardValue "forwardValue" 
                let _expiryDate = Helper.toCell<Date> expiryDate "expiryDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _volatilityStructure = Helper.toCell<SwaptionVolatilityStructure> volatilityStructure "volatilityStructure" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackVanillaOptionPricer 
                                                            _forwardValue.cell 
                                                            _expiryDate.cell 
                                                            _swapTenor.cell 
                                                            _volatilityStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackVanillaOptionPricer>) l

                let source () = Helper.sourceFold "Fun.BlackVanillaOptionPricer" 
                                               [| _forwardValue.source
                                               ;  _expiryDate.source
                                               ;  _swapTenor.source
                                               ;  _volatilityStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _forwardValue.cell
                                ;  _expiryDate.cell
                                ;  _swapTenor.cell
                                ;  _volatilityStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackVanillaOptionPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackVanillaOptionPricer_value", Description="Create a BlackVanillaOptionPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVanillaOptionPricer_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVanillaOptionPricer",Description = "BlackVanillaOptionPricer")>] 
         blackvanillaoptionpricer : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="optionType",Description = "Option.Type: Put, Call")>] 
         optionType : obj)
        ([<ExcelArgument(Name="deflator",Description = "double")>] 
         deflator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVanillaOptionPricer = Helper.toCell<BlackVanillaOptionPricer> blackvanillaoptionpricer "BlackVanillaOptionPricer"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _optionType = Helper.toCell<Option.Type> optionType "optionType" 
                let _deflator = Helper.toCell<double> deflator "deflator" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackVanillaOptionPricerModel.Cast _BlackVanillaOptionPricer.cell).Value
                                                            _strike.cell 
                                                            _optionType.cell 
                                                            _deflator.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackVanillaOptionPricer.source + ".Value") 

                                               [| _strike.source
                                               ;  _optionType.source
                                               ;  _deflator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVanillaOptionPricer.cell
                                ;  _strike.cell
                                ;  _optionType.cell
                                ;  _deflator.cell
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
    [<ExcelFunction(Name="_BlackVanillaOptionPricer_Range", Description="Create a range of BlackVanillaOptionPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackVanillaOptionPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackVanillaOptionPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<BlackVanillaOptionPricer> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<BlackVanillaOptionPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BlackVanillaOptionPricer>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
