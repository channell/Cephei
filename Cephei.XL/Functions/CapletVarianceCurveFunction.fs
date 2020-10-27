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
module CapletVarianceCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CapletVarianceCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Date")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dates",Description = "Date")>] 
         dates : obj)
        ([<ExcelArgument(Name="capletVolCurve",Description = "double")>] 
         capletVolCurve : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _capletVolCurve = Helper.toCell<Generic.List<double>> capletVolCurve "capletVolCurve" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CapletVarianceCurve 
                                                            _referenceDate.cell 
                                                            _dates.cell 
                                                            _capletVolCurve.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CapletVarianceCurve>) l

                let source () = Helper.sourceFold "Fun.CapletVarianceCurve" 
                                               [| _referenceDate.source
                                               ;  _dates.source
                                               ;  _capletVolCurve.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _dates.cell
                                ;  _capletVolCurve.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapletVarianceCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_dayCounter", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapletVarianceCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_maxDate", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".MaxDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_maxStrike", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".MaxStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_minStrike", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".MinStrike") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
        ! returns the Black variance for a given option time and strike rate
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_blackVariance", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).BlackVariance
                                                            _optionTime.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".BlackVariance") 

                                               [| _optionTime.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                ;  _optionTime.cell
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
        ! returns the Black variance for a given option tenor and strike rate
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_blackVariance2", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_blackVariance2
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).BlackVariance2
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".BlackVariance2") 

                                               [| _optionTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                ;  _optionTenor.cell
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
        ! returns the Black variance for a given option date and strike rate
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_blackVariance1", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_blackVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).BlackVariance1
                                                            _optionDate.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".BlackVariance1") 

                                               [| _optionDate.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                ;  _optionDate.cell
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
        
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_displacement", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_displacement
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).Displacement
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".Displacement") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
        ! returns the smile for a given option time
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_smileSection", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="extr",Description = "bool")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).SmileSection
                                                            _optionTime.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".SmileSection") 

                                               [| _optionTime.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                ;  _optionTime.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapletVarianceCurve> format
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
    [<ExcelFunction(Name="_CapletVarianceCurve_smileSection2", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_smileSection2
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="extr",Description = "bool")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).SmileSection2
                                                            _optionDate.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".SmileSection2") 

                                               [| _optionDate.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                ;  _optionDate.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapletVarianceCurve> format
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
    [<ExcelFunction(Name="_CapletVarianceCurve_smileSection1", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_smileSection1
        ([<ExcelArgument(Name="Mnemonic",Description = "SmileSection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "bool")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).SmileSection1
                                                            _optionTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".SmileSection1") 

                                               [| _optionTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                ;  _optionTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapletVarianceCurve> format
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
    [<ExcelFunction(Name="_CapletVarianceCurve_volatility2", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="optionTime",Description = "double")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).Volatility2
                                                            _optionTime.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".Volatility2") 

                                               [| _optionTime.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                ;  _optionTime.cell
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
        ! returns the volatility for a given option date and strike rate
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_volatility1", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Date")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).Volatility1
                                                            _optionDate.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".Volatility1") 

                                               [| _optionDate.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                ;  _optionDate.cell
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
        ! returns the volatility for a given option tenor and strike rate
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_volatility", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Period")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "bool")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).Volatility
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".Volatility") 

                                               [| _optionTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                ;  _optionTenor.cell
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
        
    *)
    [<ExcelFunction(Name="_CapletVarianceCurve_volatilityType", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".VolatilityType") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_businessDayConvention", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_optionDateFromTenor", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".OptionDateFromTenor") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_calendar", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CapletVarianceCurve> format
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
    [<ExcelFunction(Name="_CapletVarianceCurve_maxTime", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".MaxTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_referenceDate", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".ReferenceDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_settlementDays", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_timeFromReference", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".TimeFromReference") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_update", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).Update
                                                       ) :> ICell
                let format (o : CapletVarianceCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_allowsExtrapolation", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".AllowsExtrapolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_disableExtrapolation", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapletVarianceCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".DisableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_enableExtrapolation", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        ([<ExcelArgument(Name="b",Description = "bool")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : CapletVarianceCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".EnableExtrapolation") 

                                               [| _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_extrapolate", Description="Create a CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CapletVarianceCurve",Description = "CapletVarianceCurve")>] 
         capletvariancecurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CapletVarianceCurve = Helper.toCell<CapletVarianceCurve> capletvariancecurve "CapletVarianceCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((CapletVarianceCurveModel.Cast _CapletVarianceCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CapletVarianceCurve.source + ".Extrapolate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CapletVarianceCurve.cell
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
    [<ExcelFunction(Name="_CapletVarianceCurve_Range", Description="Create a range of CapletVarianceCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CapletVarianceCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CapletVarianceCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CapletVarianceCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CapletVarianceCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CapletVarianceCurve>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
