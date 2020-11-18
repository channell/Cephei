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
  f(t) = t^i}
  </summary> *)
[<AutoSerializable(true)>]
module PolynomialFunctionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PolynomialFunction_coefficients", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_coefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).Coefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".Coefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
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
        ! coefficients of a PolynomialFunction defined as definite derivative on a rolling window of length tau, with tau = t2-t
    *)
    [<ExcelFunction(Name="_PolynomialFunction_definiteDerivativeCoefficients", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_definiteDerivativeCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let _t = Helper.toCell<double> t "t" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).DefiniteDerivativeCoefficients
                                                            _t.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".DefiniteDerivativeCoefficients") 

                                               [| _t.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
                                ;  _t.cell
                                ;  _t2.cell
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
        ! definite integral of the function between t1 and t2 \f[ \int_{t1}^{t2} f(t)dt \f]
    *)
    [<ExcelFunction(Name="_PolynomialFunction_definiteIntegral", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_definiteIntegral
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        ([<ExcelArgument(Name="t1",Description = "double")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).DefiniteIntegral
                                                            _t1.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".DefiniteIntegral") 

                                               [| _t1.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
                                ;  _t1.cell
                                ;  _t2.cell
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
        ! coefficients of a PolynomialFunction defined as definite integral on a rolling window of length tau, with tau = t2-t
    *)
    [<ExcelFunction(Name="_PolynomialFunction_definiteIntegralCoefficients", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_definiteIntegralCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let _t = Helper.toCell<double> t "t" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).DefiniteIntegralCoefficients
                                                            _t.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".DefiniteIntegralCoefficients") 

                                               [| _t.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
                                ;  _t.cell
                                ;  _t2.cell
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
        ! first derivative of the function at time t \f[ f'(t) = \sum_{i=0}^{n-1}{(i+1) c_{i+1} t^i} \f]
    *)
    [<ExcelFunction(Name="_PolynomialFunction_derivative", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).Derivative
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".Derivative") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
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
    [<ExcelFunction(Name="_PolynomialFunction_derivativeCoefficients", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_derivativeCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).DerivativeCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".DerivativeCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
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
        ! Inspectors
    *)
    [<ExcelFunction(Name="_PolynomialFunction_order", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_order
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).Order
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".Order") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
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
    [<ExcelFunction(Name="_PolynomialFunction", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="coeff",Description = "double range")>] 
         coeff : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _coeff = Helper.toCell<Generic.List<double>> coeff "coeff" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PolynomialFunction 
                                                            _coeff.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PolynomialFunction>) l

                let source () = Helper.sourceFold "Fun.PolynomialFunction" 
                                               [| _coeff.source
                                               |]
                let hash = Helper.hashFold 
                                [| _coeff.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PolynomialFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! indefinite integral of the function at time t \f[ \int f(t)dt = \sum_{i=0}^n{c_i t^{i+1} / (i+1)} + K \f]
    *)
    [<ExcelFunction(Name="_PolynomialFunction_primitive", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).Primitive
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".Primitive") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
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
    [<ExcelFunction(Name="_PolynomialFunction_primitiveCoefficients", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_primitiveCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).PrimitiveCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".PrimitiveCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
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
        ! function value at time t: \f[ f(t) = \sum_{i=0}^n{c_i t^i} \f]
    *)
    [<ExcelFunction(Name="_PolynomialFunction_value", Description="Create a PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PolynomialFunction",Description = "PolynomialFunction")>] 
         polynomialfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PolynomialFunction = Helper.toCell<PolynomialFunction> polynomialfunction "PolynomialFunction"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PolynomialFunctionModel.Cast _PolynomialFunction.cell).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PolynomialFunction.source + ".Value") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PolynomialFunction.cell
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
    [<ExcelFunction(Name="_PolynomialFunction_Range", Description="Create a range of PolynomialFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PolynomialFunction_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PolynomialFunction> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<PolynomialFunction> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<PolynomialFunction>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PolynomialFunction>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
