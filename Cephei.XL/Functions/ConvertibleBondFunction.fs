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
(*!!
(* <summary>
  base class for convertible bonds
  </summary> *)
[<AutoSerializable(true)>]
module ConvertibleBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleBond_callability", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Callability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_conversionRatio", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_conversionRatio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).ConversionRatio
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".ConversionRatio") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_creditSpread", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_creditSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).CreditSpread
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".CreditSpread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleBond_dividends", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_dividends
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Dividends
                                                       ) :> ICell
                let format (o : DividendSchedule) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Dividends") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_accruedAmount", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_calendar", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        \note returns all the cashflows, including the redemptions.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_cashflows", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_cleanPrice", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_cleanPrice", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".CleanPrice") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_dirtyPrice", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).DirtyPrice
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".DirtyPrice") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_dirtyPrice", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).DirtyPrice1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_isExpired", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_issueDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_isTradable", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_maturityDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_nextCashFlowDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
        ! Expected next coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the already-fixed not-yet-paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_nextCouponRate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_notional", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_notionals", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_previousCashFlowDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
        ! Expected previous coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the last paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_previousCouponRate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
        returns the redemption, if only one is defined
    *)
    [<ExcelFunction(Name="_ConvertibleBond_redemption", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvertibleBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns just the redemption flows (not interest payments)
    *)
    [<ExcelFunction(Name="_ConvertibleBond_redemptions", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvertibleBond_settlementDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_settlementDays", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_settlementValue", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _cleanPrice.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_settlementValue", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".SettlementValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_startDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_yield", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Yield
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Yield") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _cleanPrice.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
        ! The default bond settlement and theoretical price are used for calculation.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_yield", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Yield1
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_CASH", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_errorEstimate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_NPV", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_result", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_setPricingEngine", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ConvertibleBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_valuationDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((ConvertibleBondModel.Cast _ConvertibleBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ConvertibleBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_Range", Description="Create a range of ConvertibleBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvertibleBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvertibleBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConvertibleBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConvertibleBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ConvertibleBond>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
