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
  This class implements the BlackVolatilityTermStructure interface for a constant Black volatility (no time/strike dependence).
  </summary> *)
[<AutoSerializable(true)>]
module BlackConstantVolFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackConstantVol", Description="Create a BlackConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackConstantVol_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackConstantVol 
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackConstantVol>) l

                let source () = Helper.sourceFold "Fun.BlackConstantVol" 
                                               [| _settlementDays.source
                                               ;  _cal.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _cal.cell
                                ;  _volatility.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackConstantVol1", Description="Create a BlackConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackConstantVol_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="volatility",Description = "double")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _volatility = Helper.toCell<double> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackConstantVol1 
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackConstantVol>) l

                let source () = Helper.sourceFold "Fun.BlackConstantVol1" 
                                               [| _settlementDays.source
                                               ;  _cal.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _cal.cell
                                ;  _volatility.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackConstantVol2", Description="Create a BlackConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackConstantVol_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="volatility",Description = "Quote")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _volatility = Helper.toHandle<Quote> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackConstantVol2 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackConstantVol>) l

                let source () = Helper.sourceFold "Fun.BlackConstantVol2" 
                                               [| _referenceDate.source
                                               ;  _cal.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _cal.cell
                                ;  _volatility.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackConstantVol3", Description="Create a BlackConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackConstantVol_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Calendar")>] 
         cal : obj)
        ([<ExcelArgument(Name="volatility",Description = "double")>] 
         volatility : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _volatility = Helper.toCell<double> volatility "volatility" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackConstantVol3 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _volatility.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackConstantVol>) l

                let source () = Helper.sourceFold "Fun.BlackConstantVol3" 
                                               [| _referenceDate.source
                                               ;  _cal.source
                                               ;  _volatility.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _cal.cell
                                ;  _volatility.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackConstantVol> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackConstantVol_maxDate", Description="Create a BlackConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackConstantVol_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackConstantVol",Description = "BlackConstantVol")>] 
         blackconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackConstantVol = Helper.toCell<BlackConstantVol> blackconstantvol "BlackConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackConstantVolModel.Cast _BlackConstantVol.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BlackConstantVol.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackConstantVol.cell
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
    [<ExcelFunction(Name="_BlackConstantVol_maxStrike", Description="Create a BlackConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackConstantVol_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackConstantVol",Description = "BlackConstantVol")>] 
         blackconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackConstantVol = Helper.toCell<BlackConstantVol> blackconstantvol "BlackConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackConstantVolModel.Cast _BlackConstantVol.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackConstantVol.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackConstantVol.cell
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
    [<ExcelFunction(Name="_BlackConstantVol_minStrike", Description="Create a BlackConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackConstantVol_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackConstantVol",Description = "BlackConstantVol")>] 
         blackconstantvol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackConstantVol = Helper.toCell<BlackConstantVol> blackconstantvol "BlackConstantVol"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackConstantVolModel.Cast _BlackConstantVol.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackConstantVol.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackConstantVol.cell
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
    [<ExcelFunction(Name="_BlackConstantVol_Range", Description="Create a range of BlackConstantVol",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackConstantVol_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackConstantVol> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackConstantVol>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackConstantVol>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BlackConstantVol>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
