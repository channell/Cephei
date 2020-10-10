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
  This class provides the at-the-money volatility for a given swaption by interpolating a volatility matrix whose elements are the market volatilities of a set of swaption with given option date and swapLength.  The volatility matrix <tt>M</tt> must be defined so that: - the number of rows equals the number of option dates - the number of columns equals the number of swap tenors - <tt>M[i][j]</tt> contains the volatility corresponding to the <tt>i</tt>-th option and <tt>j</tt>-th tenor.
  </summary> *)
[<AutoSerializable(true)>]
module SwaptionVolatilityMatrixFunction =

    (*
        ! returns the lower indexes of surrounding volatility matrix corners
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_locate", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_locate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Locate
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                       ) :> ICell
                let format (o : Generic.KeyValuePair<int,int>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Locate") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
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
        Other inspectors ! returns the lower indexes of surrounding volatility matrix corners
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_locate1", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_locate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Locate1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : Generic.KeyValuePair<int,int>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Locate1") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
        TermStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_maxDate", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".MaxDate") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_maxStrike", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".MaxStrike") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
        SwaptionVolatilityStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_maxSwapTenor", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_maxSwapTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).MaxSwapTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".MaxSwapTenor") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_minStrike", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".MinStrike") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
        ! floating reference date, fixed market data
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix2", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="swapTenors",Description = "Reference to swapTenors")>] 
         swapTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="flatExtrapolation",Description = "Reference to flatExtrapolation")>] 
         flatExtrapolation : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shifts",Description = "Reference to shifts")>] 
         shifts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _swapTenors = Helper.toCell<Generic.List<Period>> swapTenors "swapTenors" 
                let _vols = Helper.toCell<Matrix> vols "vols" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _flatExtrapolation = Helper.toDefault<bool> flatExtrapolation "flatExtrapolation" false
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shifts = Helper.toDefault<Matrix> shifts "shifts" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwaptionVolatilityMatrix2
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _swapTenors.cell 
                                                            _vols.cell 
                                                            _dayCounter.cell 
                                                            _flatExtrapolation.cell 
                                                            _Type.cell 
                                                            _shifts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionVolatilityMatrix>) l

                let source () = Helper.sourceFold "Fun.SwaptionVolatilityMatrix2" 
                                               [| _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _swapTenors.source
                                               ;  _vols.source
                                               ;  _dayCounter.source
                                               ;  _flatExtrapolation.source
                                               ;  _Type.source
                                               ;  _shifts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _swapTenors.cell
                                ;  _vols.cell
                                ;  _dayCounter.cell
                                ;  _flatExtrapolation.cell
                                ;  _Type.cell
                                ;  _shifts.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix3", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="swapTenors",Description = "Reference to swapTenors")>] 
         swapTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="flatExtrapolation",Description = "Reference to flatExtrapolation")>] 
         flatExtrapolation : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shifts",Description = "Reference to shifts")>] 
         shifts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _swapTenors = Helper.toCell<Generic.List<Period>> swapTenors "swapTenors" 
                let _vols = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> vols "vols" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _flatExtrapolation = Helper.toDefault<bool> flatExtrapolation "flatExtrapolation" false
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shifts = Helper.toDefault<Generic.List<Generic.List<double>>> shifts "shifts" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwaptionVolatilityMatrix3
                                                            _referenceDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _swapTenors.cell 
                                                            _vols.cell 
                                                            _dayCounter.cell 
                                                            _flatExtrapolation.cell 
                                                            _Type.cell 
                                                            _shifts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionVolatilityMatrix>) l

                let source () = Helper.sourceFold "Fun.SwaptionVolatilityMatrix3" 
                                               [| _referenceDate.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _swapTenors.source
                                               ;  _vols.source
                                               ;  _dayCounter.source
                                               ;  _flatExtrapolation.source
                                               ;  _Type.source
                                               ;  _shifts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _swapTenors.cell
                                ;  _vols.cell
                                ;  _dayCounter.cell
                                ;  _flatExtrapolation.cell
                                ;  _Type.cell
                                ;  _shifts.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixed reference date, fixed market data
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix1", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="swapTenors",Description = "Reference to swapTenors")>] 
         swapTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="flatExtrapolation",Description = "Reference to flatExtrapolation")>] 
         flatExtrapolation : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shifts",Description = "Reference to shifts")>] 
         shifts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _swapTenors = Helper.toCell<Generic.List<Period>> swapTenors "swapTenors" 
                let _vols = Helper.toCell<Matrix> vols "vols" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _flatExtrapolation = Helper.toDefault<bool> flatExtrapolation "flatExtrapolation" false
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shifts = Helper.toDefault<Matrix> shifts "shifts" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwaptionVolatilityMatrix1
                                                            _referenceDate.cell 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _swapTenors.cell 
                                                            _vols.cell 
                                                            _dayCounter.cell 
                                                            _flatExtrapolation.cell 
                                                            _Type.cell 
                                                            _shifts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionVolatilityMatrix>) l

                let source () = Helper.sourceFold "Fun.SwaptionVolatilityMatrix1" 
                                               [| _referenceDate.source
                                               ;  _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _swapTenors.source
                                               ;  _vols.source
                                               ;  _dayCounter.source
                                               ;  _flatExtrapolation.source
                                               ;  _Type.source
                                               ;  _shifts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _swapTenors.cell
                                ;  _vols.cell
                                ;  _dayCounter.cell
                                ;  _flatExtrapolation.cell
                                ;  _Type.cell
                                ;  _shifts.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        fixed reference date and fixed market data, option dates
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="today",Description = "Reference to today")>] 
         today : obj)
        ([<ExcelArgument(Name="optionDates",Description = "Reference to optionDates")>] 
         optionDates : obj)
        ([<ExcelArgument(Name="swapTenors",Description = "Reference to swapTenors")>] 
         swapTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="flatExtrapolation",Description = "Reference to flatExtrapolation")>] 
         flatExtrapolation : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shifts",Description = "Reference to shifts")>] 
         shifts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _today = Helper.toCell<Date> today "today" 
                let _optionDates = Helper.toCell<Generic.List<Date>> optionDates "optionDates" 
                let _swapTenors = Helper.toCell<Generic.List<Period>> swapTenors "swapTenors" 
                let _vols = Helper.toCell<Matrix> vols "vols" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _flatExtrapolation = Helper.toDefault<bool> flatExtrapolation "flatExtrapolation" false
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shifts = Helper.toDefault<Matrix> shifts "shifts" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwaptionVolatilityMatrix
                                                            _today.cell 
                                                            _optionDates.cell 
                                                            _swapTenors.cell 
                                                            _vols.cell 
                                                            _dayCounter.cell 
                                                            _flatExtrapolation.cell 
                                                            _Type.cell 
                                                            _shifts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionVolatilityMatrix>) l

                let source () = Helper.sourceFold "Fun.SwaptionVolatilityMatrix" 
                                               [| _today.source
                                               ;  _optionDates.source
                                               ;  _swapTenors.source
                                               ;  _vols.source
                                               ;  _dayCounter.source
                                               ;  _flatExtrapolation.source
                                               ;  _Type.source
                                               ;  _shifts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _today.cell
                                ;  _optionDates.cell
                                ;  _swapTenors.cell
                                ;  _vols.cell
                                ;  _dayCounter.cell
                                ;  _flatExtrapolation.cell
                                ;  _Type.cell
                                ;  _shifts.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix4", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="swapTenors",Description = "Reference to swapTenors")>] 
         swapTenors : obj)
        ([<ExcelArgument(Name="vols",Description = "Reference to vols")>] 
         vols : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="flatExtrapolation",Description = "Reference to flatExtrapolation")>] 
         flatExtrapolation : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="shifts",Description = "Reference to shifts")>] 
         shifts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _swapTenors = Helper.toCell<Generic.List<Period>> swapTenors "swapTenors" 
                let _vols = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> vols "vols" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _flatExtrapolation = Helper.toDefault<bool> flatExtrapolation "flatExtrapolation" false
                let _Type = Helper.toCell<VolatilityType> Type "Type" 
                let _shifts = Helper.toDefault<Generic.List<Generic.List<double>>> shifts "shifts" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwaptionVolatilityMatrix4 
                                                            _calendar.cell 
                                                            _bdc.cell 
                                                            _optionTenors.cell 
                                                            _swapTenors.cell 
                                                            _vols.cell 
                                                            _dayCounter.cell 
                                                            _flatExtrapolation.cell 
                                                            _Type.cell 
                                                            _shifts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionVolatilityMatrix>) l

                let source () = Helper.sourceFold "Fun.SwaptionVolatilityMatrix4" 
                                               [| _calendar.source
                                               ;  _bdc.source
                                               ;  _optionTenors.source
                                               ;  _swapTenors.source
                                               ;  _vols.source
                                               ;  _dayCounter.source
                                               ;  _flatExtrapolation.source
                                               ;  _Type.source
                                               ;  _shifts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _calendar.cell
                                ;  _bdc.cell
                                ;  _optionTenors.cell
                                ;  _swapTenors.cell
                                ;  _vols.cell
                                ;  _dayCounter.cell
                                ;  _flatExtrapolation.cell
                                ;  _Type.cell
                                ;  _shifts.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Volatility type
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_volatilityType", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".VolatilityType") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
        ! additional inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_optionDateFromTime", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_optionDateFromTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).OptionDateFromTime
                                                            _optionTime.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".OptionDateFromTime") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTime.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTime.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_optionDates", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_optionDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).OptionDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".OptionDates") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_optionTenors", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_optionTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).OptionTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".OptionTenors") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_optionTimes", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_optionTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).OptionTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".OptionTimes") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_swapLengths", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_swapLengths
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).SwapLengths
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".SwapLengths") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_swapTenors", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_swapTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).SwapTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".SwapTenors") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_update", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Update
                                                       ) :> ICell
                let format (o : SwaptionVolatilityMatrix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Update") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
        ! returns the Black variance for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_blackVariance4", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_blackVariance4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).BlackVariance4
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".BlackVariance4") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
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
        ! returns the Black variance for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_blackVariance5", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_blackVariance5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).BlackVariance5
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".BlackVariance5") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
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
        ! returns the Black variance for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_blackVariance3", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_blackVariance3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).BlackVariance3
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".BlackVariance3") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
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
        ! returns the Black variance for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_blackVariance2", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_blackVariance2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).BlackVariance2
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".BlackVariance2") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
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
        ! returns the Black variance for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_blackVariance1", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_blackVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).BlackVariance1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".BlackVariance1") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
        ! returns the Black variance for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_blackVariance", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).BlackVariance
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".BlackVariance") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        ! the largest swapLength for which the term structure can return vols
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_maxSwapLength", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_maxSwapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).MaxSwapLength
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".MaxSwapLength") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
        ! returns the shift for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_shift4", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_shift4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Shift4
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Shift4") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
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
        ! returns the shift for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_shift5", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_shift5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Shift5
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Shift5") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
        ! returns the shift for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_shift1", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_shift1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Shift1
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Shift1") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
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
        ! returns the shift for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_shift", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Shift
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Shift") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
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
        ! returns the shift for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_shift2", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_shift2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Shift2
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Shift2") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        ! returns the shift for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_shift3", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_shift3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Shift3
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Shift3") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
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
        ! returns the smile for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_smileSection1", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_smileSection1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).SmileSection1
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".SmileSection1") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_smileSection2", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_smileSection2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).SmileSection2
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".SmileSection2") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_smileSection", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).SmileSection
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".SmileSection") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! implements the conversion between swap dates and swap (time) length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_swapLength", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_swapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="start",Description = "Reference to start")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _start = Helper.toCell<Date> start "start" 
                let _End = Helper.toCell<Date> End "End" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).SwapLength
                                                            _start.cell 
                                                            _End.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".SwapLength") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _start.source
                                               ;  _End.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _start.cell
                                ;  _End.cell
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
        ! implements the conversion between swap tenor and swap (time) length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_swapLength1", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_swapLength1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).SwapLength1
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".SwapLength1") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_volatility4", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_volatility4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Volatility4
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Volatility4") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_volatility2", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Volatility2
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Volatility2") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
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
        ! returns the volatility for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_volatility5", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_volatility5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Volatility5
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Volatility5") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_volatility1", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Volatility1
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Volatility1") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
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
        ! returns the volatility for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_volatility3", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_volatility3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Volatility3
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Volatility3") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
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
        ! returns the volatility for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_volatility", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Volatility
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Volatility") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_businessDayConvention", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".BusinessDayConvention") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_optionDateFromTenor", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".OptionDateFromTenor") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_calendar", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Calendar") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_dayCounter", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".DayCounter") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolatilityMatrix> format
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_maxTime", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".MaxTime") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_referenceDate", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".ReferenceDate") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_settlementDays", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".SettlementDays") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_timeFromReference", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".TimeFromReference") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_allowsExtrapolation", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".AllowsExtrapolation") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_disableExtrapolation", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolatilityMatrix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".DisableExtrapolation") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_enableExtrapolation", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolatilityMatrix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".EnableExtrapolation") 
                                               [| _SwaptionVolatilityMatrix.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_extrapolate", Description="Create a SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolatilityMatrix",Description = "Reference to SwaptionVolatilityMatrix")>] 
         swaptionvolatilitymatrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolatilityMatrix = Helper.toCell<SwaptionVolatilityMatrix> swaptionvolatilitymatrix "SwaptionVolatilityMatrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwaptionVolatilityMatrixModel.Cast _SwaptionVolatilityMatrix.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwaptionVolatilityMatrix.source + ".Extrapolate") 
                                               [| _SwaptionVolatilityMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolatilityMatrix.cell
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
    [<ExcelFunction(Name="_SwaptionVolatilityMatrix_Range", Description="Create a range of SwaptionVolatilityMatrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwaptionVolatilityMatrix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SwaptionVolatilityMatrix")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SwaptionVolatilityMatrix> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SwaptionVolatilityMatrix>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SwaptionVolatilityMatrix>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SwaptionVolatilityMatrix>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
