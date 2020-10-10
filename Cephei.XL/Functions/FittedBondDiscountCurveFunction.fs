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
  This class fits a discount function d(t) over a set of bonds, using a user defined fitting method. The discount function is fit in such a way so that all cashflows of all input bonds, when discounted using d(t) will reproduce the set of input bond prices in an optimized sense. Minimized price errors are weighted by the inverse of their respective bond duration.  The FittedBondDiscountCurve class acts as a generic wrapper, while its inner class FittingMethod provides the implementation details. Developers thus need only derive new fitting methods from the latter. 
<b> Example: </b> FittedBondCurve.cpp compares various bond discount curve fitting methodologies  The method can be slow if there are many bonds to fit. Speed also depends on the particular choice of fitting method chosen and its convergence properties under optimization.  See also todo list for BondDiscountCurveFittingMethod.  refactor the bond helper class so that it is pure virtual and returns a generic bond or its cash flows. Derived classes would include helpers for fixed-rate and zero-coupon bonds. In this way, both bonds and bills can be used to fit a discount curve using the exact same machinery. At present, only fixed-coupon bonds are supported. An even better way to move forward might be to get rate helpers to return cashflows, in which case this class could be used to fit any set of cash flows, not just bonds.  add more fitting diagnostics: smoothness, standard deviation, student-t test, etc. Generic smoothness method may be useful for smoothing splines fitting. See Fisher, M., D. Nychka and D. Zervos: "Fitting the term structure of interest rates with smoothing splines." Board of Governors of the Federal Reserve System, Federal Resere Board Working Paper, 95-1.  add extrapolation routines  yieldtermstructures
  </summary> *)
[<AutoSerializable(true)>]
module FittedBondDiscountCurveFunction =

    (*
        ! curve reference date fixed for life of curve
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve1", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="bondHelpers",Description = "Reference to bondHelpers")>] 
         bondHelpers : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="fittingMethod",Description = "Reference to fittingMethod")>] 
         fittingMethod : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="guess",Description = "Reference to guess")>] 
         guess : obj)
        ([<ExcelArgument(Name="simplexLambda",Description = "Reference to simplexLambda")>] 
         simplexLambda : obj)
        ([<ExcelArgument(Name="maxStationaryStateIterations",Description = "Reference to maxStationaryStateIterations")>] 
         maxStationaryStateIterations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _bondHelpers = Helper.toCell<Generic.List<BondHelper>> bondHelpers "bondHelpers" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _fittingMethod = Helper.toCell<FittedBondDiscountCurve.FittingMethod> fittingMethod "fittingMethod" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-10
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 10000
                let _guess = Helper.toDefault<Vector> guess "guess" null
                let _simplexLambda = Helper.toDefault<double> simplexLambda "simplexLambda" 1.0
                let _maxStationaryStateIterations = Helper.toDefault<int> maxStationaryStateIterations "maxStationaryStateIterations" 100
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FittedBondDiscountCurve1 
                                                            _referenceDate.cell 
                                                            _bondHelpers.cell 
                                                            _dayCounter.cell 
                                                            _fittingMethod.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _guess.cell 
                                                            _simplexLambda.cell 
                                                            _maxStationaryStateIterations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FittedBondDiscountCurve>) l

                let source () = Helper.sourceFold "Fun.FittedBondDiscountCurve1" 
                                               [| _referenceDate.source
                                               ;  _bondHelpers.source
                                               ;  _dayCounter.source
                                               ;  _fittingMethod.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _guess.source
                                               ;  _simplexLambda.source
                                               ;  _maxStationaryStateIterations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _bondHelpers.cell
                                ;  _dayCounter.cell
                                ;  _fittingMethod.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _guess.cell
                                ;  _simplexLambda.cell
                                ;  _maxStationaryStateIterations.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FittedBondDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Constructors ! reference date based on current evaluation date
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bondHelpers",Description = "Reference to bondHelpers")>] 
         bondHelpers : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="fittingMethod",Description = "Reference to fittingMethod")>] 
         fittingMethod : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="guess",Description = "Reference to guess")>] 
         guess : obj)
        ([<ExcelArgument(Name="simplexLambda",Description = "Reference to simplexLambda")>] 
         simplexLambda : obj)
        ([<ExcelArgument(Name="maxStationaryStateIterations",Description = "Reference to maxStationaryStateIterations")>] 
         maxStationaryStateIterations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bondHelpers = Helper.toCell<Generic.List<BondHelper>> bondHelpers "bondHelpers" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _fittingMethod = Helper.toCell<FittedBondDiscountCurve.FittingMethod> fittingMethod "fittingMethod" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-10
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 10000
                let _guess = Helper.toDefault<Vector> guess "guess" null
                let _simplexLambda = Helper.toDefault<double> simplexLambda "simplexLambda" 1.0
                let _maxStationaryStateIterations = Helper.toDefault<int> maxStationaryStateIterations "maxStationaryStateIterations" 100
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FittedBondDiscountCurve
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bondHelpers.cell 
                                                            _dayCounter.cell 
                                                            _fittingMethod.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _guess.cell 
                                                            _simplexLambda.cell 
                                                            _maxStationaryStateIterations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FittedBondDiscountCurve>) l

                let source () = Helper.sourceFold "Fun.FittedBondDiscountCurve" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _bondHelpers.source
                                               ;  _dayCounter.source
                                               ;  _fittingMethod.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _guess.source
                                               ;  _simplexLambda.source
                                               ;  _maxStationaryStateIterations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _bondHelpers.cell
                                ;  _dayCounter.cell
                                ;  _fittingMethod.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _guess.cell
                                ;  _simplexLambda.cell
                                ;  _maxStationaryStateIterations.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FittedBondDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest date for which the curve can return values
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_maxDate", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".MaxDate") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
        Inspectors ! total number of bonds used to fit the yield curve
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_numberOfBonds", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_numberOfBonds
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).NumberOfBonds
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".NumberOfBonds") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
        ! The same day-counting rule used by the term structure should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_discount", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).Discount
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".Discount") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
                                ;  _t.cell
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
        These methods return the discount factor from a given date or time to the reference date.  In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_discount1", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_discount1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).Discount1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".Discount1") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
                                ;  _d.cell
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
        ! The resulting interest rate has the required day-counting rule. \warning dates are not adjusted for holidays
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_forwardRate", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).ForwardRate
                                                            _d.cell 
                                                            _p.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".ForwardRate") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FittedBondDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the required day-counting rule.
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_forwardRate1", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_forwardRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).ForwardRate1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".ForwardRate1") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FittedBondDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed times t1 and t2.
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_forwardRate2", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_forwardRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).ForwardRate2
                                                            _t1.cell 
                                                            _t2.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".ForwardRate2") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
                                ;  _t1.cell
                                ;  _t2.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FittedBondDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_jumpDates", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_jumpDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).JumpDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".JumpDates") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_jumpTimes", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_jumpTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).JumpTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".JumpTimes") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_update", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).Update
                                                       ) :> ICell
                let format (o : FittedBondDiscountCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".Update") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
        ! The resulting interest rate has the required daycounting rule.
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_zeroRate1", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_zeroRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _d = Helper.toCell<Date> d "d" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).ZeroRate1
                                                            _d.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".ZeroRate1") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _d.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
                                ;  _d.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FittedBondDiscountCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_FittedBondDiscountCurve_zeroRate", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _t = Helper.toCell<double> t "t" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).ZeroRate
                                                            _t.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".ZeroRate") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _t.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
                                ;  _t.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FittedBondDiscountCurve> format
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_calendar", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".Calendar") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FittedBondDiscountCurve> format
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_dayCounter", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".DayCounter") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FittedBondDiscountCurve> format
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_maxTime", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".MaxTime") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_referenceDate", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".ReferenceDate") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_settlementDays", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".SettlementDays") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_timeFromReference", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".TimeFromReference") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_allowsExtrapolation", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".AllowsExtrapolation") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_disableExtrapolation", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FittedBondDiscountCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".DisableExtrapolation") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_enableExtrapolation", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FittedBondDiscountCurve) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".EnableExtrapolation") 
                                               [| _FittedBondDiscountCurve.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_extrapolate", Description="Create a FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FittedBondDiscountCurve",Description = "Reference to FittedBondDiscountCurve")>] 
         fittedbonddiscountcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FittedBondDiscountCurve = Helper.toCell<FittedBondDiscountCurve> fittedbonddiscountcurve "FittedBondDiscountCurve"  
                let builder (current : ICell) = withMnemonic mnemonic ((FittedBondDiscountCurveModel.Cast _FittedBondDiscountCurve.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FittedBondDiscountCurve.source + ".Extrapolate") 
                                               [| _FittedBondDiscountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FittedBondDiscountCurve.cell
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
    [<ExcelFunction(Name="_FittedBondDiscountCurve_Range", Description="Create a range of FittedBondDiscountCurve",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FittedBondDiscountCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FittedBondDiscountCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FittedBondDiscountCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FittedBondDiscountCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FittedBondDiscountCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FittedBondDiscountCurve>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
