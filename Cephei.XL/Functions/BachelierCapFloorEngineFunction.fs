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
module BachelierCapFloorEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BachelierCapFloorEngine1", Description="Create a BachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierCapFloorEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "Quote")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BachelierCapFloorEngine1 
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BachelierCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.BachelierCapFloorEngine1" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierCapFloorEngine2", Description="Create a BachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierCapFloorEngine_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "double")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter or empty")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toCell<double> vol "vol" 
                let _dc = Helper.toDefault<DayCounter> dc "dc" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BachelierCapFloorEngine2
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BachelierCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.BachelierCapFloorEngine12" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierCapFloorEngine", Description="Create a BachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierCapFloorEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="vol",Description = "OptionletVolatilityStructure")>] 
         vol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _vol = Helper.toHandle<OptionletVolatilityStructure> vol "vol" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BachelierCapFloorEngine
                                                            _discountCurve.cell 
                                                            _vol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BachelierCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.BachelierCapFloorEngine2" 
                                               [| _discountCurve.source
                                               ;  _vol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _discountCurve.cell
                                ;  _vol.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierCapFloorEngine_termStructure", Description="Create a BachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierCapFloorEngine_termStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierCapFloorEngine",Description = "BachelierCapFloorEngine")>] 
         bacheliercapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierCapFloorEngine = Helper.toCell<BachelierCapFloorEngine> bacheliercapfloorengine "BachelierCapFloorEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierCapFloorEngineModel.Cast _BachelierCapFloorEngine.cell).TermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BachelierCapFloorEngine.source + ".TermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BachelierCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierCapFloorEngine_volatility", Description="Create a BachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierCapFloorEngine_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierCapFloorEngine",Description = "BachelierCapFloorEngine")>] 
         bacheliercapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierCapFloorEngine = Helper.toCell<BachelierCapFloorEngine> bacheliercapfloorengine "BachelierCapFloorEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierCapFloorEngineModel.Cast _BachelierCapFloorEngine.cell).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<OptionletVolatilityStructure>>) l

                let source () = Helper.sourceFold (_BachelierCapFloorEngine.source + ".Volatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BachelierCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BachelierCapFloorEngine_Range", Description="Create a range of BachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierCapFloorEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BachelierCapFloorEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BachelierCapFloorEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BachelierCapFloorEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BachelierCapFloorEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
