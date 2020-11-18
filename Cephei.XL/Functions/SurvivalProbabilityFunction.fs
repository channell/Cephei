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
module SurvivalProbabilityFunction =

    (*
        upper bound for convergence loop
    *)
    [<ExcelFunction(Name="_SurvivalProbability_discountImpl", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".DiscountImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_SurvivalProbability_forwardImpl", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".ForwardImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_SurvivalProbability_guess", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "InterpolatedCurve")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "bool")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "int")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".Guess") 

                                               [| _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_SurvivalProbability_initialDate", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        ([<ExcelArgument(Name="c",Description = "DefaultProbabilityTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let _c = Helper.toCell<DefaultProbabilityTermStructure> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".InitialDate") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
                                ;  _c.cell
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
        start of curve data
    *)
    [<ExcelFunction(Name="_SurvivalProbability_initialValue", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        ([<ExcelArgument(Name="c",Description = "DefaultProbabilityTermStructure")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let _c = Helper.toCell<DefaultProbabilityTermStructure> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).InitialValue
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".InitialValue") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_SurvivalProbability_maxIterations", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".MaxIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
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
    [<ExcelFunction(Name="_SurvivalProbability_maxValueAfter", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "InterpolatedCurve")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "bool")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "int")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".MaxValueAfter") 

                                               [| _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_SurvivalProbability_minValueAfter", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "InterpolatedCurve")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "bool")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "int")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".MinValueAfter") 

                                               [| _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _f.cell
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
        value at reference date
    *)
    [<ExcelFunction(Name="_SurvivalProbability_updateGuess", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        ([<ExcelArgument(Name="data",Description = "double range")>] 
         data : obj)
        ([<ExcelArgument(Name="discount",Description = "double")>] 
         discount : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _discount = Helper.toCell<double> discount "discount" 
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).UpdateGuess
                                                            _data.cell 
                                                            _discount.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : SurvivalProbability) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".UpdateGuess") 

                                               [| _data.source
                                               ;  _discount.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
                                ;  _data.cell
                                ;  _discount.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_SurvivalProbability_zeroYieldImpl", Description="Create a SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SurvivalProbability",Description = "SurvivalProbability")>] 
         survivalprobability : obj)
        ([<ExcelArgument(Name="i",Description = "Interpolation")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SurvivalProbability = Helper.toCell<SurvivalProbability> survivalprobability "SurvivalProbability"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((SurvivalProbabilityModel.Cast _SurvivalProbability.cell).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SurvivalProbability.source + ".ZeroYieldImpl") 

                                               [| _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SurvivalProbability.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_SurvivalProbability_Range", Description="Create a range of SurvivalProbability",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SurvivalProbability_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SurvivalProbability> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<SurvivalProbability> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<SurvivalProbability>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SurvivalProbability>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
