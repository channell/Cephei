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
  f(t) = [ a + b*t ] e^{-c*t} + d following Rebonato's notation.
  </summary> *)
[<AutoSerializable(true)>]
module AbcdMathFunctionFunction =

    (*
        ! Inspectors
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_a", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".A") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
    [<ExcelFunction(Name="_AbcdMathFunction", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="abcd",Description = "double range")>] 
         abcd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _abcd = Helper.toCell<Generic.List<double>> abcd "abcd" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AbcdMathFunction 
                                                            _abcd.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AbcdMathFunction>) l

                let source () = Helper.sourceFold "Fun.AbcdMathFunction" 
                                               [| _abcd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _abcd.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AbcdMathFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AbcdMathFunction1", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="a",Description = "double or empty")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double or empty")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "double or empty")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "double or empty")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _a = Helper.toDefault<double> a "a" 0.002
                let _b = Helper.toDefault<double> b "b" 0.001
                let _c = Helper.toDefault<double> c "c" 0.16
                let _d = Helper.toDefault<double> d "d" 0.0005
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AbcdMathFunction1 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AbcdMathFunction>) l

                let source () = Helper.sourceFold "Fun.AbcdMathFunction1" 
                                               [| _a.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _a.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AbcdMathFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_b", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).B
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".B") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
    [<ExcelFunction(Name="_AbcdMathFunction_c", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_c
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).C
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".C") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
    [<ExcelFunction(Name="_AbcdMathFunction_coefficients", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_coefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).Coefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".Coefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
    [<ExcelFunction(Name="_AbcdMathFunction_d", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_d
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).D
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".D") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
        ! coefficients of a AbcdMathFunction defined as definite derivative on a rolling window of length tau, with tau = t2-t
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_definiteDerivativeCoefficients", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_definiteDerivativeCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let _t = Helper.toCell<double> t "t" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).DefiniteDerivativeCoefficients
                                                            _t.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".DefiniteDerivativeCoefficients") 

                                               [| _t.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
    [<ExcelFunction(Name="_AbcdMathFunction_definiteIntegral", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_definiteIntegral
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        ([<ExcelArgument(Name="t1",Description = "double")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).DefiniteIntegral
                                                            _t1.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".DefiniteIntegral") 

                                               [| _t1.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
        ! coefficients of a AbcdMathFunction defined as definite integral on a rolling window of length tau, with tau = t2-t
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_definiteIntegralCoefficients", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_definiteIntegralCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="t2",Description = "double")>] 
         t2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let _t = Helper.toCell<double> t "t" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).DefiniteIntegralCoefficients
                                                            _t.cell 
                                                            _t2.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".DefiniteIntegralCoefficients") 

                                               [| _t.source
                                               ;  _t2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
        ! first derivative of the function at time t \f[ f'(t) = [ (b-c*a) + (-c*b)*t) ] e^{-c*t} \f]
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_derivative", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).Derivative
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".Derivative") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
    [<ExcelFunction(Name="_AbcdMathFunction_derivativeCoefficients", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_derivativeCoefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).DerivativeCoefficients
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".DerivativeCoefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
        ! function value at time +inf: \f[ f(\inf) \f]
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_longTermValue", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_longTermValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).LongTermValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".LongTermValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
        ! time at which the function reaches maximum (if any)
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_maximumLocation", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_maximumLocation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).MaximumLocation
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".MaximumLocation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
        ! maximum value of the function
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_maximumValue", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_maximumValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).MaximumValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".MaximumValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
        ! indefinite integral of the function at time t \f[ \int f(t)dt = [ (-a/c-b/c^2) + (-b/c)*t ] e^{-c*t} + d*t \f]
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_primitive", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).Primitive
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".Primitive") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
        ! function value at time t: \f[ f(t) \f]
    *)
    [<ExcelFunction(Name="_AbcdMathFunction_value", Description="Create a AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdMathFunction",Description = "AbcdMathFunction")>] 
         abcdmathfunction : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdMathFunction = Helper.toCell<AbcdMathFunction> abcdmathfunction "AbcdMathFunction"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdMathFunctionModel.Cast _AbcdMathFunction.cell).Value
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AbcdMathFunction.source + ".Value") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdMathFunction.cell
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
    [<ExcelFunction(Name="_AbcdMathFunction_Range", Description="Create a range of AbcdMathFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AbcdMathFunction_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AbcdMathFunction> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AbcdMathFunction> (c)) :> ICell
                let format (i : Cephei.Cell.List<AbcdMathFunction>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AbcdMathFunction>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
