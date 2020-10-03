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
  Black volatility surface backed by Heston model
  </summary> *)
[<AutoSerializable(true)>]
module HestonBlackVolSurfaceFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="hestonModel",Description = "Reference to hestonModel")>] 
         hestonModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _hestonModel = Helper.toHandle<HestonModel> hestonModel "hestonModel" 
                let builder () = withMnemonic mnemonic (Fun.HestonBlackVolSurface 
                                                            _hestonModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HestonBlackVolSurface>) l

                let source = Helper.sourceFold "Fun.HestonBlackVolSurface" 
                                               [| _hestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _hestonModel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonBlackVolSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_maxDate", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".MaxDate") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_maxStrike", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".MaxStrike") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_minStrike", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".MinStrike") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
        ! forward (at-the-money) variance
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_blackForwardVariance", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_blackForwardVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="time1",Description = "Reference to time1")>] 
         time1 : obj)
        ([<ExcelArgument(Name="time2",Description = "Reference to time2")>] 
         time2 : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _time1 = Helper.toCell<double> time1 "time1" 
                let _time2 = Helper.toCell<double> time2 "time2" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).BlackForwardVariance
                                                            _time1.cell 
                                                            _time2.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".BlackForwardVariance") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _time1.source
                                               ;  _time2.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                ;  _time1.cell
                                ;  _time2.cell
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
        ! forward (at-the-money) variance
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_blackForwardVariance1", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_blackForwardVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="date1",Description = "Reference to date1")>] 
         date1 : obj)
        ([<ExcelArgument(Name="date2",Description = "Reference to date2")>] 
         date2 : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _date1 = Helper.toCell<Date> date1 "date1" 
                let _date2 = Helper.toCell<Date> date2 "date2" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).BlackForwardVariance1
                                                            _date1.cell 
                                                            _date2.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".BlackForwardVariance1") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _date1.source
                                               ;  _date2.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                ;  _date1.cell
                                ;  _date2.cell
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
        ! forward (at-the-money) volatility
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_blackForwardVol1", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_blackForwardVol1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="date1",Description = "Reference to date1")>] 
         date1 : obj)
        ([<ExcelArgument(Name="date2",Description = "Reference to date2")>] 
         date2 : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _date1 = Helper.toCell<Date> date1 "date1" 
                let _date2 = Helper.toCell<Date> date2 "date2" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).BlackForwardVol1
                                                            _date1.cell 
                                                            _date2.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".BlackForwardVol1") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _date1.source
                                               ;  _date2.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                ;  _date1.cell
                                ;  _date2.cell
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
        ! forward (at-the-money) volatility
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_blackForwardVol", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_blackForwardVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="time1",Description = "Reference to time1")>] 
         time1 : obj)
        ([<ExcelArgument(Name="time2",Description = "Reference to time2")>] 
         time2 : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _time1 = Helper.toCell<double> time1 "time1" 
                let _time2 = Helper.toCell<double> time2 "time2" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).BlackForwardVol
                                                            _time1.cell 
                                                            _time2.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".BlackForwardVol") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _time1.source
                                               ;  _time2.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                ;  _time1.cell
                                ;  _time2.cell
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
        ! spot variance
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_blackVariance1", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_blackVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).BlackVariance1
                                                            _maturity.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".BlackVariance1") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _maturity.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                ;  _maturity.cell
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
        ! spot variance
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_blackVariance", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _maturity = Helper.toCell<Date> maturity "maturity" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).BlackVariance
                                                            _maturity.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".BlackVariance") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _maturity.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                ;  _maturity.cell
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
        ! spot volatility
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_blackVol", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_blackVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _maturity = Helper.toCell<Date> maturity "maturity" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).BlackVol
                                                            _maturity.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".BlackVol") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _maturity.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                ;  _maturity.cell
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
        ! spot volatility
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_blackVol1", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_blackVol1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).BlackVol1
                                                            _maturity.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".BlackVol1") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _maturity.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                ;  _maturity.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_HestonBlackVolSurface_businessDayConvention", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".BusinessDayConvention") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_optionDateFromTenor", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _p = Helper.toCell<Period> p "p" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".OptionDateFromTenor") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_calendar", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".Calendar") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonBlackVolSurface> format
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_dayCounter", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".DayCounter") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonBlackVolSurface> format
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_maxTime", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".MaxTime") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_referenceDate", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".ReferenceDate") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_settlementDays", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".SettlementDays") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_timeFromReference", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".TimeFromReference") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_update", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).Update
                                                       ) :> ICell
                let format (o : HestonBlackVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".Update") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_allowsExtrapolation", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".AllowsExtrapolation") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_disableExtrapolation", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : HestonBlackVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".DisableExtrapolation") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_enableExtrapolation", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : HestonBlackVolSurface) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".EnableExtrapolation") 
                                               [| _HestonBlackVolSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_extrapolate", Description="Create a HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonBlackVolSurface",Description = "Reference to HestonBlackVolSurface")>] 
         hestonblackvolsurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonBlackVolSurface = Helper.toCell<HestonBlackVolSurface> hestonblackvolsurface "HestonBlackVolSurface"  
                let builder () = withMnemonic mnemonic ((HestonBlackVolSurfaceModel.Cast _HestonBlackVolSurface.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HestonBlackVolSurface.source + ".Extrapolate") 
                                               [| _HestonBlackVolSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonBlackVolSurface.cell
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
    [<ExcelFunction(Name="_HestonBlackVolSurface_Range", Description="Create a range of HestonBlackVolSurface",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HestonBlackVolSurface_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HestonBlackVolSurface")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HestonBlackVolSurface> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HestonBlackVolSurface>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<HestonBlackVolSurface>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<HestonBlackVolSurface>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
