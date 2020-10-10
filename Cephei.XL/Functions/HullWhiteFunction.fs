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
module HullWhiteFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HullWhite_discountBondOption", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_discountBondOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
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

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _bondMaturity = Helper.toCell<double> bondMaturity "bondMaturity" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).DiscountBondOption
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _maturity.cell 
                                                            _bondMaturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".DiscountBondOption") 
                                               [| _HullWhite.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _maturity.source
                                               ;  _bondMaturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _Type.cell
                                ;  _strike.cell
                                ;  _maturity.cell
                                ;  _bondMaturity.cell
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
    [<ExcelFunction(Name="_HullWhite_dynamics", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_dynamics
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Dynamics
                                                       ) :> ICell
                let format (o : OneFactorModel.ShortRateDynamics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".Dynamics") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
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
    [<ExcelFunction(Name="_HullWhite", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.HullWhite 
                                                            _termStructure.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HullWhite>) l

                let source () = Helper.sourceFold "Fun.HullWhite" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhite2", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_create2
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.HullWhite2
                                                            _termStructure.cell 
                                                            _a.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HullWhite>) l

                let source () = Helper.sourceFold "Fun.HullWhite2" 
                                               [| _termStructure.source
                                               ;  _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                ;  _a.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhite1", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.HullWhite1
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HullWhite>) l

                let source () = Helper.sourceFold "Fun.HullWhite1" 
                                               [| _termStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _termStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhite_termStructure", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_termStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).TermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_HullWhite.source + ".TermStructure") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhite_termStructure_", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_termStructure_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).TermStructure_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_HullWhite.source + ".TermStructure_") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhite_tree", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_tree
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _grid = Helper.toCell<TimeGrid> grid "grid" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Tree
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_HullWhite.source + ".Tree") 
                                               [| _HullWhite.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhite_a", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".A") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
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
    [<ExcelFunction(Name="_HullWhite_b", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".B") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
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
    [<ExcelFunction(Name="_HullWhite_lambda", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_lambda
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Lambda
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".Lambda") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
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
    [<ExcelFunction(Name="_HullWhite_sigma", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".Sigma") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
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
    [<ExcelFunction(Name="_HullWhite_discount", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Discount
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".Discount") 
                                               [| _HullWhite.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_HullWhite_discountBond1", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_discountBond1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        ([<ExcelArgument(Name="now",Description = "Reference to now")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _now = Helper.toCell<double> now "now" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _rate = Helper.toCell<double> rate "rate" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).DiscountBond1
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _rate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".DiscountBond1") 
                                               [| _HullWhite.source
                                               ;  _now.source
                                               ;  _maturity.source
                                               ;  _rate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _now.cell
                                ;  _maturity.cell
                                ;  _rate.cell
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
    [<ExcelFunction(Name="_HullWhite_discountBond", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_discountBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        ([<ExcelArgument(Name="now",Description = "Reference to now")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="factors",Description = "Reference to factors")>] 
         factors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _now = Helper.toCell<double> now "now" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _factors = Helper.toCell<Vector> factors "factors" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).DiscountBond
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _factors.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".DiscountBond") 
                                               [| _HullWhite.source
                                               ;  _now.source
                                               ;  _maturity.source
                                               ;  _factors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _now.cell
                                ;  _maturity.cell
                                ;  _factors.cell
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
        ! An additional constraint can be passed which must be satisfied in addition to the constraints of the model.
    *)
    [<ExcelFunction(Name="_HullWhite_calibrate", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
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

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" 
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" 
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : HullWhite) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".Calibrate") 
                                               [| _HullWhite.source
                                               ;  _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _instruments.cell
                                ;  _Method.cell
                                ;  _endCriteria.cell
                                ;  _additionalConstraint.cell
                                ;  _weights.cell
                                ;  _fixParameters.cell
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
    [<ExcelFunction(Name="_HullWhite_constraint", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source () = Helper.sourceFold (_HullWhite.source + ".CONSTRAINT") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhite_endCriteria", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".EndCriteria") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
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
    [<ExcelFunction(Name="_HullWhite_notifyObservers", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).NotifyObservers
                                                       ) :> ICell
                let format (o : HullWhite) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".NotifyObservers") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
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
        ! Returns array of arguments on which calibration is done
    *)
    [<ExcelFunction(Name="_HullWhite_parameters", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HullWhite.source + ".Parameters") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhite_registerWith", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HullWhite) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".RegisterWith") 
                                               [| _HullWhite.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_HullWhite_setParams", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : HullWhite) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".SetParams") 
                                               [| _HullWhite.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _parameters.cell
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
    [<ExcelFunction(Name="_HullWhite_unregisterWith", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HullWhite) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".UnregisterWith") 
                                               [| _HullWhite.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_HullWhite_update", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Update
                                                       ) :> ICell
                let format (o : HullWhite) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".Update") 
                                               [| _HullWhite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
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
    [<ExcelFunction(Name="_HullWhite_value", Description="Create a HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhite",Description = "Reference to HullWhite")>] 
         hullwhite : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhite = Helper.toCell<HullWhite> hullwhite "HullWhite"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteModel.Cast _HullWhite.cell).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhite.source + ".Value") 
                                               [| _HullWhite.source
                                               ;  _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhite.cell
                                ;  _parameters.cell
                                ;  _instruments.cell
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
    [<ExcelFunction(Name="_HullWhite_Range", Description="Create a range of HullWhite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhite_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HullWhite")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HullWhite> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HullWhite>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<HullWhite>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<HullWhite>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
