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
module Black76SpecFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Black76Spec", Description="Create a Black76Spec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Black76Spec_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Black76Spec ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Black76Spec>) l

                let source = Helper.sourceFold "Fun.Black76Spec" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Black76Spec_type", Description="Create a Black76Spec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Black76Spec_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Black76Spec",Description = "Reference to Black76Spec")>] 
         black76spec : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Black76Spec = Helper.toCell<Black76Spec> black76spec "Black76Spec" true 
                let builder () = withMnemonic mnemonic ((_Black76Spec.cell :?> Black76SpecModel).Type
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Black76Spec.source + ".TYPE") 
                                               [| _Black76Spec.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Black76Spec.cell
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
    [<ExcelFunction(Name="_Black76Spec_value", Description="Create a Black76Spec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Black76Spec_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Black76Spec",Description = "Reference to Black76Spec")>] 
         black76spec : obj)
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

                let _Black76Spec = Helper.toCell<Black76Spec> black76spec "Black76Spec" true 
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _atmForward = Helper.toCell<double> atmForward "atmForward" true
                let _stdDev = Helper.toCell<double> stdDev "stdDev" true
                let _annuity = Helper.toCell<double> annuity "annuity" true
                let _displacement = Helper.toCell<double> displacement "displacement" true
                let builder () = withMnemonic mnemonic ((_Black76Spec.cell :?> Black76SpecModel).Value
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _atmForward.cell 
                                                            _stdDev.cell 
                                                            _annuity.cell 
                                                            _displacement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Black76Spec.source + ".Value") 
                                               [| _Black76Spec.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _atmForward.source
                                               ;  _stdDev.source
                                               ;  _annuity.source
                                               ;  _displacement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Black76Spec.cell
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
    [<ExcelFunction(Name="_Black76Spec_vega", Description="Create a Black76Spec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Black76Spec_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Black76Spec",Description = "Reference to Black76Spec")>] 
         black76spec : obj)
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

                let _Black76Spec = Helper.toCell<Black76Spec> black76spec "Black76Spec" true 
                let _strike = Helper.toCell<double> strike "strike" true
                let _atmForward = Helper.toCell<double> atmForward "atmForward" true
                let _stdDev = Helper.toCell<double> stdDev "stdDev" true
                let _exerciseTime = Helper.toCell<double> exerciseTime "exerciseTime" true
                let _annuity = Helper.toCell<double> annuity "annuity" true
                let _displacement = Helper.toCell<double> displacement "displacement" true
                let builder () = withMnemonic mnemonic ((_Black76Spec.cell :?> Black76SpecModel).Vega
                                                            _strike.cell 
                                                            _atmForward.cell 
                                                            _stdDev.cell 
                                                            _exerciseTime.cell 
                                                            _annuity.cell 
                                                            _displacement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Black76Spec.source + ".Vega") 
                                               [| _Black76Spec.source
                                               ;  _strike.source
                                               ;  _atmForward.source
                                               ;  _stdDev.source
                                               ;  _exerciseTime.source
                                               ;  _annuity.source
                                               ;  _displacement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Black76Spec.cell
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
    [<ExcelFunction(Name="_Black76Spec_Range", Description="Create a range of Black76Spec",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Black76Spec_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Black76Spec")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Black76Spec> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Black76Spec>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Black76Spec>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Black76Spec>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
