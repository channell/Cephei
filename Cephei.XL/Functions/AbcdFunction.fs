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
  interpolations
  </summary> *)
[<AutoSerializable(true)>]
module AbcdFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Abcd", Description="Create a Abcd",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Abcd_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Abcd")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "double")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "double")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        ([<ExcelArgument(Name="aIsFixed",Description = "bool")>] 
         aIsFixed : obj)
        ([<ExcelArgument(Name="bIsFixed",Description = "bool")>] 
         bIsFixed : obj)
        ([<ExcelArgument(Name="cIsFixed",Description = "bool")>] 
         cIsFixed : obj)
        ([<ExcelArgument(Name="dIsFixed",Description = "bool")>] 
         dIsFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "Abcd")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Abcd")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="optMethod",Description = "Abcd")>] 
         optMethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _c = Helper.toCell<double> c "c" 
                let _d = Helper.toCell<double> d "d" 
                let _aIsFixed = Helper.toCell<bool> aIsFixed "aIsFixed" 
                let _bIsFixed = Helper.toCell<bool> bIsFixed "bIsFixed" 
                let _cIsFixed = Helper.toCell<bool> cIsFixed "cIsFixed" 
                let _dIsFixed = Helper.toCell<bool> dIsFixed "dIsFixed" 
                let _vegaWeighted = Helper.toDefault<bool> vegaWeighted "vegaWeighted" false
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _optMethod = Helper.toDefault<OptimizationMethod> optMethod "optMethod" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Abcd 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                            _aIsFixed.cell 
                                                            _bIsFixed.cell 
                                                            _cIsFixed.cell 
                                                            _dIsFixed.cell 
                                                            _vegaWeighted.cell 
                                                            _endCriteria.cell 
                                                            _optMethod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Abcd>) l

                let source () = Helper.sourceFold "Fun.Abcd" 
                                               [| _a.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               ;  _aIsFixed.source
                                               ;  _bIsFixed.source
                                               ;  _cIsFixed.source
                                               ;  _dIsFixed.source
                                               ;  _vegaWeighted.source
                                               ;  _endCriteria.source
                                               ;  _optMethod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _a.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
                                ;  _aIsFixed.cell
                                ;  _bIsFixed.cell
                                ;  _cIsFixed.cell
                                ;  _dIsFixed.cell
                                ;  _vegaWeighted.cell
                                ;  _endCriteria.cell
                                ;  _optMethod.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Abcd> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Abcd_global", Description="Create a Abcd",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Abcd_global
        ([<ExcelArgument(Name="Mnemonic",Description = "Interpolation")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Abcd",Description = "Abcd")>] 
         abcd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Abcd = Helper.toCell<Abcd> abcd "Abcd"  
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdModel.Cast _Abcd.cell).Global
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Abcd.source + ".GLOBAL") 
                                               [| _Abcd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Abcd.cell
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
    [<ExcelFunction(Name="_Abcd_interpolate", Description="Create a Abcd",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Abcd_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Interpolation")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Abcd",Description = "Abcd")>] 
         abcd : obj)
        ([<ExcelArgument(Name="xBegin",Description = "double")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "double")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Abcd = Helper.toCell<Abcd> abcd "Abcd"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = withMnemonic mnemonic ((AbcdModel.Cast _Abcd.cell).Interpolate
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_Abcd.source + ".Interpolate") 
                                               [| _Abcd.source
                                               ;  _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Abcd.cell
                                ;  _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Abcd> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Abcd_Range", Description="Create a range of Abcd",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Abcd_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Abcd> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Abcd>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Abcd>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Abcd>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
