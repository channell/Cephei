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

  </summary> *)
[<AutoSerializable(true)>]
module InterpolatedCPICapFloorTermPriceSurfaceFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_capPrice", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_capPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="k",Description = "Reference to k")>] 
         k : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let _d = Helper.toCell<Date> d "d" 
                let _k = Helper.toCell<double> k "k" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).CapPrice
                                                            _d.cell 
                                                            _k.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".CapPrice") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               ;  _d.source
                                               ;  _k.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                ;  _d.cell
                                ;  _k.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_floorPrice", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_floorPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="k",Description = "Reference to k")>] 
         k : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let _d = Helper.toCell<Date> d "d" 
                let _k = Helper.toCell<double> k "k" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).FloorPrice
                                                            _d.cell 
                                                            _k.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".FloorPrice") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               ;  _d.source
                                               ;  _k.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                ;  _d.cell
                                ;  _k.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="startRate",Description = "Reference to startRate")>] 
         startRate : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="bdc",Description = "Reference to bdc")>] 
         bdc : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="zii",Description = "Reference to zii")>] 
         zii : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        ([<ExcelArgument(Name="cStrikes",Description = "Reference to cStrikes")>] 
         cStrikes : obj)
        ([<ExcelArgument(Name="fStrikes",Description = "Reference to fStrikes")>] 
         fStrikes : obj)
        ([<ExcelArgument(Name="cfMaturities",Description = "Reference to cfMaturities")>] 
         cfMaturities : obj)
        ([<ExcelArgument(Name="cPrice",Description = "Reference to cPrice")>] 
         cPrice : obj)
        ([<ExcelArgument(Name="fPrice",Description = "Reference to fPrice")>] 
         fPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startRate = Helper.toCell<double> startRate "startRate" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _bdc = Helper.toCell<BusinessDayConvention> bdc "bdc" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _zii = Helper.toHandle<ZeroInflationIndex> zii "zii" 
                let _yts = Helper.toHandle<YieldTermStructure> yts "yts" 
                let _cStrikes = Helper.toCell<Generic.List<double>> cStrikes "cStrikes" 
                let _fStrikes = Helper.toCell<Generic.List<double>> fStrikes "fStrikes" 
                let _cfMaturities = Helper.toCell<Generic.List<Period>> cfMaturities "cfMaturities" 
                let _cPrice = Helper.toCell<Matrix> cPrice "cPrice" 
                let _fPrice = Helper.toCell<Matrix> fPrice "fPrice" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InterpolatedCPICapFloorTermPriceSurface 
                                                            _nominal.cell 
                                                            _startRate.cell 
                                                            _observationLag.cell 
                                                            _cal.cell 
                                                            _bdc.cell 
                                                            _dc.cell 
                                                            _zii.cell 
                                                            _yts.cell 
                                                            _cStrikes.cell 
                                                            _fStrikes.cell 
                                                            _cfMaturities.cell 
                                                            _cPrice.cell 
                                                            _fPrice.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedCPICapFloorTermPriceSurface>) l

                let source () = Helper.sourceFold "Fun.InterpolatedCPICapFloorTermPriceSurface" 
                                               [| _nominal.source
                                               ;  _startRate.source
                                               ;  _observationLag.source
                                               ;  _cal.source
                                               ;  _bdc.source
                                               ;  _dc.source
                                               ;  _zii.source
                                               ;  _yts.source
                                               ;  _cStrikes.source
                                               ;  _fStrikes.source
                                               ;  _cfMaturities.source
                                               ;  _cPrice.source
                                               ;  _fPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _nominal.cell
                                ;  _startRate.cell
                                ;  _observationLag.cell
                                ;  _cal.cell
                                ;  _bdc.cell
                                ;  _dc.cell
                                ;  _zii.cell
                                ;  _yts.cell
                                ;  _cStrikes.cell
                                ;  _fStrikes.cell
                                ;  _cfMaturities.cell
                                ;  _cPrice.cell
                                ;  _fPrice.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedCPICapFloorTermPriceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! remember that the strikes use the quoting convention
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_price", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="k",Description = "Reference to k")>] 
         k : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let _d = Helper.toCell<Date> d "d" 
                let _k = Helper.toCell<double> k "k" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).Price
                                                            _d.cell 
                                                            _k.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".Price") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               ;  _d.source
                                               ;  _k.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                ;  _d.cell
                                ;  _k.cell
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
        LazyObject interface
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_update", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).Update
                                                       ) :> ICell
                let format (o : InterpolatedCPICapFloorTermPriceSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".Update") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_baseDate", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_baseDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).BaseDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".BaseDate") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_businessDayConvention", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".BusinessDayConvention") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_capPrices", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_capPrices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).CapPrices
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".CapPrices") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedCPICapFloorTermPriceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_capStrikes", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_capStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).CapStrikes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".CapStrikes") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_cpiOptionDateFromTenor", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_cpiOptionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let _p = Helper.toCell<Period> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).CpiOptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".CpiOptionDateFromTenor") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
        
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_floorPrices", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_floorPrices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).FloorPrices
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".FloorPrices") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedCPICapFloorTermPriceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_floorStrikes", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_floorStrikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).FloorStrikes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".FloorStrikes") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_maturities", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_maturities
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).Maturities
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".Maturities") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
        \TODO deal with index interpolation
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_maxDate", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".MaxDate") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_maxStrike", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".MaxStrike") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_minDate", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_minDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).MinDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".MinDate") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_minStrike", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".MinStrike") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
        ! \note you don't know if price() is a cap or a floor without checking the ZeroInflation ATM level.
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_nominal", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".Nominal") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
        InflationTermStructure interface
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_observationLag", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".ObservationLag") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedCPICapFloorTermPriceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_strikes", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_strikes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).Strikes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".Strikes") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
        ! is based on
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_zeroInflationIndex", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_zeroInflationIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).ZeroInflationIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationIndex>>) l

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".ZeroInflationIndex") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedCPICapFloorTermPriceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_baseRate", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_baseRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).BaseRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".BaseRate") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_frequency", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".Frequency") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_hasSeasonality", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_hasSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).HasSeasonality
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".HasSeasonality") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_indexIsInterpolated", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_indexIsInterpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).IndexIsInterpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".IndexIsInterpolated") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_nominalTermStructure", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_nominalTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).NominalTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".NominalTermStructure") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedCPICapFloorTermPriceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_seasonality", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_seasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).Seasonality
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Seasonality>) l

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".Seasonality") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedCPICapFloorTermPriceSurface> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Calling setSeasonality with no arguments means unsetting as the default is used to choose unsetting.
    *)
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_setSeasonality", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_setSeasonality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        ([<ExcelArgument(Name="seasonality",Description = "Reference to seasonality")>] 
         seasonality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let _seasonality = Helper.toCell<Seasonality> seasonality "seasonality" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).SetSeasonality
                                                            _seasonality.cell 
                                                       ) :> ICell
                let format (o : InterpolatedCPICapFloorTermPriceSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".SetSeasonality") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               ;  _seasonality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                ;  _seasonality.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_calendar", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".Calendar") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedCPICapFloorTermPriceSurface> format
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_dayCounter", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".DayCounter") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedCPICapFloorTermPriceSurface> format
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_maxTime", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".MaxTime") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_referenceDate", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".ReferenceDate") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_settlementDays", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".SettlementDays") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_timeFromReference", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".TimeFromReference") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_allowsExtrapolation", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".AllowsExtrapolation") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_disableExtrapolation", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedCPICapFloorTermPriceSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".DisableExtrapolation") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_enableExtrapolation", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let _b = Helper.toCell<bool> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : InterpolatedCPICapFloorTermPriceSurface) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".EnableExtrapolation") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_extrapolate", Description="Create a InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedCPICapFloorTermPriceSurface",Description = "Reference to InterpolatedCPICapFloorTermPriceSurface")>] 
         interpolatedcpicapfloortermpricesurface : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedCPICapFloorTermPriceSurface = Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> interpolatedcpicapfloortermpricesurface "InterpolatedCPICapFloorTermPriceSurface"  
                let builder (current : ICell) = withMnemonic mnemonic ((InterpolatedCPICapFloorTermPriceSurfaceModel.Cast _InterpolatedCPICapFloorTermPriceSurface.cell).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InterpolatedCPICapFloorTermPriceSurface.source + ".Extrapolate") 
                                               [| _InterpolatedCPICapFloorTermPriceSurface.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedCPICapFloorTermPriceSurface.cell
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
    [<ExcelFunction(Name="_InterpolatedCPICapFloorTermPriceSurface_Range", Description="Create a range of InterpolatedCPICapFloorTermPriceSurface",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InterpolatedCPICapFloorTermPriceSurface_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InterpolatedCPICapFloorTermPriceSurface")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedCPICapFloorTermPriceSurface> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InterpolatedCPICapFloorTermPriceSurface>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<InterpolatedCPICapFloorTermPriceSurface>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<InterpolatedCPICapFloorTermPriceSurface>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
