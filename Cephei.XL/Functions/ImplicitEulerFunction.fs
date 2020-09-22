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
(*!! generic
(* <summary>
  In this implementation, the passed operator must be derived from either TimeConstantOperator or TimeDependentOperator. Also, it must implement at least the following interface:  copy constructor/assignment (these will be provided by the compiler if none is defined) Operator(const Operator&); Operator& operator=(const Operator&);  inspectors Size size();  modifiers void setTime(Time t);  operator interface array_type solveFor(const array_type&); static Operator identity(Size size);  operator algebra Operator operator*(Real, const Operator&); Operator operator+(const Operator&, const Operator&);  findiff
  </summary> *)
[<AutoSerializable(true)>]
module ImplicitEulerFunction =

    (*
        constructors
    *)
    [<ExcelFunction(Name="_ImplicitEuler", Description="Create a ImplicitEuler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEuler_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ImplicitEuler 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImplicitEuler>) l

                let source = Helper.sourceFold "Fun.ImplicitEuler" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
        required for generics
    *)
    [<ExcelFunction(Name="_ImplicitEuler1", Description="Create a ImplicitEuler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEuler_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        ([<ExcelArgument(Name="bcs",Description = "Reference to bcs")>] 
         bcs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _L = Helper.toCell<'Operator> L "L" true
                let _bcs = Helper.toCell<Generic.List<BoundaryCondition<IOperator>>> bcs "bcs" true
                let builder () = withMnemonic mnemonic (Fun.ImplicitEuler1 
                                                            _L.cell 
                                                            _bcs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImplicitEuler>) l

                let source = Helper.sourceFold "Fun.ImplicitEuler1" 
                                               [| _L.source
                                               ;  _bcs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _L.cell
                                ;  _bcs.cell
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
    [<ExcelFunction(Name="_ImplicitEuler_setStep", Description="Create a ImplicitEuler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEuler_setStep
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEuler",Description = "Reference to ImplicitEuler")>] 
         impliciteuler : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEuler = Helper.toCell<ImplicitEuler> impliciteuler "ImplicitEuler" true 
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_ImplicitEuler.cell :?> ImplicitEulerModel).SetStep
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : ImplicitEuler) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ImplicitEuler.source + ".SetStep") 
                                               [| _ImplicitEuler.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImplicitEuler.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_ImplicitEuler_step", Description="Create a ImplicitEuler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEuler_step
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImplicitEuler",Description = "Reference to ImplicitEuler")>] 
         impliciteuler : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImplicitEuler = Helper.toCell<ImplicitEuler> impliciteuler "ImplicitEuler" true 
                let _o = Helper.toCell<Object> o "o" true
                let _t = Helper.toCell<double> t "t" true
                let _theta = Helper.toCell<double> theta "theta" true
                let builder () = withMnemonic mnemonic ((_ImplicitEuler.cell :?> ImplicitEulerModel).Step
                                                            _o.cell 
                                                            _t.cell 
                                                            _theta.cell 
                                                       ) :> ICell
                let format (o : ImplicitEuler) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ImplicitEuler.source + ".Step") 
                                               [| _ImplicitEuler.source
                                               ;  _o.source
                                               ;  _t.source
                                               ;  _theta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImplicitEuler.cell
                                ;  _o.cell
                                ;  _t.cell
                                ;  _theta.cell
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
    [<ExcelFunction(Name="_ImplicitEuler_Range", Description="Create a range of ImplicitEuler",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImplicitEuler_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ImplicitEuler")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ImplicitEuler> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ImplicitEuler>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ImplicitEuler>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ImplicitEuler>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)