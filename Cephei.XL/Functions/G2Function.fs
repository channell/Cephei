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
  This class implements a two-additive-factor model defined by dr_t = + x_t + y_t where x_t and y_t are defined by dx_t = -a x_t dt + dW^1_t, x_0 = 0 dy_t = -b y_t dt + dW^2_t, y_0 = 0 and dW^1_t dW^2_t = dt  This class was not tested enough to guarantee its functionality.  shortrate
  </summary> *)
[<AutoSerializable(true)>]
module G2Function =

    (*
        
    *)
    [<ExcelFunction(Name="_G2_discount", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).Discount
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_G2.source + ".Discount") 
                                               [| _G2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_G2_discountBond1", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_discountBond1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="T2",Description = "Reference to T2")>] 
         T2 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _t = Helper.toCell<double> t "t" 
                let _T2 = Helper.toCell<double> T2 "T2" 
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).DiscountBond1
                                                            _t.cell 
                                                            _T2.cell 
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_G2.source + ".DiscountBond1") 
                                               [| _G2.source
                                               ;  _t.source
                                               ;  _T2.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _t.cell
                                ;  _T2.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_G2_discountBond", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_discountBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="now",Description = "Reference to now")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="factors",Description = "Reference to factors")>] 
         factors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _now = Helper.toCell<double> now "now" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _factors = Helper.toCell<Vector> factors "factors" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).DiscountBond
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _factors.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_G2.source + ".DiscountBond") 
                                               [| _G2.source
                                               ;  _now.source
                                               ;  _maturity.source
                                               ;  _factors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _now.cell
                                ;  _maturity.cell
                                ;  _factors.cell
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
    [<ExcelFunction(Name="_G2_discountBondOption", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_discountBondOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="bondMaturity",Description = "Reference to bondMaturity")>] 
         bondMaturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _bondMaturity = Helper.toCell<double> bondMaturity "bondMaturity" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).DiscountBondOption
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _maturity.cell 
                                                            _bondMaturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_G2.source + ".DiscountBondOption") 
                                               [| _G2.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _maturity.source
                                               ;  _bondMaturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _Type.cell
                                ;  _strike.cell
                                ;  _maturity.cell
                                ;  _bondMaturity.cell
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
    [<ExcelFunction(Name="_G2_dynamics", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_dynamics
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).Dynamics
                                                       ) :> ICell
                let format (o : OneFactorModel.ShortRateDynamics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2.source + ".Dynamics") 
                                               [| _G2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
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
    [<ExcelFunction(Name="_G25", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _a = Helper.toCell<double> a "a" 
                let builder () = withMnemonic mnemonic (Fun.G25
                                                            _termStructure.cell 
                                                            _a.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<G2>) l

                let source = Helper.sourceFold "Fun.G25" 
                                               [| _termStructure.source
                                               ;  _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                ;  _a.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G23", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="eta",Description = "Reference to eta")>] 
         eta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _a = Helper.toCell<double> a "a" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _b = Helper.toCell<double> b "b" 
                let _eta = Helper.toCell<double> eta "eta" 
                let builder () = withMnemonic mnemonic (Fun.G23
                                                            _termStructure.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                            _b.cell 
                                                            _eta.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<G2>) l

                let source = Helper.sourceFold "Fun.G23" 
                                               [| _termStructure.source
                                               ;  _a.source
                                               ;  _sigma.source
                                               ;  _b.source
                                               ;  _eta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                ;  _a.cell
                                ;  _sigma.cell
                                ;  _b.cell
                                ;  _eta.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G22", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _a = Helper.toCell<double> a "a" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let builder () = withMnemonic mnemonic (Fun.G22 
                                                            _termStructure.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<G2>) l

                let source = Helper.sourceFold "Fun.G22" 
                                               [| _termStructure.source
                                               ;  _a.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                ;  _a.cell
                                ;  _sigma.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G2", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _a = Helper.toCell<double> a "a" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _b = Helper.toCell<double> b "b" 
                let builder () = withMnemonic mnemonic (Fun.G2
                                                            _termStructure.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<G2>) l

                let source = Helper.sourceFold "Fun.G2" 
                                               [| _termStructure.source
                                               ;  _a.source
                                               ;  _sigma.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                ;  _a.cell
                                ;  _sigma.cell
                                ;  _b.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G24", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="eta",Description = "Reference to eta")>] 
         eta : obj)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _a = Helper.toCell<double> a "a" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _b = Helper.toCell<double> b "b" 
                let _eta = Helper.toCell<double> eta "eta" 
                let _rho = Helper.toCell<double> rho "rho" 
                let builder () = withMnemonic mnemonic (Fun.G24 
                                                            _termStructure.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                            _b.cell 
                                                            _eta.cell 
                                                            _rho.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<G2>) l

                let source = Helper.sourceFold "Fun.G24" 
                                               [| _termStructure.source
                                               ;  _a.source
                                               ;  _sigma.source
                                               ;  _b.source
                                               ;  _eta.source
                                               ;  _rho.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                ;  _a.cell
                                ;  _sigma.cell
                                ;  _b.cell
                                ;  _eta.cell
                                ;  _rho.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G21", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let builder () = withMnemonic mnemonic (Fun.G21
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<G2>) l

                let source = Helper.sourceFold "Fun.G21" 
                                               [| _termStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G2_swaption", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_swaption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="arguments",Description = "Reference to arguments")>] 
         arguments : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="range",Description = "Reference to range")>] 
         range : obj)
        ([<ExcelArgument(Name="intervals",Description = "Reference to intervals")>] 
         intervals : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _arguments = Helper.toCell<Swaption.Arguments> arguments "arguments" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _range = Helper.toCell<double> range "range" 
                let _intervals = Helper.toCell<int> intervals "intervals" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).Swaption
                                                            _arguments.cell 
                                                            _fixedRate.cell 
                                                            _range.cell 
                                                            _intervals.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_G2.source + ".Swaption") 
                                               [| _G2.source
                                               ;  _arguments.source
                                               ;  _fixedRate.source
                                               ;  _range.source
                                               ;  _intervals.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _arguments.cell
                                ;  _fixedRate.cell
                                ;  _range.cell
                                ;  _intervals.cell
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
    [<ExcelFunction(Name="_G2_termStructure", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_termStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).TermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_G2.source + ".TermStructure") 
                                               [| _G2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G2_termStructure_", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_termStructure_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).TermStructure_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_G2.source + ".TermStructure_") 
                                               [| _G2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G2_tree", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_tree
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _grid = Helper.toCell<TimeGrid> grid "grid" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).Tree
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_G2.source + ".Tree") 
                                               [| _G2.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! An additional constraint can be passed which must be satisfied in addition to the constraints of the model.
    *)
    [<ExcelFunction(Name="_G2_calibrate", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="additionalConstraint",Description = "Reference to additionalConstraint")>] 
         additionalConstraint : obj)
        ([<ExcelArgument(Name="weights",Description = "Reference to weights")>] 
         weights : obj)
        ([<ExcelArgument(Name="fixParameters",Description = "Reference to fixParameters")>] 
         fixParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" 
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" 
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : G2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2.source + ".Calibrate") 
                                               [| _G2.source
                                               ;  _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _instruments.cell
                                ;  _Method.cell
                                ;  _endCriteria.cell
                                ;  _additionalConstraint.cell
                                ;  _weights.cell
                                ;  _fixParameters.cell
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
    [<ExcelFunction(Name="_G2_constraint", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_G2.source + ".CONSTRAINT") 
                                               [| _G2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G2_endCriteria", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2.source + ".EndCriteria") 
                                               [| _G2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
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
    [<ExcelFunction(Name="_G2_notifyObservers", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).NotifyObservers
                                                       ) :> ICell
                let format (o : G2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2.source + ".NotifyObservers") 
                                               [| _G2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
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
        ! Returns array of arguments on which calibration is done
    *)
    [<ExcelFunction(Name="_G2_parameters", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_G2.source + ".Parameters") 
                                               [| _G2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<G2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_G2_registerWith", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : G2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2.source + ".RegisterWith") 
                                               [| _G2.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_G2_setParams", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : G2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2.source + ".SetParams") 
                                               [| _G2.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _parameters.cell
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
    [<ExcelFunction(Name="_G2_unregisterWith", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : G2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2.source + ".UnregisterWith") 
                                               [| _G2.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_G2_update", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).Update
                                                       ) :> ICell
                let format (o : G2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_G2.source + ".Update") 
                                               [| _G2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
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
    [<ExcelFunction(Name="_G2_value", Description="Create a G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="G2",Description = "Reference to G2")>] 
         g2 : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _G2 = Helper.toCell<G2> g2 "G2"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let builder () = withMnemonic mnemonic ((G2Model.Cast _G2.cell).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_G2.source + ".Value") 
                                               [| _G2.source
                                               ;  _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _G2.cell
                                ;  _parameters.cell
                                ;  _instruments.cell
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
    [<ExcelFunction(Name="_G2_Range", Description="Create a range of G2",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let G2_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the G2")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<G2> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<G2>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<G2>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<G2>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
