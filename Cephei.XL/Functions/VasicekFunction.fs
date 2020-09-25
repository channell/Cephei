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
module VasicekFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Vasicek_a", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".A") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_b", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".B") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_discountBondOption", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_discountBondOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
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

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _maturity = Helper.toCell<double> maturity "maturity" true
                let _bondMaturity = Helper.toCell<double> bondMaturity "bondMaturity" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).DiscountBondOption
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _maturity.cell 
                                                            _bondMaturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".DiscountBondOption") 
                                               [| _Vasicek.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _maturity.source
                                               ;  _bondMaturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_dynamics", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_dynamics
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Dynamics
                                                       ) :> ICell
                let format (o : OneFactorModel.ShortRateDynamics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".Dynamics") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_lambda", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_lambda
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Lambda
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".Lambda") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_sigma", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".Sigma") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="r0",Description = "Reference to r0")>] 
         r0 : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="lambda",Description = "Reference to lambda")>] 
         lambda : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _r0 = Helper.toCell<double> r0 "r0" true
                let _a = Helper.toCell<double> a "a" true
                let _b = Helper.toCell<double> b "b" true
                let _sigma = Helper.toCell<double> sigma "sigma" true
                let _lambda = Helper.toCell<double> lambda "lambda" true
                let builder () = withMnemonic mnemonic (Fun.Vasicek 
                                                            _r0.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _sigma.cell 
                                                            _lambda.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vasicek>) l

                let source = Helper.sourceFold "Fun.Vasicek" 
                                               [| _r0.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _sigma.source
                                               ;  _lambda.source
                                               |]
                let hash = Helper.hashFold 
                                [| _r0.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _sigma.cell
                                ;  _lambda.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vasicek_discount", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Discount
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".Discount") 
                                               [| _Vasicek.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_discountBond1", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_discountBond1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="now",Description = "Reference to now")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _now = Helper.toCell<double> now "now" true
                let _maturity = Helper.toCell<double> maturity "maturity" true
                let _rate = Helper.toCell<double> rate "rate" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).DiscountBond1
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _rate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".DiscountBond1") 
                                               [| _Vasicek.source
                                               ;  _now.source
                                               ;  _maturity.source
                                               ;  _rate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _now.cell
                                ;  _maturity.cell
                                ;  _rate.cell
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
    [<ExcelFunction(Name="_Vasicek_discountBond", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_discountBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="now",Description = "Reference to now")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="factors",Description = "Reference to factors")>] 
         factors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _now = Helper.toCell<double> now "now" true
                let _maturity = Helper.toCell<double> maturity "maturity" true
                let _factors = Helper.toCell<Vector> factors "factors" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).DiscountBond
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _factors.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".DiscountBond") 
                                               [| _Vasicek.source
                                               ;  _now.source
                                               ;  _maturity.source
                                               ;  _factors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
        ! Return by default a trinomial recombining tree
    *)
    [<ExcelFunction(Name="_Vasicek_tree", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_tree
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _grid = Helper.toCell<TimeGrid> grid "grid" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Tree
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_Vasicek.source + ".Tree") 
                                               [| _Vasicek.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_Vasicek_calibrate", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
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

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" true
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" true
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" true
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" true
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" true
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".Calibrate") 
                                               [| _Vasicek.source
                                               ;  _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_constraint", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_Vasicek.source + ".CONSTRAINT") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vasicek_endCriteria", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".EndCriteria") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_notifyObservers", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).NotifyObservers
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".NotifyObservers") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_parameters", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Vasicek.source + ".Parameters") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vasicek_registerWith", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".RegisterWith") 
                                               [| _Vasicek.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_setParams", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".SetParams") 
                                               [| _Vasicek.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_unregisterWith", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".UnregisterWith") 
                                               [| _Vasicek.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_update", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Update
                                                       ) :> ICell
                let format (o : Vasicek) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".Update") 
                                               [| _Vasicek.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_value", Description="Create a Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vasicek",Description = "Reference to Vasicek")>] 
         vasicek : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vasicek = Helper.toCell<Vasicek> vasicek "Vasicek" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" true
                let builder () = withMnemonic mnemonic ((_Vasicek.cell :?> VasicekModel).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Vasicek.source + ".Value") 
                                               [| _Vasicek.source
                                               ;  _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vasicek.cell
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
    [<ExcelFunction(Name="_Vasicek_Range", Description="Create a range of Vasicek",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Vasicek_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Vasicek")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Vasicek> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Vasicek>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Vasicek>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Vasicek>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
