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
    [<ExcelFunction(Name="_ConvertibleBond_callability", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Callability") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_conversionRatio", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_conversionRatio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).ConversionRatio
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".ConversionRatio") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_creditSpread", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_creditSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).CreditSpread
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_ConvertibleBond.source + ".CreditSpread") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
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
    [<ExcelFunction(Name="_ConvertibleBond_dividends", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_dividends
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Dividends
                                                       ) :> ICell
                let format (o : DividendSchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Dividends") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_accruedAmount", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".AccruedAmount") 
                                               [| _ConvertibleBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_calendar", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Calendar") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
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
        \note returns all the cashflows, including the redemptions.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_cashflows", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Cashflows") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ConvertibleBond_cleanPrice", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".CleanPrice") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_cleanPrice", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".CleanPrice") 
                                               [| _ConvertibleBond.source
                                               ;  _Yield.source
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_dirtyPrice", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).DirtyPrice
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".DirtyPrice") 
                                               [| _ConvertibleBond.source
                                               ;  _Yield.source
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
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_dirtyPrice", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).DirtyPrice1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".DirtyPrice") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_isExpired", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".IsExpired") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_issueDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".IssueDate") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_isTradable", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".IsTradable") 
                                               [| _ConvertibleBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_maturityDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".MaturityDate") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_nextCashFlowDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".NextCashFlowDate") 
                                               [| _ConvertibleBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
        ! Expected next coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the already-fixed not-yet-paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_nextCouponRate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".NextCouponRate") 
                                               [| _ConvertibleBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_notional", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Notional") 
                                               [| _ConvertibleBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_notionals", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Notionals") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ConvertibleBond_previousCashFlowDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".PreviousCashFlowDate") 
                                               [| _ConvertibleBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
        ! Expected previous coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the last paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_previousCouponRate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".PreviousCouponRate") 
                                               [| _ConvertibleBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _settlement.cell
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
        returns the redemption, if only one is defined
    *)
    [<ExcelFunction(Name="_ConvertibleBond_redemption", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Redemption") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
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
        ! returns just the redemption flows (not interest payments)
    *)
    [<ExcelFunction(Name="_ConvertibleBond_redemptions", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Redemptions") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ConvertibleBond_settlementDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".SettlementDate") 
                                               [| _ConvertibleBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_settlementDays", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".SettlementDays") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_settlementValue", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".SettlementValue") 
                                               [| _ConvertibleBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _cleanPrice.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_settlementValue", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".SettlementValue") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_startDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".StartDate") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_yield", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Yield
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Yield") 
                                               [| _ConvertibleBond.source
                                               ;  _cleanPrice.source
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
        ! The default bond settlement and theoretical price are used for calculation.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_yield", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Yield1
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Yield") 
                                               [| _ConvertibleBond.source
                                               ;  _dc.source
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
    [<ExcelFunction(Name="_ConvertibleBond_CASH", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".CASH") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_errorEstimate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".ErrorEstimate") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_NPV", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".NPV") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_result", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".Result") 
                                               [| _ConvertibleBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_setPricingEngine", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ConvertibleBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".SetPricingEngine") 
                                               [| _ConvertibleBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_ConvertibleBond_valuationDate", Description="Create a ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvertibleBond",Description = "Reference to ConvertibleBond")>] 
         convertiblebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvertibleBond = Helper.toCell<ConvertibleBond> convertiblebond "ConvertibleBond" true 
                let builder () = withMnemonic mnemonic ((_ConvertibleBond.cell :?> ConvertibleBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConvertibleBond.source + ".ValuationDate") 
                                               [| _ConvertibleBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvertibleBond.cell
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
    [<ExcelFunction(Name="_ConvertibleBond_Range", Description="Create a range of ConvertibleBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvertibleBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConvertibleBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvertibleBond> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConvertibleBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConvertibleBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConvertibleBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)