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
shifted lognormal type engine
  </summary> *)
[<AutoSerializable(true)>]
module BachelierSpecFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BachelierSpec", Description="Create a BachelierSpec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierSpec_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.BachelierSpec ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BachelierSpec>) l

                let source = Helper.sourceFold "Fun.BachelierSpec" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierSpec> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierSpec_type", Description="Create a BachelierSpec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierSpec_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierSpec",Description = "Reference to BachelierSpec")>] 
         bachelierspec : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierSpec = Helper.toCell<BachelierSpec> bachelierspec "BachelierSpec"  
                let builder () = withMnemonic mnemonic ((BachelierSpecModel.Cast _BachelierSpec.cell).Type
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BachelierSpec.source + ".TYPE") 
                                               [| _BachelierSpec.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierSpec.cell
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
    [<ExcelFunction(Name="_BachelierSpec_value", Description="Create a BachelierSpec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierSpec_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierSpec",Description = "Reference to BachelierSpec")>] 
         bachelierspec : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="atmForward",Description = "Reference to atmForward")>] 
         atmForward : obj)
        ([<ExcelArgument(Name="stdDev",Description = "Reference to stdDev")>] 
         stdDev : obj)
        ([<ExcelArgument(Name="annuity",Description = "Reference to annuity")>] 
         annuity : obj)
        ([<ExcelArgument(Name="displacement",Description = "Reference to displacement")>] 
         displacement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierSpec = Helper.toCell<BachelierSpec> bachelierspec "BachelierSpec"  
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _atmForward = Helper.toCell<double> atmForward "atmForward" 
                let _stdDev = Helper.toCell<double> stdDev "stdDev" 
                let _annuity = Helper.toCell<double> annuity "annuity" 
                let _displacement = Helper.toDefault<double> displacement "displacement" 0.0
                let builder () = withMnemonic mnemonic ((BachelierSpecModel.Cast _BachelierSpec.cell).Value
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _atmForward.cell 
                                                            _stdDev.cell 
                                                            _annuity.cell 
                                                            _displacement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BachelierSpec.source + ".Value") 
                                               [| _BachelierSpec.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _atmForward.source
                                               ;  _stdDev.source
                                               ;  _annuity.source
                                               ;  _displacement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierSpec.cell
                                ;  _Type.cell
                                ;  _strike.cell
                                ;  _atmForward.cell
                                ;  _stdDev.cell
                                ;  _annuity.cell
                                ;  _displacement.cell
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
    [<ExcelFunction(Name="_BachelierSpec_vega", Description="Create a BachelierSpec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierSpec_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierSpec",Description = "Reference to BachelierSpec")>] 
         bachelierspec : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="atmForward",Description = "Reference to atmForward")>] 
         atmForward : obj)
        ([<ExcelArgument(Name="stdDev",Description = "Reference to stdDev")>] 
         stdDev : obj)
        ([<ExcelArgument(Name="exerciseTime",Description = "Reference to exerciseTime")>] 
         exerciseTime : obj)
        ([<ExcelArgument(Name="annuity",Description = "Reference to annuity")>] 
         annuity : obj)
        ([<ExcelArgument(Name="displacement",Description = "Reference to displacement")>] 
         displacement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierSpec = Helper.toCell<BachelierSpec> bachelierspec "BachelierSpec"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _atmForward = Helper.toCell<double> atmForward "atmForward" 
                let _stdDev = Helper.toCell<double> stdDev "stdDev" 
                let _exerciseTime = Helper.toCell<double> exerciseTime "exerciseTime" 
                let _annuity = Helper.toCell<double> annuity "annuity" 
                let _displacement = Helper.toDefault<double> displacement "displacement" 0.0
                let builder () = withMnemonic mnemonic ((BachelierSpecModel.Cast _BachelierSpec.cell).Vega
                                                            _strike.cell 
                                                            _atmForward.cell 
                                                            _stdDev.cell 
                                                            _exerciseTime.cell 
                                                            _annuity.cell 
                                                            _displacement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BachelierSpec.source + ".Vega") 
                                               [| _BachelierSpec.source
                                               ;  _strike.source
                                               ;  _atmForward.source
                                               ;  _stdDev.source
                                               ;  _exerciseTime.source
                                               ;  _annuity.source
                                               ;  _displacement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierSpec.cell
                                ;  _strike.cell
                                ;  _atmForward.cell
                                ;  _stdDev.cell
                                ;  _exerciseTime.cell
                                ;  _annuity.cell
                                ;  _displacement.cell
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
    [<ExcelFunction(Name="_BachelierSpec_Range", Description="Create a range of BachelierSpec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierSpec_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BachelierSpec")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BachelierSpec> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BachelierSpec>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BachelierSpec>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BachelierSpec>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
