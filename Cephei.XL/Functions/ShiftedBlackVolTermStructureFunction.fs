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
module ShiftedBlackVolTermStructureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_maxDate", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_maxStrike", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_minStrike", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="varianceOffset",Description = "double")>] 
         varianceOffset : obj)
        ([<ExcelArgument(Name="volTS",Description = "BlackVolTermStructure")>] 
         volTS : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _varianceOffset = Helper.toCell<double> varianceOffset "varianceOffset" 
                let _volTS = Helper.toHandle<BlackVolTermStructure> volTS "volTS" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ShiftedBlackVolTermStructure 
                                                            _varianceOffset.cell 
                                                            _volTS.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ShiftedBlackVolTermStructure>) l

                let source () = Helper.sourceFold "Fun.ShiftedBlackVolTermStructure" 
                                               [| _varianceOffset.source
                                               ;  _volTS.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _varianceOffset.cell
                                ;  _volTS.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ShiftedBlackVolTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! forward (at-the-money) variance
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_blackForwardVariance", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_blackForwardVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="time1",Description = "double")>] 
         time1 : obj)
        ([<ExcelArgument(Name="time2",Description = "double")>] 
         time2 : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _time1 = Helper.toCell<double> time1 "time1" 
                let _time2 = Helper.toCell<double> time2 "time2" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).BlackForwardVariance
                                                            _time1.cell 
                                                            _time2.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".BlackForwardVariance") 

                                               [| _time1.source
                                               ;  _time2.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _time1.cell
                                ;  _time2.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! forward (at-the-money) variance
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_blackForwardVariance1", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_blackForwardVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="date1",Description = "Date")>] 
         date1 : obj)
        ([<ExcelArgument(Name="date2",Description = "Date")>] 
         date2 : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _date1 = Helper.toCell<Date> date1 "date1" 
                let _date2 = Helper.toCell<Date> date2 "date2" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).BlackForwardVariance1
                                                            _date1.cell 
                                                            _date2.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".BlackForwardVariance1") 

                                               [| _date1.source
                                               ;  _date2.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _date1.cell
                                ;  _date2.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! forward (at-the-money) volatility
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_blackForwardVol1", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_blackForwardVol1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="date1",Description = "Date")>] 
         date1 : obj)
        ([<ExcelArgument(Name="date2",Description = "Date")>] 
         date2 : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _date1 = Helper.toCell<Date> date1 "date1" 
                let _date2 = Helper.toCell<Date> date2 "date2" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).BlackForwardVol1
                                                            _date1.cell 
                                                            _date2.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".BlackForwardVol1") 

                                               [| _date1.source
                                               ;  _date2.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _date1.cell
                                ;  _date2.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! forward (at-the-money) volatility
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_blackForwardVol", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_blackForwardVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="time1",Description = "double")>] 
         time1 : obj)
        ([<ExcelArgument(Name="time2",Description = "double")>] 
         time2 : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _time1 = Helper.toCell<double> time1 "time1" 
                let _time2 = Helper.toCell<double> time2 "time2" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).BlackForwardVol
                                                            _time1.cell 
                                                            _time2.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".BlackForwardVol") 

                                               [| _time1.source
                                               ;  _time2.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _time1.cell
                                ;  _time2.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! spot variance
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_blackVariance1", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_blackVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).BlackVariance1
                                                            _maturity.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".BlackVariance1") 

                                               [| _maturity.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _maturity.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! spot variance
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_blackVariance", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="maturity",Description = "Date")>] 
         maturity : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _maturity = Helper.toCell<Date> maturity "maturity" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).BlackVariance
                                                            _maturity.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".BlackVariance") 

                                               [| _maturity.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _maturity.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! spot volatility
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_blackVol", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_blackVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="maturity",Description = "Date")>] 
         maturity : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _maturity = Helper.toCell<Date> maturity "maturity" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).BlackVol
                                                            _maturity.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".BlackVol") 

                                               [| _maturity.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _maturity.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! spot volatility
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_blackVol1", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_blackVol1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).BlackVol1
                                                            _maturity.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".BlackVol1") 

                                               [| _maturity.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _maturity.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_businessDayConvention", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_optionDateFromTenor", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".OptionDateFromTenor") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _p.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_calendar", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ShiftedBlackVolTermStructure> format
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
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_dayCounter", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ShiftedBlackVolTermStructure> format
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
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_maxTime", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_referenceDate", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_settlementDays", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_timeFromReference", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_update", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).Update
                                                       ) :> ICell
                let format (o : ShiftedBlackVolTermStructure) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_allowsExtrapolation", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_disableExtrapolation", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ShiftedBlackVolTermStructure) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_enableExtrapolation", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : ShiftedBlackVolTermStructure) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_extrapolate", Description="Create a ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ShiftedBlackVolTermStructure",Description = "ShiftedBlackVolTermStructure")>] 
         shiftedblackvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ShiftedBlackVolTermStructure = Helper.toCell<ShiftedBlackVolTermStructure> shiftedblackvoltermstructure "ShiftedBlackVolTermStructure"  
                let builder (current : ICell) = withMnemonic mnemonic ((ShiftedBlackVolTermStructureModel.Cast _ShiftedBlackVolTermStructure.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ShiftedBlackVolTermStructure.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ShiftedBlackVolTermStructure.cell
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
    [<ExcelFunction(Name="_ShiftedBlackVolTermStructure_Range", Description="Create a range of ShiftedBlackVolTermStructure",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ShiftedBlackVolTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ShiftedBlackVolTermStructure> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ShiftedBlackVolTermStructure> (c)) :> ICell
                let format (i : Cephei.Cell.List<ShiftedBlackVolTermStructure>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ShiftedBlackVolTermStructure>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
