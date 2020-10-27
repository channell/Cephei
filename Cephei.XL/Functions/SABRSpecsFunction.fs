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
module SABRSpecsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SABRSpecs_defaultValues", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_defaultValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        ([<ExcelArgument(Name="param",Description = "double range")>] 
         param : obj)
        ([<ExcelArgument(Name="b",Description = "bool range")>] 
         b : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        ([<ExcelArgument(Name="expiryTime",Description = "double")>] 
         expiryTime : obj)
        ([<ExcelArgument(Name="addParams",Description = "double range")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let _param = Helper.toCell<Generic.List<Nullable<double>>> param "param" 
                let _b = Helper.toCell<Generic.List<bool>> b "b" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _expiryTime = Helper.toCell<double> expiryTime "expiryTime" 
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" 
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).DefaultValues
                                                            _param.cell 
                                                            _b.cell 
                                                            _forward.cell 
                                                            _expiryTime.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (o : SABRSpecs) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SABRSpecs.source + ".DefaultValues") 

                                               [| _param.source
                                               ;  _b.source
                                               ;  _forward.source
                                               ;  _expiryTime.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
                                ;  _param.cell
                                ;  _b.cell
                                ;  _forward.cell
                                ;  _expiryTime.cell
                                ;  _addParams.cell
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
    [<ExcelFunction(Name="_SABRSpecs_dilationFactor", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_dilationFactor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).DilationFactor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SABRSpecs.source + ".DilationFactor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
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
    [<ExcelFunction(Name="_SABRSpecs_dimension", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_dimension
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).Dimension
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SABRSpecs.source + ".Dimension") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
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
    [<ExcelFunction(Name="_SABRSpecs_direct", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_direct
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        ([<ExcelArgument(Name="b",Description = "bool range")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "double range")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let _x = Helper.toCell<Vector> x "x" 
                let _b = Helper.toCell<Generic.List<bool>> b "b" 
                let _c = Helper.toCell<Generic.List<Nullable<double>>> c "c" 
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).Direct
                                                            _x.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SABRSpecs.source + ".Direct") 

                                               [| _x.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
                                ;  _x.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SABRSpecs> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SABRSpecs_eps1", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_eps1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).Eps1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SABRSpecs.source + ".Eps1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
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
    [<ExcelFunction(Name="_SABRSpecs_eps2", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_eps2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).Eps2
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SABRSpecs.source + ".Eps2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
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
    [<ExcelFunction(Name="_SABRSpecs_guess", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        ([<ExcelArgument(Name="values",Description = "Vector")>] 
         values : obj)
        ([<ExcelArgument(Name="paramIsFixed",Description = "bool range")>] 
         paramIsFixed : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        ([<ExcelArgument(Name="expiryTime",Description = "double")>] 
         expiryTime : obj)
        ([<ExcelArgument(Name="r",Description = "double range")>] 
         r : obj)
        ([<ExcelArgument(Name="addParams",Description = "double range")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let _values = Helper.toCell<Vector> values "values" 
                let _paramIsFixed = Helper.toCell<Generic.List<bool>> paramIsFixed "paramIsFixed" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _expiryTime = Helper.toCell<double> expiryTime "expiryTime" 
                let _r = Helper.toCell<Generic.List<double>> r "r" 
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" 
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).Guess
                                                            _values.cell 
                                                            _paramIsFixed.cell 
                                                            _forward.cell 
                                                            _expiryTime.cell 
                                                            _r.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (o : SABRSpecs) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SABRSpecs.source + ".Guess") 

                                               [| _values.source
                                               ;  _paramIsFixed.source
                                               ;  _forward.source
                                               ;  _expiryTime.source
                                               ;  _r.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
                                ;  _values.cell
                                ;  _paramIsFixed.cell
                                ;  _forward.cell
                                ;  _expiryTime.cell
                                ;  _r.cell
                                ;  _addParams.cell
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
    [<ExcelFunction(Name="_SABRSpecs_instance", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_instance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        ([<ExcelArgument(Name="param",Description = "double range")>] 
         param : obj)
        ([<ExcelArgument(Name="addParams",Description = "double range")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let _t = Helper.toCell<double> t "t" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _param = Helper.toCell<Generic.List<Nullable<double>>> param "param" 
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" 
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).Instance
                                                            _t.cell 
                                                            _forward.cell 
                                                            _param.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IWrapper>) l

                let source () = Helper.sourceFold (_SABRSpecs.source + ".Instance") 

                                               [| _t.source
                                               ;  _forward.source
                                               ;  _param.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
                                ;  _t.cell
                                ;  _forward.cell
                                ;  _param.cell
                                ;  _addParams.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SABRSpecs> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SABRSpecs_inverse", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_inverse
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        ([<ExcelArgument(Name="y",Description = "Vector")>] 
         y : obj)
        ([<ExcelArgument(Name="b",Description = "bool range")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "double range")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let _y = Helper.toCell<Vector> y "y" 
                let _b = Helper.toCell<Generic.List<bool>> b "b" 
                let _c = Helper.toCell<Generic.List<Nullable<double>>> c "c" 
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).Inverse
                                                            _y.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SABRSpecs.source + ".Inverse") 

                                               [| _y.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
                                ;  _y.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SABRSpecs> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SABRSpecs_weight", Description="Create a SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_weight
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SABRSpecs",Description = "SABRSpecs")>] 
         sabrspecs : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        ([<ExcelArgument(Name="stdDev",Description = "double")>] 
         stdDev : obj)
        ([<ExcelArgument(Name="addParams",Description = "double range")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SABRSpecs = Helper.toCell<SABRSpecs> sabrspecs "SABRSpecs"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _stdDev = Helper.toCell<double> stdDev "stdDev" 
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" 
                let builder (current : ICell) = withMnemonic mnemonic ((SABRSpecsModel.Cast _SABRSpecs.cell).Weight
                                                            _strike.cell 
                                                            _forward.cell 
                                                            _stdDev.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SABRSpecs.source + ".Weight") 

                                               [| _strike.source
                                               ;  _forward.source
                                               ;  _stdDev.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SABRSpecs.cell
                                ;  _strike.cell
                                ;  _forward.cell
                                ;  _stdDev.cell
                                ;  _addParams.cell
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
    [<ExcelFunction(Name="_SABRSpecs_Range", Description="Create a range of SABRSpecs",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SABRSpecs_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SABRSpecs> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SABRSpecs>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SABRSpecs>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SABRSpecs>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
