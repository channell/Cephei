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
  Non-linear least-square method.   Using a given optimization algorithm (default is conjugate gradient),  min r(x) : x in R^n  where r(x) = |f(x)|^2 is the Euclidean norm of f(x) for some vector-valued function f from R^n to R^m f = (f_1, ..., f_m) with f_i(x) = b_i - where b is the vector of target data and phi is a scalar function.  Assuming the differentiability of f the gradient of r is defined by grad r(x) = f'(x)^t.f(x)
  </summary> *)
[<AutoSerializable(true)>]
module NonLinearLeastSquareFunction =

    (*
        ! return exit flag
    *)
    [<ExcelFunction(Name="_NonLinearLeastSquare_exitFlag", Description="Create a NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_exitFlag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonLinearLeastSquare",Description = "Reference to NonLinearLeastSquare")>] 
         nonlinearleastsquare : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonLinearLeastSquare = Helper.toCell<NonLinearLeastSquare> nonlinearleastsquare "NonLinearLeastSquare"  
                let builder () = withMnemonic mnemonic ((NonLinearLeastSquareModel.Cast _NonLinearLeastSquare.cell).ExitFlag
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NonLinearLeastSquare.source + ".ExitFlag") 
                                               [| _NonLinearLeastSquare.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonLinearLeastSquare.cell
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
        ! return last function value
    *)
    [<ExcelFunction(Name="_NonLinearLeastSquare_lastValue", Description="Create a NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_lastValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonLinearLeastSquare",Description = "Reference to NonLinearLeastSquare")>] 
         nonlinearleastsquare : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonLinearLeastSquare = Helper.toCell<NonLinearLeastSquare> nonlinearleastsquare "NonLinearLeastSquare"  
                let builder () = withMnemonic mnemonic ((NonLinearLeastSquareModel.Cast _NonLinearLeastSquare.cell).LastValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NonLinearLeastSquare.source + ".LastValue") 
                                               [| _NonLinearLeastSquare.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonLinearLeastSquare.cell
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
        ! Default constructor
    *)
    [<ExcelFunction(Name="_NonLinearLeastSquare1", Description="Create a NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c = Helper.toCell<Constraint> c "c" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder () = withMnemonic mnemonic (Fun.NonLinearLeastSquare1 
                                                            _c.cell 
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NonLinearLeastSquare>) l

                let source = Helper.sourceFold "Fun.NonLinearLeastSquare1" 
                                               [| _c.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c.cell
                                ;  _accuracy.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NonLinearLeastSquare> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Default constructor
    *)
    [<ExcelFunction(Name="_NonLinearLeastSquare", Description="Create a NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxiter",Description = "Reference to maxiter")>] 
         maxiter : obj)
        ([<ExcelArgument(Name="om",Description = "Reference to om")>] 
         om : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c = Helper.toCell<Constraint> c "c" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxiter = Helper.toCell<int> maxiter "maxiter" 
                let _om = Helper.toCell<OptimizationMethod> om "om" 
                let builder () = withMnemonic mnemonic (Fun.NonLinearLeastSquare
                                                            _c.cell 
                                                            _accuracy.cell 
                                                            _maxiter.cell 
                                                            _om.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NonLinearLeastSquare>) l

                let source = Helper.sourceFold "Fun.NonLinearLeastSquare" 
                                               [| _c.source
                                               ;  _accuracy.source
                                               ;  _maxiter.source
                                               ;  _om.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c.cell
                                ;  _accuracy.cell
                                ;  _maxiter.cell
                                ;  _om.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NonLinearLeastSquare> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NonLinearLeastSquare3", Description="Create a NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c = Helper.toCell<Constraint> c "c" 
                let builder () = withMnemonic mnemonic (Fun.NonLinearLeastSquare3
                                                            _c.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NonLinearLeastSquare>) l

                let source = Helper.sourceFold "Fun.NonLinearLeastSquare3" 
                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NonLinearLeastSquare> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NonLinearLeastSquare2", Description="Create a NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxiter",Description = "Reference to maxiter")>] 
         maxiter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c = Helper.toCell<Constraint> c "c" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxiter = Helper.toCell<int> maxiter "maxiter" 
                let builder () = withMnemonic mnemonic (Fun.NonLinearLeastSquare2
                                                            _c.cell 
                                                            _accuracy.cell 
                                                            _maxiter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NonLinearLeastSquare>) l

                let source = Helper.sourceFold "Fun.NonLinearLeastSquare2" 
                                               [| _c.source
                                               ;  _accuracy.source
                                               ;  _maxiter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c.cell
                                ;  _accuracy.cell
                                ;  _maxiter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NonLinearLeastSquare> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Solve least square problem using numerix solver
    *)
    [<ExcelFunction(Name="_NonLinearLeastSquare_perform", Description="Create a NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_perform
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonLinearLeastSquare",Description = "Reference to NonLinearLeastSquare")>] 
         nonlinearleastsquare : obj)
        ([<ExcelArgument(Name="lsProblem",Description = "Reference to lsProblem")>] 
         lsProblem : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonLinearLeastSquare = Helper.toCell<NonLinearLeastSquare> nonlinearleastsquare "NonLinearLeastSquare"  
                let _lsProblem = Helper.toCell<LeastSquareProblem> lsProblem "lsProblem" 
                let builder () = withMnemonic mnemonic ((NonLinearLeastSquareModel.Cast _NonLinearLeastSquare.cell).Perform
                                                            _lsProblem.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NonLinearLeastSquare.source + ".Perform") 
                                               [| _NonLinearLeastSquare.source
                                               ;  _lsProblem.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonLinearLeastSquare.cell
                                ;  _lsProblem.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NonLinearLeastSquare> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! return the least square residual norm
    *)
    [<ExcelFunction(Name="_NonLinearLeastSquare_residualNorm", Description="Create a NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_residualNorm
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonLinearLeastSquare",Description = "Reference to NonLinearLeastSquare")>] 
         nonlinearleastsquare : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonLinearLeastSquare = Helper.toCell<NonLinearLeastSquare> nonlinearleastsquare "NonLinearLeastSquare"  
                let builder () = withMnemonic mnemonic ((NonLinearLeastSquareModel.Cast _NonLinearLeastSquare.cell).ResidualNorm
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NonLinearLeastSquare.source + ".ResidualNorm") 
                                               [| _NonLinearLeastSquare.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonLinearLeastSquare.cell
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
    [<ExcelFunction(Name="_NonLinearLeastSquare_setInitialValue", Description="Create a NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_setInitialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonLinearLeastSquare",Description = "Reference to NonLinearLeastSquare")>] 
         nonlinearleastsquare : obj)
        ([<ExcelArgument(Name="initialValue",Description = "Reference to initialValue")>] 
         initialValue : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonLinearLeastSquare = Helper.toCell<NonLinearLeastSquare> nonlinearleastsquare "NonLinearLeastSquare"  
                let _initialValue = Helper.toCell<Vector> initialValue "initialValue" 
                let builder () = withMnemonic mnemonic ((NonLinearLeastSquareModel.Cast _NonLinearLeastSquare.cell).SetInitialValue
                                                            _initialValue.cell 
                                                       ) :> ICell
                let format (o : NonLinearLeastSquare) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NonLinearLeastSquare.source + ".SetInitialValue") 
                                               [| _NonLinearLeastSquare.source
                                               ;  _initialValue.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonLinearLeastSquare.cell
                                ;  _initialValue.cell
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
    [<ExcelFunction(Name="_NonLinearLeastSquare_Range", Description="Create a range of NonLinearLeastSquare",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NonLinearLeastSquare_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NonLinearLeastSquare")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NonLinearLeastSquare> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NonLinearLeastSquare>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NonLinearLeastSquare>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NonLinearLeastSquare>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
