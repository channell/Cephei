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
  Constant caplet volatility, no time-strike dependence
  </summary> *)
[<AutoSerializable(true)>]
module ConstantOptionletVolatilityFunction =

    (*
        ! fixed reference date, fixed market data
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _vol = Helper.toCell<double> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder () = withMnemonic mnemonic (Fun.ConstantOptionletVolatility 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantOptionletVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantOptionletVolatility" 
                                               [| _referenceDate.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! floating reference date, floating market data
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility3", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder () = withMnemonic mnemonic (Fun.ConstantOptionletVolatility3
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantOptionletVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantOptionletVolatility3" 
                                               [| _settlementDays.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! floating reference date, fixed market data
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility1", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _vol = Helper.toCell<double> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder () = withMnemonic mnemonic (Fun.ConstantOptionletVolatility1
                                                            _settlementDays.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantOptionletVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantOptionletVolatility1" 
                                               [| _settlementDays.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixed reference date, floating market data
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility2", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _vol = Helper.toHandle<Quote> vol "vol" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let builder () = withMnemonic mnemonic (Fun.ConstantOptionletVolatility2 
                                                            _referenceDate.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _vol.cell 
                                                            _dc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConstantOptionletVolatility>) l

                let source = Helper.sourceFold "Fun.ConstantOptionletVolatility2" 
                                               [| _referenceDate.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _vol.source
                                               ;  _dc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _vol.cell
                                ;  _dc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_maxDate", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".MaxDate") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantOptionletVolatility_maxStrike", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".MaxStrike") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantOptionletVolatility_minStrike", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".MinStrike") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        ! returns the Black variance for a given option time and strike rate
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_blackVariance", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).BlackVariance
                                                            _optionTime.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".BlackVariance") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _optionTime.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _optionTime.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option tenor and strike rate
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_blackVariance2", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_blackVariance2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).BlackVariance2
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".BlackVariance2") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _optionTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _optionTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option date and strike rate
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_blackVariance1", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_blackVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).BlackVariance1
                                                            _optionDate.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".BlackVariance1") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _optionDate.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _optionDate.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_ConstantOptionletVolatility_displacement", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_displacement
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).Displacement
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".Displacement") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        ! returns the smile for a given option time
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_smileSection", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).SmileSection
                                                            _optionTime.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".SmileSection") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _optionTime.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _optionTime.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option date
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_smileSection2", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_smileSection2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).SmileSection2
                                                            _optionDate.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".SmileSection2") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _optionDate.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _optionDate.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option tenor
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_smileSection1", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_smileSection1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).SmileSection1
                                                            _optionTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".SmileSection1") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _optionTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _optionTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the volatility for a given option time and strike rate
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_volatility2", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).Volatility2
                                                            _optionTime.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".Volatility2") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _optionTime.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _optionTime.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option date and strike rate
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_volatility1", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).Volatility1
                                                            _optionDate.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".Volatility1") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _optionDate.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _optionDate.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option tenor and strike rate
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_volatility", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).Volatility
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".Volatility") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _optionTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _optionTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
    [<ExcelFunction(Name="_ConstantOptionletVolatility_volatilityType", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".VolatilityType") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_businessDayConvention", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".BusinessDayConvention") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_optionDateFromTenor", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _p = Helper.toCell<Period> p "p" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".OptionDateFromTenor") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _p.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_calendar", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".Calendar") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the day counter used for date/time conversion
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_dayCounter", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".DayCounter") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConstantOptionletVolatility> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_maxTime", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".MaxTime") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_referenceDate", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".ReferenceDate") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_settlementDays", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".SettlementDays") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_timeFromReference", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".TimeFromReference") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_update", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).Update
                                                       ) :> ICell
                let format (o : ConstantOptionletVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".Update") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_allowsExtrapolation", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".AllowsExtrapolation") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_disableExtrapolation", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantOptionletVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".DisableExtrapolation") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_ConstantOptionletVolatility_enableExtrapolation", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ConstantOptionletVolatility) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".EnableExtrapolation") 
                                               [| _ConstantOptionletVolatility.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_ConstantOptionletVolatility_extrapolate", Description="Create a ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConstantOptionletVolatility",Description = "Reference to ConstantOptionletVolatility")>] 
         constantoptionletvolatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConstantOptionletVolatility = Helper.toCell<ConstantOptionletVolatility> constantoptionletvolatility "ConstantOptionletVolatility"  
                let builder () = withMnemonic mnemonic ((ConstantOptionletVolatilityModel.Cast _ConstantOptionletVolatility.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConstantOptionletVolatility.source + ".Extrapolate") 
                                               [| _ConstantOptionletVolatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConstantOptionletVolatility.cell
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
    [<ExcelFunction(Name="_ConstantOptionletVolatility_Range", Description="Create a range of ConstantOptionletVolatility",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConstantOptionletVolatility_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConstantOptionletVolatility")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConstantOptionletVolatility> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConstantOptionletVolatility>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConstantOptionletVolatility>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConstantOptionletVolatility>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
