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
  This class calculates time/strike dependent Black volatilities using as input a matrix of Black volatilities observed in the market.  The calculation is performed interpolating on the variance surface.  Bilinear interpolation is used as default; this can be changed by the setInterpolation() method.  check time extrapolation
  </summary> *)
[<AutoSerializable(true)>]
module BlackVarianceSurfaceFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackVarianceSurface", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="strikes",Description = "Reference to strikes")>] 
         strikes : obj)
        ([<ExcelArgument(Name="blackVolMatrix",Description = "Reference to blackVolMatrix")>] 
         blackVolMatrix : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="lowerExtrapolation",Description = "Reference to lowerExtrapolation")>] 
         lowerExtrapolation : obj)
        ([<ExcelArgument(Name="upperExtrapolation",Description = "Reference to upperExtrapolation")>] 
         upperExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _strikes = Helper.toCell<Generic.List<double>> strikes "strikes" 
                let _blackVolMatrix = Helper.toCell<Matrix> blackVolMatrix "blackVolMatrix" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _lowerExtrapolation = Helper.toCell<BlackVarianceSurface.Extrapolation> lowerExtrapolation "lowerExtrapolation" 
                let _upperExtrapolation = Helper.toCell<BlackVarianceSurface.Extrapolation> upperExtrapolation "upperExtrapolation" 
                let builder () = withMnemonic mnemonic (Fun.BlackVarianceSurface 
                                                            _referenceDate.cell 
                                                            _calendar.cell 
                                                            _dates.cell 
                                                            _strikes.cell 
                                                            _blackVolMatrix.cell 
                                                            _dayCounter.cell 
                                                            _lowerExtrapolation.cell 
                                                            _upperExtrapolation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackVarianceSurface>) l

                let source = Helper.sourceFold "Fun.BlackVarianceSurface" 
                                               [| _referenceDate.source
                                               ;  _calendar.source
                                               ;  _dates.source
                                               ;  _strikes.source
                                               ;  _blackVolMatrix.source
                                               ;  _dayCounter.source
                                               ;  _lowerExtrapolation.source
                                               ;  _upperExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _calendar.cell
                                ;  _dates.cell
                                ;  _strikes.cell
                                ;  _blackVolMatrix.cell
                                ;  _dayCounter.cell
                                ;  _lowerExtrapolation.cell
                                ;  _upperExtrapolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackVarianceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for Handle
    *)
    [<ExcelFunction(Name="_BlackVarianceSurface1", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.BlackVarianceSurface1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackVarianceSurface>) l

                let source = Helper.sourceFold "Fun.BlackVarianceSurface1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackVarianceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackVarianceSurface_dates", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".Dates") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
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
        TermStructure interface
    *)
    [<ExcelFunction(Name="_BlackVarianceSurface_dayCounter", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".DayCounter") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackVarianceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackVarianceSurface_maxDate", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".MaxDate") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
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
    [<ExcelFunction(Name="_BlackVarianceSurface_maxStrike", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".MaxStrike") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_BlackVarianceSurface_minStrike", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".MinStrike") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
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
    (*!!
    [<ExcelFunction(Name="_BlackVarianceSurface_setInterpolation", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_setInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let _i = Helper.toCell<Interpolator> i "i" 
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).SetInterpolation
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : BlackVarianceSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".SetInterpolation") 
                                               [| _BlackVarianceSurface.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
                                ;  _i.cell
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
            *)
    (*
        
    *)
    (*!!
    [<ExcelFunction(Name="_BlackVarianceSurface_setInterpolation", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_setInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).SetInterpolation1
                                                       ) :> ICell
                let format (o : BlackVarianceSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".SetInterpolation") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
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
            *)
    (*
        public accessors
    *)
    [<ExcelFunction(Name="_BlackVarianceSurface_strikes", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_strikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).Strikes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".Strikes") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
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
    [<ExcelFunction(Name="_BlackVarianceSurface_times", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".Times") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
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
    [<ExcelFunction(Name="_BlackVarianceSurface_variances", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_variances
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).Variances
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".Variances") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackVarianceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackVarianceSurface_volatilities", Description="Create a BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_volatilities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackVarianceSurface",Description = "Reference to BlackVarianceSurface")>] 
         blackvariancesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackVarianceSurface = Helper.toCell<BlackVarianceSurface> blackvariancesurface "BlackVarianceSurface"  
                let builder () = withMnemonic mnemonic ((_BlackVarianceSurface.cell :?> BlackVarianceSurfaceModel).Volatilities
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_BlackVarianceSurface.source + ".Volatilities") 
                                               [| _BlackVarianceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackVarianceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackVarianceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BlackVarianceSurface_Range", Description="Create a range of BlackVarianceSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackVarianceSurface_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackVarianceSurface")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackVarianceSurface> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackVarianceSurface>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackVarianceSurface>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackVarianceSurface>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
