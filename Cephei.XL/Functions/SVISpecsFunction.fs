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
module SVISpecsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SVISpecs_defaultValues", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_defaultValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        ([<ExcelArgument(Name="param",Description = "Reference to param")>] 
         param : obj)
        ([<ExcelArgument(Name="paramIsFixed",Description = "Reference to paramIsFixed")>] 
         paramIsFixed : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="expiryTime",Description = "Reference to expiryTime")>] 
         expiryTime : obj)
        ([<ExcelArgument(Name="addParams",Description = "Reference to addParams")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let _param = Helper.toCell<Generic.List<Nullable<double>>> param "param" 
                let _paramIsFixed = Helper.toCell<Generic.List<bool>> paramIsFixed "paramIsFixed" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _expiryTime = Helper.toCell<double> expiryTime "expiryTime" 
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" 
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).DefaultValues
                                                            _param.cell 
                                                            _paramIsFixed.cell 
                                                            _forward.cell 
                                                            _expiryTime.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (o : SVISpecs) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SVISpecs.source + ".DefaultValues") 
                                               [| _SVISpecs.source
                                               ;  _param.source
                                               ;  _paramIsFixed.source
                                               ;  _forward.source
                                               ;  _expiryTime.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
                                ;  _param.cell
                                ;  _paramIsFixed.cell
                                ;  _forward.cell
                                ;  _expiryTime.cell
                                ;  _addParams.cell
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
    [<ExcelFunction(Name="_SVISpecs_dilationFactor", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_dilationFactor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).DilationFactor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SVISpecs.source + ".DilationFactor") 
                                               [| _SVISpecs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
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
    [<ExcelFunction(Name="_SVISpecs_dimension", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_dimension
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).Dimension
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SVISpecs.source + ".Dimension") 
                                               [| _SVISpecs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
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
    [<ExcelFunction(Name="_SVISpecs_direct", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_direct
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="paramIsFixed",Description = "Reference to paramIsFixed")>] 
         paramIsFixed : obj)
        ([<ExcelArgument(Name="param",Description = "Reference to param")>] 
         param : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let _x = Helper.toCell<Vector> x "x" 
                let _paramIsFixed = Helper.toCell<Generic.List<bool>> paramIsFixed "paramIsFixed" 
                let _param = Helper.toCell<Generic.List<Nullable<double>>> param "param" 
                let _forward = Helper.toCell<double> forward "forward" 
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).Direct
                                                            _x.cell 
                                                            _paramIsFixed.cell 
                                                            _param.cell 
                                                            _forward.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SVISpecs.source + ".Direct") 
                                               [| _SVISpecs.source
                                               ;  _x.source
                                               ;  _paramIsFixed.source
                                               ;  _param.source
                                               ;  _forward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
                                ;  _x.cell
                                ;  _paramIsFixed.cell
                                ;  _param.cell
                                ;  _forward.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVISpecs> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVISpecs_eps1", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_eps1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).Eps1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SVISpecs.source + ".Eps1") 
                                               [| _SVISpecs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
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
    [<ExcelFunction(Name="_SVISpecs_eps2", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_eps2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).Eps2
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SVISpecs.source + ".Eps2") 
                                               [| _SVISpecs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
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
    [<ExcelFunction(Name="_SVISpecs_guess", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        ([<ExcelArgument(Name="values",Description = "Reference to values")>] 
         values : obj)
        ([<ExcelArgument(Name="paramIsFixed",Description = "Reference to paramIsFixed")>] 
         paramIsFixed : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="expiryTime",Description = "Reference to expiryTime")>] 
         expiryTime : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        ([<ExcelArgument(Name="addParams",Description = "Reference to addParams")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let _values = Helper.toCell<Vector> values "values" 
                let _paramIsFixed = Helper.toCell<Generic.List<bool>> paramIsFixed "paramIsFixed" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _expiryTime = Helper.toCell<double> expiryTime "expiryTime" 
                let _r = Helper.toCell<Generic.List<double>> r "r" 
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" 
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).Guess
                                                            _values.cell 
                                                            _paramIsFixed.cell 
                                                            _forward.cell 
                                                            _expiryTime.cell 
                                                            _r.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (o : SVISpecs) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SVISpecs.source + ".Guess") 
                                               [| _SVISpecs.source
                                               ;  _values.source
                                               ;  _paramIsFixed.source
                                               ;  _forward.source
                                               ;  _expiryTime.source
                                               ;  _r.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
                                ;  _values.cell
                                ;  _paramIsFixed.cell
                                ;  _forward.cell
                                ;  _expiryTime.cell
                                ;  _r.cell
                                ;  _addParams.cell
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
    [<ExcelFunction(Name="_SVISpecs_instance", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_instance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="param",Description = "Reference to param")>] 
         param : obj)
        ([<ExcelArgument(Name="addParams",Description = "Reference to addParams")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let _t = Helper.toCell<double> t "t" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _param = Helper.toCell<Generic.List<Nullable<double>>> param "param" 
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" 
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).Instance
                                                            _t.cell 
                                                            _forward.cell 
                                                            _param.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IWrapper>) l

                let source = Helper.sourceFold (_SVISpecs.source + ".Instance") 
                                               [| _SVISpecs.source
                                               ;  _t.source
                                               ;  _forward.source
                                               ;  _param.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
                                ;  _t.cell
                                ;  _forward.cell
                                ;  _param.cell
                                ;  _addParams.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVISpecs> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVISpecs_inverse", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_inverse
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let _y = Helper.toCell<Vector> y "y" 
                let _b = Helper.toCell<Generic.List<bool>> b "b" 
                let _c = Helper.toCell<Generic.List<Nullable<double>>> c "c" 
                let _d = Helper.toCell<double> d "d" 
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).Inverse
                                                            _y.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SVISpecs.source + ".Inverse") 
                                               [| _SVISpecs.source
                                               ;  _y.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
                                ;  _y.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVISpecs> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVISpecs_modelInstance_", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_modelInstance_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).ModelInstance_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SVIWrapper>) l

                let source = Helper.sourceFold (_SVISpecs.source + ".ModelInstance_") 
                                               [| _SVISpecs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVISpecs> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVISpecs_weight", Description="Create a SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_weight
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVISpecs",Description = "Reference to SVISpecs")>] 
         svispecs : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="stdDev",Description = "Reference to stdDev")>] 
         stdDev : obj)
        ([<ExcelArgument(Name="addParams",Description = "Reference to addParams")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVISpecs = Helper.toCell<SVISpecs> svispecs "SVISpecs"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _stdDev = Helper.toCell<double> stdDev "stdDev" 
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" 
                let builder () = withMnemonic mnemonic ((_SVISpecs.cell :?> SVISpecsModel).Weight
                                                            _strike.cell 
                                                            _forward.cell 
                                                            _stdDev.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SVISpecs.source + ".Weight") 
                                               [| _SVISpecs.source
                                               ;  _strike.source
                                               ;  _forward.source
                                               ;  _stdDev.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVISpecs.cell
                                ;  _strike.cell
                                ;  _forward.cell
                                ;  _stdDev.cell
                                ;  _addParams.cell
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
    [<ExcelFunction(Name="_SVISpecs_Range", Description="Create a range of SVISpecs",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVISpecs_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SVISpecs")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SVISpecs> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SVISpecs>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SVISpecs>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SVISpecs>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
