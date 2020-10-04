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
module CompositeZeroYieldStructureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CompositeZeroYieldStructure_calendar", Description="Create a CompositeZeroYieldStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeZeroYieldStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeZeroYieldStructure",Description = "Reference to CompositeZeroYieldStructure")>] 
         compositezeroyieldstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeZeroYieldStructure = Helper.toCell<CompositeZeroYieldStructure> compositezeroyieldstructure "CompositeZeroYieldStructure"  
                let builder () = withMnemonic mnemonic ((CompositeZeroYieldStructureModel.Cast _CompositeZeroYieldStructure.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CompositeZeroYieldStructure.source + ".Calendar") 
                                               [| _CompositeZeroYieldStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeZeroYieldStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CompositeZeroYieldStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CompositeZeroYieldStructure", Description="Create a CompositeZeroYieldStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeZeroYieldStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h1",Description = "Reference to h1")>] 
         h1 : obj)
        ([<ExcelArgument(Name="h2",Description = "Reference to h2")>] 
         h2 : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h1 = Helper.toHandle<YieldTermStructure> h1 "h1" 
                let _h2 = Helper.toHandle<YieldTermStructure> h2 "h2" 
                let _f = Helper.toCell<Func<double,double,double>> f "f" 
                let _comp = Helper.toDefault<Compounding> comp "comp" Compounding.Continuous
                let _freq = Helper.toDefault<Frequency> freq "freq" Frequency.NoFrequency
                let builder () = withMnemonic mnemonic (Fun.CompositeZeroYieldStructure 
                                                            _h1.cell 
                                                            _h2.cell 
                                                            _f.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CompositeZeroYieldStructure>) l

                let source = Helper.sourceFold "Fun.CompositeZeroYieldStructure" 
                                               [| _h1.source
                                               ;  _h2.source
                                               ;  _f.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h1.cell
                                ;  _h2.cell
                                ;  _f.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CompositeZeroYieldStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CompositeZeroYieldStructure_dayCounter", Description="Create a CompositeZeroYieldStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeZeroYieldStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeZeroYieldStructure",Description = "Reference to CompositeZeroYieldStructure")>] 
         compositezeroyieldstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeZeroYieldStructure = Helper.toCell<CompositeZeroYieldStructure> compositezeroyieldstructure "CompositeZeroYieldStructure"  
                let builder () = withMnemonic mnemonic ((CompositeZeroYieldStructureModel.Cast _CompositeZeroYieldStructure.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CompositeZeroYieldStructure.source + ".DayCounter") 
                                               [| _CompositeZeroYieldStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeZeroYieldStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CompositeZeroYieldStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CompositeZeroYieldStructure_maxDate", Description="Create a CompositeZeroYieldStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeZeroYieldStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeZeroYieldStructure",Description = "Reference to CompositeZeroYieldStructure")>] 
         compositezeroyieldstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeZeroYieldStructure = Helper.toCell<CompositeZeroYieldStructure> compositezeroyieldstructure "CompositeZeroYieldStructure"  
                let builder () = withMnemonic mnemonic ((CompositeZeroYieldStructureModel.Cast _CompositeZeroYieldStructure.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CompositeZeroYieldStructure.source + ".MaxDate") 
                                               [| _CompositeZeroYieldStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeZeroYieldStructure.cell
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
    [<ExcelFunction(Name="_CompositeZeroYieldStructure_maxTime", Description="Create a CompositeZeroYieldStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeZeroYieldStructure_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeZeroYieldStructure",Description = "Reference to CompositeZeroYieldStructure")>] 
         compositezeroyieldstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeZeroYieldStructure = Helper.toCell<CompositeZeroYieldStructure> compositezeroyieldstructure "CompositeZeroYieldStructure"  
                let builder () = withMnemonic mnemonic ((CompositeZeroYieldStructureModel.Cast _CompositeZeroYieldStructure.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CompositeZeroYieldStructure.source + ".MaxTime") 
                                               [| _CompositeZeroYieldStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeZeroYieldStructure.cell
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
    [<ExcelFunction(Name="_CompositeZeroYieldStructure_referenceDate", Description="Create a CompositeZeroYieldStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeZeroYieldStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeZeroYieldStructure",Description = "Reference to CompositeZeroYieldStructure")>] 
         compositezeroyieldstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeZeroYieldStructure = Helper.toCell<CompositeZeroYieldStructure> compositezeroyieldstructure "CompositeZeroYieldStructure"  
                let builder () = withMnemonic mnemonic ((CompositeZeroYieldStructureModel.Cast _CompositeZeroYieldStructure.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CompositeZeroYieldStructure.source + ".ReferenceDate") 
                                               [| _CompositeZeroYieldStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeZeroYieldStructure.cell
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
    [<ExcelFunction(Name="_CompositeZeroYieldStructure_settlementDays", Description="Create a CompositeZeroYieldStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeZeroYieldStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeZeroYieldStructure",Description = "Reference to CompositeZeroYieldStructure")>] 
         compositezeroyieldstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeZeroYieldStructure = Helper.toCell<CompositeZeroYieldStructure> compositezeroyieldstructure "CompositeZeroYieldStructure"  
                let builder () = withMnemonic mnemonic ((CompositeZeroYieldStructureModel.Cast _CompositeZeroYieldStructure.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CompositeZeroYieldStructure.source + ".SettlementDays") 
                                               [| _CompositeZeroYieldStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeZeroYieldStructure.cell
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
    [<ExcelFunction(Name="_CompositeZeroYieldStructure_update", Description="Create a CompositeZeroYieldStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeZeroYieldStructure_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeZeroYieldStructure",Description = "Reference to CompositeZeroYieldStructure")>] 
         compositezeroyieldstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeZeroYieldStructure = Helper.toCell<CompositeZeroYieldStructure> compositezeroyieldstructure "CompositeZeroYieldStructure"  
                let builder () = withMnemonic mnemonic ((CompositeZeroYieldStructureModel.Cast _CompositeZeroYieldStructure.cell).Update
                                                       ) :> ICell
                let format (o : CompositeZeroYieldStructure) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CompositeZeroYieldStructure.source + ".Update") 
                                               [| _CompositeZeroYieldStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeZeroYieldStructure.cell
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
    [<ExcelFunction(Name="_CompositeZeroYieldStructure_Range", Description="Create a range of CompositeZeroYieldStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CompositeZeroYieldStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CompositeZeroYieldStructure")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CompositeZeroYieldStructure> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CompositeZeroYieldStructure>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CompositeZeroYieldStructure>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CompositeZeroYieldStructure>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
