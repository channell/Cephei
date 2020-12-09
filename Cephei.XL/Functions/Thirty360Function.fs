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
  The 30/360 day count can be calculated according to US, European, or Italian conventions. US (NASD) convention: if the starting date is the 31st of a  month, it becomes equal to the 30th of the same month.  If the ending date is the 31st of a month and the starting date is earlier than the 30th of a month, the ending date  becomes equal to the 1st of the next month, otherwise the ending date becomes equal to the 30th of the same month. Also known as "30/360", "360/360", or "Bond Basis"  European convention: starting dates or ending dates that occur on the 31st of a month become equal to the 30th of the same month. Also known as "30E/360", or "Eurobond Basis"  Italian convention: starting dates or ending dates that occur on February and are grater than 27 become equal to 30 for computational sake.
  </summary> *)
[<AutoSerializable(true)>]
module Thirty360Function =

    (*
        
    *)
    [<ExcelFunction(Name="_Thirty3601", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Thirty3601 () 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Thirty360>) l

                let source () = Helper.sourceFold "Fun.Thirty3601" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Thirty360> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Thirty360", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c",Description = "Thirty360.Thirty360Convention: USA, BondBasis, European, EurobondBasis, Italian")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c = Helper.toCell<Thirty360.Thirty360Convention> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Thirty360
                                                            _c.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Thirty360>) l

                let source () = Helper.sourceFold "Fun.Thirty360" 
                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Thirty360> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Thirty360_dayCount", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_dayCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thirty360",Description = "Thirty360")>] 
         thirty360 : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thirty360 = Helper.toCell<Thirty360> thirty360 "Thirty360"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder (current : ICell) = withMnemonic mnemonic ((Thirty360Model.Cast _Thirty360.cell).DayCount
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Thirty360.source + ".DayCount") 

                                               [| _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thirty360.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
    [<ExcelFunction(Name="_Thirty360_dayCounter", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thirty360",Description = "Thirty360")>] 
         thirty360 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thirty360 = Helper.toCell<Thirty360> thirty360 "Thirty360"  
                let builder (current : ICell) = withMnemonic mnemonic ((Thirty360Model.Cast _Thirty360.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_Thirty360.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Thirty360.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Thirty360> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Thirty360_empty", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thirty360",Description = "Thirty360")>] 
         thirty360 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thirty360 = Helper.toCell<Thirty360> thirty360 "Thirty360"  
                let builder (current : ICell) = withMnemonic mnemonic ((Thirty360Model.Cast _Thirty360.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thirty360.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Thirty360.cell
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
    [<ExcelFunction(Name="_Thirty360_Equals", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thirty360",Description = "Thirty360")>] 
         thirty360 : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thirty360 = Helper.toCell<Thirty360> thirty360 "Thirty360"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((Thirty360Model.Cast _Thirty360.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thirty360.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thirty360.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_Thirty360_name", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thirty360",Description = "Thirty360")>] 
         thirty360 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thirty360 = Helper.toCell<Thirty360> thirty360 "Thirty360"  
                let builder (current : ICell) = withMnemonic mnemonic ((Thirty360Model.Cast _Thirty360.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thirty360.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Thirty360.cell
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
    [<ExcelFunction(Name="_Thirty360_ToString", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thirty360",Description = "Thirty360")>] 
         thirty360 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thirty360 = Helper.toCell<Thirty360> thirty360 "Thirty360"  
                let builder (current : ICell) = withMnemonic mnemonic ((Thirty360Model.Cast _Thirty360.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thirty360.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Thirty360.cell
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
    [<ExcelFunction(Name="_Thirty360_yearFraction", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_yearFraction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thirty360",Description = "Thirty360")>] 
         thirty360 : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Date")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Date")>] 
         refPeriodEnd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thirty360 = Helper.toCell<Thirty360> thirty360 "Thirty360"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" 
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" 
                let builder (current : ICell) = withMnemonic mnemonic ((Thirty360Model.Cast _Thirty360.cell).YearFraction
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Thirty360.source + ".YearFraction") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thirty360.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
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
    [<ExcelFunction(Name="_Thirty360_yearFraction1", Description="Create a Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_yearFraction1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thirty360",Description = "Thirty360")>] 
         thirty360 : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thirty360 = Helper.toCell<Thirty360> thirty360 "Thirty360"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let builder (current : ICell) = withMnemonic mnemonic ((Thirty360Model.Cast _Thirty360.cell).YearFraction1
                                                            _d1.cell 
                                                            _d2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Thirty360.source + ".YearFraction1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thirty360.cell
                                ;  _d1.cell
                                ;  _d2.cell
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
    [<ExcelFunction(Name="_Thirty360_Range", Description="Create a range of Thirty360",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thirty360_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Thirty360> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Thirty360> (c)) :> ICell
                let format (i : Generic.List<ICell<Thirty360>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Thirty360>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
