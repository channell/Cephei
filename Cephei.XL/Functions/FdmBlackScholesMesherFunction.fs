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
module FdmBlackScholesMesherFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesMesher", Description="Create a FdmBlackScholesMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesMesher_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmBlackScholesMesher")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="xMinConstraint",Description = "double")>] 
         xMinConstraint : obj)
        ([<ExcelArgument(Name="xMaxConstraint",Description = "double")>] 
         xMaxConstraint : obj)
        ([<ExcelArgument(Name="eps",Description = "FdmBlackScholesMesher")>] 
         eps : obj)
        ([<ExcelArgument(Name="scaleFactor",Description = "FdmBlackScholesMesher")>] 
         scaleFactor : obj)
        ([<ExcelArgument(Name="cPoint",Description = "FdmBlackScholesMesher")>] 
         cPoint : obj)
        ([<ExcelArgument(Name="dividendSchedule",Description = "FdmBlackScholesMesher")>] 
         dividendSchedule : obj)
        ([<ExcelArgument(Name="fdmQuantoHelper",Description = "FdmBlackScholesMesher")>] 
         fdmQuantoHelper : obj)
        ([<ExcelArgument(Name="spotAdjustment",Description = "FdmBlackScholesMesher")>] 
         spotAdjustment : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _xMinConstraint = Helper.toNullable<double> xMinConstraint "xMinConstraint"
                let _xMaxConstraint = Helper.toNullable<double> xMaxConstraint "xMaxConstraint"
                let _eps = Helper.toDefault<double> eps "eps" 0.0001
                let _scaleFactor = Helper.toDefault<double> scaleFactor "scaleFactor" 1.5
                let _cPoint = Helper.toDefault<Pair<Nullable<double>,Nullable<double>>> cPoint "cPoint" null
                let _dividendSchedule = Helper.toDefault<DividendSchedule> dividendSchedule "dividendSchedule" null
                let _fdmQuantoHelper = Helper.toDefault<FdmQuantoHelper> fdmQuantoHelper "fdmQuantoHelper" null
                let _spotAdjustment = Helper.toDefault<double> spotAdjustment "spotAdjustment" 0.0
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmBlackScholesMesher 
                                                            _size.cell 
                                                            _Process.cell 
                                                            _maturity.cell 
                                                            _strike.cell 
                                                            _xMinConstraint.cell 
                                                            _xMaxConstraint.cell 
                                                            _eps.cell 
                                                            _scaleFactor.cell 
                                                            _cPoint.cell 
                                                            _dividendSchedule.cell 
                                                            _fdmQuantoHelper.cell 
                                                            _spotAdjustment.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmBlackScholesMesher>) l

                let source () = Helper.sourceFold "Fun.FdmBlackScholesMesher" 
                                               [| _size.source
                                               ;  _Process.source
                                               ;  _maturity.source
                                               ;  _strike.source
                                               ;  _xMinConstraint.source
                                               ;  _xMaxConstraint.source
                                               ;  _eps.source
                                               ;  _scaleFactor.source
                                               ;  _cPoint.source
                                               ;  _dividendSchedule.source
                                               ;  _fdmQuantoHelper.source
                                               ;  _spotAdjustment.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                ;  _Process.cell
                                ;  _maturity.cell
                                ;  _strike.cell
                                ;  _xMinConstraint.cell
                                ;  _xMaxConstraint.cell
                                ;  _eps.cell
                                ;  _scaleFactor.cell
                                ;  _cPoint.cell
                                ;  _dividendSchedule.cell
                                ;  _fdmQuantoHelper.cell
                                ;  _spotAdjustment.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesMesher> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesMesher_dminus", Description="Create a FdmBlackScholesMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesMesher_dminus
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesMesher",Description = "FdmBlackScholesMesher")>] 
         fdmblackscholesmesher : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesMesher = Helper.toCell<FdmBlackScholesMesher> fdmblackscholesmesher "FdmBlackScholesMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesMesherModel.Cast _FdmBlackScholesMesher.cell).Dminus
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesMesher.source + ".Dminus") 
                                               [| _FdmBlackScholesMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesMesher.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesMesher_dplus", Description="Create a FdmBlackScholesMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesMesher_dplus
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesMesher",Description = "FdmBlackScholesMesher")>] 
         fdmblackscholesmesher : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesMesher = Helper.toCell<FdmBlackScholesMesher> fdmblackscholesmesher "FdmBlackScholesMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesMesherModel.Cast _FdmBlackScholesMesher.cell).Dplus
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesMesher.source + ".Dplus") 
                                               [| _FdmBlackScholesMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesMesher.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesMesher_location", Description="Create a FdmBlackScholesMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesMesher_location
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesMesher",Description = "FdmBlackScholesMesher")>] 
         fdmblackscholesmesher : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesMesher = Helper.toCell<FdmBlackScholesMesher> fdmblackscholesmesher "FdmBlackScholesMesher"  
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesMesherModel.Cast _FdmBlackScholesMesher.cell).Location
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesMesher.source + ".Location") 
                                               [| _FdmBlackScholesMesher.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesMesher.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesMesher_locations", Description="Create a FdmBlackScholesMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesMesher_locations
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesMesher",Description = "FdmBlackScholesMesher")>] 
         fdmblackscholesmesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesMesher = Helper.toCell<FdmBlackScholesMesher> fdmblackscholesmesher "FdmBlackScholesMesher"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesMesherModel.Cast _FdmBlackScholesMesher.cell).Locations
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FdmBlackScholesMesher.source + ".Locations") 
                                               [| _FdmBlackScholesMesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesMesher.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesMesher_size", Description="Create a FdmBlackScholesMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesMesher_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesMesher",Description = "FdmBlackScholesMesher")>] 
         fdmblackscholesmesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesMesher = Helper.toCell<FdmBlackScholesMesher> fdmblackscholesmesher "FdmBlackScholesMesher"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmBlackScholesMesherModel.Cast _FdmBlackScholesMesher.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesMesher.source + ".Size") 
                                               [| _FdmBlackScholesMesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesMesher.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesMesher_Range", Description="Create a range of FdmBlackScholesMesher",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesMesher_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmBlackScholesMesher> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmBlackScholesMesher>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmBlackScholesMesher>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdmBlackScholesMesher>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
